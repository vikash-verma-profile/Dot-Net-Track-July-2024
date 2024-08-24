using System;
using System.Collections.Generic;

namespace RestWithDB.Models;

public partial class TblEmployee
{
    public int Id { get; set; }

    public string? EmployeeName { get; set; }

    public decimal? EmployeeSalary { get; set; }

    public int? EmployeeGender { get; set; }
}
