using System.Diagnostics;
using Cronos;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly CronExpression _cron;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _cron = CronExpression.Parse("0 20 * * *"); // 8 PM daily
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("DSA Auto Tracker started. Waiting for 8 PM trigger...");

        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.UtcNow;
            var next = _cron.GetNextOccurrence(now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            if (next.HasValue)
            {
                var delay = next.Value - DateTimeOffset.Now;
                if (delay > TimeSpan.Zero)
                {
                    _logger.LogInformation("Next run scheduled at: {NextRun} IST", next.Value.ToLocalTime());
                    await Task.Delay(delay, stoppingToken);
                }
            }

            RunAutomation();
        }
    }

    private void RunAutomation()
    {
        try
        {
            string basePath = @"C:\DSA";
            string working = Path.Combine(basePath, "working");
            string archive = Path.Combine(basePath, "archive", DateTime.Now.ToString("yyyy-MM-dd"));

            Directory.CreateDirectory(archive);

            var files = Directory.GetFiles(working);

            if (files.Length == 0)
            {
                _logger.LogWarning("No files found in {WorkingDir}. Skipping.", working);
                return;
            }

            // Copy files from working to archive
            foreach (var file in files)
            {
                var dest = Path.Combine(archive, Path.GetFileName(file));
                File.Copy(file, dest, true);
                _logger.LogInformation("Copied: {FileName}", Path.GetFileName(file));
            }

            // Git commit and push
            RunCommand("git", "add .", basePath);
            RunCommand("git", $"commit -m \"DSA auto save {DateTime.Now:yyyy-MM-dd HH:mm}\"", basePath);
            RunCommand("git", "push", basePath);

            _logger.LogInformation("✅ DSA Auto Save Completed — {FileCount} file(s) archived.", files.Length);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "❌ DSA Auto Save FAILED");
        }
    }

    private void RunCommand(string cmd, string args, string workingDir)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = cmd,
                Arguments = args,
                WorkingDirectory = workingDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (!string.IsNullOrWhiteSpace(output))
            _logger.LogInformation("[{Command}] {Output}", cmd, output.Trim());

        if (!string.IsNullOrWhiteSpace(error) && process.ExitCode != 0)
            _logger.LogWarning("[{Command}] {Error}", cmd, error.Trim());
    }
}
