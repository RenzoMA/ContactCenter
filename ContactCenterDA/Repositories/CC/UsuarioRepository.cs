using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using System.Data.OleDb;
using System.Data;

namespace ContactCenterDA.Repositories.CC
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);


        public void Delete(int id)
        {
           
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM CC_USUARIO WHERE IdUsuario = {0}",
                                            id);
                cmd.CommandText = sql;
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public Usuario GetById(int id)
        {
            Usuario objUsuario = null;

            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_USUARIO WHERE IdUsuario = {0}", id);
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objUsuario = new Usuario();
                    objUsuario.IdUsuario = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdRol")).ToString());
                    objUsuario.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                    objUsuario.ApellidoPaterno = dtr.GetValue(dtr.GetOrdinal("ApePaterno")).ToString();
                    objUsuario.ApellidoMaterno = dtr.GetValue(dtr.GetOrdinal("ApeMaterno")).ToString();
                    objUsuario.Correo = dtr.GetValue(dtr.GetOrdinal("Correo")).ToString();
                    objUsuario.Login = dtr.GetValue(dtr.GetOrdinal("Login")).ToString();
                    objUsuario.Contraseña = dtr.GetValue(dtr.GetOrdinal("Contraseña")).ToString();
                    objUsuario.Rol.IdRol = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdRol")).ToString());
                    objUsuario.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                    objUsuario.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                    objUsuario.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                    objUsuario.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();

                    dtr.Close();
                }

                return objUsuario;
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public IList<Usuario> GetLista()
        {
            List<Usuario> listaUsuario = null;

            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_USUARIO");
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        Usuario objUsuario = new Usuario();
                        objUsuario.IdUsuario = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdRol")).ToString());
                        objUsuario.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                        objUsuario.ApellidoPaterno = dtr.GetValue(dtr.GetOrdinal("ApePaterno")).ToString();
                        objUsuario.ApellidoMaterno = dtr.GetValue(dtr.GetOrdinal("ApeMaterno")).ToString();
                        objUsuario.Correo = dtr.GetValue(dtr.GetOrdinal("Correo")).ToString();
                        objUsuario.Login = dtr.GetValue(dtr.GetOrdinal("Login")).ToString();
                        objUsuario.Contraseña = dtr.GetValue(dtr.GetOrdinal("Contraseña")).ToString();
                        objUsuario.Rol.IdRol = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdRol")).ToString());
                        objUsuario.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                        objUsuario.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                        objUsuario.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                        objUsuario.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();
                        listaUsuario.Add(objUsuario);
                    }

                    dtr.Close();
                }


                return listaUsuario;
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public void Insert(Usuario datos)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            string sql = String.Format("INSERTO INTO CC_USUARIO(Nombre, ApePaterno, ApeMaterno, Correo, Login, Contraseña, IdRol, FechaCrea, UsuarioCre, FechaMod, UsuarioMod) " +
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                         datos.Nombre, datos.ApellidoPaterno, datos.ApellidoMaterno, datos.Correo, datos.Login, datos.Contraseña, datos.Rol, datos.FechaCreacion, datos.UsuarioCreacion,
                                         datos.FechaModificacion, datos.UsuarioModificacion);
            cmd.CommandText = sql;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public void Update(Usuario datos)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("UPDATE CC_USUARIO SET Nombre = {0}, Estado = {1}, ApePaterno = {2}, ApeMaterno = {3}, Correo = {4}, Login = {5}, Contraseña = {6}, Rol = {7}" +
                                        "FechaCrea = {8}, UsuarioCrea = {9}, FechaMod = {10}, UsuarioMod = {11} where IdUsuario = {12}",
                                        datos.Nombre, datos.ApellidoPaterno, datos.ApellidoMaterno, datos.Correo, datos.Login, datos.Contraseña, datos.Rol, datos.FechaCreacion, datos.UsuarioCreacion,
                                         datos.FechaModificacion, datos.UsuarioModificacion);
            cmd.CommandText = sql;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }
    }
}
