using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models;
using ResturantAPI.Models.BE;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private I_Articles<Articles> _repository;


        public ArticlesController(I_Articles<Articles> repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Articles> articles = _repository.GetAll();
            return Ok(articles);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Articles articles = _repository.Get(id);

            if (articles == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(articles);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Articles articles)
        {
            if (articles == null)
            {
                return BadRequest("Categorys is Null");
            }
            _repository.Add(articles);
            return CreatedAtRoute("Get", new { Id = articles.Id }, articles);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Articles articles)
        {
            if (articles == null)
            {
                return BadRequest("Customer is null");
            }
            Articles articlesToUpdate = _repository.Get(id);
            if (articlesToUpdate == null)
            {
                return NotFound("Customer could not be found");
            }
            _repository.Update(articlesToUpdate, articles);
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Articles articles = _repository.Get(id);
            if (articles == null)
            {
                return BadRequest("Customer is not found");
            }
            _repository.Delete(articles);
            return NoContent();
        }
    }
}
