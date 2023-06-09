﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        SqlDataAdapter _adapter;
        DataSet _dataset;
        string _sql;

        //Une chaine de connection
        string _connectionstring;

        public DataContext()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings["businessdb"].ConnectionString;
            _connection = new SqlConnection(_connectionstring);
        }

        public void AddCategorie(Categorie categorie)
        {
            try
            {
                //Injection sql
                //_sql = $"INSERT INTO [dbo].[Categories]([Id],[Label]) VALUES({categorie.Id},'{categorie.Label}')";

                _sql = $"INSERT INTO [dbo].[Categories]([Id],[Label]) VALUES(@id,@label)";//Requête paramétrée

                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = categorie.Id;

                SqlParameter labelparam = new SqlParameter("@label", SqlDbType.NVarChar,50);
                labelparam.Direction = ParameterDirection.Input;
                labelparam.Value = categorie.Label;

                _command = new SqlCommand(_sql, _connection);
                _command.Parameters.Add(idparam);
                _command.Parameters.Add(labelparam);

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
        public void UpdateCategorie(int id, string label)
        {
            try
            {
                _sql = $"UPDATE [dbo].[Categories] SET [Label] ='{label}'  WHERE Id ={id}";
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
        public void DeleteCategorie(int id)
        {
            try
            {
                _sql = $"DELETE FROM [dbo].[Categories] WHERE Id={id}";
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

        public Categorie GetCategorie(int id)
        {
            Categorie categorie;
            try
            {
                _sql = $"SELECT [Id],[Label] FROM [dbo].[Categories] WHERE Id = {id}";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                _reader.Read();
                
                categorie = new Categorie
                {
                    Id = int.Parse(_reader[0].ToString()),
                    Label = _reader[1].ToString(),
                };

                return categorie;
                
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
        public List<Categorie> GetCategorieList()
        {
            List<Categorie> categorieList;
            Categorie categorie;
            try
            {
                _sql = $"SELECT [Id],[Label] FROM [dbo].[Categories]";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                categorieList = new List<Categorie>();
                while (_reader.Read())
                {
                    categorie = new Categorie
                    {
                        Id = int.Parse(_reader[0].ToString()),
                        Label = _reader[1].ToString()
                    };
                    categorieList.Add(categorie);
                }
                return categorieList;

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
