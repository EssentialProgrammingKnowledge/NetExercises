﻿namespace Exercise1.Services
{
    public class Cart : BaseObject
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}; ProductId = {ProductId}; UserId = {UserId}";
        }
    }
}
