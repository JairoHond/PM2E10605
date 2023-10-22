using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E10605.Models
{
    public class Sitios
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Descripcion { get; set; }      
        public byte[] Foto { get; set; }
    }
}
