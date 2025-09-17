using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnThietKeWeb1.Models;

public partial class Cart
{
    public string CartId { get; set; } = null!;
    [ForeignKey("UserId")]
    public string? UserId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public IdentityUser? User { get; set; }
}
