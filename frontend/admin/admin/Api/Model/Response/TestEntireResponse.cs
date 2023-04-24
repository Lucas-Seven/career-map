using Newtonsoft.Json;

namespace admin.Api.Model.Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Alternative
    {
        [JsonProperty("alternativeId")]
        public int AlternativeId { get; set; }

        [JsonProperty("alternative")]
        public string Text { get; set; }
    }

    public class QuestionsAlternative
    {
        [JsonProperty("questionId")]
        public int QuestionId { get; set; }

        [JsonProperty("isRequired")]
        public bool IsRequired { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public Type Type { get; set; }

        [JsonProperty("alternatives")]
        public List<Alternative> Alternatives { get; set; }
    }

    public class Requirement
    {
        [JsonProperty("requirementId")]
        public int RequirementId { get; set; }

        [JsonProperty("requirementName")]
        public string RequirementName { get; set; }
    }

    public class TestEntireResponse
    {
        [JsonProperty("testId")]
        public int TestId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("requirement")]
        public Requirement Requirement { get; set; }

        [JsonProperty("questionsAlternatives")]
        public List<QuestionsAlternative> QuestionsAlternatives { get; set; }
    }

    public class Type
    {
        [JsonProperty("questionTypeId")]
        public int QuestionTypeId { get; set; }

        [JsonProperty("questionTypeName")]
        public string QuestionTypeName { get; set; }
    }


}
