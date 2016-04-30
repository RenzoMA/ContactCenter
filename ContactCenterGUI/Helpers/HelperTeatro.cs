using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using System.Windows.Forms;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterGUI.Teatros;
using MaterialSkin.Controls;

namespace ContactCenterGUI.Helpers
{
    class HelperTeatro
    {
        private static string tokenTemp;
        private static Reserva reservaTemp;
        private static Form formTemp;
        private static List<Asiento> lOcupados;
        private static List<AsientoPrecio> lAsientoTotal;
        private static IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private static List<AsientoPrecio> asientosReserva;

        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private static void PintarAsiento(Button btn, AsientoPrecio asiento)
        {
            string estado = asiento.Disponible;
            switch (estado)
            {
                case "N":
                    btn.BackColor = System.Drawing.Color.LightGray;
                    btn.Enabled = false;
                    btn.Text = "X";
                    break;
                case "S":
                    btn.Text = asiento.Descripcion;
                    break;
            }
            btn.Tag = asiento;
            btn.MouseClick += new MouseEventHandler(ReservarAsientoClick);
        }

        public async static void EliminarSeparadas(string token)
        {
            Animacion.ShowLoader(formTemp);
            await servicio.EliminarAsientoTemporalTotalAsync(token);
            Animacion.HideLoader(formTemp);
            formTemp.Close();
        }

        private static void PintarAsientoOcupado(Button btn, Asiento asiento)
        {
            btn.BackColor = System.Drawing.Color.Red;
            btn.Enabled = false;
        }
        public static void CruzarBotonData(List<AsientoPrecio> lAsientoTotal, Form form)
        {
            foreach (Button btn in GetAll(form,typeof(Button)))
            {
                int IdAsiento;
                bool isNumber = int.TryParse(btn.Name.Replace("A",""), out IdAsiento);
                if (isNumber)
                {
                    AsientoPrecio asiento = lAsientoTotal.Where(tx => tx.IdAsiento == IdAsiento).FirstOrDefault();
                    if (asiento != null)
                    {
                        PintarAsiento(btn, asiento);
                    }
                    else
                    {
                        MessageBox.Show("Error en asignacion de asientos!!!!!!!!!");
                    }
                }
            }
        }
        public static void SetEventosBoton()
        {
            foreach (MaterialRaisedButton btn in GetAll(formTemp, typeof(MaterialRaisedButton)))
            {
                if (btn.Name == "btnContinuar")
                {
                    btn.MouseClick += new MouseEventHandler(ConfirmarReserva);
                }
                if (btn.Name == "btnAtras")
                {
                    btn.MouseClick += new MouseEventHandler(CancelarAsientoTotal);

                }
            }
        }
        public static void SetEventosLabel()
        {
            foreach (Label lbl in GetAll(formTemp, typeof(Label)))
            {
                if (lbl.Name == "lblCerrar")
                {
                    lbl.MouseClick += new MouseEventHandler(CancelarAsientoTotal);
                }
            }
        }

        public static string GenerarToken()
        {
            String usuarioActual = Sesion.usuario.Login;
            int randomNumber1 = new Random().Next(100000, 1000000);
            int randomNumber2 = new Random().Next(1000000, 10000000);
            return Util.Encriptar(randomNumber1 + usuarioActual + randomNumber2);
        }
        public static async void AsignarListaOcupada(List<Asiento> lOcupada)
        {
            lOcupada = await servicio.ListarAsientoDisponibleAsync(reservaTemp.Obra.IdObra, reservaTemp.Funcion.IdFuncion, reservaTemp.FechaReserva,tokenTemp);
            CruzarBotonOcupado(lOcupada);
        }
        public static void CruzarBotonOcupado(List<Asiento> lista)
        {
            foreach (Button btn in GetAll(formTemp, typeof(Button)))
            {
                int IdAsiento;
                bool isNumber = int.TryParse(btn.Name.Replace("A", ""), out IdAsiento);
                if (isNumber)
                {
                    Asiento Ocupado = lista.Where(tx => tx.IdAsiento == IdAsiento).FirstOrDefault();
                    if (Ocupado != null)
                    {
                        PintarAsientoOcupado(btn, Ocupado);
                    }

                }
            }
        }

        public static async void MostrarDisponibilidad(Form form,Reserva reserva)
        {
            asientosReserva = new List<AsientoPrecio>();
            tokenTemp = GenerarToken();
            reservaTemp = reserva;
            formTemp = form;

            try
            {
                Animacion.ShowLoader(form);
                lAsientoTotal = await servicio.listarAsientoTeatroAsync(reserva.Obra.IdObra);
                lOcupados = await servicio.ListarAsientoDisponibleAsync(reservaTemp.Obra.IdObra, reservaTemp.Funcion.IdFuncion, reservaTemp.FechaReserva,tokenTemp);
                CruzarBotonData(lAsientoTotal, form);
                AsignarListaOcupada(lOcupados);
                SetEventosBoton();
                SetEventosLabel();

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
        static void ConfirmarReserva(object sender, EventArgs e)
        {
            if (asientosReserva.Count > 0)
            {
                PerInfoTheater info = new PerInfoTheater(formTemp, reservaTemp);
                info.listaAsientoPrecio = asientosReserva;
                info.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un asiento", "Aviso");
            }

        }

        public async static void ReservarAsiento(Button btnAsiento, AsientoPrecio asiento)
        {
            Animacion.ShowLoader(formTemp);
            if (asiento.EstadoTemporal == "" || asiento.EstadoTemporal == null)
            {
                Boolean exito = await servicio.InserAsientoTemporalAsync(reservaTemp.Funcion.IdFuncion, asiento.IdAsiento, reservaTemp.FechaReserva, tokenTemp);
                if (exito)
                {
                    asiento.ColorTemporal = btnAsiento.BackColor;
                    asiento.EstadoTemporal = "R";
                    btnAsiento.Tag = asiento;
                    btnAsiento.BackColor = System.Drawing.Color.Green;
                    asientosReserva.Add(asiento);
                }
                else
                {
                    AsignarListaOcupada(lOcupados);
                }
            }
            else
            {
                Boolean exito = await servicio.EliminarAsientoTemporalAsync(reservaTemp.Funcion.IdFuncion, asiento.IdAsiento, reservaTemp.FechaReserva, tokenTemp);
                if (exito)
                {
                    asiento.EstadoTemporal = "";
                    btnAsiento.BackColor = asiento.ColorTemporal;
                    btnAsiento.Tag = asiento;
                    asientosReserva.Remove(asiento);

                }
            }
            Animacion.HideLoader(formTemp);
        }
        static void ReservarAsientoClick(object sender, EventArgs e)
        {
            Button btnAsiento = (Button)sender;
            AsientoPrecio asiento = (AsientoPrecio)btnAsiento.Tag;
            ReservarAsiento(btnAsiento, asiento);
            
        }
        public static void CancelarReservaAsiento()
        {
            EliminarSeparadas(tokenTemp);
        }
        public static void CancelarAsientoTotal(object sender, EventArgs e)
        {
            EliminarSeparadas(tokenTemp);
        }
    }
}
