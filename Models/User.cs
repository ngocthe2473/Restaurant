using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models;

public partial class User
{
    [Key]
    public long UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string? Password { get; set; }

    [Required]
    [StringLength(50)]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(11)]
    [Phone]
    public string Phone { get; set; } = null!;

    [Required]
    [StringLength(50)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; }

    [StringLength(100)]
    public string? Avatar { get; set; }

    public int? RoleId { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool? IsDeleted { get; set; }

    public int? IsBlocked { get; set; }

    [StringLength(10)]
    public string? ConfirmCode { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
