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
using ContactCenterGUI.CC.Mantenimientos.AplicacionMan;
using ContactCenterGUI.Teatros.Mantenimientos.AsientoMan;
using ContactCenterGUI.Teatros.Mantenimientos.FuncionMan;
using ContactCenterGUI.Teatros.Mantenimientos.ObraMan;
using ContactCenterGUI.Teatros.Mantenimientos.PromocionMan;
using ContactCenterGUI.Teatros.Mantenimientos.TarifaMan;
using ContactCenterGUI.CC.Mantenimientos.UsuarioMan;

namespace ContactCenterGUI
{
    public partial class ManPrincipal : MaterialForm
    {
        public ManPrincipal()
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
                ManAppMenu manappmenu = new ManAppMenu();
                manappmenu.ShowDialog();
                this.Show();

            }
            else if (metroComboBox1.SelectedItem.ToString() == "Asiento")
            {
                this.Hide();
                ManAsiento manfunmenu = new ManAsiento();
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
                ManTarifa manfaremenu = new ManTarifa();
                manfaremenu.ShowDialog();
                this.Show();
            }
        }
    }
}
