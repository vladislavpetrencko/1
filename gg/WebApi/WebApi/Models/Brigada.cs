using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Brigada
    {
        [Key]
        public int id_brigada { get; set; }
        public string Название { get; set; }
        public string Бригадир { get; set; }
        public string Раб1 { get; set; }
        public string Раб2 { get; set; }
        public string Раб3 { get; set; }
        public string Раб4 { get; set; }
        public string Раб5 { get; set; }
    }
}
