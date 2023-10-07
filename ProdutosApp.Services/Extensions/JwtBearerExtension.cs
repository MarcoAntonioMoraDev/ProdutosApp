using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProdutosApp.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos a forma de autenticação
    /// do projeto, neste caso, por meio do JWT - JSON WEB TOKENS
    /// </summary>
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services)
        {
            //definindo a política de autenticação do projeto
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //definindo as preferencias para autenticação com TOKEN JWT
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes("978A023502D94A9CB785A7307A45E94A"))
                };
            });

            return services;
        }
    }
}


