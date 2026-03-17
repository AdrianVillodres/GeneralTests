namespace ForGeneralTests
{
    public class Program
    {
        public static void Main()
        {
            //Listas etc etc etc
            Person juan = new Person("Juan", 18);
            Person laura = new Person("laura", 27);
            Person adrian = new Person("adrian", 20);
            List<Person> usuaris = new List<Person>();

            usuaris.Add(juan);
            usuaris.Add(laura);
            usuaris.Add(adrian);
            Console.Write("LISTAS");
            Console.WriteLine();
            foreach (var i in usuaris)
            {
                Console.WriteLine($"{i.Name} {i.Age}");
            }

            

        }
    }
}