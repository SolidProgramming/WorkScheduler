
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
        internal static List<ShiftModel> LoadEmployeesWithSchedules(int month)
        {
            List<ShiftModel> shifts = new List<ShiftModel>();            

            using (var connection = new SqliteConnection("Data Source=workscheduler.db"))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"select employees.id as employeeId, shifts.id as shiftId ,firstname, surname, shifttypes.name as shiftname, day, month, year FROM employees
                                        inner join shifts on shifts.employee_id = employees.id
                                        inner join shifttypes on shifts.shift_type = shifttypes.id
                                        WHERE shifts.month = {month};";

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int employeeId = reader.GetInt32(0);
                        int shiftId = reader.GetInt32(1);
                        string firstname = reader.GetString(2);
                        string surname = reader.GetString(3);                        
                        string shiftName = reader.GetString(4);
                        string shiftDay = reader.GetString(5);
                        string shiftMonth = reader.GetString(6);
                        string shiftYear = reader.GetString(7);

                        ShiftModel shift = new ShiftModel()
                        {
                            Id = shiftId,
                            Date = DateTime.Parse($"{shiftDay}.{shiftMonth}.{shiftYear}"),
                            Name = shiftName,

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
    }
}
