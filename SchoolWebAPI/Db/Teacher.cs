using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Db;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
