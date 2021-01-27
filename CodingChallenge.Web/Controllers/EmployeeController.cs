using System;
using System.Linq;
using CodingChallenge.Business;
using CodingChallenge.Business.Interfaces;
using CodingChallenge.Entity;
using CodingChallenge.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingChallenge.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CreatedDate = DateTime.UtcNow
                    };

                    for (int i = 0; i < model.DependentFirstName.Count(); i++)
                    {
                        employee.Dependents.Add(new Dependent()
                        {
                            FirstName = model.DependentFirstName[i],
                            LastName = model.DependentLastName[i],
                            DependentType = model.DependentType[i],
                            CreatedDate = DateTime.UtcNow
                        });
                    }

                    var response = _employeeService.SaveEmployeeInfo(employee);
                    if (response)
                    {
                        return RedirectToAction(nameof(Create));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Failed to save employee info");
            }

            return null;
        }


    }
}
