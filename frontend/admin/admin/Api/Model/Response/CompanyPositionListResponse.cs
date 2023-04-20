using Newtonsoft.Json;
using System.Collections.Generic;

namespace admin.Api.Model.Response
{
    public class CompanyPositionListResponse
    {
        [JsonProperty("careerMap")]
        public CareerMapResponse CareerMapResponse { get; set; }

        [JsonProperty("companyPositions")]
        public List<CompanyPositionResponse> CompanyPositionResponseList { get; set; }
    }

    public class CompanyPositionResponse
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