namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<string> CS = new CustomStack<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string command = input.Split(new string[] {" ", ", " }, StringSplitOptions.RemoveEmptyEntries)[0];
                string[] data = input.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)[1..];
                    
                switch (command)
                {
                    case "Push":
                        CS.Push(data);
                        break;

                    case "Pop":
                        CS.Pop();
                        break;
                }
            }

            foreach (var i in CS)
            {
                Console.WriteLine(i);
            }
        }
    }
}