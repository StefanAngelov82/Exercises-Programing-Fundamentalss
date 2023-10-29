namespace Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Song> list = new List<Song>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Song newSong = Song.ParsInput(Console.ReadLine());
                list.Add(newSong);
            }

            string input = Console.ReadLine();

            if (input == "all")
            {
                foreach (var song in list)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in list.Where(x => x.TypeList == input))
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }


        public Song(string typeList, string name, int time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }

        public static Song ParsInput(string input)
        {
            string[] inputArg = input.Split('_');

            return new Song(inputArg[0], inputArg[1], int.Parse(inputArg[2]));
        }
    }
}