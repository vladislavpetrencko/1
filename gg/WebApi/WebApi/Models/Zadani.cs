using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Zadani
    {
        [Key]
        public int id_zadani { get; set; }
        public string Название { get; set; }
        public string Описание { get; set; }
        public string Допуски { get; set; }
        public int id_brigada { get; set; }
        public int id_cotry { get; set; }
        public int СтатусЗадания { get; set; }
    }
}
