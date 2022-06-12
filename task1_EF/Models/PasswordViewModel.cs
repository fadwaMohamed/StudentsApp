using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace task1_EF.Models
{
    public class PasswordViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string CPassword { get; set; }

        [Required]
        [Remote("CheckUserName", "Std", AdditionalFields = "Id")]
        public string UserName { get; set; }
    }
}
