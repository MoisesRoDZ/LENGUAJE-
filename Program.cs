using System;

public class Guerrero
{
    private int fuerza;
    private int resistencia;
    private int energia;
    private int experiencia;
    private int nivel;
    private const int energiaMaxima = 100; // Define la energía máxima

    public Guerrero(string nombre) //Constructor, ahora pide nombre
    {
        Nombre = nombre;
        fuerza = 10;
        resistencia = 12;
        energia = energiaMaxima;
        experiencia = 0;
        nivel = 1;
    }
    public string Nombre { get; set; } //Propiedad para el nombre

    public int Fuerza
    {
        get { return fuerza; }
        set { fuerza = Math.Max(0, value); } // No permitir fuerza negativa
    }

    public int Resistencia
    {
        get { return resistencia; }
        set { resistencia = Math.Max(0, value); } // No permitir resistencia negativa
    }

    public int Energia
    {
        get { return energia; }
        set { energia = Math.Clamp(value, 0, energiaMaxima); } // Asegurar que la energía esté entre 0 y el máximo
    }

    public int Experiencia
    {
        get { return experiencia; }
        set { experiencia = Math.Max(0, value); } // No permitir experiencia negativa
    }

    public int Nivel
    {
        get { return nivel; }
        set { nivel = Math.Max(1, value); } // El nivel no puede ser menor que 1
    }

    public void VerEstado()
    {
        Console.WriteLine("-Estado guerrero-");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Nivel: {Nivel}");
        Console.WriteLine($"Experiencia: {Experiencia}");
        Console.WriteLine($"Fuerza: {Fuerza}");
        Console.WriteLine($"Resistencia: {Resistencia}");
        Console.WriteLine($"Energia: {Energia}");
    }

    public void EntrenarFuerza()
    {
        int horasMaximas = Energia / 5;
        if (horasMaximas == 0)
        {
            Console.WriteLine("Ya no tienes energia para entrenar fuerza!");
            return;
        }

        Console.Write($"Por cuanto tiempo vas a entrenar tu fuerza? (Tiempo maximo: {Math.Min(5, horasMaximas)})");
        if (int.TryParse(Console.ReadLine(), out int horas))
        {
            if (horas < 1 || horas > 5 || horas > horasMaximas)
            {
                Console.WriteLine("Numero invalido");
                return;
            }

            for (int i = 0; i < horas; i++)
            {
                Fuerza += 4;
                Energia -= 5;
            }
            Experiencia += 5;

            Console.WriteLine($"Entrenaste por {horas} hora(s) y ganaste {horas * 4} puntos de fuerza, 5 experiencia y perdiste {horas * 5} de energia.");
            DecirNivel();
        }
        else
        {
            Console.WriteLine("Entrada invalida. Debes ingresar un numero.");
        }
    }

    public void EntrenarResistencia()
    {
        int horasMaximas = Energia / 5;
        if (horasMaximas == 0)
        {
            Console.WriteLine("Ya no tienes energia para entrenar resistencia!");
            return;
        }

        Console.Write($"Por cuanto tiempo vas a entrenar tu resistencia? (Tiempo maximo: {Math.Min(5, horasMaximas)})");
        if (int.TryParse(Console.ReadLine(), out int horas))
        {
            if (horas < 1 || horas > 5 || horas > horasMaximas)
            {
                Console.WriteLine("Numero invalido");
                return;
            }

            for (int i = 0; i < horas; i++)
            {
                Resistencia += 3;
                Energia -= 5;
            }
            Experiencia += 6;

            Console.WriteLine($"Entrenaste por {horas} hora(s) y ganaste {horas * 3} puntos de resistencia, 6 experiencia y perdiste {horas * 5} de energia.");
            DecirNivel();
        }
        else
        {
            Console.WriteLine("Entrada invalida. Debes ingresar un numero.");
        }
    }

    public void Dormir()
    {
        Energia = energiaMaxima; // Restablecer la energía a la energía máxima
        Console.WriteLine("Descansaste y recuperaste toda tu energia.");
    }

    public void Pelear()
    {
        if (Energia < 10)
        {
            Console.WriteLine("No puedes pelear contra un enemigo sin energia.");
            return;
        }

        Energia -= 10;

        Random random = new Random();
        int enemigoPoderTotal = random.Next(15, 120);

        Console.WriteLine($"Te enfrentas a un enemigo con un total de fuerza de {enemigoPoderTotal}");
        int poderTotalGuerrero = Fuerza + Resistencia;
        Console.WriteLine($"Tu total de fuerza es {poderTotalGuerrero}");

        if (poderTotalGuerrero >= enemigoPoderTotal)
        {
            Console.WriteLine("Ganaste!");
            Experiencia += 10;
            Console.WriteLine("Ganaste 10 de experiencia y perdiste 10 puntos de energia");
        }
        else
        {
            Console.WriteLine("Perdiste...");
            Experiencia -= 8;
            Energia -= 10;
            Console.WriteLine("Perdiste 8 de experiencia y 10 puntos de energia");
        }
        DecirNivel();
    }

    private void DecirNivel()
    {
        while (Experiencia >= 100)
        {
            Nivel++;
            Experiencia -= 100;
            Console.WriteLine("Tu nivel ha incrementado!");
        }
        if (Experiencia < 0)
            Experiencia = 0;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al juego del guerrero!");
        Console.Write("Ingresa el nombre de tu guerrero: ");
        string nombreGuerrero = Console.ReadLine();

        Guerrero miGuerrero = new Guerrero(nombreGuerrero); //Crear guerrero con nombre

        bool continuar = true;
        do
        {
            Console.WriteLine("\n-Menu-");
            Console.WriteLine("1. Ver estado");
            Console.WriteLine("2. Entrenar fuerza");
            Console.WriteLine("3. Entrenar resistencia");
            Console.WriteLine("4. Dormir");
            Console.WriteLine("5. Pelear");
            Console.WriteLine("6. Salir del juego");
            Console.WriteLine(" ");
            Console.WriteLine("Elige una opcion con un numero (Ejemplo: 1 y despues Enter = Ver estado)");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    miGuerrero.VerEstado();
                    break;
                case "2":
                    miGuerrero.EntrenarFuerza();
                    break;
                case "3":
                    miGuerrero.EntrenarResistencia();
                    break;
                case "4":
                    miGuerrero.Dormir();
                    break;
                case "5":
                    miGuerrero.Pelear();
                    break;
                case "6":
                    continuar = false;
                    Console.WriteLine("Adios!");
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        } while (continuar);
    }
}