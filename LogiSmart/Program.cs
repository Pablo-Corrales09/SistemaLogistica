// See https://aka.ms/new-console-template for more information

using LogiSmart.Models;

Paquete tenis = new Paquete("Tenis", 5, 10, 05);
Conductor conductor = new Conductor("Luis", "B2");
VehiculoCamion camion = new VehiculoCamion("12345", 25);
camion.EstadoVehiculo = LogiSmart.Enums.EstadoVehiculo.Disponible;
Ruta ruta = new Ruta(500);
Ruta ruta2 = new Ruta(4500);
Ruta ruta3 = new Ruta(5000);


camion.ColocarEnRuta(conductor, tenis, ruta);
camion.RegistrarViaje(ruta, conductor);


camion.ColocarEnRuta(conductor, tenis, ruta2);
camion.RegistrarViaje(ruta2, conductor);
Console.WriteLine(camion.DescripVehiculo());


camion.ColocarEnRuta(conductor, tenis, ruta3);
camion.RegistrarViaje(ruta2, conductor);
Console.WriteLine(camion.DescripVehiculo());



