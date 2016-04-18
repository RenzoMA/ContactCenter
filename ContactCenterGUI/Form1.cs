using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.AplicacionBE;


namespace ContactCenterGUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Metodo de prueba del servicio
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                Aplicacion aplicacion = new Aplicacion();
                aplicacion.Nombre = "teatros";
                aplicacion.Correo = "renzoma89@gmail.com";
                aplicacion.Estado = "A";
                aplicacion.FechaCreacion = DateTime.Now;
                aplicacion.UsuarioCreacion = "renzo";
                aplicacion.Version = "2.5";

                servicio.InsertarAplicacion(aplicacion);
                
            }
                
        }
    }
}
