namespace Nutrition.Models.Filters
{
    public class FilterUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class FilterBodyAssessment
    {
        public string User { get; set; }
        public string Consultation { get; set; }
    }
    public class FilterFoodViewModel
    {
        public string Name { get; set; }
    }

    public class FilterConsultationViewModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
