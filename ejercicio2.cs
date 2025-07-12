using System;

public class ObtenerDatosUsuario
{
    public static void Main(string[] args)
    {
        string? nombre; 
        int añoNacimiento;
        int edadMeses;

        Console.WriteLine("Ingresa tu nombre:");
        nombre = Console.ReadLine();

        
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("No ingresaste un nombre válido.");
            nombre = "Usuario desconocido"; 
        }

        Console.WriteLine("Ingresa tu año de nacimiento:");
        while (!int.TryParse(Console.ReadLine(), out añoNacimiento))
        {
            Console.WriteLine("Año inválido. Ingresa un número entero.");
        }

        Console.WriteLine("Ingresa tu edad en meses:");
        while (!int.TryParse(Console.ReadLine(), out edadMeses))
        {
            Console.WriteLine("Edad inválida. Ingresa un número entero.");
        }

       
        Console.WriteLine($"\nNombre: {nombre}");
        Console.WriteLine($"Año de nacimiento: {añoNacimiento}");
        Console.WriteLine($"Edad en meses: {edadMeses}");
    }
}