using System;
using System.Collections.Generic;
using System.Text;

namespace DataSys
{
    public class Materia
    {
        public int          _idMateria      { get; set; }
        public string       _nombreMateria  { get; set; }
        public string       _categoria      { get; set; }
        public string       _horario        { get; set; }
        public int          _idProfesor     { get; set; }
        public int          _nota           { get; set; }
        public bool         _estado         { get; set; }
    }
}
