using viewmodels.CareerMap;

namespace viewmodels.User
{
    public class VMUserEntire
    {
        public VMUser User { get; set; }
        public VMCareerMap CareerMap { get; set; }
        public ICollection<VMAccessType> AccessTypes { get; set; }

        public VMUserEntire()
        {
            AccessTypes = new List<VMAccessType>();
        }
    }
}
