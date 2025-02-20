using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nutrition.Models.DataBase
{
    [Table("TB_PERMISSION")]
    public class Permission
    {
        [Key]
        [Column("PERMISSION_ID")]
        public int PermissionId { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
