namespace dll.Models.User
{
    public class MNUser
    {
        public int UserId { get; set; }
        public int? CareerMapId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<MNAccessType> AccessTypes { get; set; }
    }
}
