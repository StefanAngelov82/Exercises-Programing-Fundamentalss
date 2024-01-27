namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {            
            List<string> values = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();          

            ListyIterator<string> LS = new ListyIterator<string>(values);

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "END")
            { 
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(LS.Move());
                        break;

                    case "Print":
                        try
                        {
                            LS.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        break;

                    case "HasNext":
                        Console.WriteLine(LS.HasNext());
                        break;
                }
            }
        }
    }
}