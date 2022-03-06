using demo_WebAPI2.DAL.Models;
using demo_WebAPI2.Sevice;
using demo_WebAPI2.Sevice.ModelsReturn;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ServiceOfController ss = new ServiceOfController();

        [HttpGet("Get")]
        public List<InfoStudent> Get()
        {
            return ss.GetInfoStudents();
        }

        [HttpGet("Get/{id}")]
        public InfoStudent Get(int id)
        {
            InfoStudent a = ss.GetInfoStudents().FirstOrDefault(c => c.IdStudent == id);
            return a;
        }

        [HttpPost("Add")]
        public List<InfoStudent> Add(InfoStudent a)
        {
            
            return ss.AddInfoStudent(a);
        }

        [HttpPut("Edit/{id}")]
        public List<InfoStudent> Edit(InfoStudent a)
        {
            return ss.EditInfoStudent(a);
        }

        [HttpDelete("Delete/{id}")]
        public List<InfoStudent> Delete(int id)
        {
            return ss.DeleteInfoStudent(id);
        }

    }
}
