
using System.Data.Entity;

namespace CodeFirstEF6.Model
{
    public class SocieteContext :DbContext
    {
        public SocieteContext() : base("name=BusinessDBEntities")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SocieteContext>());
        }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Configurations.Add(new CategorieConfig());
            builder.Configurations.Add(new ClientConfig());
            builder.Configurations.Add(new EmployeeConfig());
            builder.Configurations.Add(new ProduitConfig());
        }


        public DbSet<Produit> Produits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
