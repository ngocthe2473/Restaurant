using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class Menu
{
    [Key]
    public long MenuId { get; set; }

    [Required]
    [StringLength(50)]
    public string? MenuName { get; set; }

    [StringLength(50)]
    public string? Alias { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public int? Levels { get; set; }

    [ForeignKey("ParrentId")]
    public long? ParrentId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("ParrentId")]
    public virtual Menu? ParentMenu { get; set; }

    [InverseProperty("ParentMenu")]
    public virtual ICollection<Menu> SubMenus { get; set; } = new List<Menu>();
}
