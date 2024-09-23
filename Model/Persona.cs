using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniloCorte1.Model
{
    internal class Persona
    {
        public string sNombre1 { get; set; }
        public string sNombre2 { get; set; }
        public string sApellido1 { get; set; }
        public string sApellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string sCiudad { get; set; }

        public Persona(string sNombre1, string sNombre2, string sApellido1, string sApellido2, DateTime fechaNacimiento, string sCiudad)
        {
            this.sNombre1 = sNombre1;
            this.sNombre2 = sNombre2;
            this.sApellido1 = sApellido1;
            this.sApellido2 = sApellido2;
            FechaNacimiento = fechaNacimiento;
            this.sCiudad = sCiudad;
        }
    }
}
