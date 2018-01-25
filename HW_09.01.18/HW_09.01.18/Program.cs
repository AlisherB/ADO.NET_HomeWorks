using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HW_09._01._18
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1 db = new Model1();
            var allEmployees = db.Employees.ToList();
            ////1. Вывести всех сотрудников, у которых возраст входит в [A,B]

            //Write("Введите минимальный возраст: ");
            //int beginAge = Convert.ToInt32(ReadLine());
            //Write("\nВведите максимальный возраст: ");
            //int endAge = Convert.ToInt32(ReadLine());
            //var dateNow = DateTime.Now;
            //var ageOfEmployees = allEmployees
            //        .Where(p => ((dateNow - p.BirthDate).Value.Days / 365) >= beginAge
            //                 && ((dateNow - p.BirthDate).Value.Days / 365) <= endAge)
            //        .Select(p => new {p.FirstName, age = (dateNow - p.BirthDate).Value.Days / 365 });
            //WriteLine();
            //foreach (var item in ageOfEmployees)
            //{
            //    WriteLine(item.FirstName + " - " + item.age);
            //}

            ////2. Вывести всех сотрудников по странам

            //var allCountries = allEmployees.Select(p => p.Country).Distinct();

            //foreach (var item in allCountries)
            //{
            //    WriteLine(item);
            //    var employees = allEmployees
            //                .Where(p => p.Country == item)
            //                .Select(p => new { p.FirstName, p.LastName });

            //    foreach (var innerItem in employees)
            //    {
            //        WriteLine(innerItem);
            //    }
            //}


            ////4. Для Orders вывести ShipperName

            //var allOrders = db.Orders.ToList();
            //var allShippers = db.Shippers.ToList();
            //var task4 = from order in allOrders
            //            join shipper in allShippers
            //            on order.ShipVia equals shipper.ShipperID
            //            select new
            //            {
            //                orderId = order.OrderID,
            //                shipperName = shipper.CompanyName
            //            };
            //foreach (var item in task4)
            //{
            //    WriteLine(item.orderId + " = " + item.shipperName);
            //}

            ////5. Отсортировать продукты по количеству на складе
            //var allProducts = db.Products.ToList();
            //var unitsInStock = allProducts
            //    .Select(p => p.UnitsInStock).Distinct().OrderBy(p => p.Value);
            //foreach (var item in unitsInStock)
            //{
            //    WriteLine(item);
            //    var quantityOfProducts = allProducts
            //                .Where(p => p.UnitsInStock == item)
            //                .Select(p => p.ProductName );

            //    foreach (var innerItem in quantityOfProducts)
            //    {
            //        WriteLine(innerItem);
            //    }
            //    WriteLine();
            //}
            ReadLine();
        }
    }
}
