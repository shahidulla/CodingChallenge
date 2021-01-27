using System;
using System.Linq;
using CodingChallenge.Business;
using CodingChallenge.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SunIT.Entity;

namespace CodingChallenge.Web.Controllers
{
    public class EmployeeController : Controller
    {

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

                        var empService = new EmployeeService();
                        empService.SaveEmployeeInfo(employee);

                        TempData["success_msg"] = "Employee has been saved!";
                        return RedirectToAction(nameof(Create));
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
