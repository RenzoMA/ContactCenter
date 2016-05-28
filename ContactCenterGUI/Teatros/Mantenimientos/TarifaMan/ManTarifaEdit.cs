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
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;

namespace ContactCenterGUI.Teatros.Mantenimientos.TarifaMan
{
    public partial class ManTarifaEdit : MaterialForm
    {
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private Tarifa tarifa = null;
        private List<Tarifa> listaTarifa;
        private Teatro teatro = null;
        private List<Teatro> listaTeatro;
        private Obra obra = null;
        private Zona zona = null;
        private List<Obra> listaObra;
        private List<Zona> listaZona;

        public ManTarifaEdit(Tarifa tarifa)
        {
            this.tarifa = tarifa;
            InitializeComponent();
        }

        private void ManTarifaEdit_Load(object sender, EventArgs e)
        {
            InicializarControles();
            SetEventos();
            LoadData();
        }

        private void InicializarControles()
        {
            cboObra.Enabled = false;
            cboTeatro.Enabled = false;
            cboZona.Enabled = false;
        }
        private void LoadData()
        {
            listaTeatro = servicio.ListarTeatros();
            cboTeatro.DataSource = listaTeatro;
            cboTeatro.DisplayMember = "Nombre";
            cboTeatro.SelectedItem = FindTeatro(tarifa.Obra.Teatro.IdTeatro);

            teatro = cboTeatro.SelectedItem as Teatro;
            listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
            cboObra.DataSource = listaObra;
            cboObra.DisplayMember = "Nombre";
            cboObra.SelectedItem = FindObra(tarifa.Obra.IdObra);

            listaZona = servicio.ListZonaByTeatro(teatro.IdTeatro);
            cboZona.DataSource = listaZona;
            cboZona.DisplayMember = "Nombre";
            cboZona.SelectedItem = FindZona(tarifa.Zona.IdZona);

            txtPrecio.Text = tarifa.Precio.ToString();
        }
        
        private Teatro FindTeatro(int idTeatro)
        {
            return listaTeatro.Where(tx => tx.IdTeatro == idTeatro).FirstOrDefault();
        }
        
        private Obra FindObra(int idObra)
        {
            return listaObra.Where(tx => tx.IdObra == idObra).FirstOrDefault();
        }
        
        private Zona FindZona(int idZona)
        {
            return listaZona.Where(tx => tx.IdZona == idZona).FirstOrDefault();
        }

        private void CapturarDatos()
        {
            obra = cboObra.SelectedItem as Obra;
            zona = cboZona.SelectedItem as Zona;
            tarifa.Obra = obra;
            tarifa.Zona = zona;
            tarifa.Precio = Convert.ToSingle(txtPrecio.Text);
        }
        private void SetEventos()
        {
            txtPrecio.KeyPress += HelperControl.EditTextDecimal;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        private bool Validar()
        {
            if(cboZona.SelectedIndex == 0 || txtPrecio.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Complete los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                CapturarDatos();
                if (servicio.Uptade(tarifa))
                {
                    MessageBox.Show("La tarifa se actualizó correctamente");
                }
                else
                {
                    MessageBox.Show("Hubo un error, intente nuevamente.");
                }
            }
        }
    }
}
