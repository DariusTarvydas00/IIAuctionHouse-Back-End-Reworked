﻿namespace IIAuctionHouse.Security.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
    }
}