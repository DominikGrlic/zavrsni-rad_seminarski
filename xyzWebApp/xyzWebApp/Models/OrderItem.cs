using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyzWebApp.Models;

public class OrderItem
{
    [Key]
    public int Id { get; set; }


    [Required]
    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }


    [Required]
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }


    [Required]
    public int ServiceId { get; set; }
    [ForeignKey(nameof(ServiceId))]
    public Service Service { get; set; }


    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public int Quantity { get; set; }


    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Price { get; set; }


    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Total { get; set; }


}
