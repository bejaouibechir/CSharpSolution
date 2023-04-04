using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tuple de type valeur utilisé pour représenter une adresse
            (short, string, string, string) adresse1 = (12,"Ruexyz","Paris","France");
           
            Console.WriteLine($"Numéro: {adresse1.Item1} ,rue: {adresse1.Item2}, " +
                $"cité: {adresse1.Item3}, pays: {adresse1.Item4}");
            
            //Une deuxième alternative en utilisant une structure 

            Adresse adresse2 = new Adresse();
            adresse2.Numéro = 12;
            adresse2.Rue = "Ruexyz";
            adresse2.Cité = "Paris";
            adresse2.Pays = "France";

            Console.WriteLine($"Numéro: {adresse2.Numéro} ,rue: {adresse2.Rue}, " +
                $"cité: {adresse2.Cité}, pays: {adresse2.Pays}");

            Adresse adresse3 = new Adresse(12);
            
        }

    }

    public struct Adresse
    {
        public Adresse(short numéro = 12,string rue= "Ruexyz", string cité= "Paris", string pays= "France")
        {
            Numéro = numéro;
            Rue = rue;
            Cité = cité;
            Pays = pays;
        }
        
        public short Numéro;
        public string Rue;
        public string Cité;
        public string Pays;
    }
}


