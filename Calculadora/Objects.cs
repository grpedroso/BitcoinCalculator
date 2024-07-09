using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Objects
    { 
       public double Calculator(double preco, int ano)
        {
            if (ano == 1)
            {
                preco = preco + (preco * 0.89);
            }
            if (ano == 5) 
            {
                preco = preco + (preco * 37.10);
            }
            if (ano == 10) 
            {
                preco = preco + (preco * 1100);              
            }
            return preco;
        }

    }
}
