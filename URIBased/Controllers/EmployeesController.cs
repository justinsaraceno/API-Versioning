using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using URIBased.Models;

namespace URIBased.Controllers
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
            return new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Justin", LastName = "Saraceno", HireDate = new DateTime(2014, 01, 01), Address = new Address { Id = 1, Line1 = "123 Fake St", Line2 = "Suite 300", City = "Garner", State = "NC", PostalCode = "27529" } },
                new Employee { Id = 2, FirstName = "Anders", LastName = "Holmvick", HireDate = new DateTime(2013, 11, 15), Address = new Address { Id = 2, Line1 = "17 Alice Way", Line2 = null, City = "Rancho Cucamonga", State = "CA", PostalCode = "90241" } },
                new Employee { Id = 3, FirstName = "Blake", LastName = "Henderson", HireDate = new DateTime(2013, 11, 15), Address = new Address { Id = 3, Line1 = "17 Alice Way", Line2 = null, City = "Rancho Cucamonga", State = "CA", PostalCode = "90241" } },
                new Employee { Id = 4, FirstName = "Adam", LastName = "DeMamp", HireDate = new DateTime(2013, 11, 15), Address = new Address { Id = 4, Line1 = "17 Alice Way", Line2 = null, City = "Rancho Cucamonga", State = "CA", PostalCode = "90241" } },
                new Employee { Id = 5, FirstName = "Karl", LastName = "Hevacheck", HireDate = new DateTime(2013, 11, 15), Address = new Address { Id = 5, Line1 = "264 Peace St", Line2 = null, City = "Rancho Cucamonga", State = "CA", PostalCode = "90247" } }
            };
        }
    }
}
