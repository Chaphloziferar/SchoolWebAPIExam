using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Db;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Student Student { get; set; } = null!;
}
