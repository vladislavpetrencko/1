using System;
using System.Collections.Generic;
using System.Text;

namespace Mobil.Models
{
    public class Brigada
    {
        public int id_brigada { get; set; }
        public string Название { get; set; }
        public string Бригадир { get; set; }
        public string Раб1 { get; set; }
        public string Раб2 { get; set; }
        public string Раб3 { get; set; }
        public string Раб4 { get; set; }
        public string Раб5 { get; set; }
        public override bool Equals(object obj)
        {
            Brigada drigada = obj as Brigada;
            return this.id_brigada == drigada.id_brigada;
        }
    }
    
}
