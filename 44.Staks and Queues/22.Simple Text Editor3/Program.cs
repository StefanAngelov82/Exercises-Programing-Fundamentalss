using System.Text;

Stack<string> history = new Stack<string>();
StringBuilder text = new StringBuilder();

int commandNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < commandNumber; i++)
{
    string[] command = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    switch (command[1])
    {
        case "1":
            history.Push(text.ToString());
            text.Append(command[1]);
            break;

        case "2":
            int count = int.Parse(command[1]);

            history.Push(text.ToString());
            text.Remove(text.Length - 1 - count, count);
            break;

        case "3":
            int index = int.Parse(command[1]);
            Console.WriteLine(text[index]);
            break;

        case "4":
            text.Clear();
            text.Append(history.Pop());            
            break;
    }
}

