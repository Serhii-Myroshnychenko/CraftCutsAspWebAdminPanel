using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsAspWebAdminPanel.Models
{
    [Serializable]
    public class Login
    {
        [DisplayName("Login")]
        [Required(ErrorMessage = "Введите логин")]
        public string LoginAdm { get; set; }
        [Column("Password")]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

    }
}
