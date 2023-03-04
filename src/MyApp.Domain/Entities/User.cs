using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;
using MyApp.Domain.Helpers;

namespace MyApp.Domain.Entities
{
    public class User : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        public string EmailAddress { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; private set; }
        [Required]
        public UserStatus Status { get; set; } = UserStatus.Active;
        [Required]
        public UserRole Role { get; set; } = UserRole.Admin;

        public void SetPassword(string password)
        {
            Password = PasswordHasher.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return PasswordHasher.VerifyPassword(password, this.Password);
        }
    }
}
