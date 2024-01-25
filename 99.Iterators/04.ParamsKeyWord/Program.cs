namespace ParamsKeyWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintNames("Pesho", "Gosho", "Tosho");
        }

        static void PrintNames(params string[] names)
        {
            Console.WriteLine(String.Join(", ", names));
        } 
    }
}