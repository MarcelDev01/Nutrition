namespace Nutrition.Models.User
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
}
