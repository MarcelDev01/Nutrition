using Nutrition.Models.DataBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nutrition.Models.Saves
{
    public class SaveUserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Permission { get; set; }
        public string Birthday { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool FlgActive { get; set; }
    }

    public class SaveBodyAssessmentViewModel
    {
        public int BodyAssessmentId { get; set; }
        public decimal Imc { get; set; }
        public decimal HeightNew { get; set; }
        public decimal WeightNew { get; set; }
        public decimal FatPercentage { get; set; }
        public decimal FatWeight { get; set; }
        public decimal FatVisceralWeight { get; set; }
        public decimal FatVisceralPercentage { get; set; }
        public decimal LeanMassWeight { get; set; }
        public decimal LeanMassPercentage { get; set; }
        public decimal ArmLeft { get; set; }
        public decimal ArmRight { get; set; }
        public decimal ForearmLeft { get; set; }
        public decimal ForearmRight { get; set; }
        public decimal Chest { get; set; }
        public decimal Shoulder { get; set; }
        public decimal ThighLeft { get; set; }
        public int ThighRight { get; set; }
        public int CalfLeft { get; set; }
        public int CalfRight { get; set; }
        public int Abdomen { get; set; }
        public int Hip { get; set; }
        public int Neck { get; set; }
        public int Waist { get; set; }
        public int UserId { get; set; }
        public int ConsultationId { get; set; }
    }
}
