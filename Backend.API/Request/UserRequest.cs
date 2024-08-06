using System.ComponentModel.DataAnnotations;

namespace Backend.API.Request
{
    public class UserRequest
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
