using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product 
    {
       public int Id { get; set; }

        [Required]
        [MaxLength(32), MinLength(3)]
       public string Title { get; set; }
       public string Description { get; set; }
       public string Image { get; set; }

        [Range(0, double.MaxValue)]
       public double Price { get; set; }
       public int ReviewAmount { get; set; }

    }
}
