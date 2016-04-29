using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;

namespace ContactCenterGUI.Teatros
{
    public partial class PerInfoTheater : MaterialForm
    {
        private Form frmTeatro;
        private Reserva reserva;
        public List<AsientoPrecio> listaAsientoPrecio { get; set; }

        public PerInfoTheater()
        {
            InitializeComponent();
        }
        public PerInfoTheater(Form form,Reserva _reserva)
        {
            reserva = _reserva;
            frmTeatro = form;
            frmTeatro.Visible = false;
            InitializeComponent();
        }

        public string GenerarAsiento(List<AsientoPrecio> lista)
        {
            string result = "";
            foreach (AsientoPrecio obj in lista)
            {
                result += obj.Fila + obj.Descripcion + ", ";
            }
            return result;
        }

        private void PerInfoTheater_Load(object sender, EventArgs e)
        {
            lblAsientos.Text = GenerarAsiento(listaAsientoPrecio);
            lblObra.Text = reserva.Obra.Nombre;
            lblFuncion.Text = reserva.Funcion.Horario;
            lblTeatro.Text = reserva.Obra.Teatro.Nombre;
            metroComboBox1.SelectedIndex = 0;
            metroComboBox2.SelectedIndex = 0;
            
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTeatro.Visible = true;
        }
    }
}
