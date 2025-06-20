using System;
using System.Collections.Generic;

namespace AgriConnect_POE7311_Part3.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int FarmerId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ? CategoryId { get; set; }

    public DateOnly ProductionDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Farmer Farmer { get; set; } = null!;
}
