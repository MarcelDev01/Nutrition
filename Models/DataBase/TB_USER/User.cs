using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace Nutrition.Models.DataBase
{
    [Table("TB_USER")]
    public class User
    {
        [Key]
        [Column("USER_ID")]
        public int UserId { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("AGE")]
        public int Age { get; set; }

        [Required]
        [Column("BIRTHDAY")]
        public DateOnly Birthday { get; set; }

        [Required]
        [Column("HEIGHT")]
        public decimal Height { get; set; }

        [Required]
        [Column("WEIGHT")]
        public decimal Weight { get; set; }

        [Required]
        [Column("EMAIL")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [Column("LOGIN")]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required]
        [Column("PASSWORD")]
        [MaxLength(100)]
        public string Password { get; set; }

        [Column("FLG_ACTIVE")]
        [MaxLength(1)]
        public string FlgActive { get; set; }

        //Foreign Key

        [Column("PERMISSION_ID")]
        public int PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
    }

    public class UserIdAndNameViewModel 
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

}
