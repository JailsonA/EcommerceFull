using System.ComponentModel.DataAnnotations;

namespace EcommerceFull.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Email Required *")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage ="Password Required *")]
        public string UserPass { get; set; }

    }
}
