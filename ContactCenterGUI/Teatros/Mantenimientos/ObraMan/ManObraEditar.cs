using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;
using System.IO;
using System.Drawing.Imaging;

namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    public partial class ManObraEditar : MaterialForm
    {
        private IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private Obra obra;
        private List<Teatro> listaTeatro;

        public ManObraEditar(Obra obra)
        {
            this.obra = obra;
            InitializeComponent();
        }

        private void ManObraEditar_Load(object sender, EventArgs e)
        {
            cargarData();
        }

        private void cargarData() {

            txtNomObra.Text = obra.Nombre;
            dtpFecIniObra.Value = obra.FechaInicio;
            dtpFecFinObra.Value = obra.FechaFin;
            cboEstadoObra.SelectedIndex = obra.Estado == "Activo" ? 0 : 1;
            listaTeatro = servicio.ListarTeatros();
            cboTeatroObra.DataSource = listaTeatro;
            cboTeatroObra.DisplayMember = "Nombre";
            cboTeatroObra.SelectedItem = FindTeatro(obra.Teatro.IdTeatro);
            txtDescripcionObra.Text = obra.Descripcion;
            if (obra.Image != null)
            {
                MemoryStream ms = new MemoryStream(obra.Image);
                pcbImagen.Image = Image.FromStream(ms);
            }
        }

        private Teatro FindTeatro(int idTeatro)
        {
            return listaTeatro.Where(tx => tx.IdTeatro == idTeatro).FirstOrDefault();
        }

        private void CapturarDatos()
        {
            obra.Nombre = txtNomObra.Text;
            obra.FechaInicio = dtpFecIniObra.Value.Date;
            obra.FechaFin = dtpFecFinObra.Value.Date;
            obra.Descripcion = txtDescripcionObra.Text;
            obra.Estado = cboEstadoObra.SelectedIndex == 0 ? "A" : "I";
            obra.Teatro = cboTeatroObra.SelectedItem as Teatro;
            if (pcbImagen.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pcbImagen.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                obra.Image = photo_aray;
            }

        }

        private bool ValidarDatos()
        {
            if (txtDescripcionObra.Text.ToUpper().Trim().Equals(string.Empty))
                return false;
            
            return true;

        }
        private void btnAceptarObra_Click(object sender, EventArgs e)
        {
            CapturarDatos();
            if (ValidarDatos())
            {
                try { 
                if (servicio.ActualizarObra(obra))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Completar todos los campos", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pcbImagen.Image = HelperForm.ResizeImage(Image.FromFile(openFileDialog1.FileName), 134, 194);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
