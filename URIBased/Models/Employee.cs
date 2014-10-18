using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URIBased.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTime HireDate { get; set; }
    }
}