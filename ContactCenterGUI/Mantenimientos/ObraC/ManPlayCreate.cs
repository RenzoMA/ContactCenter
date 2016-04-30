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
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterGUI.Mantenimientos.ObraC
{
    public partial class ManPlayCreate : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        public ManPlayCreate()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimientos.ObraC.ManPlayMenu manplaymenu = new Mantenimientos.ObraC.ManPlayMenu();
            manplaymenu.ShowDialog();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            

                Obra obra = new Obra();
                obra.Nombre = materialSingleLineTextField1.Text;
                obra.FechaInicio = dateTimePicker1.Value;
                obra.FechaFin = dateTimePicker2.Value;
                obra.Descripcion = richTextBox1.Text;
                obra.Estado = metroComboBox1.ValueMember;
                obra.Teatro = metroComboBox2.SelectedItem as Teatro;
                servicio.InsertarObra(obra);
            if(servicio.InsertarObra(obra) == true) {

                MessageBox.Show("Obra registrada correctamente");
            } else {

                MessageBox.Show("ERROR", "ERROR");
            }


            
        }

        private void ManPlayCreate_Load(object sender, EventArgs e)
        {
            metroComboBox2.DataSource = servicio.ListarTeatros();
            metroComboBox2.DisplayMember = "Nombre";

        }
    }
}
