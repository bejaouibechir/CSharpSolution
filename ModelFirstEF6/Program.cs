namespace ModelFirstEF6
{
    internal class Program
    {
        static BusinessModelContainer _context;
        static void Main(string[] args)
        {
            _context = new BusinessModelContainer();

            Categorie categorie = new Categorie {Id=1, Label = "Voitures" };
            _context.Categories.Add(categorie);
            _context.SaveChanges();
        }
    }
}
