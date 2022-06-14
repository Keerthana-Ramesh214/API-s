using System;
using System.Collections.Generic;

#nullable disable

namespace API_Eg.Models
{
    public partial class Employee
    {
        public int Eid { get; set; }
        public string Empname { get; set; }
        public double? Salary { get; set; }
        public DateTime? Doj { get; set; }
        public string City { get; set; }
        public int? Deptid { get; set; }

        public virtual Department Dept { get; set; }
    }
}
