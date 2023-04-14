using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using xyzWebApp.Areas.Identity.Data;

namespace xyzWebApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Column(TypeName ="datetime")]
        public DateTime DateCreated { get; set; } = DateTime.Now;


        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal SubTotal { get; set; }


        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Tax { get; set; }


        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }


        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }

        // TODO: Billing i Shipping klase sa svojstvima o kupcu (za neprijavljene kupce)
            // Svojstva: Id, FirstName, LastName, Email, Phone, City, Country, PostalCode, Message

        // TODO: Customers klasa koja je povezana sa ApplicationUser klasom (labava veza)
    }
}
