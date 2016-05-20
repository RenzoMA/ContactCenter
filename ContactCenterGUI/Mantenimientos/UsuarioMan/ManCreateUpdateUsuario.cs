using System;
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
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterGUI.Helpers;

namespace ContactCenterGUI.Mantenimientos.UsuarioMan
{
    public partial class ManCreateUpdateUsuario : MaterialForm
    {
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private bool isCreating;
        private Usuario usuario;
        private List<Aplicacion> listaAplicacion = new List<Aplicacion>();
        private List<Rol> listaRol;

        public ManCreateUpdateUsuario(bool isCreating, Usuario usuario = null)
        {
            InitializeComponent();
            this.isCreating = isCreating;
            this.usuario = usuario;
        }
        private bool ValidarContraseñas()
        {
            if (txtContraseña.Text.Trim().Length < 5)
            {
                MessageBox.Show("Contraseña debe contener al menos de 5 caracteres", "Aviso");
                return false;
            }
            if (txtContraseña.Text.Equals(txtRepiteContraseña.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Contraseñas no coinciden", "Aviso");
                return false;
            }
        }
        private Rol FindRol(Rol rol)
        {
            return listaRol.Where(tx => tx.IdRol == rol.IdRol).FirstOrDefault();
        }

        private void LoadRoles()
        {
            listaRol = servicio.ListarRol();
            cboRol.DataSource = listaRol;
            cboRol.DisplayMember = "Nombre";
        }
        private void ManCreateUpdateUsuario_Load(object sender, EventArgs e)
        {
            EnlazarListaAplicacion();
            LoadRoles();
            if (isCreating)
            {
                this.Text = "Crear nuevo usuario";
                btnCreaUpdate.MouseClick += new MouseEventHandler(CrearUsuario);
                btnCreaUpdate.Text = "Crear";
            }
            else
            {
                this.Text = "Modificar usuario";
                btnCreaUpdate.MouseClick += new MouseEventHandler(EditarUsuario);
                btnCreaUpdate.Text = "Editar";
                OcultarCamposEdicion();
                PopularDatos();
            }
            SetEventos();
        }
        private void OcultarCamposCreacion()
        {
            lblEstado.Visible = false;
            cboEstado.Visible = false;
            txtLogin.Visible = false;
            lblLogin.Visible = false;
        }
        private void SetEventos()
        {
            txtNombre.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtApeMaterno.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtApePaterno.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtLogin.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtCorreo.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtCorreo.Validating += new CancelEventHandler(HelperControl.ValidEmail);
        }
        private void EnlazarListaAplicacion()
        {
            lstAplicaciones.DataSource = servicio.ListarAplicaciones();
            lstAplicaciones.DisplayMember = "Nombre";
        }
        private void OcultarCamposEdicion()
        {
            txtContraseña.Visible = false;
            txtRepiteContraseña.Visible = false;
            lblContraseña.Visible = false;
            lblRepiteContraseña.Visible = false;
        }
        private void PopularDatos()
        {
            txtNombre.Text = usuario.Nombre;
            txtApeMaterno.Text = usuario.ApellidoMaterno;
            txtApePaterno.Text = usuario.ApellidoPaterno;
            txtLogin.Text = usuario.Login;
            txtCorreo.Text = usuario.Correo;
            cboRol.SelectedItem = FindRol(usuario.Rol);
            cboEstado.SelectedIndex = usuario.Estado == "A" ? 0 : 1;
            CargarListaPermiso();
            
        }
        private void CargarListaPermiso()
        {
            listaAplicacion = usuario.Aplicaciones;
            lstPermisos.DisplayMember = "Nombre";
            lstPermisos.DataSource = listaAplicacion;
        }

        private void CrearUsuario(object sender, EventArgs e)
        {
            if (ValidarContraseñas() && ValidarCampos())
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = txtNombre.Text,
                    ApellidoMaterno = txtApeMaterno.Text,
                    ApellidoPaterno = txtApePaterno.Text,
                    Contraseña = txtContraseña.Text,
                    Correo = txtCorreo.Text,
                    Login = txtLogin.Text,
                    Aplicaciones = listaAplicacion,
                    Rol = cboRol.SelectedItem as Rol
                };
                if (servicio.InsertarUsuario(usuario))
                {
                    MessageBox.Show("Usuario creado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verifique todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            if (txtApeMaterno.Text.Trim().Equals(String.Empty))
                return false;
            if (txtApePaterno.Text.Trim().Equals(String.Empty))
                return false;
            if (isCreating)
            {
                if (txtLogin.Text.Trim().Equals(String.Empty))
                    return false;
                if (txtContraseña.Text.Trim().Equals(String.Empty))
                    return false;
            }
            return true;

        }
        private void EditarUsuario(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                usuario.Nombre = txtNombre.Text.Trim();
                usuario.ApellidoMaterno = txtApeMaterno.Text.Trim();
                usuario.ApellidoPaterno = txtApePaterno.Text.Trim();
                usuario.Correo = txtCorreo.Text.Trim();
                usuario.Login = txtLogin.Text.Trim();
                usuario.Aplicaciones = listaAplicacion;
                usuario.Rol = cboRol.SelectedItem as Rol;
                usuario.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";

                if (servicio.UpdateUsuario(usuario))
                {
                    MessageBox.Show("Usuario editado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verifique todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnlazarListaPermiso()
        {
            lstPermisos.DataSource = null;
            lstPermisos.DataSource = listaAplicacion;
            lstPermisos.DisplayMember = "Nombre";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Aplicacion aplicacion = (Aplicacion)lstAplicaciones.SelectedItem;
            if (!BuscarAplicacion(aplicacion))
            {
                listaAplicacion.Add(aplicacion);
                EnlazarListaPermiso();
            }
        }
        private bool BuscarAplicacion(Aplicacion aplicacion)
        {
            foreach (Aplicacion app in listaAplicacion)
            {
                if (app.IdAplicacion == aplicacion.IdAplicacion)
                    return true;
            }
            return false;
        }
        private void DeleteAplicacion(Aplicacion aplicacion)
        {
            for (int x = listaAplicacion.Count - 1; x >= 0; x--)
            {
                if (listaAplicacion[x].IdAplicacion == aplicacion.IdAplicacion)
                {
                    listaAplicacion.Remove(listaAplicacion[x]);
                    break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPermisos.SelectedItems.Count > 0)
            {
                Aplicacion aplicacion = (Aplicacion)lstPermisos.SelectedItem;
                DeleteAplicacion(aplicacion);
                EnlazarListaPermiso();
            }
        }
    }
}
