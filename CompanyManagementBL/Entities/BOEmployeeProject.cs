using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BOEmployeeProject
    {
        public int EmployeeProjectNr { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
    }
}
