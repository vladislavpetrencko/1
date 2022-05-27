using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Opove
    {
        [Key]
        public int id_zaiv { get; set; }
        public string НомерСтанка { get; set; }
        public string ФИОработника { get; set; }
        public string ОписаниеПоломки { get; set; }
        public int id_master { get; set; }
    }
}
