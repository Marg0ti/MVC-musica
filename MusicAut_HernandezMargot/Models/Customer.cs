using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("Customer")]
[Index("SupportRepId", Name = "IFK_CustomerSupportRepId")]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string? Company { get; set; }

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
    public string Email { get; set; } = null!;

    public int? SupportRepId { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [ForeignKey("SupportRepId")]
    [InverseProperty("Customers")]
    public virtual Employee? SupportRep { get; set; }
}
