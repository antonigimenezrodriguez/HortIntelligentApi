﻿// <auto-generated />
using System;
using HortIntelligent.Dades.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HortIntelligentApi.Migrations
{
    [DbContext(typeof(HortIntelligentDbContext))]
    [Migration("20230508133835_ApiKey")]
    partial class ApiKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.ApiKey", b =>
                {
                    b.Property<int>("ApiKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApiKeyId"), 1L, 1);

                    b.Property<DateTime>("Exipres")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Key")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApiKeyId");

                    b.ToTable("ApiKeys");

                    b.HasData(
                        new
                        {
                            ApiKeyId = 1,
                            Exipres = new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Key = new Guid("0e6b2066-9e98-4783-8c82-c3530aa8a197"),
                            Name = "Arduinos"
                        });
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Camp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImatgeURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Latitud")
                        .HasColumnType("float");

                    b.Property<string>("Localitzacio")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.Property<string>("Observacions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VegetalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VegetalId");

                    b.ToTable("Camps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Latitud = 41.964083000000002,
                            Localitzacio = "Pati Institut Montilivi",
                            Longitud = 2.8271647
                        });
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Medicio", b =>
                {
                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<int>("CampId")
                        .HasColumnType("int");

                    b.Property<int>("VegetalId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Valor")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("DataHora", "SensorId", "CampId", "VegetalId");

                    b.HasIndex("CampId");

                    b.HasIndex("SensorId");

                    b.HasIndex("VegetalId");

                    b.ToTable("Medicions");
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImatgeURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Tipus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sensors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcio = "Este es un sensor de agua simple que puede usarse para detectar la humedad del suelo.\r\nSe puede usar en el dispositivo de despensa de planta de módulo, y las plantas en su jardín no necesitan que la gente las administre.\r\n¡Esta es una herramienta imprescindible para un jardín conectado! Será útil recordarle regar sus plantas de interior o controlar la humedad del suelo en su jardín.\r\nVoltaje de funcionamiento: 3.3V-5V\r\nMódulo de modo de salida dual, salida digital, salida analógica más precisa.",
                            ImatgeURL = "https://www.tiendatec.es/3497-large_default/sensor-de-humedad-higrometro-yl69-con-modulo-yl38-para-arduino.jpg",
                            IsDeleted = false,
                            Model = "YL-69",
                            Nom = "Sensor humitat",
                            Tipus = 3
                        },
                        new
                        {
                            Id = 2,
                            Descripcio = "El DHT11 es un sensor incorporado de bajo precio, que se utiliza para medir la temperatura (en un rango de 0 a 50 grados centígrados con una precisión de +-2 C) y la humedad (en un rango de 20% a 80% con una precisión de +-5%).\r\nConsiste en un sensor capacitivo de humedad que mide la humedad del aire.\r\nPara la medición de la temperatura, tiene un termistor incorporado, que es un dispositivo de medición de temperatura NTC resistivo y húmedo.\r\nFunciona con sistemas de microcontroladores de 3,3V y 5V.\r\nEste sensor tiene una excelente calidad, un rápido tiempo de respuesta y capacidad antiinterferencia.\r\nEn el DHT11, los coeficientes de calibración ya están almacenados en la memoria del programa OTP, sólo tenemos que llamar a estos coeficientes de calibración mientras los sensores internos detectan la señal en el proceso.\r\nUtiliza baja potencia en la transmisión de señales simples hasta 20 metros.\r\nViene en un solo paquete que comprende 4 pines con 0.1″ de espacio entre ellos y se puede proporcionar un paquete especial según la demanda del usuario.",
                            ImatgeURL = "https://descubrearduino.com/wp-content/uploads/2020/03/pinout-DHT11.jpg",
                            IsDeleted = false,
                            Model = "DHT-11",
                            Nom = "Sensor temperatura",
                            Tipus = 2
                        },
                        new
                        {
                            Id = 3,
                            Descripcio = "Sensor fácil de usar para medir la concentración de varios gases tóxicos como benzona, alcohol, humo y contaminantes transportados por el aire.\r\nEl MQ-135 mide concentraciones de gas de 10 a 1000 ppm y es ideal para la detección de fugas de gas, alarmas de gas u otros proyectos de robótica y microcontroladores.\r\nLos sensores de la serie MQ utilizan un pequeño elemento calefactor con un sensor electrónico-químico. Son sensibles a una amplia gama de gases y son adecuados para su uso en interiores.\r\nEl sensor tiene una alta sensibilidad y un tiempo de respuesta rápido, pero tarda unos minutos en dar lecturas precisas porque el sensor tiene que calentarse. Los valores medidos del sensor se emiten como valores analógicos, que se pueden evaluar fácilmente con un microcontrolador.",
                            ImatgeURL = "https://m.media-amazon.com/images/I/81wbh1mXmmL._SX466_.jpg",
                            IsDeleted = false,
                            Model = "MQ-135",
                            Nom = "Sensor qualitat de l'aire",
                            Tipus = 1
                        });
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Vegetal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("HumitatMaxima")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal?>("HumitatMinima")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal?>("HumitatOptima")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("ImatgeURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal?>("TemperaturaMaxima")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal?>("TemperaturaMinima")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal?>("TemperaturaOptima")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Vegetals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcio = "La ceba (Allium cepa) és una planta herbàcia bulbosa de la família de les amaril·lidàcies. És dita cebeta o ceballot quan és tendra, collida abans d'hora, i altres noms pels quals se la coneix en català són ceba blanca, ceba d'Egipte o ceba porrera. Originària de l'Àsia Central, actualment la ceba és un dels ingredients indispensables de la cuina mediterrània. ",
                            HumitatMaxima = 75m,
                            HumitatMinima = 65m,
                            HumitatOptima = 70m,
                            ImatgeURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/300px-Onions.jpg",
                            IsDeleted = false,
                            Nom = "Ceba",
                            TemperaturaMaxima = 35m,
                            TemperaturaMinima = 4m,
                            TemperaturaOptima = 23m
                        },
                        new
                        {
                            Id = 2,
                            Descripcio = "Daucus carota sativus, llamada popularmente zanahoria, es la forma domesticada de la zanahoria silvestre, especie de la familia de las umbelíferas, también denominadas apiáceas, y considerada la más importante y de mayor consumo dentro de esta familia. Es oriunda de Europa y Asia sudoccidental.",
                            ImatgeURL = "https://soycomocomo.es/media/2019/03/zanahorias.jpg",
                            IsDeleted = false,
                            Nom = "Pastanaga",
                            TemperaturaMaxima = 18m,
                            TemperaturaMinima = 9m,
                            TemperaturaOptima = 16m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ad8d1fe9-6cf3-4479-b6e3-4047210f8b19",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "737bf3c7-c034-402f-81d3-553967e9f2bf",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedUserName = "ANTONI",
                            PasswordHash = "AQAAAAEAACcQAAAAEMOihM9h37Bi1O/SNkLhqtwW50DJ6ejyPmX1vqSAWbmSVOBoSIYCXWAqI6y8mFqfXA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "OS32HZAWWAY4HWPKN2A5W2XCO5UVATRC",
                            TwoFactorEnabled = false,
                            UserName = "antoni"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "esAdmin",
                            ClaimValue = "true",
                            UserId = "ad8d1fe9-6cf3-4479-b6e3-4047210f8b19"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Camp", b =>
                {
                    b.HasOne("HortIntelligent.Dades.Entitats.Vegetal", "Vegetal")
                        .WithMany("Camps")
                        .HasForeignKey("VegetalId");

                    b.Navigation("Vegetal");
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Medicio", b =>
                {
                    b.HasOne("HortIntelligent.Dades.Entitats.Camp", "Camp")
                        .WithMany()
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HortIntelligent.Dades.Entitats.Sensor", "Sensor")
                        .WithMany("Medicions")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HortIntelligent.Dades.Entitats.Vegetal", "Vegetal")
                        .WithMany("Medicions")
                        .HasForeignKey("VegetalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("Sensor");

                    b.Navigation("Vegetal");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Sensor", b =>
                {
                    b.Navigation("Medicions");
                });

            modelBuilder.Entity("HortIntelligent.Dades.Entitats.Vegetal", b =>
                {
                    b.Navigation("Camps");

                    b.Navigation("Medicions");
                });
#pragma warning restore 612, 618
        }
    }
}
