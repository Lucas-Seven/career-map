using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprovatos.Models
{
    public class CompanyPosition
    {
        public CareerMap CareerMap { get; set; }


        public int CompanyPositionId { get; set; }
        public string CompanyPositionName { get; set; }
        public int HierarchyNumber { get; set; }
    }
}
