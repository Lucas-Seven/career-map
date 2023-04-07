using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.ViewModels
{
    public class CareerMapCompanyPositionsVM
    {
        public CareerMapVm careerMap { get; set; }

        public CompanyPositionVM companyPosition { get; set; }

        public int hierarchyNumber { get; set; }
    }
}
