using dll.Data;
using dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class CompanyPositions_PositionRequirementsDao : GenericDao<CompanyPosition_PositionRequirement>
    {
        public CompanyPositions_PositionRequirementsDao(CareerMapContext context) : base(context)
        { }
    }
}
