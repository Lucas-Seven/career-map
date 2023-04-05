using dll.Data;
using dll.Models;
using dll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class PositionRequirementsDao : GenericDao<PositionRequirement>
    {
        public PositionRequirementsDao(AprovAtosContext context) : base(context)
        { 
            this.Context = context;
        }

        public IEnumerable<CompanyPositionRequirementsVM> ListRequirementsByCompanyPosition(int idCompanyPosition)
        {
            var list = Context.CompanyPositions.Join(
                Context.CompanyPositions_PositionRequirements,
                p => p.company_position_id,
                pr => pr.company_position_id,
                (p, pr) => new {CompanyPosition = p, CompanyPosition_PositionRequirement = pr}
            )
            .Join(
                Context.PositionRequirements,
                ppr => ppr.CompanyPosition_PositionRequirement.requirement_id,
                r => r.requirement_id,
                (ppr, r) => new CompanyPositionRequirementsVM
                {
                    company_position_id = ppr.CompanyPosition.company_position_id,
                    company_position_name = ppr.CompanyPosition.company_position_name,
                    group_name = ppr.CompanyPosition_PositionRequirement.group_name,
                    requirement_id = r.requirement_id,
                    requirement_name = r.requirement_name                    
                }
            )
            .Where(
                w => w.company_position_id == idCompanyPosition
            )
            .OrderBy(
                o => o.group_name
            );

            return list.ToList();
        }
    }
}
