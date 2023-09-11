using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace estudo_dotnet.Entities
{
    public class User : EntityBase
    {
        public User () { }
        public User (string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email {get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }
    }
}