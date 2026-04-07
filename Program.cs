using System.Collections.Concurrent;
using System.Runtime.InteropServices;

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

            //Repaso
            Console.WriteLine("------------------------------------");
            List<Employee> employees = new List<Employee>() {
                new Employee {Id = 1, Name = "Dalia", HireDate = new DateTime(2015, 6, 15), Salary = 30000, Department = "IT"},
                new Employee {Id = 2, Name = "Wadanohara", HireDate = new DateTime(2015, 6, 16), Salary = 31000, Department = "Marketing" },
                new Employee {Id = 3, Name = "Verone", HireDate = new DateTime(2015, 6, 17), Salary = 32000, Department = "RRHH" },
                new Employee {Id = 4, Name = "Yonaka", HireDate = new DateTime(2015, 6, 18), Salary = 33000, Department = "IT" },
                new Employee {Id = 5, Name = "Satsuki", HireDate = new DateTime(2015, 6, 19), Salary = 34000, Department = "IT" }
            };
            employees.ForEach(e => Console.WriteLine(e.ToString()));
            
            List<SalesEmployee> semployees = new List<SalesEmployee>() {
                new SalesEmployee {Id = 6, Name = "Iwara", HireDate = new DateTime(2015, 6, 15), Salary = 30000, Department = "IT", SalesAmount = 3000, SalesCount = 30 },
                new SalesEmployee {Id = 7, Name = "Yuki", HireDate = new DateTime(2015, 6, 16), Salary = 31000, Department = "Marketing", SalesAmount = 2000, SalesCount = 20  },
                new SalesEmployee {Id = 8, Name = "Aria", HireDate = new DateTime(2015, 6, 17), Salary = 32000, Department = "RRHH", SalesAmount = 4500, SalesCount = 45  },
                new SalesEmployee {Id = 9, Name = "Himeko", HireDate = new DateTime(2015, 6, 18), Salary = 33000, Department = "IT", SalesAmount = 1000, SalesCount = 10  },
                new SalesEmployee {Id = 10, Name = "Matsuri", HireDate = new DateTime(2015, 6, 19), Salary = 34000, Department = "IT", SalesAmount = 10000, SalesCount = 100  }
            };
            semployees.ForEach(se => Console.WriteLine(se.ToString()));

            employees.ForEach(e => e.Salary *= 1.10m);
            employees.ForEach(e => Console.WriteLine(e.ToString()));

            foreach(var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }

            semployees.ForEach(se => se.SalesCount += 1);
            semployees.ForEach(se => Console.WriteLine(se.ToString()));

            Employee firstEmployee = employees.First(e => e.Department == "IT");
            Console.WriteLine($"El primer empleat es {firstEmployee.Name}");
            Employee unknownEmployee = employees.FirstOrDefault(e => e.Department == "Logistica");
            if (unknownEmployee == null) Console.WriteLine("No hi ha empleats d'aquest departament");

            Employee isEmployee = employees.Single(e => e.Id == 1);
            Console.WriteLine($"ID: {isEmployee.Name}");

            Employee nonExistentEmployee = employees.SingleOrDefault(e => e.Id == 35);
            if (nonExistentEmployee == null) Console.WriteLine("No existe el empleado");

            bool hasSalesEmployees = employees.Any(e => e.Department == "Ventes");
            Console.WriteLine(hasSalesEmployees ? "Hay empleados en ventas" : "No hay empleados en ventas");
            
            bool hasSalesEmployeesRRHH = employees.Any(e => e.Department == "RRHH");
            Console.WriteLine(hasSalesEmployeesRRHH ? "Hay empleados en RRHH" : "No hay empleados en RRHH");

            bool tenYearsEmployee = employees.Any(e => e.HireDate.Year <= DateTime.Now.Year - 10);
            Console.WriteLine(tenYearsEmployee ? "Hay empleados de mas de diez años" : "No hay empleados de mas de diez años");

            Func<Employee, int> calculateSeniority = e => DateTime.Now.Year - e.HireDate.Year;
            bool hasSeniorEmployees = employees.Any(e => calculateSeniority(e) > 10);
            Console.WriteLine(hasSeniorEmployees ? "Hay empleados de mas de diez años" : "No hay empleados de mas de diez años");

            List<string> employeesNames = employees.Select(e => e.Name).ToList();

            List<Employee> highSalaryEmployees = employees.Where(e => e.Salary > 30000).ToList();
            highSalaryEmployees.ForEach(e => Console.WriteLine(e.Name));

            var employeeByDepartment = employees.GroupBy(e => e.Department);
            foreach(var group in employeeByDepartment)
            {
                Console.WriteLine($"Department: {group.Key}");
                group.ToList().ForEach(e => Console.WriteLine($" - {e.Name}"));
            }



            //
            Console.WriteLine("------------------------------------");

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