using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BOEmployee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public int? DepartmentHeadId { get; set; }
        public BODepartment Department { get; set; }
        
    }
}
