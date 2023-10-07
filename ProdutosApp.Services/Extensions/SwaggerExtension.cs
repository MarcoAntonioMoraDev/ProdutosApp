using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ProdutosApp.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos a documentação
    /// da API gerada pela biblioteca Swagger
    /// </summary>
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            //Swagger irá incluir todos os endpoints deste projeto na documentação
            services.AddEndpointsApiExplorer();

            //modificar o conteudo da documentação
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ProdutosApp - API para controle de produtos.",
                    Description = "API desenvolvida em .NET 7 com EntityFramework",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Marco Antonio Mora Dev",
                        Email = "marcoantoniomora.dev@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/m4rco-4ntonio/")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            //O swagger deverá gerar um link (api-docs) capaz de importar a documentação da API
            //em uma ferramenta de teste como o POSTMAN, INSOMINIA etc.
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProdutosApp");
            });

            return app;
        }
    }
}


