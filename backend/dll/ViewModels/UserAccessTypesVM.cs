using dll.Models;

namespace dll.ViewModels
{
    public class UserAccessTypesVM
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public CareerMapVM? CareerMap { get; set; }
        public ICollection<AccessTypeVM> AccessTypes { get; set; }

        public UserAccessTypesVM()
        {
            AccessTypes = new List<AccessTypeVM>();
        }
    }
}
