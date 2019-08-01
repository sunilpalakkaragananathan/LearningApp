using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Interface;

namespace LearningApp.Controllers
{
    //[ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IFormatManager m_formatManager;
        public ValuesController(IFormatManager formatManager)
        {
            m_formatManager = formatManager;
        }
        [HttpGet]
        //[ServiceFilter(typeof(LoggingActionFilter))]
        //[LogFilter()]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
           
        }

        // GET api/values/5
        [HttpGet("{value}")]
        //[ServiceFilter(typeof(LoggingActionFilter))]
        public ActionResult<string> Get(string value)
        {
            //return "value";
            //string testvalue = "7dc87334c70fd0e0cbbc80475535e231";
            return m_formatManager.Decrypt(value);
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
