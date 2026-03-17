namespace ForGeneralTests
{
    public class Program
    {
        public static void Main()
        {
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