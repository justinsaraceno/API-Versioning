using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContentNegotiation.Models;

namespace ContentNegotiation.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return Employees();
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            var employee = Employees().FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = string.Format("Employee Id [{0}] not found.", id)
                    });
            }

            return employee;
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }

        private IEnumerable<Employee> Employees()
        {
            // version 1 doesn't have address
            return new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Justin", LastName = "Saraceno" },
                new Employee { Id = 2, FirstName = "Anders", LastName = "Holmvick" },
                new Employee { Id = 3, FirstName = "Blake", LastName = "Henderson" },
                new Employee { Id = 4, FirstName = "Adam", LastName = "DeMamp" },
                new Employee { Id = 5, FirstName = "Karl", LastName = "Hevacheck" }
            };
        }
    }
}
