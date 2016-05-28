﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using MaterialSkin.Controls;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using MaterialSkin.Animations;
using ContactCenterGUI.CC.Helpers;

namespace ContactCenterGUI.Teatros.Mantenimientos.FuncionMan
{
    public partial class ManFuncionEdit : MaterialForm
    {
        Funcion funcion = null;
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private Teatro teatro = null;
        private List<Teatro> listaTeatro;
        private Obra obra = null;
        private List<Obra> listaObra;

        public ManFuncionEdit(Funcion funcion)
        {
            this.funcion = funcion;
            InitializeComponent();
        }

        private void ManFuncionEdit_Load(object sender, EventArgs e)
        {
            //SetEventos();
            SetTextCboDia();
            InicializarControles();
            LoadData();
        }

        private void InicializarControles()
        {
            cboObra.Enabled = false;
            cboTeatro.Enabled = false;
        }


        private void LoadData()
        {
            listaTeatro = servicio.ListarTeatros();
            cboTeatro.DataSource = listaTeatro;
            cboTeatro.DisplayMember = "Nombre";
            cboTeatro.SelectedItem = FindTeatro(funcion.Obra.Teatro.IdTeatro);

            teatro = cboTeatro.SelectedItem as Teatro;
            listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
            cboObra.DataSource = listaObra;
            cboObra.DisplayMember = "Nombre";
            cboObra.SelectedItem = FindObra(funcion.Obra.IdObra);

            cboDia.SelectedIndex = funcion.Dia + 1;
            cboEstado.SelectedIndex = funcion.Estado == "Activo" ? 0 : 1;
            txtHoarario.Text = funcion.Horario;
            }

        private Teatro FindTeatro(int idTeatro)
        {
            return listaTeatro.Where(tx => tx.IdTeatro == idTeatro).FirstOrDefault();
        }

        private Obra FindObra(int idObra)
        {
            return listaObra.Where(tx => tx.IdObra == idObra).FirstOrDefault();
        }

        private void CapturarDatos()
        {
            obra = cboObra.SelectedItem as Obra;

            funcion.Obra = obra;
            funcion.Dia = Convert.ToInt32(cboDia.SelectedIndex) - 1;
            funcion.Horario = txtHoarario.Text;
            funcion.Estado = cboEstado.SelectedIndex == 0 ? "A"  :"I";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cboTeatro.SelectedIndex != 0 || cboObra.SelectedIndex != 0
                || cboDia.SelectedIndex != 0 || txtHoarario.Text.Trim().Equals(String.Empty))
            {
                CapturarDatos();
                if (servicio.ActualizarFuncion(funcion))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Completo los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEventos()
        {
            txtHoarario.KeyPress += HelperControl.EditTextDecimal;
        }

        private void SetTextCboDia()
        {
            cboDia.DropDownStyle = ComboBoxStyle.DropDown;
            cboDia.Text = "Seleccione día";
        }

    }
}
