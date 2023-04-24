using Newtonsoft.Json;
using System.Collections.Generic;

namespace admin.Api.Model.Response
{
    public class AlternativeResponse
    {
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("Alternative")]
        public AlternativeInfo AlternativeInfo { get; set; }
    }

    //public class Alternative2
    public class AlternativeInfo
    {
        [JsonProperty("AlternativeId")]
        public int AlternativeId { get; set; }

        [JsonProperty("AlternativeName")]
        public string AlternativeName { get; set; }
    }

    public class AlternativeListResponse
    {
        [JsonProperty("careerMap")]
        public CareerMapResponse CareerMap { get; set; }

        [JsonProperty("companyPosition")]
        public CompanyPositionInfo CompanyPositionInfo { get; set; }

        [JsonProperty("Alternatives")]
        public List<RequirementResponse> Requirements { get; set; }
    }
}
