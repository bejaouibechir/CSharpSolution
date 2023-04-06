using CodeFirstEF6.Model;

namespace CodeFirstEF6
{
    internal class Program
    {
        static SocieteContext _context;
        static void Main(string[] args)
        {
            _context = new SocieteContext();
            Categorie categorie = new Categorie { Id=1,Label="Voitures"};
            _context.Categories.Add(categorie);
            _context.SaveChanges();
        }
    }
}
