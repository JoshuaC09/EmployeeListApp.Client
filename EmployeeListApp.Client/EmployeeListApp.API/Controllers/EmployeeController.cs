using EmployeeListApp.Domain.Entities;
using EmployeeListApp.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeListApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            IEnumerable<Employee> employeeFromRepository = _unitOfWork.EmployeeRepository.GetAll();
            return Ok(employeeFromRepository);
        }

        [HttpGet("{id}")]

        public ActionResult GetEmployeeById(int id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.SaveChanges();
            return Ok("Successfully added an employee");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee (int id, Employee updatedEmployee)
        {

            if (id == 0)
            {
                return NotFound();
            }

            _unitOfWork.EmployeeRepository.Update(updatedEmployee);
            _unitOfWork.SaveChanges();
            return Ok("Successfully Updated an employee");
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteEmployee(int id, Employee employee)
        {
            if(id == 0)
            {
                return NotFound();
            }
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.SaveChanges();
            return Ok();
        }

    }
}
