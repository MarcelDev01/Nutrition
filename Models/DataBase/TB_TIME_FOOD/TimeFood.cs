using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nutrition.Models.DataBase
{
    [Table("TB_TIME_FOOD")]
    public class TimeFood
    {
        [Key]
        [Column("TIME_FOOD_ID")]
        public int TimeFoodId { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("TIME")]
        public TimeOnly Time { get; set; }

        //Foreign Key

        [Column("FOOD_ID")]
        public int FoodId { get; set; }

        [ForeignKey("FoodId")]
        public virtual Food Food { get; set; }

        [Column("USER_ID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
