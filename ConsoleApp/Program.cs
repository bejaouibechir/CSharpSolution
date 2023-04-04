﻿using System;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    { 
       static void Main(string[] args)
       {
            int x = 2; //entière 
            long y = x; // conversion implicite

            long x1 = 2; //entière 
            int y1 = (int)x1; // conversion explicite
            Console.WriteLine(y);

            //Boxing
            object a = 2;
            //UnBoxing
            int b = (int)a;

            string content = "{Id:1 , Nom:\"bechir\"}";
            string[] values = content.Split('{', ':', ',');
            int id = int.Parse(values[2]); //Parse converti de chaine vers une valeur numérique

            //Scénario de convrsion pour conversion d'une chaine vers un type numérique particulier
            string valuestr = "12x";
            //int value = int.Parse(valuestr);
            int value;
            int.TryParse(valuestr, out value);
            Console.WriteLine(value);

            //Pour la conversion d'un objet vers un type numérique particulier
            object entierobj = 2;
            int entier = System.Convert.ToInt32(entierobj);

            object ledoubleobj = 5.5255;
            double ledouble = System.Convert.ToDouble(ledoubleobj);

       }    
    }

}


