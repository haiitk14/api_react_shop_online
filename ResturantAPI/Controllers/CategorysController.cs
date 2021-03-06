﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models;
using ResturantAPI.Models.BE;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private I_Categorys<Categorys> _repository;


        public CategorysController (I_Categorys<Categorys> repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Categorys> categorys = _repository.GetAll();
            return Ok(categorys);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Categorys categorys = _repository.Get(id);

            if (categorys == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(categorys);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Categorys categorys)
        {
            if (categorys == null)
            {
                return BadRequest("Categorys is Null");
            }
            _repository.Add(categorys);
            return Ok(categorys);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Categorys categorys)
        {
            if (categorys == null)
            {
                return BadRequest("Customer is null");
            }
            Categorys categorysToUpdate = _repository.Get(id);
            if (categorysToUpdate == null)
            {
                return NotFound("Customer could not be found");
            }
            _repository.Update(categorysToUpdate, categorys);
            return Ok(categorys);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Categorys categorys = _repository.Get(id);
            if (categorys == null)
            {
                return BadRequest("Customer is not found");
            }
            _repository.Delete(categorys);
            return Ok(categorys);
        }

        [HttpGet("ispublic/{ispublic}")]
        public IActionResult GetCategorysByIsPublic(bool ispublic)
        {
            IEnumerable<Categorys> categorys = _repository.GetByIsPublic(ispublic);
            return Ok(categorys);
        }
    }
}
