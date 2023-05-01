using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace admin.Api.Model
{
    public class MQuestion
    {
        public int? QuestionId { get; set; }
        public int QuestionTypeId { get; set; }

        [Display(Name = "Questão")]
        public string? Question { get; set; }
        public bool IsRequired { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }
    }
}
