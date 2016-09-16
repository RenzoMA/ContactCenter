using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using MaterialSkin.Controls;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterServices;
using ContactCenterServices.ServicioTeatro;
using ContactCenterGUI.CC.Helpers;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.AsientoMan
{
    public partial class ManAsientoZona : MaterialForm
    {
        private Teatro teatro;
        private Obra obra;
        private Zona zona;
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        public ManAsientoZona(Teatro teatro, Obra obra, Zona zona)
        {
            InitializeComponent();
            this.teatro = teatro;
            this.obra = obra;
            this.zona = zona;
            
        }
        private void AsignarNombres()
        {
            lblObra.Text = obra.Nombre;
            lblTeatro.Text = teatro.Nombre;
            lblZona.Text = zona.Nombre;
        }
        private void ManAsientoZona_Load(object sender, EventArgs e)
        {
            LoadListBox();
            AsignarNombres();
        }
        private void LoadListBox()
        {
            lstAsientos.DataSource = servicio.ListAsientoNoAsignado(obra.IdObra, teatro.IdTeatro);
            lstAsientos.DisplayMember = "DescripcionFila";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Asiento> listaAsientos = new List<Asiento>();
            foreach (Asiento asiento in lstAsientos.SelectedItems)
            {
                listaAsientos.Add(asiento);
            }
            InsertarAsientoZona(listaAsientos, zona);
        }
        private async void InsertarAsientoZona(List<Asiento> lista, Zona zona)
        {
            try
            {
                bool exito = false;
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    Animacion.ShowLoader(this);
                    exito = await servicio.InsertarAsientoZonaAsync(lista,zona);
                    Animacion.HideLoader(this);
                    if (exito)
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
