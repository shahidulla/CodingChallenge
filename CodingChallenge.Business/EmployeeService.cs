using System;
using CodingChallenge.Business.Interfaces;
using CodingChallenge.Data;
using SunIT.Entity;

namespace CodingChallenge.Business
{
    public class EmployeeService: IEmployeeService
    {
        public bool SaveEmployeeInfo(Employee employee)
        {
            var empRepository = new EmployeeRepository();
            try
            {
                return empRepository.SaveEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
