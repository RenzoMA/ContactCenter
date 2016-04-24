﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterBE.CC.Entidades.RolBE;

namespace ContactCenterDA.Repositories.CC
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);


        public void Delete(int id)
        {
            String sql = "DELETE FROM CC_USUARIO WHERE IdUsuario = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, codigo);
        }

        public Usuario GetById(int id)
        {
            Usuario objUsuario = null;

            String sql = "SELECT * FROM CC_Usuario WHERE IdUsuario = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                while (dtr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.IdUsuario = DataConvert.ToInt(dtr["IdUsuario"]);
                    objUsuario.Nombre = DataConvert.ToString(dtr["Nomnbre"]);
                    objUsuario.ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]);
                    objUsuario.ApellidoMaterno = DataConvert.ToString(dtr["ApeMaterno"]);
                    objUsuario.Correo = DataConvert.ToString(dtr["Correo"]);
                    objUsuario.Login = DataConvert.ToString(dtr["Login"]);
                    objUsuario.Contraseña = DataConvert.ToString(dtr["Contraseña"]);
                    objUsuario.Rol = new Rol()
                    {
                        Estado = DataConvert.ToString(dtr["R.Estado"]),
                        IdRol = DataConvert.ToInt(dtr["R.IdRol"]),
                        Nombre = DataConvert.ToString(dtr["R.Nombre"])
                    };
                    objUsuario.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objUsuario.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objUsuario.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objUsuario.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    objUsuario.Estado = DataConvert.ToString(dtr["Estado"]);
                }
            }
            UtilDA.Close(cnx);
            return objUsuario;
        }

        public IList<Usuario> GetLista()
        {
            List<Usuario> listaUsuario = null;

            String sql = "SELECT * FROM CC_Usuario";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.IdUsuario = DataConvert.ToInt(dtr["IdUsuario"]);
                    objUsuario.Nombre = DataConvert.ToString(dtr["Nomnbre"]);
                    objUsuario.ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]);
                    objUsuario.ApellidoMaterno = DataConvert.ToString(dtr["ApeMaterno"]);
                    objUsuario.Correo = DataConvert.ToString(dtr["Correo"]);
                    objUsuario.Login = DataConvert.ToString(dtr["Login"]);
                    objUsuario.Contraseña = DataConvert.ToString(dtr["Contraseña"]);
                    objUsuario.Rol = new Rol()
                    {
                        Estado = DataConvert.ToString(dtr["R.Estado"]),
                        IdRol = DataConvert.ToInt(dtr["R.IdRol"]),
                        Nombre = DataConvert.ToString(dtr["R.Nombre"])
                    };
                    objUsuario.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objUsuario.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objUsuario.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objUsuario.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    objUsuario.Estado = DataConvert.ToString(dtr["Estado"]);
                    listaUsuario.Add(objUsuario);
                }
            }
            UtilDA.Close(cnx);
            return listaUsuario;
        }

        public void Insert(Usuario datos)
        {
            String sql = "INSERT INTO CC_Usuario(Nombre, ApePaterno, ApeMaterno, Correo, Login, Contraseña, IdRol, FechaCrea, UserCrea) " +
                         "VALUES(@nombre, @apePaterno, @apeMaterno, @correo, @login, @contraseña, @idrol, @fechaCrea, @userCrea)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter apePaterno = UtilDA.SetParameters("@apePaterno", OleDbType.VarChar, datos.ApellidoPaterno);
            OleDbParameter apeMaterno = UtilDA.SetParameters("@apeMaterno", OleDbType.VarChar, datos.ApellidoMaterno);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter login = UtilDA.SetParameters("@login", OleDbType.VarChar, datos.Login);
            OleDbParameter contraseña = UtilDA.SetParameters("@contraseña", OleDbType.VarChar, datos.Contraseña);
            OleDbParameter idrol = UtilDA.SetParameters("@idrol", OleDbType.Integer, datos.Rol);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCreacion", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@UsuarioCrea", OleDbType.VarChar, datos.UsuarioCreacion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);

            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, apePaterno, apeMaterno, correo, login, contraseña, idrol, fechaCreacion, usuarioCrea, estado);
                
        }

        public void Update(Usuario datos)
        {
            String sql = "UPDATE CC_Usuario SET Nombre = @nombre, ApePaterno = @apePaterno, ApeMaterno, @apeMaterno, Correo = @correo, Login = @login, Contraseña = @contraseña " +
                         "IdRol = @idRol, FechaMod = @fechaMod, UserMod = @userMod, Estado = @estado WHERE IdUsuario = @idUsuario";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter apePaterno = UtilDA.SetParameters("@apePaterno", OleDbType.VarChar, datos.ApellidoPaterno);
            OleDbParameter apeMaterno = UtilDA.SetParameters("@apeMaterno", OleDbType.VarChar, datos.ApellidoMaterno);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter login = UtilDA.SetParameters("@login", OleDbType.VarChar, datos.Login);
            OleDbParameter contraseña = UtilDA.SetParameters("@contraseña", OleDbType.VarChar, datos.Contraseña);
            OleDbParameter idrol = UtilDA.SetParameters("@idrol", OleDbType.Integer, datos.Rol);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaCreacion", OleDbType.Date, datos.FechaModificacion);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@UsuarioCrea", OleDbType.VarChar, datos.UsuarioModificacion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idusuario = UtilDA.SetParameters("@idUsuario", OleDbType.Integer, datos.IdUsuario);

            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, apePaterno, apeMaterno, correo, login, contraseña, idrol, fechaMod, usuarioMod, estado, idusuario);


        }

        public Usuario ValidarUsuario(string login, string password)
        {
            Usuario objUsuario = null;

            String sql = "SELECT * FROM CC_USUARIO U INNER JOIN CC_ROL R ON R.IDROL = U.IDROL WHERE U.LOGIN = @login and U.CONTRASEÑA = @contraseña";

            OleDbParameter loginParameter = UtilDA.SetParameters("@login", OleDbType.VarChar, login);
            OleDbParameter passwordParameter = UtilDA.SetParameters("@contraseña", OleDbType.VarChar, password);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, loginParameter, passwordParameter))
            {
                while (dtr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.IdUsuario = DataConvert.ToInt(dtr["IdUsuario"]);
                    objUsuario.Nombre = DataConvert.ToString(dtr["U.Nombre"]);
                    objUsuario.ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]);
                    objUsuario.ApellidoMaterno = DataConvert.ToString(dtr["ApeMaterno"]);
                    objUsuario.Correo = DataConvert.ToString(dtr["Correo"]);
                    objUsuario.Login = DataConvert.ToString(dtr["Login"]);
                    objUsuario.Rol = new Rol()
                    {
                        Estado = DataConvert.ToString(dtr["R.Estado"]),
                        IdRol = DataConvert.ToInt(dtr["R.IdRol"]),
                        Nombre = DataConvert.ToString(dtr["R.Nombre"])
                    };

                }
            }
            UtilDA.Close(cnx);
            return objUsuario;
        }
    }
}
