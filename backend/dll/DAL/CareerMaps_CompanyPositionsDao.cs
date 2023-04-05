using dll.Data;
using dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class CareerMaps_CompanyPositionsDao : GenericDao<CareerMap_CompanyPosition>
    {
        public CareerMaps_CompanyPositionsDao(AprovAtosContext context) : base(context)
        { }
    }
}
