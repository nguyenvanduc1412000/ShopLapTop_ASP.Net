using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "New Password required",AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("newPassword",ErrorMessage ="New password and confirm password does not match")]
        public string confirmPassword { get; set; }

        [Required]
        public string resetCode { get; set; }
    }
}