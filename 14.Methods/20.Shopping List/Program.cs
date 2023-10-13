namespace Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppimgList = Console.ReadLine()
               .Split('!')
               .ToList();


            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] inputArg = input.Split();

                switch (inputArg[0])
                {
                    case "Urgent":
                        Urgent(shoppimgList, inputArg[1]);
                        break;
                    case "Unnecessary":
                        Unnecessary(shoppimgList, inputArg[1]);
                        break;
                    case "Correct":
                        Correct(shoppimgList, inputArg[1], inputArg[2]);
                        break;
                    case "Rearrange":
                        Rearrange(shoppimgList, inputArg[1]);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", shoppimgList));
        }

        private static void Rearrange(List<string> shoppingList, string item)
        {
            if (shoppingList.Contains(item))
            {
                shoppingList.Remove(item);
                shoppingList.Add(item);
            }
        }

        private static void Correct(List<string> shoppingList, string oldItem, string newItem)
        {
            if (shoppingList.Contains(oldItem))
            {
                int index = shoppingList.IndexOf(oldItem);

                shoppingList[index] = newItem;
            }
        }

        private static void Unnecessary(List<string> shoppingList, string item)
        {
            shoppingList.Remove(item);
        }

        private static void Urgent(List<string> shoppingList, string item)
        {
            if (!shoppingList.Contains(item))
            {
                shoppingList.Insert(0, item);
            }
        }
    
    }
}