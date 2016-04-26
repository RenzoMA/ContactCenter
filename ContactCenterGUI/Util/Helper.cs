using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using System.Windows.Forms;
using ContactCenterServices;
using Microsoft.Practices.Unity;


namespace ContactCenterGUI.Util
{
    class Helper
    {
        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private static void PintarAsiento(Button btn, Asiento asiento)
        {
            string estado = asiento.Disponible;
            switch (estado)
            {
                case "N":
                    btn.BackColor = System.Drawing.Color.Black;
                    btn.Enabled = false;
                    break;
                case "S":
                    btn.Text = asiento.Descripcion;
                    break;
            }
            btn.Tag = asiento;
        }
        private static void PintarAsientoOcupado(Button btn, Asiento asiento)
        {
            btn.BackColor = System.Drawing.Color.LightGray;
            btn.Enabled = false;
            btn.Text = "X";
        }
        public static void CruzarBotonData(List<Asiento> lOcupados, List<AsientoPrecio> lAsientoTotal, Form form)
        {
            foreach (Button btn in GetAll(form,typeof(Button)))
            {
                int IdAsiento;
                bool isNumber = int.TryParse(btn.Name.Replace("A",""), out IdAsiento);
                if (isNumber)
                {
                    Asiento asiento = lAsientoTotal.Where(tx => tx.IdAsiento == IdAsiento).FirstOrDefault();
                    if (asiento != null)
                    {
                        PintarAsiento(btn, asiento);
                    }
                    else
                    {
                        MessageBox.Show("Error en asignacion de asientos!!!!!!!!!");
                    }
                    Asiento Ocupado = lOcupados.Where(tx => tx.IdAsiento == IdAsiento).FirstOrDefault();
                    if(Ocupado != null)
                    {
                        PintarAsientoOcupado(btn, Ocupado);
                    }

                }
            }
        }
        public static async void MostrarDisponibilidad(Form form,int idObra, int idFuncion, DateTime fechaReserva, int idTeatro)
        {
            try
            {
                Animacion.ShowLoader(form);
                IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
                List<Asiento> lOcupados = await servicio.ListarAsientoDisponibleAsync(idObra, idFuncion, fechaReserva);
                List<AsientoPrecio> lAsientoTotal = await servicio.listarAsientoTeatroAsync(idTeatro);
                Helper.CruzarBotonData(lOcupados, lAsientoTotal, form);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Animacion.HideLoader(form);
            }
        }
    }
}
