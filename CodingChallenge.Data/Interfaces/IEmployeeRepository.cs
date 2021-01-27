using System;
using System.Collections.Generic;
using System.Text;
using CodingChallenge.Entity;

namespace CodingChallenge.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        bool SaveEmployee(Employee employee);
    }
}
