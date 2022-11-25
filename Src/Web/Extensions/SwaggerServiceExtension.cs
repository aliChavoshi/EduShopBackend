using Microsoft.OpenApi.Models;

namespace Web.Extensions;

public static class SwaggerServiceExtension
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        //swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API",
                Version = "v1",
                Description = "API for a shopping cart"
            });
            c.DescribeAllParametersInCamelCase();
            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "JWT Auth Bearer Scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            c.AddSecurityDefinition("Bearer", securitySchema);
            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    securitySchema,
                    new[] { "Bearer" }
                }
            };
            c.AddSecurityRequirement(securityRequirement);
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
        return app;
    }
}