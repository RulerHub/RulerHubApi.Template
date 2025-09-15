using System.Net;

using Microsoft.OpenApi.Models;

namespace RulerHub.Api.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
    {
        var SwaggerSettings = configuration.GetSection("Swagger");

        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, ct) =>
            {
                document.Info = new()
                {
                    Title = SwaggerSettings["Title"],
                    Version = SwaggerSettings["Version"],
                    Description = "Documentación de la Api (Dev env)"
                };

                document.Components ??= new();
                //document.Components.SecuritySchemes ??= new();
                document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Authentication JWT con esquema Bearer"
                };
                document.SecurityRequirements.Add(new OpenApiSecurityRequirement
                {
                    [new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }] = Array.Empty<string>()
                });
                return Task.CompletedTask;
            });
            // Opcional: Ignorar acciones obsoletas
            options.AddDocumentTransformer((document, context, ct) =>
            {
                // Si se marcan con [Obsolete] en Tasks/Dtos, se filtran según context aquí
                return Task.CompletedTask;
            });
        });
        return services;
    }

    public static IApplicationBuilder AddSwaggerBuilder(this IApplicationBuilder app, IHostEnvironment env)
    {
        // only in dev
        if (env.IsDevelopment())
        {
            // Configure SwaggerUI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/v1.json", "RulerHub Api v1");
                c.RoutePrefix = "docs";
                c.DisplayRequestDuration();
                c.DefaultModelExpandDepth(-1);
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
            });
            // Bloqueo de acceso a la Ui en red local
            app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/docs"), branch =>
            {
                branch.Use(async (ctx, next) =>
                {
                    var ip = ctx.Connection.RemoteIpAddress;
                    if (ip is null || !IPAddress.IsLoopback(ip))
                    {
                        ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                        await ctx.Response.WriteAsync("Swagger UI solo accesible desde local host en Development.");
                    }
                    await next();
                });
            });
        }

        return app;
    }
}
