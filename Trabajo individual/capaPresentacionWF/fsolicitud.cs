using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;

namespace capaPresentacionWF
{
    public partial class fsolicitud : Form
    {
        logicaNegocioSolicitud logicaNS = new logicaNegocioSolicitud();
        public fsolicitud()
        {
            InitializeComponent();
        }
        
        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "GUARDAR")
                {
                    Solicitud objetoSolicitud = new Solicitud();
                    objetoSolicitud.aula = textBoxAula.Text;
                    objetoSolicitud.nivel = textBoxNivel.Text;
                    objetoSolicitud.fechasolicitud = textBoxFechasolitu.Text;
                    objetoSolicitud.fechauso = textBoxFechauso.Text;
                    objetoSolicitud.horainicio = textBoxHoraini.Text;
                    objetoSolicitud.horafinal = textBoxHorafinal.Text;
                    objetoSolicitud.carrera = textBoxCarrera.Text;
                    objetoSolicitud.asignatura = textBoxAsignatura.Text;
                    objetoSolicitud.idrecursos = Convert.ToInt32((textBoxIdrecurso.Text).ToString());
                    objetoSolicitud.idusuario = Convert.ToInt32((textBoxIdusuario.Text).ToString());

                    if (logicaNS.insertarSolicitud(objetoSolicitud) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
                        textBoxAula.Text = "";
                        textBoxNivel.Text = "";
                        textBoxFechasolitu.Text = "";
                        textBoxFechauso.Text = "";
                        textBoxHoraini.Text = "";
                        textBoxHorafinal.Text = "";
                        textBoxCarrera.Text = "";
                        textBoxAsignatura.Text = "";
                        textBoxIdrecurso.Text = "";
                        textBoxIdusuario.Text = "";
                        tabControlsolicitud.SelectedTab = tabPage2; //Consultar
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar Solicitud");
                    }
                }
                if (buttonGuardar.Text == "ACTUALIZAR")
                {
                    Solicitud objetoSolicitud = new Solicitud();
                    objetoSolicitud.idsolicitud = Convert.ToInt32((textBoxIdsolicitud.Text).ToString());
                    objetoSolicitud.aula = textBoxAula.Text;
                    objetoSolicitud.nivel = textBoxNivel.Text;
                    objetoSolicitud.fechasolicitud = textBoxFechasolitu.Text;
                    objetoSolicitud.fechauso = textBoxFechauso.Text;
                    objetoSolicitud.horainicio = textBoxHoraini.Text;
                    objetoSolicitud.horafinal = textBoxHorafinal.Text;
                    objetoSolicitud.carrera = textBoxCarrera.Text;
                    objetoSolicitud.asignatura = textBoxAsignatura.Text;
                    objetoSolicitud.idrecursos = Convert.ToInt32((textBoxIdrecurso.Text).ToString());
                    objetoSolicitud.idusuario = Convert.ToInt32((textBoxIdusuario.Text).ToString());

                    if (logicaNS.editarSolicitud(objetoSolicitud) > 0)
                    {
                        MessageBox.Show("Actualizado con éxito");
                        dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
                        textBoxAula.Text = "";
                        textBoxNivel.Text = "";
                        textBoxFechasolitu.Text = "";
                        textBoxFechauso.Text = "";
                        textBoxHoraini.Text = "";
                        textBoxHorafinal.Text = "";
                        textBoxCarrera.Text = "";
                        textBoxAsignatura.Text = "";
                        textBoxIdrecurso.Text = "";
                        textBoxIdusuario.Text = "";
                        tabControlsolicitud.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Solicitud");
                    }
                    buttonGuardar.Text = "GUARDAR";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }
      

        //Ocultar Id cuando se agrega un nuevo Recursos "Se agrega por defecto"
        private void fsolicitud_Load(object sender, EventArgs e)
        {
            
            textBoxIdsolicitud.Visible= false;
            labelIdsolicitud.Visible = false;
            dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
        }
 
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            textBoxIdsolicitud.Visible = true;
            textBoxIdsolicitud.Enabled = false;
            labelIdsolicitud.Visible = true;

            textBoxIdsolicitud.Text = dataGridViewSolicitud.CurrentRow.Cells["idsolicitud"].Value.ToString();
            textBoxAula.Text = dataGridViewSolicitud.CurrentRow.Cells["aula"].Value.ToString();
            textBoxNivel.Text = dataGridViewSolicitud.CurrentRow.Cells["nivel"].Value.ToString();
            textBoxFechasolitu.Text = dataGridViewSolicitud.CurrentRow.Cells["fechasolicitud"].Value.ToString();
            textBoxFechauso.Text = dataGridViewSolicitud.CurrentRow.Cells["fechauso"].Value.ToString();
            textBoxHoraini.Text = dataGridViewSolicitud.CurrentRow.Cells["horainicio"].Value.ToString();
            textBoxHorafinal.Text = dataGridViewSolicitud.CurrentRow.Cells["horafinal"].Value.ToString();
            textBoxCarrera.Text = dataGridViewSolicitud.CurrentRow.Cells["carrera"].Value.ToString();
            textBoxAsignatura.Text = dataGridViewSolicitud.CurrentRow.Cells["asignatura"].Value.ToString();
            textBoxIdrecurso.Text = dataGridViewSolicitud.CurrentRow.Cells["idrecursos"].Value.ToString();
            textBoxIdusuario.Text = dataGridViewSolicitud.CurrentRow.Cells["idusuario"].Value.ToString();

            tabControlsolicitud.SelectedTab = tabPage1;
            buttonGuardar.Text = "ACTUALIZAR";
        }

   

        private void buttonborra_Click(object sender, EventArgs e)
        {
            int codigoR = Convert.ToInt32(dataGridViewSolicitud.CurrentRow.Cells["idsolicitud"].Value.ToString());
            try
            {
                if (logicaNS.eliminarSolicitud(codigoR) > 0)
                {
                    MessageBox.Show("Eliminado con éxito!");
                    dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
                }
            }
            catch
            {
                MessageBox.Show("Error al eliminar Solicitud");
            }
        }

      
        private void actualizar_Click(object sender, EventArgs e)
        {
            List<Solicitud> Solicitud = logicaNS.BuscarSolicitud(textBoxbuscar.Text);
            dataGridViewSolicitud.DataSource = Solicitud;
        }

        //private void labelRegsolici_Click(object sender, EventArgs e)
        //{

        //}
    }
}

