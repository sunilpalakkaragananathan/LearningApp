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
            return new string[] { "value1"};
           
        }

        // GET api/values/5
        [HttpGet("{FirstName}/{Lastname}/{SSN}")]
        //[ServiceFilter(typeof(LoggingActionFilter))]
        public ActionResult<string> Get(string FirstName,string Lastname,string SSN)
        {
            //return "value";
            //string testvalue = "7dc87334c70fd0e0cbbc80475535e231";
            string formattedstring = String.Format("FirstName:{0}\nLastName:{1}\nSSN:{2}", m_formatManager.Decrypt(FirstName), m_formatManager.Decrypt(Lastname), m_formatManager.Decrypt(SSN));
            return formattedstring;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(PricingScheduleBatch value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

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



        public class Sku
        {
            [Required]
            public string SkuId { get; set; }

            public string SkuDescription { get; set; }

            [MinLength(1)]
            public List<double> SkuPrice { get; set; }
        }

        public class PricingSchedule
        {
            [MinLength(1)]
            public List<Sku> Skus { get; set; }

            [Required]
            public DateTime? EffectiveDate { get; set; }
        }

        public class PricingScheduleBatch
        {
            [Required]
            public List<string> OfficeList { get; set; }

            [Required]
            public PricingSchedule PricingSchedule { get; set; }
        }
    }

   
}
public class MyDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime d = Convert.ToDateTime(value);
        return d > DateTime.MinValue; 

    }
}
