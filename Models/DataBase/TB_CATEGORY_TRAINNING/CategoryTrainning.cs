using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nutrition.Models.DataBase
{
    [Table("TB_CATEGORY_TRAINNING")]
    public class CategoryTrainning
    {
        [Key]
        [Column("CATEGORY_TRAINNING_ID")]
        public int CategoryTrainningId { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
