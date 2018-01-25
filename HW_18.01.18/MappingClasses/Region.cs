using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_18._01._18
{
    [Table(Name = "Region")]
    public class Region
    {
        [Column(Name = "RegionId", IsPrimaryKey = true, DbType = "int", CanBeNull = false)]
        public int RegionId { get; set; }

        [Column(Name = "RegionDescription", DbType = "nchar(50)", CanBeNull = false)]
        public string RegionDescription { get; set; }

        public override string ToString()
        {
            return $"{RegionId} - {RegionDescription}";
        }
    }
}
