using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Controllers
{
    //[ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        //[ServiceFilter(typeof(LoggingActionFilter))]
        //[LogFilter()]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //[ServiceFilter(typeof(LoggingActionFilter))]
        public ActionResult<string> Get(int id)
        {
            //return "value";
            return CreatedAtAction(nameof(Get),id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Value value)
        {
            
                return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        public class Value
        {
            public int Id { get; set; }
            [MinLength(3)]
            public string Text { get; set; }
        }
    }
}
