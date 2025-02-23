using Microsoft.AspNetCore.Mvc;
using Supabase;
using TeachLink_BackEnd.Models;

namespace TeachLink_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContrController : ControllerBase
    {
        private readonly Client _supabase;

        public ContrController(Client supabase)
        {
            _supabase = supabase;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _supabase
        //        .From<TestusModel>()
        //        .Select(x => new object[] { x.Id, x.Users, x.Email })
        //        .Get();
        //    return Ok(result.Models);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] TestusModel newRecord)
        //{
        //    if (newRecord == null)
        //        return BadRequest("Invalid data.");

        //    var response = await _supabase.From<TestusModel>().Insert(newRecord);

        //    if (response == null)
        //        return StatusCode(500, "Ошибка при добавлении в базу данных.");

        //    return CreatedAtAction(nameof(GetAll), new { id = newRecord.Id }, newRecord);
        //}
    }
}
