namespace EmployeeManagementProjectAPI.Models
{
    public class Response
    {
        public int statusCode {  get; set; }
        public string statusMessage { get; set; }
        public Employee employee { get; set; }
        public List<Employee> EmployeesList { get; set; }


    }
}
