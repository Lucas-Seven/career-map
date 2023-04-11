using dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.ViewModels
{
    public class CompanyPositionVM
    {
        public int CompanyPositionId { get; set; }
        public string? CompanyPositionName { get; set; }
        public int HierarchyNumber { get; set; }
    }
}
