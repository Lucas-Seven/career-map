using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace admin.Api.Model
{
    public class MTest
    {
        public int TestId { get; set; }
        public int RequirementId { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }
    }
}
