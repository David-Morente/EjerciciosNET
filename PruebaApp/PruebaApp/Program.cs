using System;

namespace PruebaCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de hipotenusa");
            Console.Write("Ingrese el lado A de la operación: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese el lado B de la operación: ");
            double b = Convert.ToDouble(Console.ReadLine());

            double hipotenusa = Math.Sqrt((a * a) + (b * b));

            Console.WriteLine("La hipotenusa es: " + hipotenusa);
        }
    }
}