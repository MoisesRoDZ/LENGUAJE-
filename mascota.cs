using System;

public class Mascota
{
    // Atributos
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Tipo { get; set; }
    public string Sonido { get; set; }

    // Constructor
    public Mascota(string nombre, int edad, string tipo, string sonido)
    {
        this.Nombre = nombre;
        this.Edad = edad;
        this.Tipo = tipo;
        this.Sonido = sonido;
    }

    // Métodos
    public void EmitirSonido()
    {
        Console.WriteLine(Sonido);
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Tipo: {Tipo}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Crear una instancia de la clase Mascota
        Mascota miMascota = new Mascota("Firulais", 3, "Perro", "Guau!");

        // Llamar a los métodos
        miMascota.EmitirSonido();
        miMascota.MostrarInformacion();
    }
}