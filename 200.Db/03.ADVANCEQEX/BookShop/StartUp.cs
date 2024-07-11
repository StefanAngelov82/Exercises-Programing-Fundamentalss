namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
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
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
                sb.AppendLine(book.Title);

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold &&
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

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");

            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                       b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
                sb.AppendLine(book.Title);

            return sb.ToString().Trim();
        }

        static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] givenCategory = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.BooksCategories
                .Where(Check(givenCategory))
                .Select(bc => bc.Book.Title)
                .OrderBy(t => t)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
                sb.AppendLine($"{book}");

            return sb.ToString().Trim();

            Expression<Func<Models.BookCategory, bool>> Check(string[] givenCategory)
            {
                return bc => givenCategory.Contains(bc.Category.Name);
            }
        }
    }
}


