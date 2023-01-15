using System;
using System.Collections.Generic;

namespace CookNowRecipe.Models;

public partial class TbRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<TbUser> TbUsers { get; } = new List<TbUser>();
}
