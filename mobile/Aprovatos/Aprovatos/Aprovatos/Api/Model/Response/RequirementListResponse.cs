using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aprovatos.Api.Model.Response
{
    public class RequirementResponse
    {
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("requirement")]
        public RequirementInfo RequirementInfo { get; set; }
    }

    //public class Requirement2
    public class RequirementInfo
    {
        [JsonProperty("requirementId")]
        public int RequirementId { get; set; }

        [JsonProperty("requirementName")]
        public string RequirementName { get; set; }
    }

    public class RequirementListResponse
    {
        [JsonProperty("careerMap")]
        public CareerMapResponse CareerMap { get; set; }

        [JsonProperty("companyPosition")]
        public CompanyPositionInfo CompanyPositionInfo { get; set; }

        [JsonProperty("requirements")]
        public List<RequirementResponse> Requirements { get; set; }
    }
}
