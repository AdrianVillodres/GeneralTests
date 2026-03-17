using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGeneralTests
{
    public class Weapon : IComparable<Weapon> //siempre poner
    {
        const int MIN_DAMAGE = 3;
        const float FIRERATE = 1.5f;
        const string NAME = "KNIFE";
        public int Damage { get; set; }
        public float FireRate { get; set; }
        public string Name { get; set; }

        public Weapon(int damage, float fireRate, string name)
        {
            Damage = damage;
            FireRate = fireRate;
            Name = name;
        }

        public Weapon() : this(MIN_DAMAGE, FIRERATE, NAME)
        {

        }
        //Una buena practica en C# y algo obligatiorio en java al momento de hacerle un override al method.Equals() es hacerle override al metodo getHashCode
        public override string ToString() => $"Damage: {Damage}, Fire rate: {FireRate}, Name of the weapon: {Name}";

        public int CompareTo(Weapon? other)
        {
            return (other == null) ? 1 : Damage.CompareTo(other.Damage);
        }
    }
}
