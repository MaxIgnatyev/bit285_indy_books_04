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
            return Json(WritersList);
            
        }

        // GET: api/Writer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(long id)
        {
            return "value";
        }

        // POST: api/Writer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Writer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
