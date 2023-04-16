using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprovatos.ViewModels
{
    public class CompanyPositionRequirements
    {
        public CareerMap CareerMap { get; set; }
        public CompanyPosition CompanyPosition { get; set; }
        public ICollection<PositionRequirement>Requirements { get; set; }
        public CompanyPositionRequirements()
        {
            Requirements = new List<PositionRequirement>();
        }
    }
}
