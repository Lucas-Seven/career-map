using Newtonsoft.Json;

namespace Aprovatos.Api.Model.Response
{
    public class CareerMapResponse
    {
        [JsonProperty("careerMapId")]
        public int CareerMapId { get; set; }

        [JsonProperty("careerMapName")]
        public string CareerMapName { get; set; }
    }

}
