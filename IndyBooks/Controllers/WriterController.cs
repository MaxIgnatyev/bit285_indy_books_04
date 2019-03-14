using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndyBooks.Models;


namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IndyBooksDataContext _ibdc;

        public WriterController(IndyBooksDataContext ibdc)
        {
            _ibdc = ibdc;
        }
        // GET: api/Writer
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            var WritersList = _ibdc.Writers;
            return Ok(WritersList);
            
        }

        // GET: api/Writer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var writer = _ibdc.Writers.SingleOrDefault(w => w.Id == id);
            if (writer == null)
            {
                return NotFound();
            }
            return Ok(writer);
        }

        // POST: api/Writer
        [HttpPost]
        public void Post([FromBody] Writer writer)
        {
            _ibdc.Add(writer);
            _ibdc.SaveChanges();
        }

        // PUT: api/Writer/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Writer writer)
        {
            
            var thisWriter = _ibdc.Writers.SingleOrDefault(w => w.Id == id);
            if (thisWriter == null)
            {
                return NotFound();
            }
            else
            {
                thisWriter.Name = writer.Name;
                _ibdc.Update(thisWriter);
                _ibdc.SaveChanges();
                return Ok();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
