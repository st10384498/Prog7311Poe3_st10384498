using System;
using System.Collections.Generic;

namespace AgriConnect_POE7311_Part3.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Department { get; set; }

    public DateTime? CreatedAt { get; set; }
}
