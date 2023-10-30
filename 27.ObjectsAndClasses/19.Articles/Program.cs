using System.ComponentModel.DataAnnotations;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Articles art = Articles.ParseData(input);

            int N = int.Parse(Console.ReadLine());

            DataCorrection(N, art);

            Console.WriteLine(art);
        }

        static void DataCorrection(int N, Articles art)
        {
            for (int i = 0; i < N; i++)
            {
                string[] commandArg = Console.ReadLine().Split(": ");

                string command = commandArg[0];
                string newData = commandArg[1];

                switch (command)
                {
                    case "Edit":
                        art.Edit(newData);
                        break;
                    case "ChangeAuthor":
                        art.ChangeAuthor(newData);
                        break;
                    case "Rename":
                        art.Rename(newData);
                        break;
                }               
            }            
        }
    }
    class Articles
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; } 

        public Articles(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;             
            this.Author = author;
        }

        public static Articles ParseData(string input)
        {
            string[] inputArg = input.Split(", ");

            return new Articles(inputArg[0], inputArg[1], inputArg[2]);
        }

        public void Edit (string newContent)
        {
             this.Content = newContent;
        }

        public void ChangeAuthor(string newAuther)
        {            
             this.Author = newAuther;
        }

        public void Rename(string newTitle)
        {
             this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}