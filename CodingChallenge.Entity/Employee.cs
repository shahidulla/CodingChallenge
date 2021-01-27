using System;
using System.Collections.Generic;

namespace CodingChallenge.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Dependent> Dependents { get; set; }

        public Employee()
        {
            Dependents=new List<Dependent>();
        }
    }
}
