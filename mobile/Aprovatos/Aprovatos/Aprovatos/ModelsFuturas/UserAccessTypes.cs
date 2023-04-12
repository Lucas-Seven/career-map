using Aprovatos.Models;
using System.Collections.Generic;

namespace Aprovatos.ModelsFuturas
{
    public class UserAccessTypes
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public CareerMap CareerMap { get; set; }
        public ICollection<AccessType> AccessTypes { get; set; }

        public UserAccessTypes()
        {
            AccessTypes = new List<AccessType>();
        }
    }
}
