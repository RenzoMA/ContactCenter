﻿using System;
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
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterGUI.CC.Helpers;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;


namespace ContactCenterGUI.Teatros.Mantenimientos.TarifaMan
{
    public partial class ManTarifa : MaterialForm
    {
        private List<Teatro> listaTeatro = null;
        private Teatro teatro = null;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        private List<Tarifa> listaTarifa = null;
        private Tarifa tarifa = null;

        public ManTarifa()
        {
            InitializeComponent();
            dgvTarifa.AutoGenerateColumns = false;
        }

        private void ManTarifa_Load(object sender, EventArgs e)
        {
            CargarTeatros();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            ManTarifaCreate manTarifaCreate = new ManTarifaCreate();
            manTarifaCreate.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void CargarTeatros()
        {
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                Animacion.ShowLoader(this);
                listaTeatro = await servicio.ListarTeatrosAsync();
                Animacion.HideLoader(this);
                cboTeatro.DataSource = listaTeatro;
                cboTeatro.DisplayMember = "Nombre";
            }
            CargarObras();
        }

        private void CargarObras()
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                cboObra.DataSource = listaObra;
                cboObra.DisplayMember = "Nombre";
            }
        }
        
        private void cboTeatro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObras();
        }

        private void cboObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            obra = cboObra.SelectedItem as Obra;

            if(teatro.IdTeatro > 0 && obra.IdObra > 0)
            {
                using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
                {
                    dgvTarifa.DataSource = servicio.GetListaByTeatroObra(obra.IdObra);
                }
            }          
        }
    }
}
