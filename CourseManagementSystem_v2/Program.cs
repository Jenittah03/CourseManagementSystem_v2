using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var repo = new CourseRepository();


            while (!exit)
            {
                Console.WriteLine("Course Management system:");
                Console.WriteLine("1.Add a new Course");
                Console.WriteLine("2.View all Courses");
                Console.WriteLine("3.Edit an existing Course.");
                Console.WriteLine("4.Remove a Course.");
                Console.WriteLine("5.Exkit");
                Console.Write("Choose an option:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        Console.Clear();
                        Console.WriteLine("Enter the CourseId");
                        string courseid = Console.ReadLine();
                        Console.WriteLine("Enter the Course Title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the course Duration");
                        string duration = Console.ReadLine();
                        Console.WriteLine("Enter the price");
                        decimal price = decimal.Parse(Console.ReadLine());

                        repo.CreateCourse(courseid, title, duration, price);

                        break;

                    case 2:

                        Console.Clear();
                        repo.ViewAllCourse();
                        break;

                    case 3:
                        Console.Clear();

                        Console.WriteLine("Enter the CourseId");
                        string newcourseid = Console.ReadLine();
                        Console.WriteLine("Enter the Course Title");
                        string newtitle = Console.ReadLine();
                        Console.WriteLine("Enter the course Duration");
                        string newduration = Console.ReadLine();
                        Console.WriteLine("Enter the price");
                        decimal newprice = decimal.Parse(Console.ReadLine());



                        repo.UpdateCourse(newcourseid, newtitle, newduration, newprice);

                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter the Course Id to delete");
                        string deleteid = Console.ReadLine();

                        repo.DeleteCourse(deleteid);
                        break;

                    case 5:
                        Console.Clear();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option; please try again");
                        break;
                }
            }


        }
    }
}