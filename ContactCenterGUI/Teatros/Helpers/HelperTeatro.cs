﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using System.Windows.Forms;
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterGUI.Teatros.Reservas;
using MaterialSkin.Controls;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;
using ContactCenterGUI.CC.Constantes;
using System.Drawing;

namespace ContactCenterGUI.Teatros.Helpers
{
    class HelperTeatro
    {
        private static string tokenTemp;
        private static Reserva reservaTemp;
        private static Form formTemp;
        private static List<Asiento> lOcupados;
        private static List<AsientoZona> lAsientoTotal;
        private static IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private static List<AsientoZona> asientosReserva;
        private static Timer timer;
        private static TimeSpan span;
        private static int contador;
        private static int limitMinutesTime = 15;
        private static int limitSecondsTime = 30;

        private static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private static void PintarAsiento(Button btn, AsientoZona asiento)
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
                    btn.Text = asiento.Asiento.Descripcion;
                    btn.BackColor = System.Drawing.Color.FromArgb(asiento.Zona.R, asiento.Zona.G, asiento.Zona.B);
                    break;
            }
            btn.Tag = asiento;
            btn.MouseClick += new MouseEventHandler(ReservarAsientoClick);
        }

        private async static void EliminarSeparadas(string token)
        {
            Animacion.ShowLoader(formTemp);
            timer.Dispose();// Limpia timer
            await servicio.EliminarAsientoTemporalTotalAsync(token);
            Animacion.HideLoader(formTemp);
            formTemp.Close();
        }

        private static void PintarAsientoOcupado(Button btn, Asiento asiento)
        {
            btn.BackColor = System.Drawing.Color.Red;
            btn.Enabled = false;
        }
        private static void CruzarBotonData(List<AsientoZona> lAsientoTotal, Form form)
        {
            int contador = 0;
            List<Control> listaBotonAsiento = GetAll(form, typeof(Button)).Where(tx => tx.Name.Substring(0, 1) == "A").ToList();
            if (listaBotonAsiento.Count != lAsientoTotal.Count)
            {
                MessageBox.Show("No se han configurado todos los asientos para la obra","Verificar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                form.Close();
                return;
            }
            foreach (Button btn in listaBotonAsiento)
            {
                
                int IdAsiento;
                bool isNumber = int.TryParse(btn.Name.Replace("A",""), out IdAsiento);
                if (isNumber)
                {
                    contador++;
                    AsientoZona asiento = lAsientoTotal.Where(tx => tx.Asiento.IdAsiento == IdAsiento).FirstOrDefault();
                    if (asiento != null)
                    {
                        PintarAsiento(btn, asiento);
                    }
                    else
                    {
                        MessageBox.Show("Asiento no encontrado en la BD "+IdAsiento, "Verifique que todas las zonas tengan una tarifa");
                    }
                }
            }
            if (contador != lAsientoTotal.Count)
            {
                MessageBox.Show("Incongruencia en asignacion, Botones: "+contador+ " Asientos en BD: "+lAsientoTotal.Count);
            }
        }
        private static Label tiempo;
        private static void SetEventosBoton()
        {
            MaterialRaisedButton btnContinue = (MaterialRaisedButton)GetAll(formTemp, typeof(MaterialRaisedButton)).Where(a => a.Name == "btnContinuar").FirstOrDefault();
            btnContinue.MouseClick += new MouseEventHandler(ConfirmarReserva);

            Label btnClose = (Label)GetAll(formTemp, typeof(Label)).Where(d => d.Name == "btnCerrar").FirstOrDefault();
            btnClose.MouseClick += new MouseEventHandler(CancelarAsientoTotal);
            btnClose.BackColor = ConstanteColor.GetPrimaryColor();


            Label btnMiminizar = (Label)GetAll(formTemp, typeof(Label)).Where(d => d.Name == "btnMiminizar").FirstOrDefault();
            btnMiminizar.MouseClick += new MouseEventHandler(MiminizarTeatro);
            btnMiminizar.BackColor = ConstanteColor.GetPrimaryColor();

            Panel pnlPrincipal = (Panel)GetAll(formTemp, typeof(Panel)).Where(d => d.Name == "pnlPrincipal").FirstOrDefault();
            pnlPrincipal.BackColor = ConstanteColor.GetPrimaryColor();

            Panel pnlSecundary = (Panel)GetAll(formTemp, typeof(Panel)).Where(d => d.Name == "pnlSecundary").FirstOrDefault();
            pnlSecundary.BackColor = ConstanteColor.GetSecundaryColor();

            MaterialLabel tituloX = (MaterialLabel)GetAll(formTemp, typeof(MaterialLabel)).Where(d => d.Name == "lblTituloTeatro").FirstOrDefault();
            tituloX.ForeColor = System.Drawing.Color.White;

            tiempo = (Label)GetAll(formTemp, typeof(Label)).Where(d => d.Name == "lblTiempo").FirstOrDefault();
        }

        private static string GenerarToken()
        {
            String usuarioActual = Sesion.usuario.Login;
            int randomNumber1 = new Random().Next(100000, 1000000);
            int randomNumber2 = new Random().Next(1000000, 10000000);
            return Util.Encriptar(randomNumber1 + usuarioActual + randomNumber2);
        }
        private static bool procesando = false;
        private static async void AsignarListaOcupada(List<Asiento> lOcupada)
        {
            if (!procesando)
            {
                procesando = true;
                lOcupada = await servicio.ListarAsientoDisponibleAsync(reservaTemp.Obra.IdObra, reservaTemp.Funcion.IdFuncion, reservaTemp.FechaReserva, tokenTemp);
                CruzarBotonOcupado(lOcupada);
                procesando = false;
            }
        }
        private static void CruzarBotonOcupado(List<Asiento> lista)
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
        
        private static void timerTeatro_Tick(object sender, EventArgs e)
        {
            contador++;
            span = span.Subtract(TimeSpan.Parse("00:00:01"));
            tiempo.Text = span.ToString();
            if (span.Hours == 0 && span.Minutes == 0 && span.Seconds == 0)
            {
                EliminarSeparadas(tokenTemp);
                formTemp.Close();
                Timer timer = (Timer)sender;
                timer.Dispose();
            }
            
        }
        public static async void MostrarDisponibilidad(Form form,Reserva reserva)
        {
            

            span = new TimeSpan(0, limitMinutesTime, limitSecondsTime);
            asientosReserva = new List<AsientoZona>();
            tokenTemp = GenerarToken();
            reservaTemp = reserva;
            formTemp = form;
            contador = 0;

            try
            {
                Animacion.ShowLoader(form);
                lAsientoTotal = await servicio.listarAsientoTeatroAsync(reserva.Obra.IdObra);
                lOcupados = await servicio.ListarAsientoDisponibleAsync(reservaTemp.Obra.IdObra, reservaTemp.Funcion.IdFuncion, reservaTemp.FechaReserva,tokenTemp);
                CruzarBotonData(lAsientoTotal, form);
                AsignarListaOcupada(lOcupados);
                SetEventosBoton();
                timer = new Timer();
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Tick += new EventHandler(timerTeatro_Tick);

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
        private static List<AsientoZona> Clonar(List<AsientoZona> lista)
        {
            List<AsientoZona> listaClonar = new List<AsientoZona>();
            foreach (AsientoZona asiento in lista)
            {
                listaClonar.Add(new AsientoZona(asiento));
            }
            return listaClonar;
        }


        private static void ConfirmarReserva(object sender, EventArgs e)
        {
            if (asientosReserva.Count > 0)
            {
                ConfirmReservation info = new ConfirmReservation(formTemp, reservaTemp,span);
                info.listaAsientoPrecio = Clonar(asientosReserva);
                info.listaAsientoPrecio.ForEach(ap => {
                    lAsientoTotal.ForEach(a =>
                    {
                        if (a.Asiento.IdAsiento == ap.Asiento.IdAsiento)
                        {
                            ap.Zona = a.Zona;
                        }
                    });
                });
                info.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un asiento", "Aviso");
            }

        }

        private async static void ReservarAsiento(Button btnAsiento, AsientoZona asiento)
        {
            Animacion.ShowLoader(formTemp);
            if (asiento.EstadoTemporal == "" || asiento.EstadoTemporal == null)
            {
                Boolean exito = await servicio.InserAsientoTemporalAsync(reservaTemp.Funcion.IdFuncion, asiento.Asiento.IdAsiento, reservaTemp.FechaReserva, tokenTemp);
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
                Boolean exito = await servicio.EliminarAsientoTemporalAsync(reservaTemp.Funcion.IdFuncion, asiento.Asiento.IdAsiento, reservaTemp.FechaReserva, tokenTemp);
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
        private static void ReservarAsientoClick(object sender, EventArgs e)
        {
            Button btnAsiento = (Button)sender;
            AsientoZona asiento = (AsientoZona)btnAsiento.Tag;
            ReservarAsiento(btnAsiento, asiento);
            
        }
        public static void CancelarReservaAsiento()
        {
            EliminarSeparadas(tokenTemp);
        }
        private static void CancelarAsientoTotal(object sender, EventArgs e)
        {
            if (asientosReserva.Count > 0)
            {
                if (MessageBox.Show("Se perderan todos los cambios realizados hasta el momento. ¿ Seguro de regresar ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EliminarSeparadas(tokenTemp);
                }
            }
            else
            {
                EliminarSeparadas(tokenTemp);
            }
        }
        private static void MiminizarTeatro(object sender, EventArgs e)
        {
            formTemp.WindowState = FormWindowState.Minimized;
        }
    }
}
