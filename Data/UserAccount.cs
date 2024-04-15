using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCrudBlazor.Data
{
    [Table("user_account")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {  get; set; }

        [Column("user_name")]
        [MaxLength(100)]
        public string? Username { get; set; }
        [Column("password")]
        [MaxLength(100)]
        public string? Password { get; set; }
        [Column("role")]
        [MaxLength(20)]
        public string? Role { get; set; }
    }
}
