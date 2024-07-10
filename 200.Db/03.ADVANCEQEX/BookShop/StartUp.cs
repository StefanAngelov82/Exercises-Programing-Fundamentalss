namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetGoldenBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;

            if (command.ToLower() == "minor")
                ageRestriction = AgeRestriction.Minor;

            else if (command.ToLower() == "teen")
                ageRestriction = AgeRestriction.Teen;

            else ageRestriction = AgeRestriction.Adult;

           // if (!Enum.TryParse(command, true, out ageRestriction))
               // return string.Empty;

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {

                    b.Title
                })
                .OrderBy(b =>b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
                sb.AppendLine(book.Title);

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b =>b.EditionType == EditionType.Gold &&
                       b.Copies < 5_000)
                .Select(b => new
                {
                    b.BookId,
                    BookTitle = b.Title,
                })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
                sb.AppendLine(book.BookTitle);

            return sb.ToString().Trim();
        }
    }
}


