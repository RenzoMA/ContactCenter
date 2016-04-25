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
        public static void CruzarBotonData(List<Asiento> lAsiento,List<Asiento> lAsientoTotal, Form form)
        {
            foreach (Button btn in GetAll(form,typeof(Button)))
            {
                int IdAsiento;
                bool isNumber = int.TryParse(btn.Name.Replace("A",""), out IdAsiento);
                if (isNumber)
                {
                    Asiento asiento = GetAsiento(IdAsiento, lAsientoTotal);
                    Asiento ocupado = GetAsiento(IdAsiento, lAsiento);

                    if (asiento != null)
                    {
                        if (ocupado == null)
                        {
                            if (asiento.Disponible != "S")
                            {
                                btn.BackColor = System.Drawing.Color.DarkGray;
                                btn.Enabled = false;
                                btn.Text = "X";
                            }
                        }
                        else
                        {
                            btn.BackColor = System.Drawing.Color.DarkGray;
                            btn.Enabled = false;
                        }
                        btn.Tag = asiento;
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
                List<Asiento> lAsiento = await servicio.ListarAsientoDisponibleAsync(idObra, idFuncion, fechaReserva);
                List<Asiento> lAsientoTotal = await servicio.listarAsientoTeatroAsync(idTeatro);
                Helper.CruzarBotonData(lAsiento, lAsientoTotal, form);
               
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
