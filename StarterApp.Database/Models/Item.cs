using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarterApp.Database.Models;

[Table("items")]
[PrimaryKey(nameof(Id))]
public class Item
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]  
    public decimal PricePerDay { get; set; }
    [Required]
    public string Category { get; set; } = string.Empty;
    [Required]
    public bool IsAvailable { get; set; } = true;
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}