using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nutrition.Models.DataBase
{
    [Table("TB_TRAINNING")]
    public class Trainning
    {
        [Key]
        [Column("TRAINNING_ID")]
        public int TrainningId { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("OBSERVATION")]
        [MaxLength(5000)]
        public string Observation { get; set; }

        [Required]
        [Column("SERIES")]
        public int Series { get; set; }

        [Required]
        [Column("REPS")]
        public int Reps { get; set; }

        //Foreign Key

        [Column("USER_ID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("CATEGORY_TRAINNING_ID")]
        public int CategoryTrainningId { get; set; }

        [ForeignKey("CategoryTrainningId")]
        public virtual CategoryTrainning CategoryTrainning { get; set; }

    }
}
