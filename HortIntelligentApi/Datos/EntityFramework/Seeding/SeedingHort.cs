using HortIntelligentApi.Domini.Entitats;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace HortIntelligentApi.Datos.EntityFramework.Seeding
{
    public static class SeedingHort
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var sensorHumitat = new Sensor() { Id = 1, Nom = "Sensor humitat", Model = "YL-69", Tipus = EnumTipusSensor.AnalogicIDigital, ImatgeURL = "https://www.tiendatec.es/3497-large_default/sensor-de-humedad-higrometro-yl69-con-modulo-yl38-para-arduino.jpg", Descripcio = "Este es un sensor de agua simple que puede usarse para detectar la humedad del suelo.\r\nSe puede usar en el dispositivo de despensa de planta de módulo, y las plantas en su jardín no necesitan que la gente las administre.\r\n¡Esta es una herramienta imprescindible para un jardín conectado! Será útil recordarle regar sus plantas de interior o controlar la humedad del suelo en su jardín.\r\nVoltaje de funcionamiento: 3.3V-5V\r\nMódulo de modo de salida dual, salida digital, salida analógica más precisa." };
            var sensorTemperatura = new Sensor() { Id = 2, Nom = "Sensor temperatura", Model = "DHT-11", Tipus = EnumTipusSensor.Digital, ImatgeURL = "https://descubrearduino.com/wp-content/uploads/2020/03/pinout-DHT11.jpg", Descripcio = "El DHT11 es un sensor incorporado de bajo precio, que se utiliza para medir la temperatura (en un rango de 0 a 50 grados centígrados con una precisión de +-2 C) y la humedad (en un rango de 20% a 80% con una precisión de +-5%).\r\nConsiste en un sensor capacitivo de humedad que mide la humedad del aire.\r\nPara la medición de la temperatura, tiene un termistor incorporado, que es un dispositivo de medición de temperatura NTC resistivo y húmedo.\r\nFunciona con sistemas de microcontroladores de 3,3V y 5V.\r\nEste sensor tiene una excelente calidad, un rápido tiempo de respuesta y capacidad antiinterferencia.\r\nEn el DHT11, los coeficientes de calibración ya están almacenados en la memoria del programa OTP, sólo tenemos que llamar a estos coeficientes de calibración mientras los sensores internos detectan la señal en el proceso.\r\nUtiliza baja potencia en la transmisión de señales simples hasta 20 metros.\r\nViene en un solo paquete que comprende 4 pines con 0.1″ de espacio entre ellos y se puede proporcionar un paquete especial según la demanda del usuario." };
            var sensorQualitatAire = new Sensor() { Id = 3, Nom = "Sensor qualitat de l'aire", Model = "MQ-135", Tipus = EnumTipusSensor.Analgoic, ImatgeURL = "https://m.media-amazon.com/images/I/81wbh1mXmmL._SX466_.jpg", Descripcio = "Sensor fácil de usar para medir la concentración de varios gases tóxicos como benzona, alcohol, humo y contaminantes transportados por el aire.\r\nEl MQ-135 mide concentraciones de gas de 10 a 1000 ppm y es ideal para la detección de fugas de gas, alarmas de gas u otros proyectos de robótica y microcontroladores.\r\nLos sensores de la serie MQ utilizan un pequeño elemento calefactor con un sensor electrónico-químico. Son sensibles a una amplia gama de gases y son adecuados para su uso en interiores.\r\nEl sensor tiene una alta sensibilidad y un tiempo de respuesta rápido, pero tarda unos minutos en dar lecturas precisas porque el sensor tiene que calentarse. Los valores medidos del sensor se emiten como valores analógicos, que se pueden evaluar fácilmente con un microcontrolador." };
            modelBuilder.Entity<Sensor>().HasData(sensorHumitat, sensorTemperatura, sensorQualitatAire);

            var ceba = new Vegetal() { Id = 1, Nom = "Ceba", TemperaturaMinima = 4, TemperaturaMaxima = 35, TemperaturaOptima = 23, HumitatMinima = 65, HumitatMaxima = 75, HumitatOptima = 70, ImatgeURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/300px-Onions.jpg", Descripcio = "La ceba (Allium cepa) és una planta herbàcia bulbosa de la família de les amaril·lidàcies. És dita cebeta o ceballot quan és tendra, collida abans d'hora, i altres noms pels quals se la coneix en català són ceba blanca, ceba d'Egipte o ceba porrera. Originària de l'Àsia Central, actualment la ceba és un dels ingredients indispensables de la cuina mediterrània. " };
            var pastanaga = new Vegetal() { Id = 2, Nom = "Pastanaga", TemperaturaMinima = 9, TemperaturaMaxima = 18, TemperaturaOptima = 16, ImatgeURL = "https://soycomocomo.es/media/2019/03/zanahorias.jpg", Descripcio = "Daucus carota sativus, llamada popularmente zanahoria, es la forma domesticada de la zanahoria silvestre, especie de la familia de las umbelíferas, también denominadas apiáceas, y considerada la más importante y de mayor consumo dentro de esta familia. Es oriunda de Europa y Asia sudoccidental." };
            modelBuilder.Entity<Vegetal>().HasData(ceba, pastanaga);

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var camp1 = new Camp() { Id = 1, Localitzacio = "Pati Institut Montilivi", Coordenades = geometryFactory.CreatePoint(new Coordinate(41.964083, 2.8271647)) };
            modelBuilder.Entity<Camp>().HasData(camp1);
        }
    }
}
