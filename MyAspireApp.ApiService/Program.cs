// var builder = WebApplication.CreateBuilder(args);

// // Add service defaults & Aspire client integrations.
// builder.AddServiceDefaults();

// // Add services to the container.
// builder.Services.AddProblemDetails();

// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// builder.Services.AddControllers();

// builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen();


// var app = builder.Build();

// // Додайте це ПЕРШИМ у pipeline
// app.Use(async (context, next) =>
// {
//     Console.WriteLine($"🔍 Запит: {context.Request.Method} {context.Request.Path}");
//     Console.WriteLine($"🔍 URL: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
//     await next();
// });

// // Configure the HTTP request pipeline.
// app.UseExceptionHandler();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger(); // генерує swagger.json
//     app.UseSwaggerUI(options =>
//     {
//         options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAspireApp.ApiService v1");
//         options.RoutePrefix = "swagger"; // Swagger буде доступний на /swagger
//     });

// }


// string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.MapDefaultEndpoints();

// app.MapGet("/", () => "Root endpoint works!");

// app.MapGet("/simple-test", () => "Simple test works!");
// app.MapGet("/api/manual-ping", () => "Manual ping works!");

// app.MapGet("/debug/ping-exists", () =>
// {
//     var endpointSources = app.Services.GetRequiredService<IEnumerable<EndpointDataSource>>();
    
//     foreach (var dataSource in endpointSources)
//     {
//         foreach (var endpoint in dataSource.Endpoints)
//         {
//             if (endpoint.DisplayName?.Contains("PingController") == true)
//             {
//                 return Results.Ok("PingController FOUND!");
//             }
//         }
//     }
    
//     return Results.NotFound("PingController NOT FOUND");
// });

// app.MapControllers();

// app.Run();


// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "MyAspireApp API", 
        Version = "v1" 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAspireApp API v1");
        c.RoutePrefix = "swagger";
    });
}

// Your endpoints
app.MapGet("/", () => "MyAspireApp API is running!");
app.MapGet("/test", () => "Test endpoint works!");
app.MapGet("/health", () => Results.Ok("Healthy"));

// Weather forecast endpoint
string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Controllers
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}