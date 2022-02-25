using System;
using System.Collections.Generic;
using System.Text;

namespace DataSys
{
    public class Examen
    {
        public int          _idExamen       { get; set; }
        public int          _idMateria      { get; set; }
        public string       _nombreMateria  { get; set; }
        public TimeSpan     _horario        { get; set; }
        public int          _nota           { get; set; }
        public bool         _estado         { get; set; }
    }
}
