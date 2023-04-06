namespace DataAdoProject.CRUD
{
    public class Produit
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public decimal? Prix { get; set; }
        public int ClientId { get; set; }
        public int EmplyeeId { get; set; }
        public int CategrieId { get; set; }


    }
}