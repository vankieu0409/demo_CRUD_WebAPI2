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
        private ServiceShow ss = new ServiceShow();

        [HttpGet("GetInfoStudents")]
        public List<InfoStudent> Get()
        {
            return ss.GetInfoStudents();
        }

        [HttpGet("GetOneStudent/{id}")]
        public InfoStudent GetOneStudent(int id)
        {
            InfoStudent a = ss.GetInfoStudents().FirstOrDefault(c => c.IdStudent == id);
            return a;
        }

        [HttpPost("AddNewStudent")]
        public List<InfoStudent> AddNewStudent(InfoStudent a)
        {
            
            return ss.AddInfoStudent(a);
        }

        [HttpPut("EditInfoStudent/{id}")]
        public List<InfoStudent> EditInfoStudent(InfoStudent a)
        {
            return ss.EditInfoStudent(a);
        }

        [HttpDelete("DeleteInfoStudent/{id}")]
        public List<InfoStudent> DeleteInfoStudents(int id)
        {
            return ss.DeleteInfoStudent(id);
        }

    }
}
