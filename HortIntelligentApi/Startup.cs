using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Implementacions;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Implementacions;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HortIntelligentApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
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

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection"); //Recoger cadena de conexión del appsettings.json
            services.AddDbContext<HortIntelligentDbContext>(opciones =>
                    {
                        opciones.UseSqlServer(connectionString, //Usar SQL server en entity framework
                            sqlServer => sqlServer.UseNetTopologySuite()); //Utilizar NetTopologySuite para guardar y operar con coordenadas
                        opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //Las querys son NoTracking por defecto para aumentar rendimiento
                    }
                );


            services.AddTransient<ICampDomini, CampDomini>();
            services.AddTransient<IMedicioDomini, MedicioDomini>();
            services.AddTransient<ISensorDomini, SensorDomini>();
            services.AddTransient<IVegetalDomini, VegetalDomini>();

            services.AddTransient<ICampRepository, CampRepository>();
            services.AddTransient<IMedicioRepository, MedicioRepository>();
            services.AddTransient<ISensorRepository, SensorRepository>();
            services.AddTransient<IVegetalRepository, VegetalRepository>();
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
