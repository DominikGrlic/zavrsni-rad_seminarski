using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyzWebApp.Models;

public class ProductCategory
{
    [Key]
    public int Id { get; set; }


    [Required]
    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }


    [Required]
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
}
