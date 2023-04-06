using DataAdoProject.CRUD;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdoProject.CRUD
{
    public partial class DataContext
    {
        public void AddEmployee(Employee employee)
        {
            try
            {
                _sql = $"INSERT INTO [dbo].[Employees]([Id],[Nom],[Salaire],[Recrutement])" +
                    $" VALUES ({employee.Id},'{employee.Nom}',{employee.Salaire},'{employee.Recrutement}')";
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

        public void UpdateEmployee(int id,Employee employee)
        {
            try
            {
                _sql = $"UPDATE [dbo].[Employees] SET " +
                    $"[Nom] = '{employee.Nom}' ,[Salaire] ={employee.Salaire} " +
                    $",[Recrutement] = '{employee.Recrutement}' WHERE Id={id}";

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

        public void DeleteEmployee(int id)
        {
            try
            {
                _sql = $"DELETE FROM [dbo].[Employees] WHERE Id ={id}";

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

        public Employee GetEmployee(int id)
        {
            Employee Employee;
            try
            {
                _sql = $"SELECT [Id],[Nom],[Salaire],[Recrutement] FROM [dbo].[Employees] WHERE Id = {id}";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                _reader.Read();

                Employee = new Employee
                {
                    Id = int.Parse(_reader[0].ToString()),
                    Nom = _reader[1].ToString(),
                    Salaire = decimal.Parse(_reader[2].ToString()),
                    Recrutement = DateTime.Parse(_reader[3].ToString()) 
                };

                return Employee;

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
        public List<Employee> GetEmployeeList()
        {
            List<Employee> EmployeeList;
            Employee Employee;
            try
            {
                _sql = $"SELECT [Id],[Nom],[Salaire],[Recrutement] FROM [dbo].[Employees]";
                _command = new SqlCommand(_sql, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                EmployeeList = new List<Employee>();
                while (_reader.Read())
                {
                    Employee = new Employee
                    {
                        Id = int.Parse(_reader[0].ToString()),
                        Nom = _reader[1].ToString(),
                        Salaire = decimal.Parse(_reader[2].ToString()),
                        Recrutement = DateTime.Parse(_reader[3].ToString())
                    };
                    EmployeeList.Add(Employee);
                }
                return EmployeeList;

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
