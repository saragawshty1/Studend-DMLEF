using DMLScaff.Data;
using DMLScaff.Models;

using Microsoft.EntityFrameworkCore;
namespace DMLScaff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context=new  ApplicationDbContext();
            Console.WriteLine("-----ListCategoris-----");
            var Category=context.Categories.ToList();
            foreach(var item in Category)
            {
                Console.WriteLine($"CategoryId:{item.CategoryId},Name={item.CategoryName}");
            }

            Console.WriteLine("-----FirstProduct-----");
            var first=context.Products.FirstOrDefault();
            Console.WriteLine($"productId:{first.ProductId},Name={first.ProductName}");


            Console.WriteLine("-----FindProduct-----");
            var find = context.Products.Find(2);
            Console.WriteLine($"productId:{find.ProductId},Name={find.ProductName}");


            Console.WriteLine("-----year-----");
            var year = context.Products.Where(p=>p.ModelYear==2016);
            foreach (var item in year)
            {
                Console.WriteLine($"productId:{item.ProductId},year={item.ModelYear}");
            }
             

             Console.WriteLine("-----FindCustomer-----");
            var find2 = context.Customers.Find(3);
            Console.WriteLine($"CustomertId:{find2.CustomerId},Name={find2.FirstName}");

           Console.WriteLine("-----Names-----");
            var names = context.Products.Include(p=>p.Brand).ToList();
            foreach (var item in names)
            {
                Console.WriteLine($"productName:{item.ProductName},BrandName={item.Brand.BrandName}");
            }

            Console.WriteLine("-----count-----");
            var numofproducts = context.Products.Where(p=>p.CategoryId== 2).Count();
            
                Console.WriteLine(numofproducts);

            Console.WriteLine("-----total-----");
            var total = context.Products.Where(p => p.CategoryId == 2).Sum(p=>p.ListPrice);

            Console.WriteLine(total);

            Console.WriteLine("-----avg-----");
            var avg = context.Products.Average(p=>p.ListPrice);

            Console.WriteLine(avg);

            Console.WriteLine("-----complete-----");
            var complete = context.Orders.Where(o=>o.OrderStatus==4);
            foreach (var item in complete)
            {
                Console.WriteLine($"OrderId:{item.OrderId},OrderStatus={item.OrderStatus}");
            }



        }
    }
}
