using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HW_17._01._18_LINQ_
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1 db = new Model1();

            ////1 - Вывести, является ли сотрудник главным боссом(использовать let)
            //var oneTask = from p in db.Employees
            //              let isBoss = (p.ReportsTo == null)
            //              select new
            //              {
            //                  firstName = p.FirstName,
            //                  isBoss
            //              };
            //foreach (var item in oneTask)
            //{
            //    WriteLine(item.firstName + " isBoss = " + item.isBoss);
            //}
            ////2 - Для сотрудников посчитать возраст трудоустройства и отсортировать по этому параметру
            //var twoTask = from employee in db.Employees.ToList()
            //              let ageOfHiring = (employee.HireDate - employee.BirthDate).Value.Days / 365
            //              orderby ageOfHiring
            //              select new
            //              {
            //                  firstName = employee.FirstName,
            //                  lastName = employee.LastName,
            //                  age = ageOfHiring
            //              };
            //foreach (var item in twoTask)
            //{
            //    WriteLine(item.firstName + " - возраст при найме на работу : " + item.age);
            //}
            ////3 - Из orderInfo вывести стоимость каждого полного Order в тенге
            //decimal usdToTenge = 325M;
            //var threeTask = from order in db.Order_Details.ToList()
            //                let orderPrice = (order.UnitPrice * order.Quantity) * usdToTenge
            //                select new
            //                {
            //                    orderId = order.OrderID,
            //                    totalCost = orderPrice
            //                };
            //foreach (var item in threeTask)
            //{
            //    WriteLine(item.orderId + " " + item.totalCost + " тг.");
            //}
            ////4 - Сгруппировать сотрудников по возрасту
            ////младшие - 18 до 40
            ////средние - 41 - 60
            ////старые - 61 - и более


            //5 - Сгруппировать заказы по месяцам
            //var fiveTask = from orders in db.Orders.ToList()
            //               let sortingByMonths = (orders.OrderDate).Value.Month / 12
            //               group orders by sortingByMonths < 5M;

            //foreach (var item in fiveTask)
            //{
            //    foreach (var innerItem in item)
            //    {
            //        WriteLine(innerItem.OrderID + " " + item.Key);
            //    }
            //}





            //7 - Сгруппировать заказы по компании-перевозчику
            var shippingCompany = db.Shippers.ToList();
            var orders = db.Orders.ToList();
            var joins = from shipper in shippingCompany 
                        join order in orders
                        on shipper.ShipperID equals order.ShipVia
                        group orders by order.ShipVia into g
                        select new
                        {
                            CompanyName = g.Key,
                            Count = g.Count(),
                            AllOrders = from p in g select p
                        };
            foreach (var group in joins)
            {
                WriteLine("{0} : {1}", group.CompanyName, group.Count);
                foreach (Order order in group.AllOrders)
                {
                    WriteLine(order.o);
                }

                WriteLine();
            }
            //foreach (var item in shippingCompany)
            //{
            //    WriteLine(item.CompanyName);
            //    foreach (var inneritem in joins.ToList())
            //    {
            //        WriteLine(inneritem.OrderID);
            //    }
            //}
            ReadLine();
        }
    }
}
