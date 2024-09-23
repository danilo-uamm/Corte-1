using DaniloCorte1.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaniloCorte1
{
    public partial class RegistroEdadesDMES : System.Windows.Forms.Form
    {
        private Registro registro; // Declare registro as a class member

        public RegistroEdadesDMES()
        {
            InitializeComponent();
            registro = new Registro(); // Initialize registrogit 

            // Agregar algunas ciudades de nicaragua al ComboBox
            comboBoxCiudad.Items.Add("Managua");
            comboBoxCiudad.Items.Add("Leon");
            comboBoxCiudad.Items.Add("Carazo");
            comboBoxCiudad.Items.Add("Chinandega");
            comboBoxCiudad.Items.Add("Masaya");
            comboBoxCiudad.Items.Add("Granada");
            comboBoxCiudad.Items.Add("Rivas");
            comboBoxCiudad.Items.Add("Matagalpa");
            comboBoxCiudad.Items.Add("Esteli");
            comboBoxCiudad.Items.Add("Jinotega");
            comboBoxCiudad.Items.Add("Boaco");
            comboBoxCiudad.Items.Add("Chontales");
            comboBoxCiudad.Items.Add("Rio San Juan");
            comboBoxCiudad.Items.Add("Nueva Segovia");
            comboBoxCiudad.Items.Add("Madriz");
            comboBoxCiudad.Items.Add("RACCS");
            comboBoxCiudad.Items.Add("RAAN");
            

            comboBoxCiudad.SelectedIndex = 0; // Seleccionamos la primera ciudad por defecto
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string sNombre1 = txtNombre1.Text;
            string sNombre2 = txtNombre2.Text;
            string sApellido1 = txtApellido1.Text;
            string sApellido2 = txtApellido2.Text;
            DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
            string ciudad = comboBoxCiudad.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(sNombre1) || string.IsNullOrWhiteSpace(sNombre2) || string.IsNullOrWhiteSpace(sApellido2) || string.IsNullOrWhiteSpace(sApellido2))
            {
                labelMensaje.Text = "Por favor, ingrese nombres y apellidos.";
                labelMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Persona nuevaPersona = new Persona(sNombre1, sNombre2, sApellido1, sApellido2, fechaNacimiento, ciudad);
            bool agregado = registro.ValidarLista(nuevaPersona); // Use the instance of registro

            if (agregado)
            {
                labelMensaje.Text = "Persona agregada exitosamente.";
                labelMensaje.ForeColor = System.Drawing.Color.Green;

                // Actualizamos el ListBox con las personas registradas
                ActualizarListBoxPersonas();
            }
            else
            {
                labelMensaje.Text = "No se pueden agregar más de 30 personas.";
                labelMensaje.ForeColor = System.Drawing.Color.Red;
            }

            // Limpiar los campos de texto
            txtNombre1.Clear();
            txtNombre2.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            dateTimePickerFechaNacimiento.Value = DateTime.Now;
        }

        // Evento del botón Mostrar Edad y Mayor de Edad
    

        // Método para actualizar el contenido del ListBox con la lista de personas
        private void ActualizarListBoxPersonas()
        {
            listBoxPersonas.Items.Clear(); // Limpiamos el ListBox

            foreach (var persona in registro.ObtenerPersonas())
            {
                // Agregamos cada persona al ListBox mostrando el nombre completo
                listBoxPersonas.Items.Add($"{persona.sNombre1} {persona.sNombre2} {persona.sApellido1}{persona.sApellido2} ({persona.sCiudad})");
            }
        }

        private void btnMostrarEdad_Click(object sender, EventArgs e)
        {
            if (listBoxPersonas.SelectedIndex == -1)
            {
                labelMensaje.Text = "Seleccione una persona de la lista.";
                labelMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Obtenemos la persona seleccionada del ListBox
            Persona personaSeleccionada = registro.ObtenerPersonas()[listBoxPersonas.SelectedIndex];
            int edad = Operacion.iCalcularEdad(personaSeleccionada.FechaNacimiento);
            bool esMayorDeEdad = Operacion.EsMayorDeEdad(personaSeleccionada.FechaNacimiento);

            string resultado = $"{personaSeleccionada.sNombre1} {personaSeleccionada.sNombre2} {personaSeleccionada.sApellido1} {personaSeleccionada.sApellido2} tiene {edad} años y es ";
            resultado += esMayorDeEdad ? "mayor de edad." : "menor de edad.";

            labelMensaje.Text = resultado;
            labelMensaje.ForeColor = System.Drawing.Color.Blue;
        }
    }
}
