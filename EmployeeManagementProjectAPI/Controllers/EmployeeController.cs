using EmployeeManagementProjectAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeManagementProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetEmployeeInfo/{id}")]
        public Response GetEmployeeInfo(int id)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeInfoTable"));
            DatabaseAPP db = new DatabaseAPP();
            response = db.GetFullList(con, id);
            
            return response;
        }

        [HttpPost]
        [Route("UpdateLeaves/")]
        public Response UpdateLeaves(Employee emp)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeInfoTable"));
            DatabaseAPP db = new DatabaseAPP();
            response = db.UpdateLeaves(con, emp.EmployeeID , emp.LeaveFrom, emp.LeaveTo);
            Console.WriteLine(emp.EmployeeID + " " + emp.LeaveFrom + " " + emp.LeaveTo);
            return response;
        }


    }
}
