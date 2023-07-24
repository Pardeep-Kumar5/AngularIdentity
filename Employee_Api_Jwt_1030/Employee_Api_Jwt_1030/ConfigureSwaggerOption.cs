using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030
{
  public class ConfigureSwaggerOption : IConfigureOptions<SwaggerGenOptions>
  {
    public void Configure(SwaggerGenOptions options)
    {
      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Description = "JWT Authorization header using the beare schem" + "Enter 'Bearer'[space]" +
                          " and then your token in the text input below\r\r\"" + "In:header",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
      });
      options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
            {
                new OpenApiSecurityScheme
                {
                    Reference=new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    },
                    Scheme="oauth2",
                    Name="Bearer",
                    In=ParameterLocation.Header
                },
                new List<string>()
                }

         });
    }

  }
}

