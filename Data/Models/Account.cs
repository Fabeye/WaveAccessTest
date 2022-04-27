using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Data.Models
{
    public class Account
    {
        public int id { get; set; }

        [Display(Name = "Введите электронную почту")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Удалите это безобразите и напишите заново")]
        public string login { get; set; }

        [Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Удалите это безобразите и напишите заново")]
        public string password { get; set; }
    }
}
