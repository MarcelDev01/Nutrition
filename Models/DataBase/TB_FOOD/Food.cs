using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nutrition.Models.DataBase
{
    [Table("TB_FOOD")]
    public class Food
    {
        [Key]
        [Column("FOOD_ID")]
        public int FoodId { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
