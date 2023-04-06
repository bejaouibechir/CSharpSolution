using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdoProject.CRUD
{
    public partial  class DataContext
    {
        public void AddProduit(Produit produit)
        {
            try
            {
                
                _sql = $"INSERT INTO [dbo].[Produits] ([Id],[Label],[Prix],[ClientId]," +
                    $"[EmployeeId],[CategorieId])VALUES({produit.Id},'{produit.Label}'," +
                    $"{produit.Prix},{produit.ClientId},{produit.EmplyeeId},{produit.CategrieId})";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        public void UpdateProduit(int id, Produit produit)
        {
            try
            {
                
                _sql = $"UPDATE [dbo].[Produits] SET  [Label] ='{produit.Label}' ,[Prix] ={produit.Prix}  ," +
                    $"[ClientId] = {produit.ClientId} ," +
                    $"[EmployeeId] = {produit.EmplyeeId}  ,[CategorieId] = {produit.CategrieId}  WHERE Id={id}";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeleteProduit(int id)
        {
            try
            {
                _sql = $"DELETE FROM [dbo].[Produits]  WHERE Id= {id}";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public Produit GetProduit(int id)
        {
            Produit Produit;
            try
            {
                _sql = $"SELECT [Id],[Label],[Prix],[ClientId],[EmployeeId] ,[CategorieId] FROM [dbo].[Produits]" +
                    $" WHERE Id={id}";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                _reader.Read();

                Produit = new Produit
                {
                    Id = int.Parse(_reader[0].ToString()),  
                    Label = _reader[1].ToString(),
                    Prix = decimal.Parse(_reader[2].ToString()),
                    ClientId = int.Parse(_reader[3].ToString()),
                    EmplyeeId = int.Parse(_reader[4].ToString()),
                    CategrieId = int.Parse(_reader[5].ToString()),
                };

                return Produit;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _connection.Close();
            }


        }
        public List<Produit> GetProduitList()
        {
            List<Produit> ProduitList;
            Produit Produit;
            try
            {
                _sql = $"SELECT [Id],[Label],[Prix],[ClientId],[EmployeeId] ,[CategorieId] FROM [dbo].[Produits]";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                ProduitList = new List<Produit>();
                while (_reader.Read())
                {
                    Produit = new Produit
                    {
                        Id = int.Parse(_reader[0].ToString()),
                        Label = _reader[1].ToString(),
                        Prix = decimal.Parse(_reader[2].ToString()),
                        ClientId = int.Parse(_reader[3].ToString()),
                        EmplyeeId = int.Parse(_reader[4].ToString()),
                        CategrieId = int.Parse(_reader[5].ToString()),
                    };
                    ProduitList.Add(Produit);
                }
                return ProduitList;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _connection.Close();
            }

        }
    }
}
