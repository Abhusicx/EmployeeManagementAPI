namespace EmployeeManagementAPi.DTO
{
    public class EmployeeRequest : EmployeeResponse
    {
        public string EmpUserName { get; set; }
        public string EmpPassword { get; set; }
    }
}