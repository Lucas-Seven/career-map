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

        public QuestionsAlternative()
        {
            Alternatives = new List<Alternative>();
            Type = new Type();
        }
    }

    public class TestEntireResponse
    {
        [JsonProperty("testId")]
        public int TestId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("requirement")]
        public RequirementInfo Requirement { get; set; }

        [JsonProperty("questionsAlternatives")]
        public List<QuestionsAlternative> QuestionsAlternatives { get; set; }

        public TestEntireResponse()
        {
            QuestionsAlternatives = new List<QuestionsAlternative>();
        }
    }

    public class Type
    {
        [JsonProperty("questionTypeId")]
        public int QuestionTypeId { get; set; }

        [JsonProperty("questionTypeName")]
        public string QuestionTypeName { get; set; }
    }


}
