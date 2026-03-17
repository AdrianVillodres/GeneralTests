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

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("CONTENT");
            Console.WriteLine();
            Caixa<int> caixaInts = new Caixa<int>(15);
            caixaInts.ShowContent();

            Caixa<string> caixaString = new Caixa<string>("Test");
            caixaString.ShowContent();

            Console.WriteLine();

            //Weapon list
            Console.WriteLine("------------------------------------");
            Console.WriteLine("COMPARETO/OBJECTCOMPARER");
            Console.WriteLine();
            List<Weapon> weapons = new List<Weapon>();

            weapons.Add(new Weapon(25, 3.2f, "Charge rifle"));
            weapons.Add(new Weapon(67, 4.2f, "r99"));
            weapons.Add(new Weapon(40, 2.1f, "Plasma gun"));

            foreach (var item in weapons)
            {
                Console.WriteLine(item); // aqui el toString() se autoimplementa, debido al override que le hemos hecho en la clase
            }

            weapons.Sort();

            Console.WriteLine();
            Console.WriteLine("---------------------------Orenated list(compareTo from class)---------------------------");

            foreach (var item in weapons)
            {
                Console.WriteLine(item); // aqui el toString() se autoimplementa, debido al override que le hemos hecho en la clase
            }

            weapons.Sort(new WeaponComparer());

            Console.WriteLine();
            Console.WriteLine("---------------------------Orenated list(WeaponComparer)---------------------------");

            foreach (var item in weapons)
            {
                Console.WriteLine(item); // aqui el toString() se autoimplementa, debido al override que le hemos hecho en la clase
            }

        }
    }
}