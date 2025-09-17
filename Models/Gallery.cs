using System;
using System.Collections.Generic;

namespace DoAnThietKeWeb1.Models;

public partial class Gallery
{
    public string GalleryId { get; set; } = null!;

    public string? ImageName { get; set; }

    public string Path { get; set; } = null!;
}
