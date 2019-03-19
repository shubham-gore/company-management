using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerLib;

namespace CompanyManagementBL.Entities
{
    public class BOCompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<BODepartment> Departments { get; set; }
        public List<BOClient> Clients { get; set; }
    }


}
