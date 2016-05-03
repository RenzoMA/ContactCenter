using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;



namespace ContactCenterDA.Repositories.CC.TH
{
    public class PromocionRepository : IPromocionRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_PR SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IDFUNCION = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, fechaMod, userMod, codigo);
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
                    IdFuncion = DataConvert.ToInt(dtr["IdFuncion"]),
                    Dia = DataConvert.ToInt(dtr["Dia"]),
                    Horario = DataConvert.ToString(dtr["Horario"]),
                    Estado = DataConvert.ToString(dtr["F.Estado"]),
                    Obra = new Obra()
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
                    },
                };
                objPromocion.TipoPromocion = new 

            }
            return objPromocion;
            UtilDA.Close(cnx);
        }

        public IList<Promocion> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Promocion datos)
        {
            throw new NotImplementedException();
        }

        public bool Update(Promocion datos)
        {
            throw new NotImplementedException();
        }
    }
}
