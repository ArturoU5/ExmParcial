var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseCors("AllowAll");

// Enable routing for controllers
app.MapControllers();

// the build process wraps top‑level statements in an async Main, so we
// can await the asynchronous host start method.  this avoids the
// compiler warning about an un-awaited Task and ensures exceptions bubble
// correctly.
await app.RunAsync();
