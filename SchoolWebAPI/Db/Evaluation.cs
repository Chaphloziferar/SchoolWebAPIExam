using System;
using System.Collections.Generic;

namespace SchoolWebAPI.Db;

public partial class Evaluation
{
    public int EvaluationId { get; set; }

    public int EnrollmentId { get; set; }

    public DateTime EvaluationDate { get; set; }

    public string EvaluationType { get; set; } = null!;

    public decimal Score { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
