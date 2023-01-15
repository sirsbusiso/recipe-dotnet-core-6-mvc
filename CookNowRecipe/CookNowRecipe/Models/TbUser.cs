using System;
using System.Collections.Generic;

namespace CookNowRecipe.Models;

public partial class TbUser
{
    public int UserId { get; set; }

    public int? RoleId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual TbRole? Role { get; set; }

    public virtual ICollection<TbRecipe> TbRecipes { get; } = new List<TbRecipe>();
}
