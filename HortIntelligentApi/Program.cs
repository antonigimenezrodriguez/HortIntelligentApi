using AutoMapper;
using HortIntelligent.Dades.EntityFramework;
using HortIntelligent.Dades.Repositoris.Implementacions;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.AutoMapper;
using HortIntelligentApi.Domini.Implementacions;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace HortIntelligentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // open api is currently using system.text.json
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opcions => opcions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["ClauJWT"])),
                    ClockSkew = TimeSpan.Zero
                });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hort Intel·ligent API",
                    Description = "API per guardar y consultar les dades dels sensors Arduino",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Departament Informàtica Institut Montilivi",
                        Url = new Uri("https://www.institutmontilivi.cat")
                    },
                    /*License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }*/

                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
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
                            }
                        },
                        new string[]{ }
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //Recoger cadena de conexión del appsettings.json
            builder.Services.AddDbContext<HortIntelligentDbContext>(opciones =>
            {
                opciones.UseSqlServer(connectionString, //Usar SQL server en entity framework
                    sqlServer => sqlServer.UseNetTopologySuite()); //Utilizar NetTopologySuite para guardar y operar con coordenadas
                opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //Las querys son NoTracking por defecto para aumentar rendimiento
            }
                );


            builder.Services.AddTransient<ICampDomini, CampDomini>();
            builder.Services.AddTransient<IMedicioDomini, MedicioDomini>();
            builder.Services.AddTransient<ISensorDomini, SensorDomini>();
            builder.Services.AddTransient<IVegetalDomini, VegetalDomini>();

            builder.Services.AddTransient<ICampRepository, CampRepository>();
            builder.Services.AddTransient<IMedicioRepository, MedicioRepository>();
            builder.Services.AddTransient<ISensorRepository, SensorRepository>();
            builder.Services.AddTransient<IVegetalRepository, VegetalRepository>();

            builder.Services.AddResponseCaching();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<HortIntelligentDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthorization(opcions =>
            {
                opcions.AddPolicy("EsAdmin", politica => politica.RequireClaim("esAdmin"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}