using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterCommon;
using ContactCenterBE.CC.Entidades.AplicacionBE;

namespace ContactCenterDA.Repositories.CC
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public void BeginTransaction()
        {
            UtilDA.ExecuteBeginTransaction(cmd, cnx);
        }

        public void CommitTransaction()
        {
            UtilDA.ExecuteCommit(cmd, cnx);
        }

        public void RollbackTransaction()
        {
            UtilDA.ExecuteRollback(cmd, cnx);
        }
        public bool Delete(int id)
        {
            String sql = "UPDATE CC_USUARIO SET ESTADO = 'I', FechaMod = @fechaMod, UserMod = @userMod WHERE IdUsuario = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@userMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod , userMod, codigo);
        }

        public Usuario GetById(int id)
        {
            Usuario objUsuario = null;

            String sql = "SELECT * FROM CC_Usuario INNER JOIN CC_ROL R ON R.IdRol = U.IdRol WHERE IdUsuario = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
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
            List<Usuario> listaUsuario = new List<Usuario>();

            String sql = "SELECT * FROM CC_Usuario U INNER JOIN CC_ROL R ON R.IdRol = U.IdRol";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.IdUsuario = DataConvert.ToInt(dtr["IdUsuario"]);
                    objUsuario.Nombre = DataConvert.ToString(dtr["U.Nombre"]);
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
                    objUsuario.FechaCreacion = DataConvert.ToDateTime(dtr["U.FechaCrea"]);
                    objUsuario.UsuarioCreacion = DataConvert.ToString(dtr["U.UserCrea"]);
                    objUsuario.FechaModificacion = DataConvert.ToDateTime(dtr["U.FechaMod"]);
                    objUsuario.UsuarioModificacion = DataConvert.ToString(dtr["U.UserMod"]);
                    objUsuario.Estado = DataConvert.ToString(dtr["U.Estado"]);
                    listaUsuario.Add(objUsuario);
                }
            }

            UtilDA.Close(cnx);
            return listaUsuario;
        }

        public bool Insert(Usuario datos)
        {
            String sql = "INSERT INTO CC_Usuario(Login,Nombre, ApePaterno, ApeMaterno, Correo, Contraseña, IdRol, FechaCrea, UserCrea) " +
                         "VALUES(@login,@nombre, @apePaterno, @apeMaterno, @correo, @contraseña, @idrol, @fechaCrea, @usuarioCrea)";
            String sqlValidador = "SELECT * FROM CC_USUARIO WHERE LOGIN = @login";

            OleDbParameter login = UtilDA.SetParameters("@login", OleDbType.VarChar, datos.Login);
            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter apePaterno = UtilDA.SetParameters("@apePaterno", OleDbType.VarChar, datos.ApellidoPaterno);
            OleDbParameter apeMaterno = UtilDA.SetParameters("@apeMaterno", OleDbType.VarChar, datos.ApellidoMaterno);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter contraseña = UtilDA.SetParameters("@contraseña", OleDbType.VarChar, datos.Contraseña);
            OleDbParameter idrol = UtilDA.SetParameters("@idrol", OleDbType.Integer, datos.Rol.IdRol);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            UtilDA.ExecuteBeginTransaction(cmd, cnx);


            if (!UtilDA.ExecuteQueryValidador(cmd, CommandType.Text, sqlValidador, sql, cnx, true, login, nombre, apePaterno, apeMaterno, correo, contraseña, idrol, fechaCreacion, usuarioCrea, estado))
            {
                UtilDA.ExecuteRollback(cmd, cnx);
                return false;
            }

            int IdUsuario = UtilDA.GetIdentity(cmd, cnx, true);

            String sqlAplicacion = "INSERT INTO CC_USUARIO_APLICACION (IdUsuario,IdAplicacion,FechaCrea,UserCrea) " +
                                   "VALUES (@idUsuario, @idAplicacion, @fechaCrea, @userCrea)";                                    

            foreach (Aplicacion aplicacion in datos.Aplicaciones)
            {
                OleDbParameter pIdUsuario = UtilDA.SetParameters("@idUsuario", OleDbType.Integer, IdUsuario);
                OleDbParameter pIdAplicacion = UtilDA.SetParameters("@idAplicacion", OleDbType.Integer, aplicacion.IdAplicacion);
                OleDbParameter pFechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
                OleDbParameter pUserCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
                if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlAplicacion, cnx, true, pIdUsuario, pIdAplicacion, pFechaCrea, pUserCrea))
                {
                    UtilDA.ExecuteRollback(cmd, cnx);
                    return false;
                }
            }
            UtilDA.ExecuteCommit(cmd, cnx);
            return true;
                
        }

        public bool Update(Usuario datos)
        {
            String sql = "UPDATE CC_Usuario SET Nombre = @nombre, ApePaterno = @apePaterno, ApeMaterno = @apeMaterno, Correo = @correo, " +
                         "IdRol = @idRol, FechaMod = @fechaMod, UserMod = @usuarioMod, Estado = @estado,Contraseña = @Contraseña WHERE IdUsuario = @idUsuario";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter apePaterno = UtilDA.SetParameters("@apePaterno", OleDbType.VarChar, datos.ApellidoPaterno);
            OleDbParameter apeMaterno = UtilDA.SetParameters("@apeMaterno", OleDbType.VarChar, datos.ApellidoMaterno);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter idrol = UtilDA.SetParameters("@idrol", OleDbType.Integer, datos.Rol.IdRol);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idusuario = UtilDA.SetParameters("@idUsuario", OleDbType.Integer, datos.IdUsuario);
            OleDbParameter pContraseña = UtilDA.SetParameters("@Contraseña", OleDbType.VarChar, datos.Contraseña);
            UtilDA.ExecuteBeginTransaction(cmd, cnx);

            if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, true, nombre, apePaterno, apeMaterno, correo, idrol, fechaMod, usuarioMod, estado, pContraseña,idusuario))
            {
                UtilDA.ExecuteRollback(cmd, cnx);
                return false;
            }   

            string sqlDelete = "DELETE FROM CC_USUARIO_APLICACION WHERE IDUSUARIO = @IDUSUARIO";
            OleDbParameter pIdUsuario = UtilDA.SetParameters("@IDUSUARIO", OleDbType.Integer, datos.IdUsuario);

            if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlDelete, cnx, true, pIdUsuario))
            {
                UtilDA.ExecuteRollback(cmd, cnx);
                return false;
            }

            string sqlUsuarioAplicacion = "INSERT INTO CC_USUARIO_APLICACION (IdUsuario,IdAplicacion,FechaCrea,UserCrea) VALUES (@IdUsuario,@IdAplicacion,@FechaCrea,@UserCrea)";

            OleDbParameter pIdUsuario2 = UtilDA.SetParameters("@IdUsuario", OleDbType.Integer, datos.IdUsuario);
            OleDbParameter pFechaCrea = UtilDA.SetParameters("@FechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter pUserCrea = UtilDA.SetParameters("@UserCrea", OleDbType.VarChar, Sesion.usuario.Login);
            foreach (Aplicacion app in datos.Aplicaciones)
            {
                OleDbParameter pIdAplicacion = UtilDA.SetParameters("@IdAplicacion", OleDbType.Integer, app.IdAplicacion);
                if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlUsuarioAplicacion, cnx, true, pIdUsuario2, pIdAplicacion, pFechaCrea, pUserCrea))
                {
                    UtilDA.ExecuteRollback(cmd, cnx);
                    return false;
                }
            }
            UtilDA.ExecuteCommit(cmd, cnx);
            return true;



        }

        public Usuario ValidarUsuario(string login, string password)
        {
            Usuario objUsuario = null;

            String sql = "SELECT * FROM CC_USUARIO U INNER JOIN CC_ROL R ON R.IDROL = U.IDROL WHERE U.LOGIN = @login and U.CONTRASEÑA = @contraseña and u.Estado = 'A'";

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

        public List<Usuario> SearchByName(string name)
        {
            OleDbCommand cmd2 = new OleDbCommand();

            List<Usuario> listaUsuario = new List<Usuario>();

            String sql = "SELECT * FROM CC_Usuario U INNER JOIN CC_ROL R ON R.IdRol = U.IdRol WHERE (U.Nombre + ApePaterno + ApeMaterno) LIKE '%' & @Name & '%'";
            String sql2 = "SELECT * FROM CC_USUARIO_APLICACION UA INNER JOIN CC_APLICACION A ON A.IDAPLICACION = UA.IDAPLICACION WHERE IdUsuario = @IdUsuario";

            OleDbParameter pName = UtilDA.SetParameters("@Name", OleDbType.VarChar, name);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pName))
            {
                while (dtr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.IdUsuario = DataConvert.ToInt(dtr["IdUsuario"]);
                    objUsuario.Nombre = DataConvert.ToString(dtr["U.Nombre"]);
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
                    objUsuario.FechaCreacion = DataConvert.ToDateTime(dtr["U.FechaCrea"]);
                    objUsuario.UsuarioCreacion = DataConvert.ToString(dtr["U.UserCrea"]);
                    objUsuario.FechaModificacion = DataConvert.ToDateTime(dtr["U.FechaMod"]);
                    objUsuario.UsuarioModificacion = DataConvert.ToString(dtr["U.UserMod"]);
                    objUsuario.Estado = DataConvert.ToString(dtr["U.Estado"]);

                    OleDbParameter pIdUsuario = UtilDA.SetParameters("@IdUsuario", OleDbType.Integer, objUsuario.IdUsuario);

                    using (var dtr2 = UtilDA.ExecuteSubReader(cmd2, CommandType.Text, sql2,cnx, pIdUsuario))
                    {
                        List<Aplicacion> listaAplicacionUsuario = new List<Aplicacion>();
                        while (dtr2.Read())
                        {
                            Aplicacion objAplicacion = new Aplicacion()
                            {
                                IdAplicacion = DataConvert.ToInt(dtr2["A.IdAplicacion"]),
                                Nombre = DataConvert.ToString(dtr2["Nombre"])
                            };
                            listaAplicacionUsuario.Add(objAplicacion);
                        }
                        objUsuario.Aplicaciones = listaAplicacionUsuario;
                    }
                    listaUsuario.Add(objUsuario);
                }
            }
            UtilDA.Close(cnx);
            return listaUsuario;
        }
    }
}
