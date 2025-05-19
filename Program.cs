var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello from Azure Free Tier tester updated III!");

app.MapGet("/cpu", async () =>
{
    var start = DateTime.UtcNow;
    var duration = TimeSpan.FromSeconds(10); // Simulate 10 seconds of CPU work

    while (DateTime.UtcNow - start < duration)
    {
        // Simulate CPU work
        Math.Sqrt(new Random().NextDouble());
    }

    return $"Simulated CPU usage for {duration.TotalSeconds} seconds.";
});

app.Run();
