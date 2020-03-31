﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthJWT.API.Services.Context.Implementation;
using AuthJWT.DataAccess.Abstract.Entities;
using AuthJWT.DataAccess.SqlServer.Context;
using AuthJWT.Domain.Services.Implementation;
using AuthJWT.Domain.Services.Interfaces;
using AuthJWT.Domain.Services.Security;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Microsoft.AspNetCore.Authorization;
using Tapioca.HATEOAS;
using AuthJWT.Domain.Model.Entities;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace AuthJWT.API
{
    public class Startup
    {

        private readonly ILogger _logger;

        public IConfiguration _configuration;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Registra o controle de versionamento

            //services.AddApiVersioning();

            //services.AddApiVersioning(p =>
            //{
            //    p.DefaultApiVersion = new ApiVersion(1, 0);
            //    p.ReportApiVersions = true;
            //    p.AssumeDefaultVersionWhenUnspecified = true;
            //});

            //services.AddVersionedApiExplorer(p =>
            //{
            //    p.GroupNameFormat = "'v'VVV";
            //    p.SubstituteApiVersionInUrl = true;
            //});

            #endregion

            #region Registra o banco de dados

            var connection = _configuration["SQLServerConnection:SQLServerConnectionString"];
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(connection));
            
            #endregion

            #region Executa o Migration

            //if (_environment.IsDevelopment())
            //{


            //    try
            //    {
            //        var envolveConnection = new System.Data.SqlClient.SqlConnection(connection);
            //        var envolve = new Evolve.Evolve(envolveConnection, msg => _logger.LogInformation(msg))
            //        {
            //            Locations = new List<string>() { "db/migrations" },
            //            IsEraseDisabled = true
            //        };

            //        envolve.Migrate();
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogCritical("Erro ao realizar o 'Migration': " + ex.Message);
            //        throw;
            //    }
            //}
            #endregion
            
            #region Registra o modelo de autenticação via JWT

            var signConfiguration = new SignConfiguration();
            services.AddSingleton(signConfiguration);

            var tokenConfiguration = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                    _configuration.GetSection("TokenConfigurations")
                ).Configure(tokenConfiguration);

            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signConfiguration.Key;
                paramsValidation.ValidateAudience = string.IsNullOrEmpty(tokenConfiguration.Audience);
                paramsValidation.ValidateIssuer = string.IsNullOrEmpty(tokenConfiguration.Issuer);

                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            #endregion

            #region Registra os links Hypermedia (HATEOAS)

            //var filterOptions = new HyperMediaFilterOptions();
            //filterOptions.ObjectContentResponseEnricherList.Add(new UsuariosEnricher());

            //services.AddSingleton(filterOptions);

            #endregion

            #region  Registra as dependências da camada de serviços

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPersonalizacaoService, PersonalizacaoService>(); 

            #endregion

            #region  Registra as dependências da camada de dados

            services.AddScoped<IUserServiceSqlServer, UserServiceSqlServer>();
            services.AddScoped<IPedidoPersonalizacaoServiceSqlServer, PersonalizacaoPedidoServiceSqlServer>();
            services.AddScoped<IPedidoServiceSqlServer, PedidoServiceSqlServer>();
            services.AddScoped<IPersonalizacaoServiceSqlServer, PersonalizacaoServiceSqlServer>();

            #endregion

            #region Registra o Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Serviços disponíveis para o Pizza Hot.",
                    Version = "v1"
                });
            });              

            #endregion
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Configurações do Swagger

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            #endregion

            #region Configurações Gerais

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "DefaultAPI",
                        template: "{controllern=Values}/{id?}"
                    );

            });

            #endregion

        }
    }
}
