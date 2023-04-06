using System.Data.Entity.ModelConfiguration;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;

namespace CodeFirstEF6.Model
{
    public class CategorieConfig : EntityTypeConfiguration<Categorie>
    {
        public CategorieConfig()
        {
            //Dicte à sql server de créer le Id comme clé primaire
            HasKey(c => c.Id);
            // Dicte à sql server de ne pas accepter les valeur nulles pour Label
            //HasRequired(c=>c.Label);
          
        }
    }
}