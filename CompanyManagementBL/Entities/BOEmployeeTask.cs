using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BOEmployeeTask
    {
        public int EmployeeTaskNr { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int StatusId { get; set; }

    }
}
