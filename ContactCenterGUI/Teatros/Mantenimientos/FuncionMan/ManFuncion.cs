﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using MaterialSkin.Controls;
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using MaterialSkin.Animations;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.FuncionMan
{
    public partial class ManFuncion : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();

        private List<Teatro> listaTeatro = null;
        private Teatro teatro = null;

        private List<Obra> listaObra = null;
        private Obra obra = null;



        public ManFuncion()
        {
            InitializeComponent();
            
        }

        private void ManFuncion_Load(object sender, EventArgs e)
        {
            CargarTeatros();
            dgvFuncion.AutoGenerateColumns = false;
        }

        private async void CargarTeatros()
        {
            try
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    Animacion.ShowLoader(this);
                    listaTeatro = await servicio.ListarTeatrosAsync();
                    Animacion.HideLoader(this);
                    cboTeatro.DataSource = listaTeatro;
                    cboTeatro.DisplayMember = "Nombre";
                }
                CargarObras();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarObras()
        {
            try
            {
                teatro = cboTeatro.SelectedItem as Teatro;
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaObra = servicio.ComboManGetListaTeatro(teatro.IdTeatro);
                    cboObra.DataSource = listaObra;
                    cboObra.DisplayMember = "Nombre";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cboObra.SelectedIndex != 0 && cboTeatro.SelectedIndex != 0)
            {
                EnlazarGrilla();
            }
            else
            {
                MessageBox.Show("Completar todos los campos","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTeatro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObras();
        }

        private void EnlazarGrilla()
        {
            try
            {
                teatro = cboTeatro.SelectedItem as Teatro;
                obra = cboObra.SelectedItem as Obra;

                if (teatro.IdTeatro > 0 && obra.IdObra > 0)
                {
                    using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                    {
                        List<Funcion> listFuncion = servicio.ListarFuncionByObraGrilla(obra.IdObra);
                        dgvFuncion.DataSource = listFuncion;

                        String[] diasNombre = new String[7] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

                        foreach (DataGridViewRow row in dgvFuncion.Rows)
                        {

                            int indice = Convert.ToInt32(row.Cells[3].Value);

                            String nombre = diasNombre.ElementAt(indice);

                            row.Cells[4].Value = nombre;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            ManFuncionCreate manFunCreate = new ManFuncionCreate();
            manFunCreate.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvFuncion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idTarifa = Convert.ToInt32(dgvFuncion.CurrentRow.Cells[2].Value);
            try
            {
                if (e.ColumnIndex == 1)
                {
                    if (servicio.EliminarFuncion(idTarifa))
                    {
                        MessageBox.Show("La función se eliminó correctamente");
                        EnlazarGrilla();
                    }
                    else
                    {
                        MessageBox.Show("Hubo inconvenientes al eliminar la reserva, por favor intente nuevamente");
                    }
                }

                else if (e.ColumnIndex == 0)
                {
                    Funcion funcion = (Funcion)dgvFuncion.CurrentRow.DataBoundItem;
                    ManFuncionEdit manFuncionEdit = new ManFuncionEdit(funcion);
                    manFuncionEdit.ShowDialog();
                    EnlazarGrilla();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
