namespace viewmodels.User
{
    public class VMUserAccessTypes
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<VMAccessType> AccessTypes { get; set; }

        public VMUserAccessTypes()
        {
            AccessTypes = new List<VMAccessType>();
        }
    }
}
