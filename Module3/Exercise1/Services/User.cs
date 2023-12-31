﻿namespace Exercise1.Services
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            // password shouldn't be visible
            return $"Id = {Id}; Name = {Name}; Email = {Email};";
        }
    }
}
