using System;
using System.Collections.Generic;

#nullable disable

namespace API_Eg.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Did { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
