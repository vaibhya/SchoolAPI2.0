var builder = WebApplication.CreateBuilder(args);

// Create an instance of Startup and configure services
var startup = new SchoolAPI.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Use the Startup class to configure middleware
startup.Configure(app);

app.Run();
