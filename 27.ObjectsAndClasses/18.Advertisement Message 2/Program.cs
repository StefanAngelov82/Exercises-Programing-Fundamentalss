namespace Advertisement_Message_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ad ad = new Ad();

            int N = int.Parse(Console.ReadLine());

            Random rd = new Random();           

            while (N > 0)
            {
                int index1 = rd.Next(0, ad.Phrases.Length);
                int index2 = rd.Next(0, ad.Events.Length);
                int index3 = rd.Next(0, ad.Authors.Length);
                int index4 = rd.Next(0, ad.Cities.Length);

                Console.WriteLine($"{ad.Phrases[index1]} {ad.Events[index2]} {ad.Authors[index3]} - {ad.Cities[index4]}");
                N--;
            }            
        }
    }
    class Ad
    {
        public string[] Phrases
        {
            get
            {
                return new string[] 
                {
                    "Excellent product.",                                      
                    "Such a great product.",                 
                    "I always use that product.",                 
                    "Best product of its category.",                 
                    "Exceptional product.",                 
                    "I can't live without this product." 
                };
            }
        }
        public string[] Events
        {
            get 
            {
                return new string[] 
                {
                    "Now I feel good.",
                    "I have succeeded with this product.",
                    "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.",
                    "Try it yourself, I am very satisfied.",
                    "I feel great!"
                };
            }  
        }
        public string[] Authors 
        {
            get 
            {
                return new string[] 
                {
                    "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
                };
            }  
        }
        public string[] Cities 
        {
            get 
            {
                return new string[] 
                {
                    "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
                };
            }  
        }

    }
}