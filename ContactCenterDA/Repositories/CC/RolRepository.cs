using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.RolBE;
using System.Data.OleDb;
using System.Data;

namespace ContactCenterDA.Repositories.CC
{
    public class RolRepository : IRolRepository
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
                string sql = String.Format("DELETE FROM CC_ROL WHERE IdRol = {0}",
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

        public Rol GetById(int id)
        {
            Rol objRol = null;

            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_ROL WHERE IdRol = {0}", id);
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objRol = new Rol();
                    objRol.IdRol = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdRol")).ToString());
                    objRol.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                    objRol.Estado = dtr.GetValue(dtr.GetOrdinal("Estado")).ToString();
                    objRol.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                    objRol.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                    objRol.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                    objRol.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();

                    dtr.Close();
                }

                return objRol;
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


        public IList<Rol> GetLista()
        {

            List<Rol> listaRol = null;

            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_ROL");
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        Rol objRol = new Rol();
                        objRol.IdRol = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdRol")).ToString());
                        objRol.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                        objRol.Estado = dtr.GetValue(dtr.GetOrdinal("Estado")).ToString();
                        objRol.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                        objRol.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                        objRol.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                        objRol.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();
                        listaRol.Add(objRol);
                    }

                    dtr.Close();
                }


                return listaRol;
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

        public void Insert(Rol datos)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            string sql = String.Format("INSERTO INTO CC_ROL(Nombre, Estado, FechaCrea, UsuarioCrea, FechaMod, UsuarioMod) " +
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}')",
                                         datos.Nombre, datos.Estado, datos.FechaCreacion, datos.UsuarioCreacion,
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

        public void Update(Rol datos)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("UPDATE CC_ROL SET Nombre = {0}, Estado = {1}, FechaCrea = {2}, UsuarioCrea = {3}, FechaMod = {4}, UsuarioMod = {5} where IdCliente = {6}",
                                        datos.Nombre, datos.Estado, datos.FechaCreacion, datos.UsuarioCreacion,
                                        datos.FechaModificacion, datos.UsuarioModificacion, datos.IdRol);
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
