using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
//using EmployeeClient.Models; // Раскомментируйте эту директиву
//using EmployeeClient;
using EmployeeClient.Models; // Добавьте эту директиву


//namespace EmployeeClient.Repositories
namespace EmployeeClient

{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Создание таблицы persons
        public void CreateTable()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='persons' AND xtype='U')
                    CREATE TABLE [dbo].[persons] (
                        [id]           INT           IDENTITY (1, 1) NOT NULL,
                        [first_name]   VARCHAR (100) NOT NULL,
                        [second_name]  VARCHAR (100) NOT NULL,
                        [last_name]    VARCHAR (100) NOT NULL,
                        [date_employ]  DATETIME      NULL,
                        [date_uneploy] DATETIME      NULL,
                        [status]       INT           NOT NULL,
                        [id_dep]       INT           NOT NULL,
                        [id_post]      INT           NOT NULL,
                        CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED ([id] ASC)
                    );";

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Очистка таблицы и сброс идентификатора
        public void ClearTable()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = @"
                    DELETE FROM dbo.persons;
                    DBCC CHECKIDENT ('[persons]', RESEED, 0);";

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Вставка данных с проверкой на дубликаты
        public int InsertData(List<Employee> employees)
        {
            int affectedRows = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var employee in employees)
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"
                            IF NOT EXISTS (
                                SELECT 1 FROM dbo.persons 
                                WHERE first_name = @firstName 
                                AND second_name = @secondName 
                                AND last_name = @lastName
                            )
                            INSERT INTO dbo.persons 
                                (first_name, second_name, last_name, date_employ, date_uneploy, status, id_dep, id_post)
                            VALUES 
                                (@firstName, @secondName, @lastName, @dateEmploy, @dateUneploy, @status, @idDep, @idPost)";

                        command.Parameters.AddWithValue("@firstName", employee.FirstName);
                        command.Parameters.AddWithValue("@secondName", employee.SecondName);
                        command.Parameters.AddWithValue("@lastName", employee.LastName);
                        command.Parameters.AddWithValue("@dateEmploy", employee.DateEmploy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@dateUneploy", employee.DateUnemploy ?? (object)DBNull.Value); // Исправлено на DateUnemploy
                        command.Parameters.AddWithValue("@status", employee.StatusId); // Исправлено на StatusId
                        command.Parameters.AddWithValue("@idDep", employee.DepartmentId); // Исправлено на DepartmentId
                        command.Parameters.AddWithValue("@idPost", employee.PostId); // Исправлено на PostId

                        affectedRows += command.ExecuteNonQuery();
                    }
                }
            }

            return affectedRows;
        }

        // Получение всех сотрудников
        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM dbo.persons ORDER BY last_name, first_name", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            SecondName = reader.GetString(2),
                            LastName = reader.GetString(3),
                            DateEmploy = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                            DateUnemploy = reader.IsDBNull(5) ? null : reader.GetDateTime(5), // Исправлено на DateUnemploy
                            StatusId = reader.GetInt32(6), // Исправлено на StatusId
                            DepartmentId = reader.GetInt32(7), // Исправлено на DepartmentId
                            PostId = reader.GetInt32(8) // Исправлено на PostId
                        });
                    }
                }
            }

            return employees;
        }

        // Создание и заполнение тестовыми данными
        public void InitializeWithSampleData()
        {
            CreateTable();

            var sampleEmployees = new List<Employee>
            {
                new Employee {
                    FirstName = "Александр",
                    SecondName = "Михайлович",
                    LastName = "Иванов",
                    DateEmploy = new DateTime(2019, 5, 10),
                    StatusId = 1, // Исправлено на StatusId
                    DepartmentId = 1, // Исправлено на DepartmentId
                    PostId = 1 // Исправлено на PostId
                },
                new Employee {
                    FirstName = "Екатерина",
                    SecondName = "Сергеевна",
                    LastName = "Петрова",
                    DateEmploy = new DateTime(2020, 2, 15),
                    DateUnemploy = new DateTime(2023, 8, 20), // Исправлено на DateUnemploy
                    StatusId = 2, // Исправлено на StatusId
                    DepartmentId = 2, // Исправлено на DepartmentId
                    PostId = 3 // Исправлено на PostId
                },
                new Employee {
                    FirstName = "Максим",
                    SecondName = "Андреевич",
                    LastName = "Сидоров",
                    DateEmploy = new DateTime(2021, 8, 12),
                    StatusId = 1, // Исправлено на StatusId
                    DepartmentId = 3, // Исправлено на DepartmentId
                    PostId = 4 // Исправлено на PostId
                },
                new Employee {
                    FirstName = "Ольга",
                    SecondName = "Викторовна",
                    LastName = "Смирнова",
                    DateEmploy = new DateTime(2018, 11, 20),
                    StatusId = 3, // Исправлено на StatusId
                    DepartmentId = 4, // Исправлено на DepartmentId
                    PostId = 5 // Исправлено на PostId
                },
                new Employee {
                    FirstName = "Денис",
                    SecondName = "Олегович",
                    LastName = "Кузнецов",
                    DateEmploy = new DateTime(2022, 1, 30),
                    StatusId = 1, // Исправлено на StatusId
                    DepartmentId = 5, // Исправлено на DepartmentId
                    PostId = 6 // Исправлено на PostId
                }
            };

            int inserted = InsertData(sampleEmployees);
            Console.WriteLine($"Вставлено {inserted} записей");
        }
    }
}
