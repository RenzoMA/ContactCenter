using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.CLienteBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;

namespace ContactCenterDA.Repositories.CC
{
    public class ClienteRepository : IClienteRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public void Delete(int id)
        {
            try
            {
                cnx.ConnectionString = cnx.GetCnx();
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM CC_CLIENTE WHERE IdCliente = {0}",
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

        public Cliente GetById(int id)
        {
            Cliente objCliente = null;

            try
            {
                cnx.ConnectionString = cnx.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_CLIENTE WHERE IdCliente = {0}", id);
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdCliente")).ToString());
                    objCliente.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                    objCliente.ApellidoPaterno = dtr.GetValue(dtr.GetOrdinal("ApePaterno")).ToString();
                    objCliente.Apellidomaterno = dtr.GetValue(dtr.GetOrdinal("ApeMaterno")).ToString();
                    objCliente.Telefono = dtr.GetValue(dtr.GetOrdinal("Telefono")).ToString();
                    objCliente.Correo = dtr.GetValue(dtr.GetOrdinal("Correo")).ToString();
                    objCliente.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                    objCliente.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                    objCliente.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                    objCliente.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();

                    dtr.Close();
                }

                return objCliente;
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

        public IList<Cliente> GetLista()
        {
            List<Cliente> listaCliente = null;

            try
            {
                cnx.ConnectionString = cnx.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM CC_CLIENTE");
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        Cliente objCliente = new Cliente();
                        objCliente.IdCliente = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdCliente")).ToString());
                        objCliente.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                        objCliente.ApellidoPaterno = dtr.GetValue(dtr.GetOrdinal("ApePaterno")).ToString();
                        objCliente.Apellidomaterno = dtr.GetValue(dtr.GetOrdinal("ApeMaterno")).ToString();
                        objCliente.Correo = dtr.GetValue(dtr.GetOrdinal("Correo")).ToString();
                        objCliente.Telefono = dtr.GetValue(dtr.GetOrdinal("Telefono")).ToString();
                        objCliente.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                        objCliente.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                        objCliente.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                        objCliente.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();
                        listaCliente.Add(objCliente);
                    }

                    dtr.Close();
                }


                return listaCliente;
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

        public void Insert(Cliente datos)
        {

            cnx.ConnectionString = cnx.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            string sql = String.Format("INSERTO INTO CC_CLIENTE(Nombre, ApePaterno, ApeMaterno, Correo, Telefono, FechaCrea, UsuarioCrea, FechaMod, UsuarioMod) " +
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                         datos.Nombre, datos.ApellidoPaterno, datos.Apellidomaterno, datos.Correo, datos.Telefono, datos.FechaCreacion, datos.UsuarioCreacion,
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

        public void Update(Cliente datos)
        {
            cnx.ConnectionString = cnx.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("UPDATE CC_CLIENTE SET Nombre = {0}, ApePaterno = {1}, ApeMaterno = {2}, ApePaterno = {3}, Correo = {4}" +
                                        "Telefono = '{5}', FechaCrea = {6}, UsuarioCrea = {7}, FechaMod = {8}, UsuarioMod = {9} where IdCliente = {10}",
                                        datos.Nombre, datos.ApellidoPaterno, datos.Apellidomaterno, datos.Correo, datos.Telefono, datos.FechaCreacion, datos.UsuarioCreacion,
                                        datos.FechaModificacion, datos.UsuarioModificacion, datos.IdCliente);
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

