using Dapper.Contrib.Extensions;

namespace dll.Models
{
    [Table("accessTypes_tb")]
    public class AccessType
    {
        [Key]
        public int access_type_id { get; set; }
        public string access_type_name { get; set; }
    }
}
