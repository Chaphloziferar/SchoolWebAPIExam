using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Db;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public int TeacherId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Teacher Teacher { get; set; } = null!;
}
