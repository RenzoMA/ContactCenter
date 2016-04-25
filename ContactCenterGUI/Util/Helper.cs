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
        private static Asiento GetAsiento(int IdAsiento, List<Asiento> lista)
        {
            foreach (Asiento asiento in lista)
            {
                if (asiento.IdAsiento == IdAsiento)
                {
                    return asiento;
                }
            }
            return null;
        }
        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public static void CruzarBotonData(List<Asiento> lAsiento, Form form)
        {
            foreach (Button btn in GetAll(form,typeof(Button)))
            {
                int IdAsiento;
                bool isNumber = int.TryParse(btn.Name.Replace("A",""), out IdAsiento);
                if (isNumber)
                {
                    Asiento asiento = GetAsiento(IdAsiento, lAsiento);
                    btn.Tag = asiento;
                    btn.Enabled = false;
                    btn.BackColor = System.Drawing.Color.Gray;
                }
            }
        }
        public static async void MostrarDisponibilidad(Form form,int idObra, int idFuncion, DateTime fechaReserva)
        {
            try
            {
                Animacion.ShowLoader(form);
                IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
                List<Asiento> lAsiento = await servicio.ListarAsientoDisponibleAsync(idObra, idFuncion, fechaReserva);
                Helper.CruzarBotonData(lAsiento, form);
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
