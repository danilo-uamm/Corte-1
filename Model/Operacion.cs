using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniloCorte1.Model
{
    internal class Operacion
    {// Calcula la edad de una persona dada su fecha de nacimiento
        public static int iCalcularEdad(DateTime fechaNacimiento)
        {
            int iEdad = DateTime.Now.Year - fechaNacimiento.Year;

            // Si aún no ha cumplido años este año, restamos 1
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
            {
                iEdad--;
            }

            return iEdad;
        }

        // Determina si una persona es mayor de edad (18 años o más)
        public static bool EsMayorDeEdad(DateTime fechaNacimiento)
        {
            int iEdad = iCalcularEdad(fechaNacimiento);

            // Si la edad es mayor o igual a 18, es mayor de edad
            if (iEdad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

