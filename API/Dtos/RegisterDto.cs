using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {

        [Required]
        public string  DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string  Email { get; set; }
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
        ErrorMessage = "Password must have 1 Upper, 1 Lower case")]
        public string  Password { get; set; }
        
    }
}