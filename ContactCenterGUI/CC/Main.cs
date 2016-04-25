﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.Util;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterCommon;


namespace ContactCenterGUI.CC
{
    public partial class Main : MaterialForm
    {
        List<Aplicacion> listaAplicacion;
        int positionX;
        int positionY;
        int buttonHeight = 134;
        int buttonWidth = 194;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopularPantalla();
        }

        private async void PopularPantalla()
        {
            try
            {
                Animacion.ShowLoader(this);
                IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
                listaAplicacion = await servicio.ListarAplicacionUsuarioAsync(Sesion.usuario);
                GenerarMenu(listaAplicacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Aviso");
            }
            finally
            {
                Animacion.HideLoader(this);
            }
            
        }

        private void LimpiarXCoordenadas()
        {
            positionX = 45;
        }
        private void LimpiarYCoordenadas()
        {
            positionY = 120;
        }

        private void CoordSiguienteElemento(int x, int y)
        {
            int width = this.Width;
            int height = this.Height;
            int marginRight = 50;
            int marginBottom = 30;

            if ((x + marginRight + (buttonWidth * 2)) > width)
            {
                LimpiarXCoordenadas();
                positionY += marginBottom + buttonHeight;
            }
            else
            {
                positionX += marginRight + buttonWidth;
            }

        }

        private void GenerarMenu(List<Aplicacion> lAplicacion)
        {
            LimpiarXCoordenadas();
            LimpiarYCoordenadas();
            foreach (Aplicacion aplicacion in lAplicacion)
            {
                GenerarElemento(aplicacion);
            }
        }

        void elemento_Click(object sender, EventArgs e)
        {
            Button btnElemento = (Button)sender;
            Aplicacion aplicacion = (Aplicacion)btnElemento.Tag;
            setApplication(aplicacion);
            changeForm(aplicacion.FormInicio,aplicacion.Nombre, true);
        }

        void changeForm(string formName,string aplicacion, bool hide)
        {
            
            Type CAType = Type.GetType("ContactCenterGUI." + aplicacion + "."+ formName);
            if (CAType != null)
            {
                if (hide) this.Hide();
                Form nextForm2 = (Form)Activator.CreateInstance(CAType);
                nextForm2.ShowDialog();
                if (hide) this.Show();
            }
            else
            {
                MessageBox.Show("Aplicación no disponible");
            }
        }

        void setApplication(Aplicacion aplicacion)
        {
            Sesion.aplicacion = aplicacion;
        }

        private void GenerarElemento(Aplicacion aplicacion)
        {
            Button btn = new Button();
            btn.Tag = aplicacion;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            btn.BackgroundImage = global::ContactCenterGUI.Properties.Resources.teatro;
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Name = aplicacion.IdAplicacion.ToString();
            btn.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btn.UseVisualStyleBackColor = false;
            btn.Location = new System.Drawing.Point(positionX, positionY);
            btn.Click += elemento_Click;
            this.Controls.Add(btn);
            CoordSiguienteElemento(positionX, positionY);
        }
    }
}