namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetTotalProfitByCategory(db));
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

         public static string GetBooksByCategory(BookShopContext context, string input)
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

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var datetime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b =>b.ReleaseDate < datetime)
                .Select(b => new
                {
                    RelDate = b.ReleaseDate,
                    BookTitle =  b.Title,
                    EdType = b.EditionType,
                    Price = b.Price

                })
                .OrderByDescending(b =>b.RelDate)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
                sb.AppendLine($"{book.BookTitle} - {book.EdType} - ${book.Price:F2}");

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToList()
                .OrderBy(z => z);

            return string.Join(Environment.NewLine, authors);            
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t =>t)
                .ToList();

                return string.Join(Environment.NewLine, books);

        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string cor = input.ToLower();
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(cor))
                .OrderBy(b =>b.BookId)
                .Select(b => 
                     $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")                
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copies = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    TotalCopies = a.Books.Sum(t => t.Copies)

                })
                .OrderByDescending(t => t.TotalCopies)
                .ToList();

            StringBuilder sb = new();

            foreach (var copy in copies)
                sb.AppendLine($"{copy.Name} - {copy.TotalCopies}");

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(t => t.Book.Copies * t.Book.Price)                           
                })
                .OrderByDescending (v => v.TotalProfit)
                .ThenBy(v => v.CategoryName)
                .ToList();

            return string.Join(Environment.NewLine, result.Select(r => $"{r.CategoryName} ${r.TotalProfit:F2}"));
             
        }
    }
}


