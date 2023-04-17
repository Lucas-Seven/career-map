using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprovatos.ViewModels
{
    public class RequirementListVM
    {
        public CompanyPositionVM CompanyPosition { get; set; }
        public ICollection<RequirementVM>Requirements { get; set; }
        public RequirementListVM()
        {
            Requirements = new List<RequirementVM>();
        }
    }
}
