using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
