﻿
namespace Bangazon.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public bool IsSeller { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
