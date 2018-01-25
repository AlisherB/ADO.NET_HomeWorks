using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_18._01._18
{
    [Table(Name = "Customers")]
    public class Customer
    {
        [Column(Name = "CustomerId", IsPrimaryKey = true, DbType = "nchar(5)", CanBeNull = false)]
        public string CustomerId { get; set; }

        [Column(Name = "CompanyName", DbType = "nvarchar(40)", CanBeNull = false)]
        public string CompanyName { get; set; }

        [Column(Name = "ContactName", DbType = "nvarchar(30)", CanBeNull = true)]
        public string ContactName { get; set; }

        [Column(Name = "ContactTitle", DbType = "nvarchar(30)", CanBeNull = true)]
        public string ContactTitle { get; set; }

        [Column(Name = "Address", DbType = "nvarchar(60)", CanBeNull = true)]
        public string Address { get; set; }

        [Column(Name = "City", DbType = "nvarchar(15)", CanBeNull = true)]
        public string City { get; set; }

        [Column(Name = "Region", DbType = "nvarchar(15)", CanBeNull = true)]
        public string Region { get; set; }

        [Column(Name = "PostalCode", DbType = "nvarchar(10)", CanBeNull = true)]
        public string PostalCode { get; set; }

        [Column(Name = "Country", DbType = "nvarchar(15)", CanBeNull = true)]
        public string Country { get; set; }

        [Column(Name = "Phone", DbType = "nvarchar(24)", CanBeNull = true)]
        public string Phone { get; set; }

        [Column(Name = "Fax", DbType = "nvarchar(24)", CanBeNull = true)]
        public string Fax { get; set; }

        public override string ToString()
        {
            return $"{CustomerId} - {CompanyName} - {ContactName} - {ContactTitle} - {Address} - {City} - {Region} - {PostalCode} - {Country} - {Phone} - {Fax}";
        }
    }
}
