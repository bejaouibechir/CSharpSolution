using System.Data.Entity.ModelConfiguration;

namespace CodeFirstEF6.Model
{
    internal class ProduitConfig : EntityTypeConfiguration<Produit>
    {
        public ProduitConfig()
        {
            HasKey(p => p.Id);
            //HasRequired(p => p.Label);

            //Relation 1 (Categorie) => plusieurs (Produits)
            HasRequired(ca => ca.Categorie)
                .WithMany(p => p.Produits).HasForeignKey(p => p.CategorieId)
                .WillCascadeOnDelete(false);

            //Relation 1 (Client) => plusieurs (Produits)
            HasRequired(cl => cl.Client)
               .WithMany(p => p.Produits).HasForeignKey(p => p.ClientId)
               .WillCascadeOnDelete(true);

            //Relation 1 (Employee) => plusieurs (Produits)
            HasRequired(e => e.Employee)
               .WithMany(p => p.Produits).HasForeignKey(p => p.EmployeeId)
               .WillCascadeOnDelete(false);

        }
    }
}