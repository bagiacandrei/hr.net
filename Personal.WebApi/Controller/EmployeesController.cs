using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi.Controller
{
    public class EmployeesController : ApiController
    {
         private readonly IHrContext context;

        public EmployeesController(IHrContext ctx)
        {
            context = ctx;
        }
        // GET: api/Employees
        public IHttpActionResult Get()
        {
            return Ok(context.Employees);
        }

        // GET: api/Employees/5
        public IHttpActionResult Get(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Employees
        public IHttpActionResult Post(Employee employee)
        {
            var addedEmployee = context.Employees.Add(employee);
            return CreatedAtRoute("DefaultApi", new { controller = "Employees", addedEmployee.EmployeeId }, addedEmployee);
        }


        // PUT: api/Employees/5
        public IHttpActionResult Put(Employee employee)
        {
            var dbEmployee = context.Employees.Find(employee.EmployeeId);

            if (dbEmployee != null)
            {
                dbEmployee.FirstName = employee.FirstName;
                dbEmployee.LastName = employee.LastName;
                dbEmployee.CommisionPercent = employee.CommisionPercent;
                dbEmployee.Email = employee.Email;
                dbEmployee.HireDate = employee.HireDate;
                dbEmployee.PhoneNumber = employee.PhoneNumber;
                dbEmployee.Salary = employee.Salary;
            }

            return Ok(context.SaveChanges());
        }

        // DELETE: api/Employees/5
        public IHttpActionResult Delete(int id)
        {
            var dbEmployee = context.Employees.Find(id);
            if (dbEmployee != null)
            {
                return Ok(context.Employees.Remove(dbEmployee));
            }
            else return NotFound();
        }
    }
}
