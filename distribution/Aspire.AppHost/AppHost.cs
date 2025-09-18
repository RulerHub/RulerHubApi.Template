var builder = DistributedApplication.CreateBuilder(args);


builder.AddProject<Projects.RulerHub_Api>("RulerHub-api");


builder.Build().Run();
