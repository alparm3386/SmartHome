var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Get logger from DI
var logger = app.Logger;

app.MapGet("/", () => "Hello from Azure Free Tier tester updated dev.!");

app.MapGet("/cpu", async () =>
{
    logger.LogInformation("Starting CPU simulation...");

    var start = DateTime.UtcNow;
    var duration = TimeSpan.FromSeconds(10);

    while (DateTime.UtcNow - start < duration)
    {
        Math.Sqrt(new Random().NextDouble());
    }

    logger.LogInformation("Finished CPU simulation after {Duration} seconds", duration.TotalSeconds);

    return $"Simulated CPU usage for {duration.TotalSeconds} seconds.";
});

app.Run();
