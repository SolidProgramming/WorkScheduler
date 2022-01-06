
using Microsoft.Data.Sqlite;
using Shared.Classes;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkScheduler.Classes
{
    internal static class SQLiteController
    {
        internal static List<ShiftsModel> LoadEmployeesWithSchedules(int month)
        {
            List<ShiftsModel> shifts = new List<ShiftsModel>();

            using (var connection = new SqliteConnection("Data Source=workscheduler.db"))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"select id, firstname, surname FROM employees;";

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int employeeId = reader.GetInt32(0);
                        string firstname = reader.GetString(1);
                        string surname = reader.GetString(2);

                        List<ShiftModel> employeeshifts = GetShiftsFromEmployeeByMonth(employeeId, month);

                        if (employeeshifts.Count == 0)
                        {
                            continue;
                        }

                        ShiftsModel shift = new ShiftsModel()
                        {
                            Shifts = employeeshifts,

                            Employee = new EmployeeModel()
                            {
                                Id = employeeId,
                                FirstName = firstname,
                                Surname = surname
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

        private static List<ShiftModel> GetShiftsFromEmployeeByMonth(int employeeId, int month)
        {
            List<ShiftModel> shifts = new List<ShiftModel>();

            using (var connection = new SqliteConnection("Data Source=workscheduler.db"))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"select shifts.id, day, month, year, shifttypes.name as shiftname from shifts
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

                        ShiftModel shift = new ShiftModel()
                        {
                            Id = reader.GetInt32(0),
                            Date = date,
                            Name = reader.GetString(4),
                        };

                        shifts.Add(shift);
                    }
                }
            }
            return shifts;
        }
    }
}
