namespace Microsoft.AspNetCore.Builder;

public static class ConfigureAuthentication
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder UseSecurity()
        {
            builder.Services.AddAuthentication()
                            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                            {
                                options.RequireHttpsMetadata = false;
                                options.SaveToken = false;
                                options.MapInboundClaims = false;
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuerSigningKey = true,
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ClockSkew = TimeSpan.Zero,
                                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                                    ValidAudience = builder.Configuration["JWT:Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                                };
                            });

            return builder;
        }
    }

    extension(WebApplication app)
    {
        public IApplicationBuilder UseSecurity()
        {
            app.UseAuthentication();
            app.UseAuthentication();

            return app;
        }
    }
}
