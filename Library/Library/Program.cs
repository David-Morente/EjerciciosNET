using Library.Model;
List<Book> books = new List<Book>();

Console.WriteLine("Bienvenido a la biblioteca virtual de libros.");
Console.WriteLine("Por favor, elija una opción:");
Console.WriteLine("1. Agregar un libro");
Console.WriteLine("2. Listar los libros");
Console.WriteLine("3. Salir");
string option = Console.ReadLine();
while (option != "3")
{
    switch (option)
    {
        case "1":
            AddBookWithConstructor();
            break;
        case "2":
            ListBooks();
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
            break;
    }
    Console.WriteLine("Por favor, elija una opción:");
    Console.WriteLine("1. Agregar un libro");
    Console.WriteLine("2. Listar los libros");
    Console.WriteLine("3. Salir");
    option = Console.ReadLine();
}
void AddBook() 
{
    Console.Write("Por favor, ingrese el nombre del libro: ");
    string titleBook = Console.ReadLine();
    Console.Write("Por favor, ingrese el autor del libro: ");
    string authorBook = Console.ReadLine();
    Console.Write("Por favor, ingrese el ISBN del libro: ");
    string isbnBook = Console.ReadLine();
    Console.Write("Por favor, ingrese la fecha de publicación del libro (formato: dd/mm/yyyy): ");
    DateTime publishedDateInput = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("¡Libro agregado exitosamente!");

    Book book = new Book(titleBook, authorBook, isbnBook, publishedDateInput);
    books.Add(book);
}

void AddBookWithConstructor()
{
    Book book = new Book();
    Console.Write("Por favor, ingrese el nombre del libro: ");
    book.Title = Console.ReadLine();
    Console.Write("Por favor, ingrese el autor del libro: ");
    book.Author = Console.ReadLine();
    Console.Write("Por favor, ingrese el ISBN del libro: ");
    book.ISBN = Console.ReadLine();
    Console.Write("Por favor, ingrese la fecha de publicación del libro (formato: dd/mm/yyyy): ");
    book.PublishedDate = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("¡Libro agregado exitosamente!");

    books.Add(book);
}

void ListBooks()
{
    Console.WriteLine("Lista de los libros en la biblioteca:");
    foreach (Book book in books)
    {
        Console.WriteLine($"Titulo del libro: {book.Title}, Autor: {book.Author}, ISBN: {book.ISBN}, Fecha de Publicación: {book.PublishedDate.ToShortDateString()}");
    }
}