using System;
using System.Collections.Generic;
using System.Text;

namespace Mobil.Models
{
    public class Cmena
    {
        public int id_cotry { get; set; }
        public string ФИО { get; set; }
        public string ОсновнаяПрофессия { get; set; }
        public string Разряд { get; set; }
        public string ВторостепенныеПрофессии { get; set; }
        public string РазрядВторостепенных { get; set; }
        public string Статус { get; set; }
        public int id_master { get; set; }
        public int id_brigada { get; set; }
        public string ТБ { get; set; }
        public string Допуски { get; set; }
        public DateTime ДатаОкончанияДопуска { get; set; }
        public DateTime ДатаОкончанияТБ { get; set; }
        public string Сокращение { get; set; }
        public override bool Equals(object obj)
        {
            Cmena Cmena = obj as Cmena;
            return this.id_cotry == Cmena.id_cotry;
        }
    }
    
}
