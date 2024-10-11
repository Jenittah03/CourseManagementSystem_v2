using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CourseManagementSystem_v2
{
    public class CourseRepository
    {
        public string dbconnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=CourseManagement; Trusted_Connection=true; TrustServerCertificate=true";

        public void CreateCourse(string courseId, string title, string duration, decimal price)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbconnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO Courses(CourseId,Title,Duration,price) VALUES(@CourseId,@Title,@Duration,@price);";
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Duration", duration);
                    command.Parameters.AddWithValue("@price", price);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Course created successfully");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        public void ViewAllCourse()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbconnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM Courses;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Courseid: {reader.GetString(0)} Title:{reader.GetString(1)} Duration:{reader.GetString(2)} price:{reader.GetDecimal(3)}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void ViewCourseById( string CourseId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbconnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT CourseId,Title,Duration,price FROM Courses WHERE CourseId=@CourseId ;";
                    command.Parameters.AddWithValue("@CourseId", CourseId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Courseid: {reader.GetString(0)} Title:{reader.GetString(1)} Duration:{reader.GetString(2)} price:{reader.GetDecimal(3)}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void UpdateCourse(string courseId, string title, string duration, decimal price)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbconnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"UPDATE Courses SET CourseId=@CourseId,Title=@Title,Duration=@Duration,price=@price;";
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Duration", duration);
                    command.Parameters.AddWithValue("@price", price);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Course UPDATED successfully");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteCourse(string courseId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbconnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"DELETE FROM Courses WHERE CourseId=@CourseId ;";
                    command.Parameters.AddWithValue("@CourseId", courseId);
                  

                    command.ExecuteNonQuery();

                    Console.WriteLine("Course deleted successfully");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

       public string Capitalizetitle(string title)
        {
            string[] words = title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0])+ words[i].Substring(1).ToLower();
            }
            return string.Join(" ", words);
        }


    }
}
