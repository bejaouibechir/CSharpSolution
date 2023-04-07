

using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataAdoProject.CRUD
{
    public partial class DataContext
    {
        public void AddClient(Client client) 
        {
            try
            {
                
                //int status;

                //if(client.Status==false)
                //{
                //    status = 0;
                //}
                //else
                //{
                //    status = 1;
                //}
                //      A
                //      |
                //  Equivalent
                int status = (client.Status == false) ? 0 : 1; //Operateur ternaire

                _sql = $"INSERT INTO [dbo].[Clients]([Id],[Nom],[Status],[Adresse],[Contact])" +
                    $" VALUES({client.Id},'{client.Nom}',{status},'{client.Adresse}','{client.Contact}')";
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
        public void UpdateClient(int id,Client client) 
        {
            try
            {
                int status = (client.Status == false) ? 0 : 1; //Operateur ternaire
                _sql = $"UPDATE [dbo].[Clients] SET [Nom] ='{client.Nom}'" +
                    $" ,[Status] ={status} ,[Adresse] ='{client.Adresse}' ,[Contact] ='{client.Contact}'" +
                    $" WHERE Id= {id} ";
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

        public void DeleteClient(int id)
        {
            try
            {
                _sql = $"DELETE FROM [dbo].[Clients]WHERE Id ={id}";
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


        public Client GetClient(int id)
        {
            Client Client;
            try
            {
                _sql = $"SELECT [Id],[Nom],[Status],[Adresse],[Contact] FROM [dbo].[Clients] Where Id={id}";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                _reader.Read();

                Client = new Client
                {
                    Id = int.Parse(_reader[0].ToString()),
                    Nom = _reader[1].ToString(),
                    Status = (_reader[2].ToString()=="0")?false:true ,
                    Adresse = _reader[3].ToString(),
                    Contact = _reader[4].ToString()
                };

                return Client;

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
        public List<Client> GetClientList()
        {
            List<Client> ClientList;
            Client Client;
            try
            {
                _sql = $"SELECT [Id],[Nom],[Status],[Adresse],[Contact] FROM [dbo].[Clients]";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                ClientList = new List<Client>();
                while (_reader.Read())
                {
                    Client = new Client
                    {
                        Id = int.Parse(_reader[0].ToString()),
                        Nom = _reader[1].ToString(),
                        Status = (_reader[2].ToString() == "False") ? false : true,
                        Adresse = _reader[3].ToString(),
                        Contact = _reader[4].ToString()
                    };
                    ClientList.Add(Client);
                }
                return ClientList;

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
