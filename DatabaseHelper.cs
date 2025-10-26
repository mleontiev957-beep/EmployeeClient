using EmployeeClient.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace EmployeeClient
{
    public class DatabaseHelper
    {
        // Правильная строка подключения для MDF файла
          private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=C:\USERS\МИХАИЛ\DESKTOP\EMPLOYEECLIENT\EMPLOYEECLIENT\EMPLOYEECLIENT\TESTBD.MDF;Trusted_Connection=True;";
        //  private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=TestBD;Trusted_Connection=True;";
      //  private static string connectionString = @"Server=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TESTBD.MDF;Trusted_Connection=True;";
        public DatabaseHelper()
        {
            // Пытаемся получить строку подключения из конфигурации
         //   try
          //  {
            //    var configConnectionString = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"]?.ConnectionString;
             //   if (!string.IsNullOrEmpty(configConnectionString))
              //  {
              //      connectionString = configConnectionString;
              //  }
           // }
          //  catch
         //   {
                // В случае ошибки используем статическую строку
         //  }
        }

        // Метод для изменения строки подключения во время выполнения
        public static void SetConnectionString(string newConnectionString)
        {
            if (!string.IsNullOrEmpty(newConnectionString))
            {
                connectionString = newConnectionString;
          }
        }

        // Метод для получения текущей строки подключения
        public static string GetConnectionString()
        {
            return connectionString;
        }

        // Метод для проверки подключения к базе данных
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
                return false;
            }
        }

        // Метод GetPersons для получения всех сотрудников
        public DataTable GetPersons()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetPersons", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Если процедура не существует, используем прямой запрос
                return ExecuteQuery("SELECT * FROM dbo.persons ORDER BY last_name, first_name");
            }
        }

        // Метод для получения статистики
        public DataTable GetStatistics(int statusId, DateTime startDate, DateTime endDate, string statType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetStatisticsByStatus", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@statusId", statusId);
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        cmd.Parameters.AddWithValue("@statType", statType);

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Если процедура не существует, используем прямой запрос
                return GetStatisticsDirectQuery(statusId, startDate, endDate, statType);
            }
        }

        // Резервный метод для статистики (если процедура не существует)
        private DataTable GetStatisticsDirectQuery(int statusId, DateTime startDate, DateTime endDate, string statType)
        {
            try
            {
                string query = "";

                if (statType.ToLower() == "employ")
                {
                    query = $@"
                        SELECT 
                            s.name AS StatusName,
                            d.name AS DepartmentName,
                            p.name AS PositionName,
                            CAST(pers.date_employ AS DATE) AS EventDate,
                            COUNT(*) AS EmployeeCount
                        FROM persons pers
                        INNER JOIN status s ON pers.status = s.id
                        INNER JOIN deps d ON pers.id_dep = d.id
                        INNER JOIN posts p ON pers.id_post = p.id
                        WHERE pers.status = {statusId} 
                            AND pers.date_employ BETWEEN '{startDate:yyyy-MM-dd}' AND '{endDate:yyyy-MM-dd}'
                        GROUP BY s.name, d.name, p.name, CAST(pers.date_employ AS DATE)
                        ORDER BY StatusName, EventDate, DepartmentName";
                }
                else if (statType.ToLower() == "uneploy")
                {
                    query = $@"
                        SELECT 
                            s.name AS StatusName,
                            d.name AS DepartmentName,
                            p.name AS PositionName,
                            CAST(pers.date_uneploy AS DATE) AS EventDate,
                            COUNT(*) AS EmployeeCount
                        FROM persons pers
                        INNER JOIN status s ON pers.status = s.id
                        INNER JOIN deps d ON pers.id_dep = d.id
                        INNER JOIN posts p ON pers.id_post = p.id
                        WHERE pers.status = {statusId} 
                            AND pers.date_uneploy BETWEEN '{startDate:yyyy-MM-dd}' AND '{endDate:yyyy-MM-dd}'
                        GROUP BY s.name, d.name, p.name, CAST(pers.date_uneploy AS DATE)
                        ORDER BY StatusName, EventDate, DepartmentName";
                }
                else
                {
                    throw new ArgumentException("Неверный тип статистики. Используйте 'employ' или 'uneploy'.");
                }

                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении статистики: {ex.Message}");
            }
        }

        public DataTable GetEmployees(int? statusFilter, int? depFilter, int? postFilter,
                            string lastNameFilter, string sortField, string sortOrder)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetEmployees", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Правильные имена параметров согласно созданной процедуре
                        cmd.Parameters.AddWithValue("@StatusId", statusFilter ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DepartmentId", depFilter ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PositionId", postFilter ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@LastNameFilter", string.IsNullOrEmpty(lastNameFilter) ? (object)DBNull.Value : lastNameFilter);
                        cmd.Parameters.AddWithValue("@SortField", sortField);
                        cmd.Parameters.AddWithValue("@SortOrder", sortOrder);

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Если процедура не работает, используем прямой запрос
                return GetEmployeesDirectQuery(statusFilter, depFilter, postFilter, lastNameFilter, sortField, sortOrder);
            }
        }

        private DataTable GetEmployeesDirectQuery(int? statusFilter, int? depFilter, int? postFilter,
                                        string lastNameFilter, string sortField, string sortOrder)
        {
            try
            {
                string query = @"
            SELECT 
                p.id,
                p.first_name,
                p.second_name,
                p.last_name,
                p.last_name + ' ' + LEFT(p.first_name, 1) + '. ' + LEFT(p.second_name, 1) + '.' as FullName,
                s.name as StatusName,
                d.name as DepartmentName,
                po.name as PositionName,
                p.date_employ,
                p.date_uneploy,
                p.status as StatusId,
                p.id_dep as DepartmentId,
                p.id_post as PositionId
            FROM persons p
            INNER JOIN status s ON p.status = s.id
            INNER JOIN deps d ON p.id_dep = d.id
            INNER JOIN posts po ON p.id_post = po.id
            WHERE 1=1";

                // Добавляем условия фильтрации
                if (statusFilter.HasValue)
                    query += $" AND p.status = {statusFilter.Value}";

                if (depFilter.HasValue)
                    query += $" AND p.id_dep = {depFilter.Value}";

                if (postFilter.HasValue)
                    query += $" AND p.id_post = {postFilter.Value}";

                if (!string.IsNullOrEmpty(lastNameFilter))
                    query += $" AND p.last_name LIKE '%{lastNameFilter}%'";

                // Добавляем сортировку
                query += $" ORDER BY {sortField} {sortOrder}";

                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при выполнении прямого запроса: {ex.Message}");
            }
        }

        public DataTable GetStatuses()
        {
            return ExecuteStoredProcedure("GetStatuses");
        }

        public DataTable GetDepartments()
        {
            return ExecuteStoredProcedure("GetAllDepartments");
        }

        public DataTable GetPosts()
        {
            return ExecuteStoredProcedure("GetPositions");
        }

        // Метод для получения всех сотрудников (альтернативное название)
        public DataTable GetAllEmployees()
        {
            return GetPersons(); // Используем тот же метод
        }

        public int InsertEmployee(string firstName, string secondName, string lastName,
                                 DateTime? dateEmploy, DateTime? dateUnemploy, int status, int idDep, int idPost)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"
                        INSERT INTO dbo.persons 
                            (first_name, second_name, last_name, date_employ, date_uneploy, status, id_dep, id_post)
                        VALUES 
                            (@firstName, @secondName, @lastName, @dateEmploy, @dateUnemploy, @status, @idDep, @idPost);
                        SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@secondName", secondName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@dateEmploy", dateEmploy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@dateUnemploy", dateUnemploy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@idDep", idDep);
                    cmd.Parameters.AddWithValue("@idPost", idPost);

                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении сотрудника: {ex.Message}");
            }
        }

        public bool EmployeeExists(string firstName, string secondName, string lastName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM dbo.persons WHERE first_name = @firstName AND second_name = @secondName AND last_name = @lastName";

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@secondName", secondName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);

                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при проверке сотрудника: {ex.Message}");
            }
        }

        private DataTable ExecuteStoredProcedure(string procedureName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при выполнении процедуры {procedureName}: {ex.Message}");
            }
        }

        private DataTable ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при выполнении запроса: {ex.Message}\nQuery: {query}");
            }
        }

        // Метод для проверки существования хранимых процедур
        public bool CheckStoredProcedures()
        {
            try
            {
                string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM INFORMATION_SCHEMA.ROUTINES 
                    WHERE ROUTINE_TYPE = 'PROCEDURE' 
                    AND ROUTINE_NAME IN ('GetEmployees', 'GetStatuses', 'GetAllDepartments', 'GetPositions', 'GetPersons', 'GetStatisticsByStatus')";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count >= 5; // Минимум 5 основных процедур
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetEmployeesList()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                    SELECT 
                        p.id,
                        p.first_name,
                        p.second_name,
                        p.last_name,
                        p.date_employ,
                        p.date_uneploy,
                        p.status,
                        p.id_dep,
                        p.id_post,
                        s.name as status_name,
                        d.name as department_name,
                        po.name as post_name
                    FROM persons p
                    INNER JOIN status s ON p.status = s.id
                    INNER JOIN deps d ON p.id_dep = d.id
                    INNER JOIN posts po ON p.id_post = po.id", connection);
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                            SecondName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            LastName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            DateEmploy = reader.IsDBNull(4) ? null : (DateTime?)reader.GetDateTime(4),
                            DateUnemploy = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5),
                            StatusId = reader.GetInt32(6),
                            DepartmentId = reader.GetInt32(7),
                            PostId = reader.GetInt32(8),
                            StatusName = reader.IsDBNull(9) ? null : reader.GetString(9),
                            DepartmentName = reader.IsDBNull(10) ? null : reader.GetString(10),
                            PostName = reader.IsDBNull(11) ? null : reader.GetString(11)
                        });
                    }
                }
            }

            return employees;
        }
    }
}