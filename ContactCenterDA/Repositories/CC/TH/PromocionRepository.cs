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
using ContactCenterBE.CC.TH.Entidades.ZonaBE;

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
            objPromocion.RequiereEmpresa = DataConvert.ToBool(dtr["RequiereEmpresa"]);
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
            }
            UtilDA.Close(cnx);
            return objPromocion;
    }

        public IList<Promocion> GetLista()
        {
            List<Promocion> listaPromocion = new List<Promocion>();

            String sql = "SELECT * FROM (TH_PROMOCION P INNER JOIN TH_FUNCION F ON F.IDFUNCION = P.IDFUNCION) INNER JOIN TH_TIPO_PROMOCION TP ON TP.IDTIPOPROMOCION = P.IDTIPOPROMOCION WHERE TP.ESTADO NOT IN ('E') ";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    Promocion objPromocion = new Promocion();
                    objPromocion.IdPromocion = DataConvert.ToInt(dtr["IdPromocion"]);
                    objPromocion.Descripcion = DataConvert.ToString(dtr["P.Descripcion"]);
                    objPromocion.Estado = DataConvert.ToString(dtr["P.Estado"]);
                    objPromocion.FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]);
                    objPromocion.FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]);
                    objPromocion.RequiereEmpresa = DataConvert.ToBool(dtr["RequiereEmpresa"]);
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
                    listaPromocion.Add(objPromocion);
                }
            }
            UtilDA.Close(cnx);
            return listaPromocion;
        }

        public bool Insert(Promocion datos)
        {
            try
            {
                String sql = "INSERT INTO TH_PROMOCION(Descripcion, Estado, FechaInicio, FechaFin, IdTipoPromocion, FechaCrea, UserCrea,RequiereEmpresa) " +
                            "VALUES(@descripcion, @estado, @fechaInicio, @fechaFin, @idTipoPromocion, @fechaCrea, @userCrea,@requiereEmpresa)";

                OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
                OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, "A");
                OleDbParameter fechaInicio = UtilDA.SetParameters("@fechInicio", OleDbType.Date, datos.FechaInicio);
                OleDbParameter fechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.Date, datos.FechaFin);
                OleDbParameter idTipoPromocion = UtilDA.SetParameters("@idTipoPromocion", OleDbType.Integer, datos.TipoPromocion.IdTipoPromocion);
                OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
                OleDbParameter userCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
                OleDbParameter pRequiereEmpresa = UtilDA.SetParameters("@requiereEmpresa", OleDbType.Boolean, datos.RequiereEmpresa);
                UtilDA.ExecuteBeginTransaction(cmd, cnx);
                int idPromocion = UtilDA.ExecuteNonQueryGetId(cmd, CommandType.Text, sql, cnx, true, descripcion, estado, fechaInicio, fechaFin, idTipoPromocion, fechaCrea, userCrea, pRequiereEmpresa);
                if (idPromocion == 0)
                {
                    UtilDA.ExecuteRollback(cmd, cnx);
                    return false;
                }
                foreach (PromocionZona pzona in datos.PromocionZonas)
                {
                    string sqlZona = "INSERT INTO TH_PROMOCION_ZONA (IDPROMOCION, IDZONA, PRECIO) VALUES (@idPromocion, @idZona, @precio)";
                    OleDbParameter pIdPromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, idPromocion);
                    OleDbParameter pIdZona = UtilDA.SetParameters("@idZona", OleDbType.Integer, pzona.Zona.IdZona);
                    OleDbParameter pPrecio = UtilDA.SetParameters("@precio", OleDbType.Single, pzona.Precio);
                    if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlZona, cnx, true, pIdPromocion, pIdZona, pPrecio))
                    {
                        UtilDA.ExecuteRollback(cmd, cnx);
                        return false;
                    }
                }

                foreach (PromocionFuncion pfuncion in datos.PromocionFunciones)
                {
                    string sqlFuncion = "INSERT INTO TH_PROMOCION_FUNCION (IdPromocion, IdFuncion) values (@idPromocion, @idFuncion)";
                    OleDbParameter pIdpromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, idPromocion);
                    OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, pfuncion.Funcion.IdFuncion);
                    if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlFuncion, cnx, true, pIdpromocion, pIdFuncion))
                    {
                        UtilDA.ExecuteRollback(cmd, cnx);
                        return false;
                    }
                }
                UtilDA.ExecuteCommit(cmd, cnx);
                return true;
            }
            catch
            {
                UtilDA.ExecuteRollback(cmd, cnx);
                return false;
            }

        }

        public bool Update(Promocion datos)
        {

            try
            {
                String sql = "UPDATE TH_PROMOCION SET Descripcion = @descripciom, Estado = @estado, FechaInicio = @fechaInicio, FechaFin = @fechaFin, IdTipoPromocion = @idTipoPromocion, " +
                            " FechaMod = @fechaMod, UserMod = @userMod, RequiereEmpresa = @requiereEmpresa WHERE IdPromocion = @idPromocion";

                OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
                OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
                OleDbParameter fechaInicio = UtilDA.SetParameters("@fechInicio", OleDbType.Date, datos.FechaInicio);
                OleDbParameter fechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.Date, datos.FechaFin);
                OleDbParameter idTipoPromocion = UtilDA.SetParameters("@idTipoPromocion", OleDbType.Integer, datos.TipoPromocion.IdTipoPromocion);
                OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
                OleDbParameter userMod = UtilDA.SetParameters("@userMod", OleDbType.VarChar, Sesion.usuario.Login);
                OleDbParameter pRequiereEmpresa = UtilDA.SetParameters("@requiereEmpresa", OleDbType.Boolean, datos.RequiereEmpresa);
                OleDbParameter idPromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, datos.IdPromocion);
                
                UtilDA.ExecuteBeginTransaction(cmd, cnx);
                if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, true, descripcion, estado, fechaInicio, fechaFin, idTipoPromocion, fechaMod, userMod, pRequiereEmpresa, idPromocion))
                {
                    UtilDA.ExecuteRollback(cmd, cnx);
                    return false;
                }

                String SQLDeletePromoZona = "DELETE FROM TH_PROMOCION_ZONA WHERE IDPROMOCION = @idPromocion";
                OleDbParameter pIdPromo = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, datos.IdPromocion);

                if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, SQLDeletePromoZona, cnx, true, pIdPromo))
                {
                    UtilDA.ExecuteRollback(cmd, cnx);
                    return false;
                }

                String SQLDeletePromoFuncion = "DELETE FROM TH_PROMOCION_FUNCION WHERE IDPROMOCION = @idPromocion";
                OleDbParameter pIdPromoFuncion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, datos.IdPromocion);

                if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, SQLDeletePromoFuncion, cnx, true, pIdPromoFuncion))
                {
                    UtilDA.ExecuteRollback(cmd, cnx);
                    return false;
                }


                foreach (PromocionZona pzona in datos.PromocionZonas)
                {
                    string sqlZona = "INSERT INTO TH_PROMOCION_ZONA (IDPROMOCION, IDZONA, PRECIO) VALUES (@idPromocion, @idZona, @precio)";
                    OleDbParameter pIdPromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, datos.IdPromocion);
                    OleDbParameter pIdZona = UtilDA.SetParameters("@idZona", OleDbType.Integer, pzona.Zona.IdZona);
                    OleDbParameter pPrecio = UtilDA.SetParameters("@precio", OleDbType.Single, pzona.Precio);
                    if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlZona, cnx, true, pIdPromocion, pIdZona, pPrecio))
                    {
                        UtilDA.ExecuteRollback(cmd, cnx);
                        return false;
                    }
                }

                foreach (PromocionFuncion pfuncion in datos.PromocionFunciones)
                {
                    string sqlFuncion = "INSERT INTO TH_PROMOCION_FUNCION (IdPromocion, IdFuncion) values (@idPromocion, @idFuncion)";
                    OleDbParameter pIdpromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, datos.IdPromocion);
                    OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, pfuncion.Funcion.IdFuncion);
                    if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlFuncion, cnx, true, pIdpromocion, pIdFuncion))
                    {
                        UtilDA.ExecuteRollback(cmd, cnx);
                        return false;
                    }
                }
                UtilDA.ExecuteCommit(cmd, cnx);
                return true;
            }
            catch
            {
                UtilDA.ExecuteRollback(cmd, cnx);
                return false;
            }


        }
        public List<PromocionZona> ListPromocionZonaByFuncionZona(int idFuncion, string zonas)
        {
            string sql = "SELECT * FROM TH_PROMOCION_ZONA PZ INNER JOIN TH_ZONA Z ON Z.IDZONA = PZ.IDZONA WHERE PZ.IDPROMOCION IN (SELECT IDPROMOCION FROM TH_PROMOCION_FUNCION WHERE IDFUNCION = @idFuncion) AND PZ.IDZONA IN (@zonas)";
            sql = sql.Replace("@zonas", zonas);
            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, idFuncion);
            List<PromocionZona> listPromocionZona = new List<PromocionZona>();
            PromocionZona promocionZona;
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdFuncion))
            {
                while (dtr.Read())
                {
                    promocionZona = new PromocionZona()
                    {
                        Promocion = new Promocion()
                        {
                            IdPromocion = DataConvert.ToInt(dtr["IdPromocion"])
                        },
                        Precio = DataConvert.ToSingle(dtr["PZ.Precio"]),
                        Zona = new Zona()
                        {
                            IdZona = DataConvert.ToInt(dtr["Z.IdZona"])
                        }
                    };
                    listPromocionZona.Add(promocionZona);
                }
            }
            UtilDA.Close(cnx);
            return listPromocionZona;
        }
        public List<Promocion> ListByFuncionTipoPromo(int idFuncion, int idTipoPromo,string zonas)
        {
            string SQL = "SELECT * FROM TH_PROMOCION WHERE IDPROMOCION IN (SELECT PZ.IDPROMOCION FROM TH_PROMOCION_ZONA PZ INNER JOIN TH_PROMOCION_FUNCION PF ON PF.IDPROMOCION = PZ.IDPROMOCION WHERE PF.IDFUNCION = @idFuncion AND PZ.IDZONA IN (@zonas)) AND IDTIPOPROMOCION = @idTipoPromocion AND ESTADO = 'A' AND (@fechaActual BETWEEN FechaInicio AND FechaFin)";
            SQL = SQL.Replace("@zonas", zonas);
            OleDbParameter pIdfuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter pIdTipoPromo = UtilDA.SetParameters("@idTipoPromocion", OleDbType.Integer, idTipoPromo);
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
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]),
                        RequiereEmpresa = DataConvert.ToBool(dtr["RequiereEmpresa"])
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
                        RequiereEmpresa = DataConvert.ToBool(dtr["RequiereEmpresa"]),
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

        public List<Promocion> ListPromocionByObra(int idObra)
        {
            OleDbCommand cmd2 = new OleDbCommand();
            OleDbCommand cmd3 = new OleDbCommand();
            string sql = "SELECT * FROM TH_PROMOCION P INNER JOIN TH_TIPO_PROMOCION TP ON TP.IDTIPOPROMOCION = P.IDTIPOPROMOCION WHERE IDPROMOCION IN (SELECT PZ.IDPROMOCION FROM TH_PROMOCION_ZONA PZ INNER JOIN TH_ZONA Z ON Z.IDZONA = PZ.IDZONA WHERE Z.IDOBRA = @idObra)";
            OleDbParameter pIdObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, idObra);
            Promocion promocion = null;
            PromocionZona promocionZona = null;
            PromocionFuncion promocionFuncion = null;
            List<Promocion> ListaPromocion = new List<Promocion>();
            List<PromocionZona> listaZona = null;
            List<PromocionFuncion> listaFuncion = null;
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdObra))
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
                        RequiereEmpresa = DataConvert.ToBool(dtr["RequiereEmpresa"]),
                        TipoPromocion = new TipoPromocion()
                        {
                            IdTipoPromocion = DataConvert.ToInt(dtr["TP.IdTipoPromocion"]),
                            Descripcion = DataConvert.ToString(dtr["TP.Descripcion"]),
                            Estado = DataConvert.ToString(dtr["TP.FechaCrea"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["TP.UserCrea"])
                        }
                    };
                    listaZona = new List<PromocionZona>();
                    string SQLZONA = "SELECT PZ.PRECIO,Z.IDZONA,Z.NOMBRE,Z.DESCRIPCION,Z.ESTADO,O.IdObra,O.Nombre FROM (TH_PROMOCION_ZONA PZ INNER JOIN TH_ZONA Z ON Z.IDZONA = PZ.IDZONA) INNER JOIN TH_OBRA O ON O.IDOBRA = Z.IDOBRA  WHERE PZ.idpromocion = @idPromocion";
                    OleDbParameter pIdPromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, promocion.IdPromocion);
                    using (var subdtr = UtilDA.ExecuteSubReader(cmd2, CommandType.Text, SQLZONA, cnx, pIdPromocion))
                    {
                        while (subdtr.Read())
                        {
                            promocionZona = new PromocionZona()
                            {
                                Promocion = promocion,
                                Precio = DataConvert.ToSingle(subdtr["Precio"]),
                                Zona = new Zona()
                                {
                                    IdZona = DataConvert.ToInt(subdtr["IdZona"]),
                                    Nombre = DataConvert.ToString(subdtr["Z.Nombre"]),
                                    Descripcion = DataConvert.ToString(subdtr["Descripcion"]),
                                    Estado = DataConvert.ToString(subdtr["Estado"]),
                                    Obra = new Obra()
                                    {
                                        IdObra = DataConvert.ToInt(subdtr["IdObra"]),
                                        Nombre = DataConvert.ToString(subdtr["O.Nombre"])
                                    }
                                }
                            };
                            listaZona.Add(promocionZona);
                        }
                    }

                    listaFuncion = new List<PromocionFuncion>();
                    string SQLFUNCION = "SELECT * FROM TH_PROMOCION_FUNCION PF INNER JOIN TH_FUNCION P ON P.IDFUNCION = PF.IDFUNCION WHERE PF.IDPROMOCION = @idPromocion";
                    OleDbParameter pIdPromocionFuncion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, promocion.IdPromocion);
                    using (var subdtr2 = UtilDA.ExecuteSubReader(cmd3, CommandType.Text, SQLFUNCION, cnx, pIdPromocionFuncion))
                    {
                        while (subdtr2.Read())
                        {
                            promocionFuncion = new PromocionFuncion()
                            {
                                Promocion = promocion,
                                Funcion = new Funcion()
                                {
                                    IdFuncion = DataConvert.ToInt(subdtr2["P.IdFuncion"]),
                                    Dia = DataConvert.ToInt(subdtr2["Dia"]),
                                    Horario = DataConvert.ToString(subdtr2["Horario"]),
                                    Estado = DataConvert.ToString(subdtr2["Estado"])
                                }
                            };
                            listaFuncion.Add(promocionFuncion);
                        }
                    }

                    promocion.PromocionFunciones = listaFuncion;
                    promocion.PromocionZonas = listaZona;
                    ListaPromocion.Add(promocion);
                }
            }

            UtilDA.Close(cnx);
            return ListaPromocion;
        }
    }
}
