// var builder = DistributedApplication.CreateBuilder(args);

// var apiService = builder.AddProject<Projects.MyAspireApp_ApiService>("apiservice")
//     .WithHttpHealthCheck("/health")
//     .WithEndpoint("https", endpoint => endpoint.Port = 7369)
//     .WithEndpoint("http", endpoint => endpoint.Port = 5312);

// builder.AddProject<Projects.MyAspireApp_Web>("webfrontend")
//     .WithExternalHttpEndpoints()
//     .WithHttpHealthCheck("/health")
//     .WithReference(apiService)
//     .WaitFor(apiService);

// builder.Build().Run();


var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MyAspireApp_ApiService>("apiservice")
    .WithEndpoint("https", endpoint => endpoint.Port = 7369)
    .WithEndpoint("http", endpoint => endpoint.Port = 5312);

builder.AddProject<Projects.MyAspireApp_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();