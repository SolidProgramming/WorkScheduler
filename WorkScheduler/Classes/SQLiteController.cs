
using Microsoft.Data.Sqlite;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkScheduler.Classes
{
    internal static class SQLiteController
    {
        internal static List<EmployeeModel> LoadEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            using (var connection = new SqliteConnection("Data Source=workscheduler.db"))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM employees;";


                using (var reader = command.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string firstname = reader.GetString(1);
                        string surname = reader.GetString(2);                       
                        string birthdate = reader.GetString(3);
                        string telephone = reader.GetString(4);
                        string mobile = reader.GetString(5);
                        string street = reader.GetString(6);
                        string region = reader.GetString(7);
                        int housenumber = reader.GetInt32(8);
                        bool isActive = reader.GetBoolean(9);

                        EmployeeModel employee = new EmployeeModel()
                        {
                            Id = id,
                            FirstName = firstname,
                            Surname = surname,                           
                            Birthdate = birthdate,
                            TelephoneNumber = telephone,
                            MobileNumber = mobile,
                            Street = street,
                            Region = region,
                            HouseNumber = housenumber,
                            Active = isActive
                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        internal static bool TryAddEmployee(EmployeeModel employee)
        {
            using (var connection = new SqliteConnection("Data Source=workscheduler.db"))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Employees (firstname, surname, birthdate, telephonenumber, mobilenumber, street, region, housenumber, active)
                    VALUES (@firstname,@surname,@birthdate,@telephonenumber,@mobilenumber,@street,@region,@housenumber,@active);";

                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@surname", employee.Surname);              
                command.Parameters.AddWithValue("@birthdate", employee.Birthdate);
                command.Parameters.AddWithValue("@telephonenumber", employee.TelephoneNumber);
                command.Parameters.AddWithValue("@mobilenumber", employee.MobileNumber);
                command.Parameters.AddWithValue("@street", employee.Street);
                command.Parameters.AddWithValue("@region", employee.Region);
                command.Parameters.AddWithValue("@housenumber", employee.HouseNumber);
                command.Parameters.AddWithValue("@active", employee.Active);

                try
                {
                    command.ExecuteNonQuery();                   
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
