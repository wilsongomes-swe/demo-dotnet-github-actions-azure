var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
var app = builder.Build();

app.UseSwagger().UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/", () => new InfoResponse(
    Version: "1.0.0",
    Timestamp: DateTime.UtcNow,
    Message: "Hello World",
    HostName: Environment.MachineName,
    EnvironmentName: app.Environment.EnvironmentName));

app.Run();

record InfoResponse(string Version, DateTime Timestamp, string Message, string HostName, string EnvironmentName);
