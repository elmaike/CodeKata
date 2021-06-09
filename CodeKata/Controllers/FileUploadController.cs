using CodeKata.DTO;
using CodeKata.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeKata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        // GET: api/<FileUploadController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FileUploadController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FileUploadController>
        [HttpPost]
        public IActionResult Post()
        {
            var file = Request.Form.Files[0];
            Dictionary<string, OutputReportDto> result;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var text = reader.ReadToEnd();
                result = new HelperOutputReport().GetDriversReport(text);
            }

            return Ok(JsonConvert.SerializeObject(result.ToArray(), Formatting.None));
        }

        // PUT api/<FileUploadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileUploadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //[HttpPost, DisableRequestSizeLimit]
        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "UploadedFiles");
        //        var pathToSave = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName);
        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}
    }
}
