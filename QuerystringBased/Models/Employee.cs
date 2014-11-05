using System;
using Newtonsoft.Json;

namespace QuerystringBased.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Address Address { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? HireDate { get; set; }
    }
}