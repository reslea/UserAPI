using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public  string LName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
