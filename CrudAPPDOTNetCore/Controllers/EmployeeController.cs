using CrudAPPDOTNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
namespace CrudAPPDOTNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployes")]
         public Response GetAllEmployees()
        {
            SqlConnection connection=new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal=new DAL();
            response = dal.GetAllEmployes(connection);


            return response;

        }
        [HttpGet]
        [Route("GetAllEmployeById/{id}")]
        public Response GetAllEmployeesById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmployesById(connection,id);


            return response;

        }

        [HttpPost]
        [Route("AddEmploye")]
        public Response AddEmploye(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddEmploye(connection, employee);
            return response;
        }

        [HttpPut]
        [Route("UpdateEmploye")]
        public Response UpdateEmploye(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateEmploye(connection, employee);
            return response;
        }

        [HttpDelete]
        [Route("DeleteEmploye/{id}")]
        public Response DeleteEmploye(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteEmploye(connection, id);
            return response;
        }
    }
}
