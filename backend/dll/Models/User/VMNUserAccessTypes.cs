using dll.Models.User;

namespace viewmodels.User
{
    public class VMNUserAccessTypes
    {
        public MNUser User { get; set; }
        public ICollection<MNAccessType> AccessTypes { get; set; }

        public VMNUserAccessTypes()
        {
            AccessTypes = new List<MNAccessType>();
        }
    }
}
