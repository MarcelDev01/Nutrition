using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nutrition.Models.DataBase
{
    [Table("TB_CONSULTATION")]
    public class Consultation
    {
        [Key]
        [Column("CONSULTATION_ID")]
        public int ConsultationId { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("DATE")]
        public DateTime Date { get; set; }

        //Foreign Key

        [Column("USER_ID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public class ConsultationIdAndNames
    {
        public int ConsultationId { get; set; }
        public string ConsultationName { get; set; }
    }
}
