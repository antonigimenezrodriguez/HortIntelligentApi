using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HortIntelligentApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipus = table.Column<int>(type: "int", nullable: false),
                    ImatgeURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vegetals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImatgeURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperaturaMaxima = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    TemperaturaMinima = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    TemperaturaOptima = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    HumitatMaxima = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    HumitatMinima = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    HumitatOptima = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localitzacio = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    Observacions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImatgeURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VegetalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Camps_Vegetals_VegetalId",
                        column: x => x.VegetalId,
                        principalTable: "Vegetals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicions",
                columns: table => new
                {
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    VegetalId = table.Column<int>(type: "int", nullable: false),
                    CampId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicions", x => new { x.DataHora, x.SensorId, x.CampId, x.VegetalId });
                    table.ForeignKey(
                        name: "FK_Medicions_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicions_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicions_Vegetals_VegetalId",
                        column: x => x.VegetalId,
                        principalTable: "Vegetals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Camps",
                columns: new[] { "Id", "ImatgeURL", "Latitud", "Localitzacio", "Longitud", "Observacions", "VegetalId" },
                values: new object[] { 1, null, 41.964083000000002, "Pati Institut Montilivi", 2.8271647, null, null });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Descripcio", "ImatgeURL", "Model", "Nom", "Tipus" },
                values: new object[,]
                {
                    { 1, "Este es un sensor de agua simple que puede usarse para detectar la humedad del suelo.\r\nSe puede usar en el dispositivo de despensa de planta de módulo, y las plantas en su jardín no necesitan que la gente las administre.\r\n¡Esta es una herramienta imprescindible para un jardín conectado! Será útil recordarle regar sus plantas de interior o controlar la humedad del suelo en su jardín.\r\nVoltaje de funcionamiento: 3.3V-5V\r\nMódulo de modo de salida dual, salida digital, salida analógica más precisa.", "https://www.tiendatec.es/3497-large_default/sensor-de-humedad-higrometro-yl69-con-modulo-yl38-para-arduino.jpg", "YL-69", "Sensor humitat", 3 },
                    { 2, "El DHT11 es un sensor incorporado de bajo precio, que se utiliza para medir la temperatura (en un rango de 0 a 50 grados centígrados con una precisión de +-2 C) y la humedad (en un rango de 20% a 80% con una precisión de +-5%).\r\nConsiste en un sensor capacitivo de humedad que mide la humedad del aire.\r\nPara la medición de la temperatura, tiene un termistor incorporado, que es un dispositivo de medición de temperatura NTC resistivo y húmedo.\r\nFunciona con sistemas de microcontroladores de 3,3V y 5V.\r\nEste sensor tiene una excelente calidad, un rápido tiempo de respuesta y capacidad antiinterferencia.\r\nEn el DHT11, los coeficientes de calibración ya están almacenados en la memoria del programa OTP, sólo tenemos que llamar a estos coeficientes de calibración mientras los sensores internos detectan la señal en el proceso.\r\nUtiliza baja potencia en la transmisión de señales simples hasta 20 metros.\r\nViene en un solo paquete que comprende 4 pines con 0.1″ de espacio entre ellos y se puede proporcionar un paquete especial según la demanda del usuario.", "https://descubrearduino.com/wp-content/uploads/2020/03/pinout-DHT11.jpg", "DHT-11", "Sensor temperatura", 2 },
                    { 3, "Sensor fácil de usar para medir la concentración de varios gases tóxicos como benzona, alcohol, humo y contaminantes transportados por el aire.\r\nEl MQ-135 mide concentraciones de gas de 10 a 1000 ppm y es ideal para la detección de fugas de gas, alarmas de gas u otros proyectos de robótica y microcontroladores.\r\nLos sensores de la serie MQ utilizan un pequeño elemento calefactor con un sensor electrónico-químico. Son sensibles a una amplia gama de gases y son adecuados para su uso en interiores.\r\nEl sensor tiene una alta sensibilidad y un tiempo de respuesta rápido, pero tarda unos minutos en dar lecturas precisas porque el sensor tiene que calentarse. Los valores medidos del sensor se emiten como valores analógicos, que se pueden evaluar fácilmente con un microcontrolador.", "https://m.media-amazon.com/images/I/81wbh1mXmmL._SX466_.jpg", "MQ-135", "Sensor qualitat de l'aire", 1 }
                });

            migrationBuilder.InsertData(
                table: "Vegetals",
                columns: new[] { "Id", "Descripcio", "HumitatMaxima", "HumitatMinima", "HumitatOptima", "ImatgeURL", "Nom", "TemperaturaMaxima", "TemperaturaMinima", "TemperaturaOptima" },
                values: new object[,]
                {
                    { 1, "La ceba (Allium cepa) és una planta herbàcia bulbosa de la família de les amaril·lidàcies. És dita cebeta o ceballot quan és tendra, collida abans d'hora, i altres noms pels quals se la coneix en català són ceba blanca, ceba d'Egipte o ceba porrera. Originària de l'Àsia Central, actualment la ceba és un dels ingredients indispensables de la cuina mediterrània. ", 75m, 65m, 70m, "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/300px-Onions.jpg", "Ceba", 35m, 4m, 23m },
                    { 2, "Daucus carota sativus, llamada popularmente zanahoria, es la forma domesticada de la zanahoria silvestre, especie de la familia de las umbelíferas, también denominadas apiáceas, y considerada la más importante y de mayor consumo dentro de esta familia. Es oriunda de Europa y Asia sudoccidental.", null, null, null, "https://soycomocomo.es/media/2019/03/zanahorias.jpg", "Pastanaga", 18m, 9m, 16m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camps_VegetalId",
                table: "Camps",
                column: "VegetalId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicions_CampId",
                table: "Medicions",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicions_SensorId",
                table: "Medicions",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicions_VegetalId",
                table: "Medicions",
                column: "VegetalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicions");

            migrationBuilder.DropTable(
                name: "Camps");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Vegetals");
        }
    }
}
