using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography.X509Certificates;

namespace CodeFirstEF6.Model
{
    public class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            HasKey(c => c.Id);
            /*HasRequired(c => c.Nom);
            HasRequired(c => c.Contact);
            HasRequired(c => c.Adresse);*/

        }
    }
}