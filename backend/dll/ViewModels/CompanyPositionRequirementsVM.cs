using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.ViewModels
{
    public class CompanyPositionRequirementsVM
    {
        public int CareerMapId { get; set; }
        public int CompanyPositionId { get; set; }
        public string? CompanyPositionName { get; set; }
        public ICollection<PositionRequirementVM>? Requirements { get; set; }
        public CompanyPositionRequirementsVM()
        {
            Requirements = new List<PositionRequirementVM>();
        }
    }
}
