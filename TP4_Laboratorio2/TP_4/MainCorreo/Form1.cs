using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;
using System.Data.SqlClient;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        Correo correo = new Correo();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado.
            Paquete paq = new Paquete(this.mtxtTrackingID.Text, this.txtDireccion.Text);
            paq.InformaEstado += Paq_InformaEstado;

            //Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
            try
            {
                correo += paq;
                this.ActualizarEstados();
                paq.informaExcepcion += MostrarExcepcionSQL;
            }
            catch (TrackingIdRepetidoException tIdE)
            {

                MessageBox.Show(tIdE.Message, "Atención!!");
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Atención!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencion!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lstEstadoEntregado.ContextMenuStrip = cmsLstEntregado;
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            correo.FinEntregas();
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            try
            {
                foreach (Paquete xItem in correo.Paquetes)
                {
                    switch (xItem.Estado)
                    {
                        case Paquete.EEstado.Ingresado:
                            lstEstadoIngresado.Items.Add(xItem);
                            break;

                        case Paquete.EEstado.EnViaje:
                            lstEstadoEnViaje.Items.Add(xItem);
                            break;

                        case Paquete.EEstado.Entregado:
                            lstEstadoEntregado.Items.Add(xItem);
                            break;
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message,"Atención!!");
            }
            

        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                try
                {
                    if (elemento is Correo)
                    {
                        this.rtbMostrar.Text = ((Correo)elemento).MostrarDatos((IMostrar<List<Paquete>>)elemento);
                        GuardarString.Guardar(((Correo)elemento).MostrarDatos((IMostrar<List<Paquete>>)elemento), "Salida.txt");

                    }
                    else
                        if (elemento is Paquete)
                        {
                            this.rtbMostrar.Text = ((Paquete)elemento).ToString();
                            GuardarString.Guardar(((Paquete)elemento).ToString(), "Salida.txt");
                        }
                }
                catch (FileNotFoundException fnfExc)
                {
                    MessageBox.Show(fnfExc.Message,"Atención");
                }
                catch (IOException ioExc)
                {

                    MessageBox.Show(ioExc.Message, "Atención");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Atención");
                }
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void Paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(Paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                // Llamar al método }
                this.ActualizarEstados();
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void MostrarExcepcionSQL(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención!!");
        }
    }
}
