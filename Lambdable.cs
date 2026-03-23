using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGeneralTests
{
    public class Lambdable : ILambda
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
