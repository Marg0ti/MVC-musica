using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Models;

[Table("Invoice")]
[Index("CustomerId", Name = "IFK_InvoiceCustomerId")]
public partial class Invoice
{
    [Key]
    public int InvoiceId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly InvoiceDate { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string? BillingAddress { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? BillingCity { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? BillingState { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? BillingCountry { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? BillingPostalCode { get; set; }

    [Column(TypeName = "numeric(10, 2)")]
    public decimal Total { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Invoices")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Invoice")]
    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
}
