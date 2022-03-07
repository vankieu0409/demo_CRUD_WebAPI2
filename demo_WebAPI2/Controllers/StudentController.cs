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
        private readonly ServiceOfController _serviceOfController;// Khai báo DI của Service of Controller


        public StudentController( ServiceOfController serviceOfController)
        {
            _serviceOfController = serviceOfController;
        }

        [HttpGet("Get")]
        public List<InfoStudent> Get()
        {
            return _serviceOfController.GetInfoStudents();
        }

        [HttpGet("Get/{id}")]
        public InfoStudent Get(int id)
        {
            InfoStudent infoStudent = _serviceOfController.GetInfoStudents().FirstOrDefault(c => c.IdStudent == id);
            return infoStudent;
        }

        [HttpPost("Add")]
        public List<InfoStudent> Add(InfoStudent a)
        {
            
            return _serviceOfController.AddInfoStudent(a);
        }

        [HttpPut("Edit/{id}")]
        public List<InfoStudent> Edit(InfoStudent a)
        {
            return _serviceOfController.EditInfoStudent(a);
        }

        [HttpDelete("Delete/{id}")]
        public List<InfoStudent> Delete(int id)
        {
            return _serviceOfController.DeleteInfoStudent(id);
        }

    }
}
