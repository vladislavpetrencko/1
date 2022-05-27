using System;
using System.Collections.Generic;
using System.Text;

namespace Mobil.Models
{
    public class Zadani
    {
        public int id_zadani { get; set; }
        public string Название { get; set; }
        public string Описание { get; set; }
        public string Допуски { get; set; }
        public int id_brigada { get; set; }
        public int id_cotry { get; set; }
        public int СтатусЗадания { get; set; }
        public override bool Equals(object obj)
        {
            Zadani Zadani = obj as Zadani;
            return this.id_zadani == Zadani.id_zadani;
        }
    }
    
}
