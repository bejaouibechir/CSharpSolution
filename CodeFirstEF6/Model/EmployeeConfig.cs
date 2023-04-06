using System.Data.Entity.ModelConfiguration;

namespace CodeFirstEF6.Model
{
    internal class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig()
        {
            HasKey(e => e.Id);
            //HasRequired(e => e.Nom);
        }
    }
}