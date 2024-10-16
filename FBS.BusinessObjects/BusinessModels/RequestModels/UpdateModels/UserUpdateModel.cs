using System;
using System.Collections.Generic;

namespace FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;

public partial class UserUpdateModel
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public bool IsActive { get; set; }
}
