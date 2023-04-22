using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Db;

public partial class Grade
{
    public int GradeId { get; set; }

    public int EnrollmentId { get; set; }

    public double Grade1 { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
