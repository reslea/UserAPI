using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class UserModel
    {
        [Required]
        public string FName { get; set; }

        [Required]
        public  string LName { get; set; }

        [Required, EmailAddress]
        public string Value { get; set; }
    }
}
