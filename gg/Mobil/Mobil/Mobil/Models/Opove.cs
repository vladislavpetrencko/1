using System;
using System.Collections.Generic;
using System.Text;

namespace Mobil.Models
{
    public class Opove
    {
        public int id_zaiv { get; set; }
        public string НомерСтанка { get; set; }
        public string ФИОработника { get; set; }
        public string ОписаниеПоломки { get; set; }
        public int id_master { get; set; }
        public override bool Equals(object obj)
        {
            Opove opove = obj as Opove;
            return this.id_zaiv == opove.id_zaiv;
        }
    }

    
}
