using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BODepartment
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentHeadId { get; set; }
        public BOCompany Company { get; set; }
    }
}
