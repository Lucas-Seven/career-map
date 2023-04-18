using Newtonsoft.Json;

namespace admin.Api.Model.Response
{
    public class CareerMapResponse
    {
        [JsonProperty("careerMapId")]
        public int CareerMapId { get; set; }

        [JsonProperty("careerMapName")]
        public string CareerMapName { get; set; }
    }

}
