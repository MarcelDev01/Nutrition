using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nutrition.Models.DataBase
{
    [Table("TB_BODY_ASSESSMENT")]
    public class BodyAssessment
    {
        [Key]
        [Column("BODY_ASSESSMENT")]
        public int BodyAssessmentId { get; set; }

        [Required]
        [Column("IMC")]
        public decimal Imc { get; set; }

        [Required]
        [Column("HEIGHT_NEW")]
        public decimal HeightNew { get; set; }

        [Required]
        [Column("WEIGHT_NEW")]
        public decimal WeightNew { get; set; }

        [Required]
        [Column("FAT_PERCENTAGE")]
        public decimal FatPercentage { get; set; }

        [Required]
        [Column("FAT_WEIGHT")]
        public decimal FatWeight { get; set; }

        [Required]
        [Column("FAT_VISCERAL_WEIGHT")]
        public decimal FatVisceralWeight { get; set; }

        [Required]
        [Column("FAT_VISCERAL_PERCENTAGE")]
        public decimal FatVisceralPercentage { get; set; }

        [Required]
        [Column("LEAN_MASS_WEIGHT")]
        public decimal LeanMassWeight { get; set; }

        [Required]
        [Column("LEAN_MASS_PERCENTAGE")]
        public decimal LeanMassPercentage { get; set; }

        [Required]
        [Column("ARM_LEFT")]
        public decimal ArmLeft { get; set; }

        [Required]
        [Column("ARM_RIGHT")]
        public decimal ArmRight { get; set; }

        [Required]
        [Column("FOREARM_LEFT")]
        public decimal ForearmLeft { get; set; }

        [Required]
        [Column("FOREARM_RIGHT")]
        public decimal ForearmRight { get; set; }

        [Required]
        [Column("CHEST")]
        public decimal Chest { get; set; }

        [Required]
        [Column("SHOULDER")]
        public decimal Shoulder { get; set; }

        [Required]
        [Column("THIGH_LEFT")]
        public decimal ThighLeft { get; set; }

        [Required]
        [Column("THIGH_RIGHT")]
        public int ThighRight { get; set; }

        [Required]
        [Column("CALF_LEFT")]
        public int CalfLeft { get; set; }

        [Required]
        [Column("CALF_RIGHT")]
        public int CalfRight { get; set; }

        [Required]
        [Column("ABDOMEN")]
        public int Abdomen { get; set; }

        [Required]
        [Column("HIP")]
        public int Hip { get; set; }

        [Required]
        [Column("NECK")]
        public int Neck { get; set; }

        [Required]
        [Column("WAIST")]
        public int Waist { get; set; }

        //Foreign Key

        [Column("USER_ID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("CONSULTATION_ID")]
        public int ConsultationId { get; set; }

        [ForeignKey("ConsultationId")]
        public virtual Consultation Consultation { get; set; }
    }
}
