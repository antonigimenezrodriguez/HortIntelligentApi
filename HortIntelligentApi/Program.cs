using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Implementacions;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Implementacions;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}