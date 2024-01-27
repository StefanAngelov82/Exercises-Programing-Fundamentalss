namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002,
                                    "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            LibraryA libraryOne = new LibraryA();
            LibraryA libraryTwo = new LibraryA(bookOne, bookTwo, bookThree);

            foreach (var books in libraryTwo)
            {
                Console.WriteLine($"{books.Title} {books.Years} {string.Join(", ", books.Authors)}");
            }
        }
    }
}