using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viewmodels
{
    public class CompanyPositionRequirementsVM
    {
        public CareerMapVM CareerMap { get; set; }
        public CompanyPositionVM CompanyPosition { get; set; }
        public ICollection<PositionRequirementVM>? Requirements { get; set; }
        public CompanyPositionRequirementsVM()
        {
            Requirements = new List<PositionRequirementVM>();
        }
    }
}
