using System;
using System.Collections.Generic;

namespace CookNowRecipe.Models;

public partial class TbRecipeImage
{
    public int ImageId { get; set; }

    public int? RecId { get; set; }

    public string? FileName { get; set; }

    public string FilePath { get; set; } = null!;

    public string? FileType { get; set; }

    public virtual TbRecipe? Rec { get; set; }
}
