using AdamStore.Infrastructure;
using AdamStore.Infrastructure.EF;
using AdamStore.Infrastructure.Repositories;
using Application._Abstracts;
using Application.Auth;
using Application.Auth.Token;
using Application.Catalog.Categories;
using Application.Catalog.Products;
using Application.Common;
using Application.System.Languages;
using Application.System.Roles;
using Application.System.Users;
using Application.Ultilities.Slides;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.Entities;
using Shared.Utilities.Constants;
using System;
using System.Collections.Generic;

namespace API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdamStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(SystemConstants.MainConnectionString)));
            services.AddScoped<Func<AdamStoreDbContext>>((provider) => () => provider.GetService<AdamStoreDbContext>());
            services.AddScoped<DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IProductTranslationRepository, ProductTranslationRepository>()
                .AddScoped<IProductImageRepository, ProductImageRepository>()
                .AddScoped<IProductInCategoryRepository, ProductInCategoryRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ILanguageService, LanguageService>()
                .AddScoped<IStorageService, FileStorageService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<UserManager<AppUser>, UserManager<AppUser>>()
                .AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>()
                .AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>()

                .AddScoped<ISlideService, SlideService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAuthServices, AuthServices>()
                .AddScoped<ITokenServices, TokenServices>();
        }

        public static AuthenticationBuilder AddAuthen(this IServiceCollection services, IConfiguration configuration)
        {
            string issuer = configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
            return services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });

        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger eShop Solution", Version = "v1" });

                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer"
                 });

                 c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
        }

        public static IServiceCollection AddAuthor(this IServiceCollection services)
        {
           return services.AddAuthorization(options =>
            {
                options.AddPolicy("Founders", policy =>
                                  policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
            });
        }
    }
}