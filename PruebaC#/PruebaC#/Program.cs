using System;

namespace PruebaCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(":D ");
            Console.WriteLine("\n¡Hola, mundo!");
            Console.WriteLine("\tEmpezando con C#");

            // \n: Darle como formato al texto para que se vea mejor
            // \t: Agregar un tabulador al texto

            int x; // Declaración de la variable
            x = 20; // Inicialización de la variable
            int y = 5; // Declaración e inicialización de la variable
            double peso = 75.5; // Variable de tipo double
            bool activo = true; // Variable de tipo booleano
            char simbolo = '$'; // Variable de tipo carácter
            string nombre = "Juan"; // Variable de tipo cadena de texto
            const string PI = "3.1416"; // Constante de tipo cadena de texto, la constante no puede cambiar su valor
            double gravedad = 9.8; //
            int entero = Convert.ToInt32(gravedad); //Convierte la gravedad a un entero pero no le cambia el valor a la variable gravedad y al momento de imprimir se remueven los decimales
            string name;
            int edad;

            //Interactuar con el usuario
            Console.Write("¿Cuál es tu nombre?: ");
            name = Console.ReadLine();

            Console.Write("¿Cuál es tu edad?: ");
            edad = Convert.ToInt32(Console.ReadLine()); // Convert.ToInt32 convierte el valor ingresado por el usuario a un entero

            Console.WriteLine("Mucho gusto: " + name);
            Console.WriteLine("Tu edad es: " + edad);
            //Imprimir variables
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(y + x);
            Console.WriteLine(peso);
            Console.WriteLine(activo);
            Console.WriteLine(simbolo);
            Console.WriteLine(nombre);
            Console.WriteLine(PI);

            // Type Casting esto convierte valores a distinto tipo de datos por ejemplo string a double
            Console.WriteLine(entero);
            Console.WriteLine(gravedad);
            Console.WriteLine(entero.GetType()); //GetType() sirve para imprimir el tipo de la variable, pero no imprime la variable
            Console.WriteLine(entero.GetType()); //GetType() sirve para imprimir el tipo de la variable, pero no imprime la variable

            Console.ReadKey(); // Espera a que el usuario presione una tecla antes de cerrar la consola para que finalice el programa
        }
    }
}