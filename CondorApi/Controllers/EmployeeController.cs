using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CondorApi.Models.Response;
using CondorApi.Models.Request;
using CondorApi.Models;

namespace CondorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Employe>> _respuesta = new Respuesta<List<Employe>>();

            try 
            { 
                using (CondorDBContext db = new CondorDBContext())
                {
                    var lst = db.Employes.ToList();
                    _respuesta.Success = 1;
                    _respuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Success = 0;
                _respuesta.Message = ex.Message;
            }
            

            return Ok(_respuesta);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<Employe> _respuesta = new Respuesta<Employe>();

            try
            {
                using (CondorDBContext db = new CondorDBContext())
                {
                    var lst = db.Employes.Find(Id);
                    _respuesta.Success = 1;
                    _respuesta.Data = lst!;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Success = 0;
                _respuesta.Message = ex.Message;
            }


            return Ok(_respuesta);
        }

        [HttpPost]
        public IActionResult Add(EmployeRequest model)
        {
            Respuesta<object> _respuesta = new Respuesta<object>();

            try
            {
                using (CondorDBContext db = new CondorDBContext())
                {
                    Employe _employee = new Employe();
                    _employee.TypeDocument = model.TypeDocument;
                    _employee.DocumentNumber = model.DocumentNumber;
                    _employee.Name = model.Name;
                    _employee.LastName = model.LastName;
                    _employee.DateBirth = model.DateBirth;
                    _employee.Area = model.Area;
                    db.Employes.Add(_employee);
                    db.SaveChanges();
                    _respuesta.Success = 1;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Success = 0;
                _respuesta.Message = ex.Message;
            }

            return Ok(_respuesta);
        }

        [HttpPut]
        public IActionResult Edit(EmployeRequest model)
        {
            Respuesta<object> _respuesta = new Respuesta<object>();

            try
            {
                using (CondorDBContext db = new CondorDBContext())
                {
                    Employe _employee = db.Employes.Find(model.Id);
                    _employee.TypeDocument = model.TypeDocument;
                    _employee.DocumentNumber = model.DocumentNumber;
                    _employee.Name = model.Name;
                    _employee.LastName = model.LastName;
                    _employee.DateBirth = model.DateBirth;
                    _employee.Area = model.Area;
                    db.Entry(_employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    _respuesta.Success = 1;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Success = 0;
                _respuesta.Message = ex.Message;
            }

            return Ok(_respuesta);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<object> _respuesta = new Respuesta<object>();

            try
            {
                using (CondorDBContext db = new CondorDBContext())
                {
                    Employe _employee = db.Employes.Find(Id);
                    db.Remove(_employee);
                    db.SaveChanges();
                    _respuesta.Success = 1;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Success = 0;
                _respuesta.Message = ex.Message;
            }

            return Ok(_respuesta);
        }
    }
}
