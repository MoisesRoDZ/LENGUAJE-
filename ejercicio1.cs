using System;

public class Usuario
{
    public string Nombre { get; set; }
    public int AñoNacimiento { get; set; }
    public int EdadMeses { get; set; }

    public Usuario(string nombre, int añoNacimiento)
    {
        Nombre = nombre;
        AñoNacimiento = añoNacimiento;
        
        DateTime fechaNacimiento = new DateTime(añoNacimiento, 1, 1); 
        DateTime fechaActual = DateTime.Now;
        EdadMeses = (fechaActual.Year - fechaNacimiento.Year) * 12 + (fechaActual.Month - fechaNacimiento.Month);

        
        if (fechaActual.Month < fechaNacimiento.Month)
        {
            EdadMeses -= 12;
        }

    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Año de nacimiento: {AñoNacimiento}");
        Console.WriteLine($"Edad en meses: {EdadMeses}");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese su nombre:");
        string? nombre = Console.ReadLine();
        if (string.IsNullOrEmpty(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío. Por favor, ingrese un nombre válido.");
            return;
        }

        Console.WriteLine("Ingrese su año de nacimiento:");
        int añoNacimiento;
        while (!int.TryParse(Console.ReadLine(), out añoNacimiento))
        {
            Console.WriteLine("Año de nacimiento inválido. Por favor ingrese un número entero.");
        }

        Usuario usuario = new Usuario(nombre, añoNacimiento);
        usuario.MostrarInformacion();
    }
}
