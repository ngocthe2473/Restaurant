using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuyTo.Models;

public partial class Reservation
{
    [Key]
    public long ReservationId { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(15)]
    [Phone]
    public string Phone { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public int NumberOfGuests { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    [StringLength(1000)]
    public string? SpecialRequest { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
}

public enum ReservationStatus
{
    Available,
    Pending,
    Confirmed,
    Cancelled,
    Completed
}
