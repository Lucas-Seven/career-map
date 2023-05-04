using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace admin.Api.Model
{
    public class MQuestion
    {
        public int QuestionId { get; set; }
        [Display(Name = "Tipo de Questão")]
        public int QuestionTypeId { get; set; }

        [Display(Name = "Questão")]
        public string? Question { get; set; }
        [Display(Name = "Necessário")]
        public bool IsRequired { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }
    }
}
