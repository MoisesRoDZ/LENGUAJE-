using System;

public class AdivinaContraseña
{
    public static void Main(string[] args)
    {
        string contraseñaSecreta = "1234";
        string? contraseñaIngresada; 
        int intentosRestantes = 3;
        bool contraseñaCorrecta = false;

        do
        {
            Console.WriteLine($"\nIntentos restantes: {intentosRestantes}");
            Console.Write("Ingresa la contraseña: ");
            contraseñaIngresada = Console.ReadLine();

            if (contraseñaIngresada == contraseñaSecreta)
            {
                contraseñaCorrecta = true;
            }
            else
            {
                intentosRestantes--;
                Console.WriteLine("Contraseña incorrecta.");
            }
        } while (!contraseñaCorrecta && intentosRestantes > 0);

        if (contraseñaCorrecta)
        {
            Console.WriteLine("\n¡Contraseña correcta!");
        }
        else
        {
            Console.WriteLine("\nSe te acabaron los intentos. La contraseña era: " + contraseñaSecreta);
        }
    }
}