using System.ComponentModel.DataAnnotations;

namespace AdvancedEshop.Models
{
    public class Size
    {
        [Key]
        public int SizeID { get; set; }

        [StringLength(150)]
        public string? SizeName { get; set; }
    }
}
