using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace nzwalks.API.Controllers
{
    //https://localhost::portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] strArray = new string[] { "Gaurav", "Sneha", "Suniti" };
            return Ok(strArray);
        }
    }
}
