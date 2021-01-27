using System;
using System.Collections.Generic;
using System.Text;
using CodingChallenge.Entity;

namespace CodingChallenge.Business.Interfaces
{
   public interface IEmployeeService
   {
       bool SaveEmployeeInfo(Employee employee);
   }
}
