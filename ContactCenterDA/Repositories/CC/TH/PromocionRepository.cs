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

namespace ContactCenterDA.Repositories.CC.TH
{
    public class PromocionRepository : IPromocionRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Promocion GetById(int id)
        {
            throw new NotImplementedException();
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

        public List<Promocion> ListByFuncionTipoPromo(int idFuncion, int idTipoPromo)
        {
            string SQL = "SELECT* FROM (TH_PROMOCION P INNER JOIN TH_FUNCION F ON F.IDFUNCION = P.IDFUNCION) INNER JOIN TH_TIPO_PROMOCION TP ON TP.IDTIPOPROMOCION = P.IDTIPOPROMOCION WHERE P.IDFUNCION = @IdFuncion AND P.Estado = 'A' AND P.IDTIPOPROMOCION = @IdTipoPromocion";

            OleDbParameter pIdfuncion = UtilDA.SetParameters("@IdFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter pIdTipoPromo = UtilDA.SetParameters("@IdTipoPromocion", OleDbType.Integer, idTipoPromo);
            Promocion promocion = null;
            List<Promocion> ListaPromocion = new List<Promocion>();

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, SQL, cnx, pIdfuncion, pIdTipoPromo))
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
    }
}
