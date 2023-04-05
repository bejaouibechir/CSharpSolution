using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    class Arithmetique // <= internal class Arithmetique 
    {
        double Somme(double a,double b) // <= private 
        {
            return a + b;
        }

        public double Soustraction(double a, double b)
        {
            return a - b;
        }
    }

    
}
