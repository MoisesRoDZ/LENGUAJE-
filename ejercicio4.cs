using System;

public class LustrosVividos
{
    public static void Main(string[] args)
    {
        int edad;

        Console.WriteLine("Ingresa tu edad:");
        while (!int.TryParse(Console.ReadLine(), out edad) || edad < 0)
        {
            Console.WriteLine("Edad inválida. Ingresa un número entero no negativo.");
        }

        Console.WriteLine("\nLustros vividos:");
        for (int lustro = 0; lustro <= edad / 5; lustro++)
        {
            Console.WriteLine($"Lustro {lustro}: {lustro * 5} - {(lustro * 5) + 4} años");
        }
    }
}