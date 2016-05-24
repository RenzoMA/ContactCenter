using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;


namespace ContactCenterDA.Repositories.CC.TH
{
    public class PromocionRepository : IPromocionRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_PROMOCION SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IDFUNCION = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, codigo);
        }
    

        public Promocion GetById(int id)
        {
        Promocion objPromocion = null;

        String sql = "SELECT * FROM TH_PROMOCION P INNER JOIN TH_FUNCION F ON F.IDFUNCION = P.IDFUNCION INNER JOIN TH_TIPO_PROMOCION TP ON TP.IDTIPOPROMCION = P.IDTIPOPROMOCION " +
                    "WHERE IDPROMOCION = @codigo";

        OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

        using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
        {
            objPromocion = new Promocion();
            objPromocion.IdPromocion = DataConvert.ToInt(dtr["P.IdPromocion"]);
            objPromocion.Descripcion = DataConvert.ToString(dtr["P.Descripcion"]);
            objPromocion.Estado = DataConvert.ToString(dtr["P.Estado"]);
            objPromocion.FechaInicio = DataConvert.ToDateTime(dtr["P.FechaInicio"]);
            objPromocion.FechaFin = DataConvert.ToDateTime(dtr["P.FechaFin"]);
            objPromocion.Funcion = new Funcion()
            {
                IdFuncion = DataConvert.ToInt(dtr["F.IdFuncion"]),
                Dia = DataConvert.ToInt(dtr["F.Dia"]),
                Horario = DataConvert.ToString(dtr["F.Horario"]),
                Estado = DataConvert.ToString(dtr["F.Estado"]),
                Obra = new Obra()
                {
                    Nombre = DataConvert.ToString(dtr["Nombre"]),
                    FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                    FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                    Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["Nombre"]),
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                    }
                },
            };
            objPromocion.TipoPromocion = new TipoPromocion()
            {
                IdTipoPromocion = DataConvert.ToInt(dtr["TP.IdTipoPromocion"]),
                Descripcion = DataConvert.ToString(dtr["TP.Descripcion"]),
                Estado = DataConvert.ToString(dtr["TP.Estado"])
            };
                objPromocion.FechaCreacion = DataConvert.ToDateTime(dtr["P.FechaCrea"]);
                objPromocion.UsuarioCreacion = DataConvert.ToString(dtr["P.UserCrea"]);
                objPromocion.FechaModificacion = DataConvert.ToDateTime(dtr["P.FechaMod"]);
                objPromocion.UsuarioModificacion = DataConvert.ToString(dtr["P.UserMod"]);
                objPromocion.Descuento = DataConvert.ToSingle(dtr["P.Descuento"]);
                objPromocion.TipoDescuento = DataConvert.ToString(dtr["P.TipoDescuento"]);
            }
            UtilDA.Close(cnx);
            return objPromocion;
    }

        public IList<Promocion> GetLista()
        {
            List<Promocion> listaPromocion = null;

            String sql = "SELECT * FROM TH_PROMOCION P INNER JOIN TH_FUNCION F ON F.IDFUNCION = P.IDFUNCION INNER JOIN TH_TIPO_PROMOCION TP ON TP.IDTIPOPROMCION = P.IDTIPOPROMOCION ";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                Promocion objPromocion = new Promocion();
                objPromocion.IdPromocion = DataConvert.ToInt(dtr["P.IdPromocion"]);
                objPromocion.Descripcion = DataConvert.ToString(dtr["P.Descripcion"]);
                objPromocion.Estado = DataConvert.ToString(dtr["P.Estado"]);
                objPromocion.FechaInicio = DataConvert.ToDateTime(dtr["P.FechaInicio"]);
                objPromocion.FechaFin = DataConvert.ToDateTime(dtr["P.FechaFin"]);
                objPromocion.Funcion = new Funcion()
                {
                    IdFuncion = DataConvert.ToInt(dtr["F.IdFuncion"]),
                    Dia = DataConvert.ToInt(dtr["F.Dia"]),
                    Horario = DataConvert.ToString(dtr["F.Horario"]),
                    Estado = DataConvert.ToString(dtr["F.Estado"]),
                    Obra = new Obra()
                    {
                        Nombre = DataConvert.ToString(dtr["Nombre"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Teatro = new Teatro()
                        {
                            IdTeatro = DataConvert.ToInt(dtr["IdTeatro"]),
                            Nombre = DataConvert.ToString(dtr["Nombre"]),
                            Estado = DataConvert.ToString(dtr["Estado"]),
                            frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                        }
                    },
                };
                objPromocion.TipoPromocion = new TipoPromocion()
                {
                    IdTipoPromocion = DataConvert.ToInt(dtr["TP.IdTipoPromocion"]),
                    Descripcion = DataConvert.ToString(dtr["TP.Descripcion"]),
                    Estado = DataConvert.ToString(dtr["TP.Estado"])
                };
                objPromocion.FechaCreacion = DataConvert.ToDateTime(dtr["P.FechaCrea"]);
                objPromocion.UsuarioCreacion = DataConvert.ToString(dtr["P.UserCrea"]);
                objPromocion.FechaModificacion = DataConvert.ToDateTime(dtr["P.FechaMod"]);
                objPromocion.UsuarioModificacion = DataConvert.ToString(dtr["P.UserMod"]);
                objPromocion.Descuento = DataConvert.ToSingle(dtr["P.Descuento"]);
                objPromocion.TipoDescuento = DataConvert.ToString(dtr["P.TipoDescuento"]);
                listaPromocion.Add(objPromocion);
            }
            UtilDA.Close(cnx);
            return listaPromocion;
        }

        public bool Insert(Promocion datos)
        {
            String sql = "INSERT INTO TH_PROMOCION(Descripcion, Estado, FechaInicio, FechaFin, IdFuncion, IdTipoPromocion, TipoDescuento, Descuento, FechaCrea, UserCrea) " +
                        "VALUES(@descripcion, @estado, @fechaInicio, @fechaFin, @idFuncion, @idTipoPromocion, @tipoDescuento, @descuento, @fechaCrea, @userCrea)";

            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaInicio = UtilDA.SetParameters("@fechInicio", OleDbType.Date, datos.FechaInicio);
            OleDbParameter fechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.VarChar, datos.FechaFin);
            OleDbParameter idFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, datos.Funcion.IdFuncion);
            OleDbParameter idTipoPromocion = UtilDA.SetParameters("@idTipoPromocion", OleDbType.Integer, datos.TipoPromocion.IdTipoPromocion);
            OleDbParameter tipoDescuento = UtilDA.SetParameters("@tipoDescuento", OleDbType.VarChar, datos.TipoDescuento);
            OleDbParameter descuento = UtilDA.SetParameters("@descuento", OleDbType.Single, datos.Descuento);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter userCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, datos.UsuarioCreacion);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, descripcion, estado, fechaInicio, fechaFin, idFuncion, idTipoPromocion, tipoDescuento, descuento, fechaCrea, userCrea);

        }

        public bool Update(Promocion datos)
        {
            String sql = "UPDATE TH_PROMOCION SET Descripcion = @descripciom, Estado = @estado, FechaInicio = @fechaInicio, FechaFin = @fechaFin, IdTipoPromocion = @idTipoPromocion, " +
                        "TipoDescuento = @tipoDescuento, Descuento = @descuento, FechaMod = @fechaMod, UserMod = @userMod WHERE IdPromocion = @idPromocion";

            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaInicio = UtilDA.SetParameters("@fechInicio", OleDbType.Date, datos.FechaInicio);
            OleDbParameter fechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.VarChar, datos.FechaFin);
            OleDbParameter idTipoPromocion = UtilDA.SetParameters("@idTipoPromocion", OleDbType.Integer, datos.TipoPromocion.IdTipoPromocion);
            OleDbParameter tipoDescuento = UtilDA.SetParameters("@tipoDescuento", OleDbType.VarChar, datos.TipoDescuento);
            OleDbParameter descuento = UtilDA.SetParameters("@descuento", OleDbType.Single, datos.Descuento);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter userMod = UtilDA.SetParameters("@userMod", OleDbType.VarChar, datos.UsuarioCreacion);
            OleDbParameter idPromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, datos.IdPromocion);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, descripcion, estado, fechaInicio, fechaFin, idTipoPromocion, tipoDescuento, descuento, fechaMod, userMod, idPromocion);

        }

        public List<Promocion> ListByFuncionTipoPromo(int idFuncion, int idTipoPromo)
        {
            string SQL = "SELECT* FROM (TH_PROMOCION P INNER JOIN TH_FUNCION F ON F.IDFUNCION = P.IDFUNCION) INNER JOIN TH_TIPO_PROMOCION TP ON TP.IDTIPOPROMOCION = P.IDTIPOPROMOCION WHERE P.IDFUNCION = @IdFuncion AND P.Estado = 'A' AND P.IDTIPOPROMOCION = @IdTipoPromocion AND @FechaActual BETWEEN FechaInicio and FechaFin";

            OleDbParameter pIdfuncion = UtilDA.SetParameters("@IdFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter pIdTipoPromo = UtilDA.SetParameters("@IdTipoPromocion", OleDbType.Integer, idTipoPromo);
            OleDbParameter pFechaActual = UtilDA.SetParameters("@FechaActual", OleDbType.Date, DateTime.Today);
            Promocion promocion = null;
            List<Promocion> ListaPromocion = new List<Promocion>();

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, SQL, cnx, pIdfuncion, pIdTipoPromo,pFechaActual))
            {
                while (dtr.Read())
                {
                    promocion = new Promocion()
                    {
                        IdPromocion = DataConvert.ToInt(dtr["IdPromocion"]),
                        Descripcion = DataConvert.ToString(dtr["P.Descripcion"]),
                        Estado = DataConvert.ToString(dtr["P.Estado"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["P.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["P.UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["P.FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["P.UserMod"]),
                        TipoDescuento = DataConvert.ToString(dtr["TipoDescuento"]),
                        Descuento = DataConvert.ToSingle(dtr["Descuento"])
                    };
                    ListaPromocion.Add(promocion);
                }
            }
            UtilDA.Close(cnx);
            return ListaPromocion;

        }

        public List<Promocion> ListarPromocionByFuncion(int idFuncion)
        {
            string SQL = "SELECT* FROM (TH_PROMOCION P INNER JOIN TH_FUNCION F ON F.IDFUNCION = P.IDFUNCION) INNER JOIN TH_TIPO_PROMOCION TP ON TP.IDTIPOPROMOCION = P.IDTIPOPROMOCION WHERE P.IDFUNCION = @IdFuncion";

            OleDbParameter pIdfuncion = UtilDA.SetParameters("@IdFuncion", OleDbType.Integer, idFuncion);
            Promocion promocion = null;
            List<Promocion> ListaPromocion = new List<Promocion>();

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, SQL, cnx, pIdfuncion))
            {
                while (dtr.Read())
                {
                    promocion = new Promocion()
                    {
                        IdPromocion = DataConvert.ToInt(dtr["IdPromocion"]),
                        Descripcion = DataConvert.ToString(dtr["P.Descripcion"]),
                        Estado = DataConvert.ToString(dtr["P.Estado"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["P.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["P.UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["P.FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["P.UserMod"]),
                        TipoDescuento = DataConvert.ToString(dtr["TipoDescuento"]),
                        Descuento = DataConvert.ToSingle(dtr["Descuento"]),
                        TipoPromocion = new TipoPromocion()
                        {
                            IdTipoPromocion = DataConvert.ToInt(dtr["TP.IdTipoPromocion"]),
                            Descripcion = DataConvert.ToString(dtr["TP.Descripcion"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["TP.FechaCrea"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["TP.UserCrea"])
                        }
                    };
                    ListaPromocion.Add(promocion);
                }
            }
            UtilDA.Close(cnx);
            return ListaPromocion;
        }
    }
}
