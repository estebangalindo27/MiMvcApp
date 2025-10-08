using System.ComponentModel.DataAnnotations;

namespace MiMvcApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required] public string Username { get; set; }
        [Required] public byte[] PasswordHash { get; set; }
        [Required] public byte[] PasswordSalt { get; set; }

        public void SetPassword(string password)
        {
            var (hash, salt) = PasswordHelper.HashPassword(password);
            PasswordHash = hash; PasswordSalt = salt;
        }
        public bool VerifyPassword(string password)
        {
            return PasswordHelper.VerifyPassword(password, PasswordHash, PasswordSalt);
        }
    }
}
