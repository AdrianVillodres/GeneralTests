using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGeneralTests
{
    public class Caixa <T>
    {
        public T Content { get; set; }

        public Caixa(T content)
        {
            Content = content;
        }

        public void ShowContent()
        {
            Console.WriteLine($"El contingut és: {Content}");
        }
    }
}
