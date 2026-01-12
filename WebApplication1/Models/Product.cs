using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product 
    {
       public int Id { get; set; }

        [Required]
        [MaxLength(32), MinLength(3)]
       public string ProductTitle { get; set; }
       public string ProductDescription { get; set; }


        public string ProductImage { get; set; }

        [Range(0, double.MaxValue)]
       public double ProductPrice { get; set; }

    }
}
