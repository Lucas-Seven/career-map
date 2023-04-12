using dll.ViewModels;

namespace dll.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public CareerMapVM? CareerMap { get; set; }
    }
}
