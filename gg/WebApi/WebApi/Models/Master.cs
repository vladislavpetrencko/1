using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Master
    {
        [Key]
        public int id_master { get; set; }
        public string ФИО { get; set; }
        public string Пароль { get; set; }
        public string Логин { get; set; }
    }
}
