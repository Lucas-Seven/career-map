using dll.Data;
using dll.Models;
using dll.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class CompanyPositionsDao : GenericDao<CompanyPosition>
    {
        public CompanyPositionsDao(CareerMapContext context) : base(context)
        { 
            this.Context = context;
        }

        public IEnumerable<CareerMapCompanyPositionsVM> ListCompanyPositionsByCareerMap(int idCareerMap)
        {
            var list = Context.CareerMaps.Join(
                Context.CareerMaps_CompanyPositions,
                m => m.career_map_id,
                mp => mp.career_map_id,
                (m, mp) => new { CareerMap = m, CareerMap_CompanyPosition = mp}
            )
            .Join(
                Context.CompanyPositions,
                mmp => mmp.CareerMap_CompanyPosition.company_position_id,
                p => p.company_position_id,
                (mmp, p) => new CareerMapCompanyPositionsVM
                {
                    career_map_id = mmp.CareerMap.career_map_id,
                    career_map_name = mmp.CareerMap.career_map_name,
                    company_position_id = p.company_position_id,
                    company_position_name = p.company_position_name,
                    hierarchy_number = mmp.CareerMap_CompanyPosition.hierarchy_number
                }
            )
            .Where(
                w => w.career_map_id == idCareerMap
            )
            .OrderBy(
                o => o.hierarchy_number
            );

            return list.ToList();
        }
    }
}
