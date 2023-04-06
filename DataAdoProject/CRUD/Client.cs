namespace DataAdoProject.CRUD
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public bool Status { get; set; } //0 pour personne physique sinon 1 pour personne morale
        public string Adresse { get; set; }
        public string Contact { get; set; }
    }
}