using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class Contact
{
    [Key]
    public long ContactId { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    [Required]
    [StringLength(11)]
    [Phone]
    public string? Phone { get; set; }

    [Required]
    [StringLength(50)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [Column(TypeName = "longtext")]
    public string? Message { get; set; }

    public bool? IsRead { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
