using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("Employee")]
[Index("ReportsTo", Name = "IFK_EmployeeReportsTo")]
public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Title { get; set; }

    public int? ReportsTo { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? HireDate { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? City { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? State { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? Country { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [StringLength(24)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(24)]
    [Unicode(false)]
    public string? Fax { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Email { get; set; }

    [InverseProperty("SupportRep")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("ReportsToNavigation")]
    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    [ForeignKey("ReportsTo")]
    [InverseProperty("InverseReportsToNavigation")]
    public virtual Employee? ReportsToNavigation { get; set; }
}
