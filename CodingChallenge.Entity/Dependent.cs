using System;
using System.Collections.Generic;
using System.Text;

namespace SunIT.Entity
{
   public class Dependent
    {
        public  int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DependentType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
