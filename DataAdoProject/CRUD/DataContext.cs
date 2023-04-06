using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
//Data Source=PC2023\PC2023;Initial Catalog=BusinessDB;Integrated Security=True
namespace DataAdoProject.CRUD
{
    public partial class DataContext
    {
        //Sql server
        SqlConnection _connection;
        SqlCommand _command;
        SqlDataReader _reader;
        string _sql;

        //Une chaine de connection
        string _connectionstring;

        public DataContext()
        {
            _connectionstring = "Data Source=PC2023\\PC2023;" +
                 "Initial Catalog=BusinessDB;Integrated Security=True";
            _connection = new SqlConnection(_connectionstring);
        }

        public void AddCategorie(Categorie categorie)
        {
            try
            {
                _sql = $"INSERT INTO [dbo].[Categories]([Id],[Label]) VALUES({categorie.Id},{categorie.Label})";
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

    }
}
