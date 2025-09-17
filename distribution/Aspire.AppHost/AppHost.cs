var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RulerHub_Api>("RulerHub-Api");

builder.Build().Run();
