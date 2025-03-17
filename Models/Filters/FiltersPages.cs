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
}
