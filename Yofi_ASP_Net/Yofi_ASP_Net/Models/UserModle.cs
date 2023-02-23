using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yofi_ASP_Net.Models
{
    public class UserModle
    {
        // data types defention
        // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model?view=aspnetcore-7.0
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public int EmailConfirmed { get; set; }
        public string PasswordConfirmed { get; set; }
        public string PhoneNumberConfirmed { get; set;}
        [NotMapped] // this on will ignor the colmun
        public IFormFile File { get; set; }
    }
}
