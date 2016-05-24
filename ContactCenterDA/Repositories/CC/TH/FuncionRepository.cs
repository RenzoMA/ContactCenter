using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class FuncionRepository : IFuncionRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_FUNCION SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IDFUNCION = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, codigo);
        }

        public Funcion GetById(int id)
        {
            Funcion objFuncion = null;

            String sql = "SELECT * FROM TH_FUNCION F INNER JOIN TH_OBRA O ON F.IDOBRA = O.IDOBRA  INNER JOIN TH_TEATRO T ON O.IDTEATRO = T.IDTEATRO WHERE IDFUNCION = @codigo ";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objFuncion = new Funcion();
                objFuncion.IdFuncion = DataConvert.ToInt(dtr["IdFuncion"]);
                objFuncion.Dia = DataConvert.ToInt(dtr["Dia"]);
                objFuncion.Horario = DataConvert.ToString(dtr["Horario"]);
                objFuncion.Estado = DataConvert.ToString(dtr["F.Estado"]);
                objFuncion.Obra = new Obra()
                {
                    Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                    FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]),
                    FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]),
                    Descripcion = DataConvert.ToString(dtr["O.Descripcion"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["T.frmTeatro"])
                    }
                };
                objFuncion.FechaCreacion = DataConvert.ToDateTime(dtr["F.FechaCrea"]);
                objFuncion.UsuarioCreacion = DataConvert.ToString(dtr["F.UserCrea"]);
                objFuncion.FechaModificacion = DataConvert.ToDateTime(dtr["F.FechaMod"]);
                objFuncion.UsuarioModificacion = DataConvert.ToString(dtr["F.UserMod"]);
            }
            UtilDA.Close(cnx);
            return objFuncion;
        }

        public IList<Funcion> GetLista()
        {
            List<Funcion> listaFuncion = null;

            String sql = "SELECT * FROM TH_FUNCION F INNER JOIN TH_OBRA O ON F.IDOBRA = O.IDOBRA  INNER JOIN TH_TEATRO T ON O.IDTEATRO = T.IDTEATRO";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                Funcion objFuncion = new Funcion();
                objFuncion.IdFuncion = DataConvert.ToInt(dtr["IdFuncion"]);
                objFuncion.Dia = DataConvert.ToInt(dtr["Dia"]);
                objFuncion.Horario = DataConvert.ToString(dtr["Horario"]);
                objFuncion.Estado = DataConvert.ToString(dtr["F.Estado"]);
                objFuncion.Obra = new Obra()
                {
                    Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                    FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]),
                    FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]),
                    Descripcion = DataConvert.ToString(dtr["O.Descripcion"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["T.frmTeatro"])
                    }
                };
                objFuncion.FechaCreacion = DataConvert.ToDateTime(dtr["F.FechaCrea"]);
                objFuncion.UsuarioCreacion = DataConvert.ToString(dtr["F.UserCrea"]);
                objFuncion.FechaModificacion = DataConvert.ToDateTime(dtr["F.FechaMod"]);
                objFuncion.UsuarioModificacion = DataConvert.ToString(dtr["F.UserMod"]);
                listaFuncion.Add(objFuncion);
            }
            UtilDA.Close(cnx);
            return listaFuncion;
        }

        public bool Insert(Funcion datos)
        {
            String sql = "INSERT INTO TH_FUNCION(DIA, HORARIO, ESTADO, IDOBRA, FECHACREA, USERCREA) " +
                            "VALUES(@dia, @horario, @estado, @idobra, @fechacrea, @usuariocrea)";

            OleDbParameter dia = UtilDA.SetParameters("@nombre", OleDbType.Integer, datos.Dia);
            OleDbParameter horario = UtilDA.SetParameters("@horario", OleDbType.VarChar, datos.Horario);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idobra = UtilDA.SetParameters("@IdZona", OleDbType.Integer, datos.Obra.IdObra);
            OleDbParameter fechacreacion = UtilDA.SetParameters("@fechacrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuariocrea = UtilDA.SetParameters("@usuariocrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, dia, horario, estado , idobra, fechacreacion, usuariocrea);
        }

        public List<Funcion> ListarFuncionDiaObra(int dia, int obra)
        {
            List<Funcion> lFuncion = new List<Funcion>();
            Funcion funcion = null;
            string sql = "SELECT * FROM (TH_FUNCION F INNER JOIN TH_OBRA O ON F.IDOBRA = O.IDOBRA) INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE F.IDOBRA = @Obra AND Dia = @Dia";
            OleDbParameter pObra = UtilDA.SetParameters("@Obra", OleDbType.Integer, obra);
            OleDbParameter pDia = UtilDA.SetParameters("@Dia", OleDbType.Integer, dia);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pObra, pDia))
            {
                while (dtr.Read())
                {
                    funcion = new Funcion()
                    {
                        Dia = DataConvert.ToInt(dtr["Dia"]),
                        Estado = DataConvert.ToString(dtr["F.Estado"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["F.FechaCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["F.FechaMod"]),
                        Horario = DataConvert.ToString(dtr["Horario"]),
                        IdFuncion = DataConvert.ToInt(dtr["IdFuncion"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["F.UserCrea"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["F.UserMod"]),
                        Obra = new Obra()
                        {
                            IdObra = DataConvert.ToInt(dtr["O.IdObra"]),
                            Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                            Estado = DataConvert.ToString(dtr["O.Estado"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]),
                            FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]),
                            FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                            FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                            Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]),
                            UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]),
                            Teatro = new Teatro()
                            {
                                IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                                Estado = DataConvert.ToString(dtr["T.Estado"]),
                                FechaCreacion = DataConvert.ToDateTime(dtr["T.FechaCrea"]),
                                FechaModificacion = DataConvert.ToDateTime(dtr["T.FechaMod"]),
                                UsuarioCreacion = DataConvert.ToString(dtr["T.UserCrea"]),
                                UsuarioModificacion = DataConvert.ToString(dtr["T.UserMod"]),
                                frmTeatro = DataConvert.ToString(dtr["frmTeatro"]),
                                Nombre = DataConvert.ToString(dtr["T.Nombre"])
                            }
                        }
                        
                    };
                    lFuncion.Add(funcion);
                }
                
            }
            UtilDA.Close(cnx);
            return lFuncion;
        }

        public bool Update(Funcion datos)
        {
            String sql = "UPDATE TH_FUNCION SET DIA = @dia, HORARIO = @horario, ESTADO = @estado, IDOBRA = @idobra, " +
                           "FECHAMOD = @fechamod, USERMOD = @usermod WHERE IDFUNCION = @idfuncion";

            OleDbParameter dia = UtilDA.SetParameters("@dia", OleDbType.Integer, datos.Dia);
            OleDbParameter horario = UtilDA.SetParameters("@horario", OleDbType.VarChar, datos.Horario);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idobra = UtilDA.SetParameters("@Idobra", OleDbType.Integer, datos.Obra.IdObra);
            OleDbParameter fechamod = UtilDA.SetParameters("@fechamod", OleDbType.Date, DateTime.Now);
            OleDbParameter usermod = UtilDA.SetParameters("@usermod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idfuncion = UtilDA.SetParameters("@idfuncion", OleDbType.Integer, datos.IdFuncion);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, dia, horario, estado, idobra, fechamod, usermod, idobra);
        }

        public List<Funcion> ListarFuncionByObra(int idObra)
        {
            List<Funcion> listaFuncion = new List<Funcion>(); ;

            String sql = "SELECT * FROM (TH_FUNCION F INNER JOIN TH_OBRA O ON F.IDOBRA = O.IDOBRA)  INNER JOIN TH_TEATRO T ON O.IDTEATRO = T.IDTEATRO WHERE F.IDOBRA = @IdObra";

            OleDbParameter pIdObra = UtilDA.SetParameters("@IdObra", OleDbType.Integer, idObra);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdObra))
            {
                while (dtr.Read())
                {
                    Funcion objFuncion = new Funcion();
                    objFuncion.IdFuncion = DataConvert.ToInt(dtr["IdFuncion"]);
                    objFuncion.Dia = DataConvert.ToInt(dtr["Dia"]);
                    objFuncion.Horario = DataConvert.ToString(dtr["Horario"]);
                    objFuncion.Estado = DataConvert.ToString(dtr["F.Estado"]);
                    objFuncion.Obra = new Obra()
                    {
                        Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Teatro = new Teatro()
                        {
                            IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                            Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                            Estado = DataConvert.ToString(dtr["T.Estado"]),
                            frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                        }
                    };
                    objFuncion.FechaCreacion = DataConvert.ToDateTime(dtr["F.FechaCrea"]);
                    objFuncion.UsuarioCreacion = DataConvert.ToString(dtr["F.UserCrea"]);
                    objFuncion.FechaModificacion = DataConvert.ToDateTime(dtr["F.FechaMod"]);
                    objFuncion.UsuarioModificacion = DataConvert.ToString(dtr["F.UserMod"]);
                    listaFuncion.Add(objFuncion);
                }
            }
            UtilDA.Close(cnx);
            return listaFuncion;
        }
    }
}
