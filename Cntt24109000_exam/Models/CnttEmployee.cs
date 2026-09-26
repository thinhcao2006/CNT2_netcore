using System;
using System.Collections.Generic;

namespace Cntt24109000_exam.Models;

public partial class CnttEmployee
{
    public int Id { get; set; }

    public string CnttName { get; set; } = null!;

    public string? CnttGender { get; set; }

    public DateOnly? CnttBirthDay { get; set; }

    public string? CnttEmail { get; set; }

    public string? CnttPhone { get; set; }

    public bool? CnttActive { get; set; }
}
