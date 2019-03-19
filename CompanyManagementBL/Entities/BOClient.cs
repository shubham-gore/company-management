using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BOClient
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }

    }
}
