using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGeneralTests
{
    public class WeaponComparer : IComparer<Weapon>
    {
        public int Compare(Weapon? x, Weapon? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.FireRate.CompareTo(y.FireRate);
        }
    }
}
