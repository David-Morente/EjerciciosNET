using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su nombre:");
            string nombre = Console.ReadLine();
            //nombre = nombre.ToUpper(); // Convierte lo que hay en la variable a mayúsculas
            //nombre = nombre.ToLower(); // Convierte lo que hay en la variable a minúsculas
            //nombre = nombre.Insert(0, "@");
            //nombre = nombre.Substring(0, 5); // Extrae los primeros 5 caracteres de la variable
            string telefono = "123-456-789";
            telefono = telefono.Replace("-", "/"); // Reemplaza el guion por una barra diagonal

        //if (String.IsNullOrEmpty(nombre))
        //{
        //    nombre = "No se ingresó un nombre";
        //} else {
        //    Console.WriteLine(nombre.Length); //Muestra la cantidad de caracteres que lleva la variable
        //}

        if (!String.IsNullOrEmpty(nombre))
        {
            Console.WriteLine(nombre.Length);
        }

        Console.WriteLine(nombre);
            Console.WriteLine(telefono);
            Console.ReadKey();
        }
    }