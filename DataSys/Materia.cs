using System;
using System.Collections.Generic;
using System.Text;

namespace DataSys
{
    public class Materia
    {   
        public int          _idMxU          { get; set; }
        public string       _nombreAlumno   { get; set; }
        public int          _idUsuario      { get; set; }
        public int          _idMateria      { get; set; }
        public string       _nombreMateria  { get; set; }
        public string       _categoria      { get; set; }
        public TimeSpan     _horario        { get; set; }
        public string       _profesor       { get; set; }
        public int          _idProfesor     { get; set; }
        public string       _carrera        { get; set; }
        public int          _idCarrera      { get; set; }
        public int          _nota           { get; set; }
        public bool         _estado         { get; set; }
        public string       _estadoMateria  { get; set; }
    }
}
