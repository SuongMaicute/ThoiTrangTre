using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int UsersId { get; set; }

    public string UsersName { get; set; } = null!;

    public string? UsersEmail { get; set; }

    public string UsersPhone { get; set; } = null!;

    public string UsersAddress { get; set; } = null!;

    public int RoleId { get; set; }

    public string? Passwords { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;
}
