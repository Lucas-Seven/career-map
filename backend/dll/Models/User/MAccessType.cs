﻿namespace dll.Models.User
{
    public class MAccessType
    {
        public int AccessTypeId { get; set; }
        public string AccessTypeName { get; set; }
        public List<MNUser> Users { get; set; }
    }
}
