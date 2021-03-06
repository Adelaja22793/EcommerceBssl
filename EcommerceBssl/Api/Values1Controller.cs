﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceBssl.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceBssl.Api
{
    [Route("api/[controller]")]
    public class Values1Controller : Controller
    {

        private readonly EcommerceBssl.Data.ApplicationDbContext _context;



        public Values1Controller(EcommerceBssl.Data.ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet("MainCategoryById")]
        public IActionResult GetMainCategoryById([FromQuery]int id)
        {
            var main = _context.MainCategories.FirstOrDefault(x => x.Id == id);
            if (main != null)
            {
            return Ok(main);

            }
            else
            {
                return NotFound("No record Found");
            };
            //return $"your name is {name} and ur ID is : {id}";
        }

        [HttpGet("MainCategoryALL")]
        public List<MainCategory> MainCategories()
        {
            var main = _context.MainCategories.ToList();

            return main;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
