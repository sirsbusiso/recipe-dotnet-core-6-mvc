using System;
using System.Collections.Generic;

namespace CookNowRecipe.Models;

public partial class TbRecipe
{
    public int RecId { get; set; }

    public int? UserId { get; set; }

    public string RecipeName { get; set; } = null!;

    public string? Ingredient { get; set; }

    public string? Instructions { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ICollection<TbRecipeImage> TbRecipeImages { get; } = new List<TbRecipeImage>();

    public virtual TbUser? User { get; set; }
}
