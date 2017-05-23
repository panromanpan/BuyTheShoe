using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Shoe
    {
        [Key]
        public int ShoeId { get; set; }

        [Required]
        [StringLength(200)]
        public string ShoeBrand { get; set; }

        [Required]
        [StringLength(200)]
        public string ShoeTitle { get; set; }

        public float Size { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool InStock { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
