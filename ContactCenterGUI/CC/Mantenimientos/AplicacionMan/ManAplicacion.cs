﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ContactCenterServices;
using MaterialSkin.Animations;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.AplicacionBE;

namespace ContactCenterGUI.CC.Mantenimientos.AplicacionMan
{
    public partial class ManAplicacion : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        public ManAplicacion()
        {
            InitializeComponent();
            dgbAplicacion.AutoGenerateColumns = false;
        }

        private void EnlazarGrilla()
        {
            dgbAplicacion.DataSource = servicio.ListarAplicaciones();
        }

        private void dgbAplicacion_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Aplicacion aplicacion = (Aplicacion)dgbAplicacion.CurrentRow.DataBoundItem;
                ManAplicacionEditar editarAplicacion = new ManAplicacionEditar(aplicacion);
                editarAplicacion.ShowDialog();
                EnlazarGrilla();
            }
        }

        private void ManAplicacion_Load(object sender, EventArgs e)
        {
            EnlazarGrilla();
        }
    }
}
