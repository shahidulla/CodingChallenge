using System;
using CodingChallenge.Business.Interfaces;
using CodingChallenge.Data;
using CodingChallenge.Data.Interfaces;
using CodingChallenge.Entity;

namespace CodingChallenge.Business
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool SaveEmployeeInfo(Employee employee)
        {
            try
            {
                return _employeeRepository.SaveEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
