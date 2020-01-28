using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceBssl.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBssl.Api
{
    public class ValuesViewModel
    {
        public string ActualAddress { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        [HttpGet("ByName")]
        public string Get([FromQuery]int id, [FromQuery] string name)
        {
            return $"Your Name is {name} and our ID is {id}";
        }
        [HttpGet("AddressById")]
        public Address GetAddressById([FromQuery]int id)
        {
            var listofAddress = new List<Address>
            {
                new Address
                {
                    Id = 2,
                    CustomerId = "1",
                    ActualAddress="No 6 john"
                },
                new Address
                {
                    Id = 1,
                    CustomerId = "4",
                    ActualAddress="No 3 coker"
                },
            };

            var requestedAddress = listofAddress.FirstOrDefault(x => x.Id == id);

            return requestedAddress;
        }

        [HttpGet("AddressBy")]
        public List<Address> GetAddressBy()
        {
            var listofAddress = new List<Address>
            {
                new Address
                {
                    Id = 2,
                    CustomerId = "1",
                    ActualAddress="No 6 john"
                },
                new Address
                {
                    Id = 1,
                    CustomerId = "4",
                    ActualAddress="No 3 coker"
                },
            };

           

            return listofAddress;
        }
        [HttpGet("{AllAddress}")]
        public List<ValuesViewModel> GetAllAddress()
        {
            // this is our database
            var listOfAddress = new List<Address>
           {
               new Address
               {
                   Id = 1,
                   ActualAddress= "No 6 john"
               },
               new Address
               {
                   Id = 1,
                   ActualAddress= "No 3 coker"
               },

           };

            var data = listOfAddress.Select(x => new ValuesViewModel
            {
                ActualAddress =
            x.ActualAddress
            }).ToList();




            return data;

        }
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}