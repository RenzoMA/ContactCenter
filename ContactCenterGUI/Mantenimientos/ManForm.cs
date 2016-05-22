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
using ContactCenterGUI.Mantenimientos.AplicacionMan;
using ContactCenterGUI.Mantenimientos.AsientoMan;
using ContactCenterGUI.Mantenimientos.FuncionMan;
using ContactCenterGUI.Mantenimientos.ObraMan;
using ContactCenterGUI.Mantenimientos.PromocionMan;
using ContactCenterGUI.Mantenimientos.TarifaMan;
using ContactCenterGUI.Mantenimientos.UsuarioMan;

namespace ContactCenterGUI.Mantenimientos
{
    public partial class ManForm : MaterialForm
    {
        public ManForm()
        {
            InitializeComponent();
        }

        private void ManForm_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione un mantenimiento", "ERROR");
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Aplicación")
            {

                this.Hide();
                Mantenimientos.AplicacionMan.ManAppMenu manappmenu = new Mantenimientos.AplicacionMan.ManAppMenu();
                manappmenu.ShowDialog();
                this.Show();

            }
            else if (metroComboBox1.SelectedItem.ToString() == "Asiento")
            {
                this.Hide();
                AsientoMan.ManAsiento manfunmenu = new AsientoMan.ManAsiento();
                manfunmenu.ShowDialog();
                this.Show();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Usuario")
            {
                this.Hide();
                ManUsuario manUsuario = new ManUsuario();
                manUsuario.ShowDialog();
                this.Show();
            }
            else if(metroComboBox1.SelectedItem.ToString() == "Funcion")
            {
               // this.Hide();
               // Mantenimientos.Funcion.ManFunctionMenu manfunmenu = new Mantenimientos.Funcion.ManFunctionMenu();
               // manfunmenu.ShowDialog();
                //this.Show();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Obra")
            {
                this.Hide();
                ManPlayMenu manaplaymenu = new ManPlayMenu();
                manaplaymenu.ShowDialog();
                this.Show();
            }

            else if (metroComboBox1.SelectedItem.ToString() == "Tarifa")
            {
                this.Hide();
                manFareMenu manfaremenu = new manFareMenu();
                manfaremenu.ShowDialog();
                this.Show();
            }
        }
    }
}
