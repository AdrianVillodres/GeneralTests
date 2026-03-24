namespace ForGeneralTests
{
    public class Program
    {
        public delegate int Metode(int x, int y); //parte del delegate

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

            //Content
            Console.WriteLine("------------------------------------");

            Console.WriteLine("CONTENT");
            Console.WriteLine();
            Caixa<int> caixaInts = new Caixa<int>(15);
            caixaInts.ShowContent();

            Caixa<string> caixaString = new Caixa<string>("Test");
            caixaString.ShowContent();

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
            Console.WriteLine();


            //Delegate
            Console.WriteLine("------------------------------------");

            Console.WriteLine("DELEGATE Y LAMBA EXPRESSIONS");
            //Se declara el metodo Metode fuera del Main
            //se crea un metodo AddMethod y PlusMethod fuera del main
            
            Metode suma = AddMethod; //NO ES DELEGATE!
            Console.WriteLine(suma(3, 5));

            Metode multi = PlusMethod; //NO ES DELEGATE!
            Console.WriteLine(multi(3, 5));

            //Version "primitiva" del delegate, abajo con el action y el func es más bonito
            Metode op = delegate (int x, int y)
            {
                return x + y;
            };
            Console.WriteLine(op(3, 5));

            //A partir de aqui viene a ser lo mismo que el delegate, són lambda expressions, igual pero más bonito, conviertes el metodo en una expresión lambda
            
            //el <string> es el valor de entrada
            Action<string> saludar = nom => Console.WriteLine($"Hola, {nom}!");
            saludar("Dalia");

            //el <int, int, int>, los 2 primeros valores són de entrada(se pueden meter más valores o menos, no hace falta que sean 2) y el ultimo de salida
            Func<int, int, int> sumar = (a, b) => a + b;
            Console.WriteLine(sumar(3, 8));

            //el <string, int>, primer valor de entrada, ultimo de salida
            Func<string, int> longitud = stg => stg.Length;
            Console.WriteLine(longitud("Hola"));
            Predicate<int> esParell = n => n % 2 == 0;
            Console.WriteLine(esParell(4));
            Console.WriteLine(esParell(7));


            //LINQ
            Console.WriteLine("------------------------------------");

            Console.WriteLine("LINQ");

            int[] scores = [97, 92, 81, 60];

            var scoreQuery =
                from score in scores
                where score > 80
                select score;

            foreach(var score in scoreQuery)
            {
                Console.WriteLine(score);
            }

            IList<string> stringList = new List<string>()
            {
                "C# Tutorials",
                "Learn C++",
                "MVC Tutorials",
                "Java"
            };

            var result =
                from s in stringList
                where s.Contains("Tutorials")
                select s;

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            //En el Where se le pasan expresiones lambda
            var result2 = stringList.Where(s => s.Contains("Tutorials"));
            
            foreach(var item in result2)
            {
                Console.WriteLine(item);
            }

            //MapReduce
            Console.WriteLine("------------------------------------");

            Console.WriteLine("MAPREDUCE");
            var testList = new List<int> { 1, 2, 3, 4, 5 };

            var resultSelect = testList.Select(x => x * 2); //Multiplica el resultado X2

            foreach(var item in testList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach(var item in resultSelect)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            var filtre = testList.Where(x => x % 2 == 0); //Mira si son pares
            Console.WriteLine();
            foreach (var item in filtre)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            var agg = testList.Aggregate((x, y) => x + y); //suma todos los valores de la lista
            Console.WriteLine(agg);
        }




        //parte del apartado delegate
        public static int AddMethod(int x, int y)
        {
            return x + y;
        }
        //parte del apartado delegate
        public static int PlusMethod(int x, int y)
        {
            return x * y;
        }
    }
}