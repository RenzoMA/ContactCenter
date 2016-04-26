using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using ContactCenterCommon;
using MaterialSkin.Controls;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterGUI.Helpers;
using System.Globalization;

namespace ContactCenterGUI.Teatros
{
    public partial class NewTheater : MaterialForm
    {
        private List<Teatro> listaTeatro = null;
        private Teatro teatro = null;
        private int idTeatro = 0;

        private List<Obra> listaObra = null;
        private Obra obra = null;
        private int idObra = 0;

        private int diaFuncion;
        private DateTime FechaFuncion;

        private List<Funcion> listaFuncion = null;
        private Funcion funcion = null;
        private int idFuncion = 0;

        private Reserva reserva = new Reserva();

        public NewTheater()
        {
            InitializeComponent();
        }

        private void NewTheater_Load(object sender, EventArgs e)
        {
            InicializarVariables();
            CargarTeatros();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            idFuncion = Convert.ToInt16(metroComboBox3.SelectedValue.ToString());
            funcion = listaFuncion.Where(tx => tx.IdFuncion == idFuncion).FirstOrDefault();

            if (funcion.IdFuncion != 0)
            {
                reserva.Horario = funcion.Horario;
                reserva.FechaReserva = FechaFuncion;
                reserva.Obra = obra;
                reserva.Funcion = funcion;

                HelperForm.changeForm(funcion.Obra.Teatro.frmTeatro, "Teatros", true, this, reserva);
            }
            else
            {
                MessageBox.Show("Debe completar todos los datos");
            }
        }
        

        private void metroComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarObras();
        }
        
        private void metroComboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarFuncion();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarFuncion();
        }

        private void InicializarVariables()
        {
            diaFuncion = Util.DayOfWeekHelper(dateTimePicker1.Value.Date.DayOfWeek);
            FechaFuncion = dateTimePicker1.Value.Date;
        }
        private void CargarTeatros()
        {
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaTeatro = servicio.ListarTeatros();
                metroComboBox1.DataSource = listaTeatro;
                metroComboBox1.DisplayMember = "Nombre";
                metroComboBox1.ValueMember = "IdTeatro";
            }
            CargarObras();
        }
        private void CargarFuncion()
        {
            idObra = Convert.ToInt32(metroComboBox2.SelectedValue.ToString());
            obra = listaObra.Where(tx => tx.IdObra == idObra).FirstOrDefault();
            diaFuncion = Util.DayOfWeekHelper(dateTimePicker1.Value.Date.DayOfWeek);
            FechaFuncion = dateTimePicker1.Value.Date;
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaFuncion = servicio.ListarFuncionDiaObra(diaFuncion, idObra);
                metroComboBox3.DataSource = listaFuncion;
                metroComboBox3.DisplayMember = "Horario";
                metroComboBox3.ValueMember = "IdFuncion";
            }
            
        }
        private void CargarObras()
        {
            idTeatro = Convert.ToInt32(metroComboBox1.SelectedValue.ToString());
            teatro = listaTeatro.Where(tx => tx.IdTeatro == idTeatro).FirstOrDefault();
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaObra = servicio.ListarObraTeatro(idTeatro);
                metroComboBox2.DataSource = listaObra;
                metroComboBox2.DisplayMember = "Nombre";
                metroComboBox2.ValueMember = "IdObra";
            }
            CargarFuncion();
        }
    }
}
