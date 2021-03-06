﻿using galdino.humanResource.Front.Configurations.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace galdino.humanResource.Front.ServiceConfigurations
{
    public class AuthConfiguration
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfigure = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                    configuration.GetSection(nameof(TokenConfiguration)))
                .Configure(tokenConfigure);

            services.AddSingleton(tokenConfigure);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(bearrerOptions =>
                {
                    var paramsValidation = bearrerOptions.TokenValidationParameters;
                    paramsValidation.ValidateIssuerSigningKey = true;
                    paramsValidation.ValidateLifetime = true;
                    paramsValidation.ValidateActor = true;
                    paramsValidation.ValidateAudience = true;
                    paramsValidation.ValidAudience = tokenConfigure.Audience;
                    paramsValidation.ValidIssuer = tokenConfigure.Issuer;
                    paramsValidation.ClockSkew = TimeSpan.Zero;

                    paramsValidation.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigure.SigningKey));
                });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }
    }
}
