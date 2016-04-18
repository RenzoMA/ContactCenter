using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using System.Data.OleDb;
using System.Data;


namespace ContactCenterDA.Repositories.CC
{
    public class AplicacionRepository : IAplicacionRepository
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
                string sql = String.Format("DELETE FROM CC_APLICACION WHERE IdAplicacion = {0}",
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

        public Aplicacion GetById(int id)
        {
            Aplicacion objAplicacion = null;

            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_Aplicacion WHERE IdAplicacion = {0}", id);
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objAplicacion = new Aplicacion();
                    objAplicacion.IdAplicacion = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdAplicacion")).ToString());
                    objAplicacion.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                    objAplicacion.Version = dtr.GetValue(dtr.GetOrdinal("Version")).ToString();
                    objAplicacion.Estado = dtr.GetValue(dtr.GetOrdinal("Estado")).ToString();
                    objAplicacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                    objAplicacion.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                    objAplicacion.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                    objAplicacion.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();

                    dtr.Close();
                }

                return objAplicacion;
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

        public IList<Aplicacion> GetLista()
        {
            List<Aplicacion> listaAplicacion = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_Aplicacion");
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        Aplicacion objAplicacion = new Aplicacion();
                        objAplicacion.IdAplicacion = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdAplicacion")).ToString());
                        objAplicacion.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                        objAplicacion.Version = dtr.GetValue(dtr.GetOrdinal("Version")).ToString();
                        objAplicacion.Estado = dtr.GetValue(dtr.GetOrdinal("Estado")).ToString();
                        objAplicacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                        objAplicacion.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                        objAplicacion.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                        objAplicacion.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();
                        listaAplicacion.Add(objAplicacion);

                    }

                    dtr.Close();
                }

                return listaAplicacion;
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

        public void Insert(Aplicacion datos)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            string sql = String.Format("INSERTO INTO CC_APLICACION(Nombre, Version, Estado, Correo, FechaCrea, UsuarioCrea, FechaMod, UsuarioMod) " +
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                                         datos.Nombre, datos.Version, datos.Estado, datos.Correo, datos.FechaCreacion, datos.UsuarioCreacion,
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

        public void Update(Aplicacion datos)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("UPDATE CC_APLICACION SET Nombre = {0}, Version = {1}, Estado = {2}, Correo = {3}" +
                                        "FechaCrea = {4}, UsuarioCrea = {5}, FechaMod = {6}, UsuarioMod = {7} where IdAplicacion = {8}",
                                        datos.Nombre, datos.Version, datos.Estado, datos.Correo, datos.FechaCreacion, datos.UsuarioCreacion,
                                        datos.FechaModificacion, datos.UsuarioModificacion, datos.IdAplicacion);
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
