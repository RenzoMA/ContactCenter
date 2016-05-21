using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class ObraRepository : IObraRepository
    {

        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_OBRA SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IdObra = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, codigo);
        }

        public Obra GetById(int id)
        {
            Obra objObra = null;

            String sql = "SELECT * FROM TH_OBRA O INNER JOIN TH_TEATRO T ON O.IDTEATRO = T.IDTEATRO WHERE IDOBRA = @codigo ";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objObra = new Obra();
                objObra.IdObra = DataConvert.ToInt(dtr["IdObra"]);
                objObra.Nombre = DataConvert.ToString(dtr["O.Nombre"]);
                objObra.FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]);
                objObra.FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]);
                objObra.Descripcion = DataConvert.ToString(dtr["Descripcion"]);
                objObra.Estado = DataConvert.ToString(dtr["O.Estado"]);
                objObra.Teatro = new Teatro()
                {
                    IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                    Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                    Estado = DataConvert.ToString(dtr["T.Estado"]),
                    frmTeatro = DataConvert.ToString(dtr["T.frmTeatro"])
                };
                objObra.FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]);
                objObra.UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]);
                objObra.FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]);
                objObra.UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]);
            }
            UtilDA.Close(cnx);
            return objObra;
        }

        public IList<Obra> GetLista()
        {
            List<Obra> listaObra = new List<Obra>();

            String sql = "SELECT * FROM TH_OBRA O INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                    Obra objObra = new Obra();
                    objObra.IdObra = DataConvert.ToInt(dtr["O.IdObra"]);
                    objObra.Nombre = DataConvert.ToString(dtr["O.Nombre"]);
                    objObra.FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]);
                    objObra.FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]);
                    objObra.Descripcion = DataConvert.ToString(dtr["O.Descripcion"]);
                    objObra.Estado = DataConvert.ToString(dtr["O.Estado"]);
                    objObra.Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"])
                    };
                    objObra.FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]);
                    objObra.UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]);
                    objObra.FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]);
                    objObra.UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]);
                    listaObra.Add(objObra);
                
            }
            UtilDA.Close(cnx);
            return listaObra;
        }

        public List<Obra> GetListaTeatro(int idTeatro)
        {
            List<Obra> lObra = new List<Obra>();
            Obra obra = null;
            string sql = "SELECT O.IDOBRA,O.DESCRIPCION,O.FECHACREA,O.FECHAFIN,O.FECHAINICIO,O.FECHAMOD,O.NOMBRE,O.USERCREA,O.USERMOD,O.Estado,O.IdTeatro, " +
                         "T.IdTeatro,T.Estado,T.FechaCrea,T.FechaMod,T.frmTeatro,T.Nombre,T.UserCrea,T.UserMod " +
                         "FROM TH_OBRA O INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @IdTeatro AND (@fechaActual BETWEEN FECHAINICIO AND FECHAFIN) AND O.ESTADO = 'A'";

            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);
            OleDbParameter pFechaActual = UtilDA.SetParameters("@fechaActual", OleDbType.Date, DateTime.Today);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdTeatro,pFechaActual))
            {
                while (dtr.Read())
                {
                    obra = new Obra()
                    {
                        IdObra = DataConvert.ToInt(dtr["IdObra"]),
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Estado = DataConvert.ToString(dtr["O.Estado"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]),
                        Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                        Teatro = new Teatro()
                        {
                            IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                            Estado = DataConvert.ToString(dtr["T.Estado"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["T.FechaCrea"]),
                            FechaModificacion = DataConvert.ToDateTime(dtr["T.FechaMod"]),
                            frmTeatro = DataConvert.ToString(dtr["frmTeatro"]),
                            Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["T.UserCrea"]),
                            UsuarioModificacion = DataConvert.ToString(dtr["T.UserMod"])
                        },
                        UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"])
                    };
                    lObra.Add(obra);
                }
                
            }
            UtilDA.Close(cnx);
            return lObra;

        }

        public bool Insert(Obra datos)
        {
            String sql = "INSERT INTO TH_OBRA(Nombre, FechaInicio, FechaFin, Descripcion, Estado, IdTeatro, FechaCrea, UserCrea) " +
                        "VALUES(@nombre, @fechaini, @fechafin, @descripcion, @estado, @idTeatro, @fechaCrea, @userCrea)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter fechaini = UtilDA.SetParameters("@fechaini", OleDbType.Date, datos.FechaInicio);
            OleDbParameter fechafin = UtilDA.SetParameters("@fechafin", OleDbType.Date, datos.FechaFin);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idTeatro = UtilDA.SetParameters("@idTeatro", OleDbType.Integer, datos.Teatro.IdTeatro);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, fechaini, fechafin, descripcion, estado, idTeatro, fechaCreacion, usuarioCrea);
        }

        public bool Update(Obra datos)
        {
            String sql = "UPDATE TH_OBRA SET Nombre = @nombre, FechaInicio = @fechaini, FechaFin = @fechafin, Descripcion = @descripcion, Estado = @estado, , IdTeatro = @idteatro, " +
                            "FechaMod = @fechaMod, UserMod = @usuarioMod WHERE IdObra = @idobra";

           
            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter fechaini = UtilDA.SetParameters("@fechaini", OleDbType.Date, datos.FechaInicio);
            OleDbParameter fechafin = UtilDA.SetParameters("@fechafin", OleDbType.Date, datos.FechaFin);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idteatro = UtilDA.SetParameters("@idteatro", OleDbType.Integer, datos.Teatro.IdTeatro);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idObra = UtilDA.SetParameters("@idobra", OleDbType.Integer, datos.IdObra);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, fechaini, fechafin, descripcion, estado, idteatro, fechaMod, usuarioMod, idObra);
        }

        public Obra GetbyName(string name)
        {
            Obra objObra = null;

            String sql = "SELECT * FROM TH_OBRA O INNER JOIN TH_TEATRO T ON O.IDTEATRO = T.IDTEATRO WHERE O.NOMBRE = @nombre";

            OleDbParameter codigo = UtilDA.SetParameters("@nombre", OleDbType.VarChar, name);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objObra = new Obra();
                objObra.IdObra = DataConvert.ToInt(dtr["O.IdObra"]);
                objObra.Nombre = DataConvert.ToString(dtr["O.Nombre"]);
                objObra.FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]);
                objObra.FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]);
                objObra.Descripcion = DataConvert.ToString(dtr["O.Descripcion"]);
                objObra.Estado = DataConvert.ToString(dtr["O.Estado"]);
                objObra.Teatro = new Teatro()
                {
                    IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                    Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                    Estado = DataConvert.ToString(dtr["T.Estado"]),
                    frmTeatro = DataConvert.ToString(dtr["T.frmTeatro"])
                };
                objObra.FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]);
                objObra.UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]);
                objObra.FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]);
                objObra.UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]);
            }
            UtilDA.Close(cnx);
            return objObra;
        }

        public Obra GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
