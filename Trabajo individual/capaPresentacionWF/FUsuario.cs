using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace capaPresentacionWF
{
    public partial class FUsuario : Form
    {
        logicaNegocioUsuario logicaNU = new logicaNegocioUsuario();
        public FUsuario()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "GUARDAR")
                {
                    Usuario objetoUsuario = new Usuario();
                    objetoUsuario.cedula = textBoxCedula.Text;
                    objetoUsuario.nombres = textBoxNombre.Text;
                    objetoUsuario.apellidos = textBoxApellido.Text;
                    objetoUsuario.email = textBoxEmail.Text;
                    objetoUsuario.telefono = textBoxTelefono.Text;

                    if (logicaNU.insertarUsuarios(objetoUsuario) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
                        textBoxCedula.Text = "";
                        textBoxNombre.Text = "";
                        textBoxApellido.Text = "";
                        textBoxEmail.Text = "";
                        textBoxTelefono.Text = "";
                        tabUsuario.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar Usuario");
                    }
                }
                if (buttonGuardar.Text == "ACTUALIZAR")
                {
                    Usuario objetoUsuario = new Usuario();
                    objetoUsuario.idusuario = Convert.ToInt32(textBoxId.Text);
                    objetoUsuario.cedula = textBoxCedula.Text;
                    objetoUsuario.nombres = textBoxNombre.Text;
                    objetoUsuario.apellidos = textBoxApellido.Text;
                    objetoUsuario.email = textBoxEmail.Text;
                    objetoUsuario.telefono = textBoxTelefono.Text;

                    if (logicaNU.editarUsuario(objetoUsuario) > 0)
                    {
                        MessageBox.Show("Actualizado con éxito");
                        dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
                        textBoxCedula.Text = "";
                        textBoxNombre.Text = "";
                        textBoxApellido.Text = "";
                        textBoxEmail.Text = "";
                        textBoxTelefono.Text = "";
                        tabUsuario.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Usuario");
                    }
                    buttonGuardar.Text = "GUARDAR";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fUsuario_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelIdUsuario.Visible = false;
            dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            List<Usuario> listaUsuario = logicaNU.BuscarUsuario(textBoxBuscar.Text);
            dataGridViewUsuario.DataSource = listaUsuario;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelIdUsuario.Visible = true;


            textBoxId.Text = dataGridViewUsuario.CurrentRow.Cells["idusuario"].Value.ToString();
            textBoxNombre.Text = dataGridViewUsuario.CurrentRow.Cells["nombres"].Value.ToString();
            textBoxApellido.Text = dataGridViewUsuario.CurrentRow.Cells["apellidos"].Value.ToString();
            textBoxTelefono.Text = dataGridViewUsuario.CurrentRow.Cells["telefono"].Value.ToString();
            textBoxCedula.Text = dataGridViewUsuario.CurrentRow.Cells["cedula"].Value.ToString();
            textBoxEmail.Text = dataGridViewUsuario.CurrentRow.Cells["email"].Value.ToString();

            tabUsuario.SelectedTab = tabPage1;
            buttonGuardar.Text = "Actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigoR = Convert.ToInt32(dataGridViewUsuario.CurrentRow.Cells["idusuario"].Value.ToString());

            try
            {
                if (logicaNU.eliminarUsuario(codigoR) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
                }
            }
            catch
            {

                MessageBox.Show("ERROR al eliminar recurso");
            }
        }
    }

}
