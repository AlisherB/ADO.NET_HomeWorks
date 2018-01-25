using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_18._01._18
{
    [Table(Name = "Employees")]
    public class Employee
    {
        [Column(Name = "EmployeeId", IsPrimaryKey = true, DbType = "int", CanBeNull = false)]
        public int EmployeeId { get; set; }

        [Column(Name = "LastName", DbType = "nvarchar(20)", CanBeNull = false)]
        public string LastName { get; set; }

        [Column(Name = "FirstName", DbType = "nvarchar(10)", CanBeNull = false)]
        public string FirstName { get; set; }

        [Column(Name = "Title", DbType = "nvarchar(30)", CanBeNull = true)]
        public string Title { get; set; }

        [Column(Name = "TitleOfCourtesy", DbType = "nvarchar(25)", CanBeNull = true)]
        public string TitleOfCourtesy { get; set; }

        [Column(Name = "BirthDate", DbType = "datetime", CanBeNull = true)]
        public DateTime ? BirthDate { get; set; }

        [Column(Name = "HireDate", DbType = "datetime", CanBeNull = true)]
        public DateTime ? HireDate { get; set; }

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

        [Column(Name = "HomePhone", DbType = "nvarchar(24)", CanBeNull = true)]
        public string HomePhone { get; set; }

        [Column(Name = "Extension", DbType = "nvarchar(4)", CanBeNull = true)]
        public string Extension { get; set; }

        [Column(Name = "Photo", DbType = "varbinary(max)", CanBeNull = true)]
        public Image Photo { get; set; }

        [Column(Name = "Notes", DbType = "ntext", CanBeNull = true)]
        public string Notes { get; set; }

        [Column(Name = "ReportsTo", DbType = "int", CanBeNull = true)]
        public int ? ReportsTo { get; set; }

        [Column(Name = "PhotoPath", DbType = "nvarchar(255)", CanBeNull = true)]
        public string PhotoPath { get; set; }



        public override string ToString()
        {
            return $"{EmployeeId} - {LastName} - {FirstName} - {Title} - {TitleOfCourtesy} - {BirthDate} - {HireDate} - {Address} - {City} - {Region} - {PostalCode} - {Country} - {HomePhone} - {Extension} - {Photo} - {Notes} - {ReportsTo} - {PhotoPath}";
        }
    }
}
