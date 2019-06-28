using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AnotherPolicy")]
    public class RestController : ControllerBase
    {
        private readonly RestContext _context;

        public RestController(RestContext context)
        {
            _context = context;
        }

        // Get Method "api/controller"
        [HttpGet]
        public ActionResult<IEnumerable<Rest>> GetAll()
        {
            return _context.RestItems;
        }

        // Get Method "api/controller/{id}"

        [HttpGet("{Id}")]
        public ActionResult<Rest> GetById(int Id)
        {
            var RestItem = _context.RestItems.Find(Id);
            return RestItem;
            // return await _context.RestItems.FindAsync (Id);
        }

        // Post Method  "api/controller"
        [HttpPost]
        public ActionResult<Rest> Post(Rest data)
        {
            _context.RestItems.Add(data);
            _context.SaveChanges();

            return CreatedAtAction("Data is added in the database", new Rest { Id = data.Id }, data);
        }

        // Put Method    "api/controller/Id"
        [HttpPut("{Id}")]
        public ActionResult<Rest> Put(Rest data, int Id)
        {

            if (Id == data.Id)
            {
                _context.Entry(data).State = EntityState.Modified;
                _context.SaveChanges();
                return NoContent();

            }
            return BadRequest();
        }

        // Delete Method     "api/controller/Id"
        [HttpDelete("{Id}")]
        public ActionResult<Rest> Delete(int Id)
        {
            var RestItem = _context.RestItems.Find(Id);
            if (RestItem == null)
            {
                return NotFound();
            }
            _context.RestItems.Remove(RestItem);
            _context.SaveChanges();
            return RestItem;

        }

    }
}