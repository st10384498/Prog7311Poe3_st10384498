using System;
using System.Collections.Generic;

namespace AgriConnect_POE7311_Part3.Models;

public partial class Farmer
{
    public int FarmerId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactNumber { get; set; }

    public string? ProfileImagePath { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
