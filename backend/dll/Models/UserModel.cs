﻿namespace dll.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public CareerMapModel? CareerMap { get; set; }
        public ICollection<AccessTypeModel> AccessTypes { get; set; }

        public UserModel()
        {
            AccessTypes = new List<AccessTypeModel>();
        }
    }
}
