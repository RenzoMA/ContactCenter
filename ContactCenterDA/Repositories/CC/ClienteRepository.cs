using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.CLienteBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;

namespace ContactCenterDA.Repositories.CC
{
    public class ClienteRepository : IClienteRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE CC_Cliente SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IdCliente = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, codigo);

        }

        public Cliente GetById(int id)
        {
            Cliente objCliente = null;

            String sql = "SELECT * FROM CC_Cliente WHERE IdCliente = @idCliente";

            OleDbParameter codigo = UtilDA.SetParameters("@idCliente", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                while (dtr.Read())
                {
                    objCliente = new Cliente();
                    objCliente.IdCliente = DataConvert.ToInt(dtr["IdCliente"]);
                    objCliente.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objCliente.ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]);
                    objCliente.Apellidomaterno = DataConvert.ToString(dtr["ApeMaterno"]);
                    objCliente.Telefono = DataConvert.ToString(dtr["Telefono"]);
                    objCliente.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objCliente.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objCliente.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objCliente.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    objCliente.DNI = DataConvert.ToString(dtr["DNI"]);

                }
            }
            UtilDA.Close(cnx);
            return objCliente;
        }

        public IList<Cliente> GetLista()
        {
            List<Cliente> listaCliente = new List<Cliente>();

            String sql = "SELECT * FROM CC_Cliente";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = DataConvert.ToInt(dtr["IdCliente"]);
                    objCliente.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objCliente.ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]);
                    objCliente.Apellidomaterno = DataConvert.ToString(dtr["ApeMaterno"]);
                    objCliente.Telefono = DataConvert.ToString(dtr["Telefono"]);
                    objCliente.Correo = DataConvert.ToString(dtr["Correo"]);
                    objCliente.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objCliente.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objCliente.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objCliente.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    objCliente.DNI = DataConvert.ToString(dtr["DNI"]);
                    listaCliente.Add(objCliente);
                }
            }
            UtilDA.Close(cnx);
            return listaCliente;
        }

        public bool Insert(Cliente datos)
        {

            String sql = "INSERT INTO CC_Cliente(Nombre, ApePaterno, ApeMaterno, Correo, Telefono, FechaCrea, UserCrea,DNI) " +
                                       "VALUES(@nombre,@apePaterno,@apeMaterno,@correo,@telefono ,@fechaCrea, @usuarioCrea,@DNI)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter apePaterno = UtilDA.SetParameters("@apePaterno", OleDbType.VarChar, datos.ApellidoPaterno);
            OleDbParameter apeMaterno = UtilDA.SetParameters("@apeMaterno", OleDbType.VarChar, datos.Apellidomaterno);       
            OleDbParameter telefono = UtilDA.SetParameters("@telefono", OleDbType.VarChar, datos.Telefono);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter UsuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pDNI = UtilDA.SetParameters("@DNI", OleDbType.VarChar, datos.DNI);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, apePaterno, apeMaterno, correo, telefono, fechaCrea, UsuarioCrea, pDNI);
           
        }

        public bool Update(Cliente datos)
        {
            String sql = "UPDATE CC_Cliente SET Nombre = @nombre, ApePaterno = @apePaterno, ApeMaterno = @apeMaterno, Correo = @correo, " +
                                       "Telefono = @telefono, FechaMod = @fechaMod, UserMod = @usuarioMod, DNI = @DNI WHERE IdCliente = @idCliente";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter apePaterno = UtilDA.SetParameters("@apePaterno", OleDbType.VarChar, datos.ApellidoPaterno);
            OleDbParameter apeMaterno = UtilDA.SetParameters("@apeMaterno", OleDbType.VarChar, datos.Apellidomaterno);
            OleDbParameter telefono = UtilDA.SetParameters("@telefono", OleDbType.VarChar, datos.Telefono);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idcliente = UtilDA.SetParameters("@idCliente", OleDbType.Integer, datos.IdCliente);
            OleDbParameter pDNI = UtilDA.SetParameters("@DNI", OleDbType.VarChar, datos.DNI);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, apePaterno, apeMaterno, correo, telefono, fechaMod, usuarioMod, pDNI, idcliente);
        }

        public Cliente GetByTelefono(string telefono)
        {
            Cliente objCliente = null;

            String sql = "SELECT * FROM CC_Cliente WHERE Telefono = @telefono";

            OleDbParameter pTelefono = UtilDA.SetParameters("@telefono", OleDbType.VarChar, telefono);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pTelefono))
            {
                while (dtr.Read())
                {
                    objCliente = new Cliente();
                    objCliente.IdCliente = DataConvert.ToInt(dtr["IdCliente"]);
                    objCliente.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objCliente.ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]);
                    objCliente.Apellidomaterno = DataConvert.ToString(dtr["ApeMaterno"]);
                    objCliente.Telefono = DataConvert.ToString(dtr["Telefono"]);
                    objCliente.Correo = DataConvert.ToString(dtr["Correo"]);
                    objCliente.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objCliente.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objCliente.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objCliente.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    objCliente.DNI = DataConvert.ToString(dtr["DNI"]);
                }
            }
            UtilDA.Close(cnx);
            return objCliente;
        }

        public int GetNewIdCliente(Cliente cliente)
        {

            String sql = "INSERT INTO CC_Cliente(Nombre, ApePaterno, ApeMaterno, Correo, Telefono, FechaCrea, UserCrea,DNI) " +
                                       "VALUES(@nombre,@apePaterno,@apeMaterno,@correo,@telefono ,@fechaCrea, @usuarioCrea,@DNI)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, cliente.Nombre);
            OleDbParameter apePaterno = UtilDA.SetParameters("@apePaterno", OleDbType.VarChar, cliente.ApellidoPaterno);
            OleDbParameter apeMaterno = UtilDA.SetParameters("@apeMaterno", OleDbType.VarChar, cliente.Apellidomaterno);
            OleDbParameter telefono = UtilDA.SetParameters("@telefono", OleDbType.VarChar, cliente.Telefono);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, cliente.Correo);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter UsuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pDNI = UtilDA.SetParameters("@DNI", OleDbType.VarChar, cliente.DNI);
            int idCliente = UtilDA.ExecuteNonQueryGetId(cmd, CommandType.Text, sql, cnx, false, nombre, apePaterno, apeMaterno, correo, telefono, fechaCrea, UsuarioCrea, pDNI);
            return idCliente;
        }
    }
}

