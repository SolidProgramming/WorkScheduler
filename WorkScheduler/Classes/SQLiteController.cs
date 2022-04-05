using Microsoft.Data.Sqlite;
using Shared.Classes;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Enums;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WorkScheduler.Classes
{
    internal static class SQLiteController
    {
        private const string DataSource = "Data Source = workscheduler.db";

        internal static List<ShiftsModel> LoadEmployeesWithSchedules(int month)
        {

            CheckDB();
            List<ShiftsModel> shifts = new List<ShiftsModel>();

            using (var connection = new SqliteConnection(DataSource))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"SELECT * FROM employees WHERE active = 1;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int employeeId = reader.GetInt32(0);
                        string firstname = reader.GetString(1);
                        string surname = reader.GetString(2);
                        string telephone = reader.GetString(4);
                        string mobile = reader.GetString(5);
                        string street = reader.GetString(6);
                        string region = reader.GetString(7);
                        bool active = Convert.ToBoolean(reader.GetInt32(9));

                        ShiftsModel shift = new ShiftsModel()
                        {
                            Shifts = GetShiftsFromEmployeeByMonth(employeeId, month),

                            Employee = new EmployeeModel()
                            {
                                Id = employeeId,
                                FirstName = firstname,
                                Surname = surname,
                                TelephoneNumber = telephone,
                                MobileNumber = mobile,
                                Street = street,
                                Region = region,
                                Active = active
                            }
                        };

                        shifts.Add(shift);
                    }
                }
            }

            return shifts;
        }

        internal static bool TryAddEmployee(EmployeeModel employee)
        {
            using (var connection = new SqliteConnection(DataSource))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Employees (firstname, surname, telephonenumber, mobilenumber, street, region, active)
                    VALUES (@firstname,@surname,@telephonenumber,@mobilenumber,@street,@region,@active);";

                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@surname", employee.Surname);
                command.Parameters.AddWithValue("@telephonenumber", employee.TelephoneNumber);
                command.Parameters.AddWithValue("@mobilenumber", employee.MobileNumber);
                command.Parameters.AddWithValue("@street", employee.Street);
                command.Parameters.AddWithValue("@region", employee.Region);
                command.Parameters.AddWithValue("@housenumber", employee.HouseNumber);
                command.Parameters.AddWithValue("@active", Convert.ToInt32(employee.Active));

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

        internal static bool TryUpdateEmployee(EmployeeModel employee)
        {
            using (var connection = new SqliteConnection(DataSource))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"UPDATE Employees SET firstname = @firstname, surname = @surname, telephonenumber = @telephonenumber,
                                        mobilenumber = @mobilenumber, street = @street, region = @region, active = @active 
                                        WHERE id = {employee.Id};";

                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@surname", employee.Surname);
                command.Parameters.AddWithValue("@telephonenumber", employee.TelephoneNumber);
                command.Parameters.AddWithValue("@mobilenumber", employee.MobileNumber);
                command.Parameters.AddWithValue("@street", employee.Street);
                command.Parameters.AddWithValue("@region", employee.Region);
                command.Parameters.AddWithValue("@housenumber", employee.HouseNumber);
                command.Parameters.AddWithValue("@active", Convert.ToInt32(employee.Active));

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

        internal static bool TryDeleteEmployee(int employeeId)
        {
            using (var connection = new SqliteConnection(DataSource))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"DELETE FROM employees WHERE id = { employeeId };";

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

        internal static bool TryAddEmployeeShift(int employeeId, ShiftModel shift)
        {
            using (var connection = new SqliteConnection(DataSource))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"INSERT INTO shifts (employee_id, shift_type, day, month, year)
                                        VALUES (@employee_id, @shift_type, @day, @month, @year);";

                command.Parameters.AddWithValue("@employee_id", employeeId);
                command.Parameters.AddWithValue("@shift_type", (int)shift.Type);
                command.Parameters.AddWithValue("@day", shift.Date.Day);
                command.Parameters.AddWithValue("@month", shift.Date.Month);
                command.Parameters.AddWithValue("@year", shift.Date.Year);

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

        internal static bool TryDeleteShift(int shiftId)
        {
            using (var connection = new SqliteConnection(DataSource))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"DELETE FROM shifts WHERE id = { shiftId };";

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

        private static void CheckDB()
        {
            if (!File.Exists("workscheduler.db"))
            {
                List<string> tableQuerys = new List<string>();

                tableQuerys.Add("CREATE TABLE \"employees\" (\"id\"	INTEGER NOT NULL UNIQUE,\"firstname\"	TEXT NOT NULL,\"surname\"	TEXT NOT NULL,\"birthdate\"	TEXT,\"telephonenumber\"	TEXT,\"mobilenumber\"	TEXT,\"street\"	TEXT,\"region\"	TEXT,\"housenumber\"	INTEGER,\"active\"	INTEGER NOT NULL,    PRIMARY KEY(\"id\" AUTOINCREMENT))");
                tableQuerys.Add("CREATE TABLE \"shifts\" (\"id\"	INTEGER NOT NULL UNIQUE,\"employee_id\"	INTEGER NOT NULL,\"shift_type\"	INTEGER NOT NULL,\"day\"	INTEGER NOT NULL,\"month\"	INTEGER NOT NULL,\"year\"	INTEGER NOT NULL,PRIMARY KEY(\"id\" AUTOINCREMENT))");
                tableQuerys.Add("CREATE TABLE \"shifttypes\" (\"id\"	INTEGER NOT NULL UNIQUE,\"name\"	TEXT NOT NULL,PRIMARY KEY(\"id\" AUTOINCREMENT))");
                tableQuerys.Add("INSERT INTO \"shifttypes\" (\"id\", \"name\") VALUES ('0', 'None') INSERT INTO \"shifttypes\" (\"id\", \"name\") VALUES ('1', 'Early') INSERT INTO \"shifttypes\" (\"id\", \"name\") VALUES ('2', 'Late') INSERT INTO \"shifttypes\" (\"id\", \"name\") VALUES ('3', 'Night') INSERT INTO \"shifttypes\" (\"id\", \"name\") VALUES ('4', 'Special') INSERT INTO \"shifttypes\" (\"id\", \"name\") VALUES ('5', 'Vacation');");

                using (var connection = new SqliteConnection(DataSource))
                {
                    connection.Open();

                    for (int i = 0; i < tableQuerys.Count; i++)
                    {
                        SqliteCommand command = connection.CreateCommand();
                        command.CommandText = tableQuerys[i];
                        command.ExecuteNonQuery();
                    }
                    
                }
            } 
        }

        private static List<ShiftModel> GetShiftsFromEmployeeByMonth(int employeeId, int month)
        {
            List<ShiftModel> shifts = new List<ShiftModel>();

            using (var connection = new SqliteConnection(DataSource))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"select shifts.id, day, month, year, shifttypes.name as shiftname, shifttypes.id as shiftTypeId from shifts
                                        INNER JOIN shifttypes ON shifts.shift_type = shifttypes.id
                                        WHERE employee_id = {employeeId} AND month = {month};";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dbDay = reader.GetInt32(1);
                        int dbMonth = reader.GetInt32(2);
                        int dbYear = reader.GetInt32(3);
                        DateTime date = new DateTime(dbYear, dbMonth, dbDay);
                        int shiftTypeId = reader.GetInt32(5);

                        ShiftModel shift = new ShiftModel()
                        {
                            Id = reader.GetInt32(0),
                            Date = date,
                            Name = reader.GetString(4),
                            Type = (ShiftType)shiftTypeId
                        };

                        shifts.Add(shift);
                    }
                }
            }
            return shifts;
        }
    }
}
