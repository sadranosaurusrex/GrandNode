using System.ComponentModel.DataAnnotations;

namespace Grand.Web.Models.Common
{
    public partial class UserFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public bool Result { get; set; } //should be a boolean so we can display a message when a form is created :)
    }
}