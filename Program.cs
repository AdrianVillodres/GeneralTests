namespace ForGeneralTests
{
    public class Program
    {
        public static void Main()
        {
            

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("CONTENT");
            Console.WriteLine();
            Caixa<int> caixaInts = new Caixa<int>(15);
            caixaInts.ShowContent();

            Caixa<string> caixaString = new Caixa<string>("Test");
            caixaString.ShowContent();

        }
    }
}