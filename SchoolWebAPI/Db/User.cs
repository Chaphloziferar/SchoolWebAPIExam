using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Db;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public DateTime? DeletedDate { get; set; }
}
