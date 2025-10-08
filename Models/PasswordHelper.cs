using System.Security.Cryptography;

namespace MiMvcApp.Models
{
    public static class PasswordHelper
    {
        public static (byte[] hash, byte[] salt) HashPassword(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[16];
            rng.GetBytes(salt);
            using var derive = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            return (derive.GetBytes(32), salt);
        }
        public static bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            using var derive = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            return CryptographicOperations.FixedTimeEquals(hash, derive.GetBytes(32));
        }
    }
}
