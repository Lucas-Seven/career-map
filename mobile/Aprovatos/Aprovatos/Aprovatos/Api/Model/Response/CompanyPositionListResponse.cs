using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aprovatos.Api.Model.Response
{
    public class CompanyPositionListResponse
    {
        [JsonProperty("careerMap")]
        public CareerMapResponse CareerMap { get; set; }

        [JsonProperty("companyPositions")]
        public List<CompanyPosition> CompanyPositions { get; set; }
    }

    public class CompanyPosition
    {
        [JsonProperty("hierarchyNumber")]
        public int HierarchyNumber { get; set; }

        [JsonProperty("companyPosition")]
        public CompanyPositionInfo CompanyPositionInfo { get; set; }
    }

    public class CompanyPositionInfo
    {
        [JsonProperty("companyPositionId")]
        public int CompanyPositionId { get; set; }

        [JsonProperty("companyPositionName")]
        public string CompanyPositionName { get; set; }
    }
}