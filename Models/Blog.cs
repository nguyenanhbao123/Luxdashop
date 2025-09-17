using System;
using System.Collections.Generic;

namespace DoAnThietKeWeb1.Models;

public partial class Blog
{
    public string BlogId { get; set; } = null!;

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public DateTime? PostedDate { get; set; }
}
