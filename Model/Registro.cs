using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniloCorte1.Model
{
    internal class Registro
    {
        private Persona[] Personas;
        private int iContador = 0;

        public Registro()
        {
            Personas = new Persona[30];
            iContador = 0;

        }

        public bool ValidarLista(Persona persona)
        {
            if (iContador < 30)
            {
                Personas[iContador] = persona;
                iContador++;
                return true;
            }
            else
            {
                return false; // No se puede agregar más personas
            }
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            for (int i = 0; i < iContador; i++)
            {
                listaPersonas.Add(Personas[i]);
            }
            return listaPersonas;
        }

    }
}
