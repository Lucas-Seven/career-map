namespace viewmodels.User
{
    public class VMUserAccessTypes
    {
        public VMUser User { get; set; }
        public ICollection<VMAccessType> AccessTypes { get; set; }

        public VMUserAccessTypes()
        {
            AccessTypes = new List<VMAccessType>();
        }
    }
}
