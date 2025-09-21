using System;

class Program
{
    static void Main(string[] args)
    {
        TemperatureSensor sensor = null;
        alertSystem alert = new alertSystem();
        bool activo = true;

        while (activo)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ DE MONITOREO DE TEMPERATURA ===");
            Console.WriteLine("1. Iniciar sensor");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    if (sensor == null)
                    {
                        sensor = new TemperatureSensor();

                        sensor.HighTemperatureReached += (sender, e) =>
                        {
                            var args = new TemperatureEventArgs(((TemperatureSensor)sender).GetCurrentTemperature());
                            alert.OnHighTemperature(sender, args);
                        };

                        sensor.LowTemperatureReached += (sender, e) =>
                        {
                            var args = new TemperatureEventArgs(((TemperatureSensor)sender).GetCurrentTemperature());
                            alert.OnLowTemperature(sender, args);
                        };

                        Console.WriteLine("Sensor iniciado. Presiona Enter para continuar...");
                    }
                    else
                    {
                        Console.WriteLine("El sensor ya está en funcionamiento.");
                    }
                    Console.ReadLine();
                    break;


                case "2":
                    activo = false;
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}