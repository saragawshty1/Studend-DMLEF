using P01_StudentSystem.Data;
using P01_StudentSystem.Models;



namespace P01_StudentSystem

{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();
            Console.WriteLine("The Students Info");
            var students = context.Students.ToList();
            foreach (var item in students)
            {
                Console.WriteLine($"StudentId:{item.StudentId},Name:{item.Name},PhoneNumber:{item.PhoneNumber},RegisteredOn:{item.RegisteredOn}");
            }
            Console.WriteLine("The Courses Info");
            var Courses = context.Courses.ToList();
            foreach (var item in Courses)
            {
                Console.WriteLine($"CourseId:{item.CourseId},Name:{item.Name},Description:{item.Description},StartDate:{item.StartDate},endDate:{item.endDate},price:{item.price}");
            }
        }
    }
}
