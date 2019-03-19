using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BOProject
    {
        public int ProjectId { get;set; }
        public string ProjectName { get; set; }
        public int StatusId { get; set; }
        public int DepartmentId { get; set; }
        public string StatusName { get; set; }
        public BODepartment Department { get; set; }
        public List<BOClient> Clients { get; set; }
        //public int TaskId { get; set; }
        //public List<DataLayerLib.Task> TaskList { get; set; }
    }
}
