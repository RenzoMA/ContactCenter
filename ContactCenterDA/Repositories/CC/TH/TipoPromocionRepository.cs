using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class TipoPromocionRepository : ITipoPromocionRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoPromocion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TipoPromocion> GetLista()
        {
            string SQL = "SELECT * FROM TH_TIPO_PROMOCION WHERE ESTADO = 'A'";
            List<TipoPromocion> ListaPromocion = new List<TipoPromocion>();
            TipoPromocion tipoPromocion = null;

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, SQL, cnx))
            {
                while (dtr.Read())
                {
                    tipoPromocion = new TipoPromocion()
                    {
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        IdTipoPromocion = DataConvert.ToInt(dtr["IdTipoPromocion"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"])
                    };
                    ListaPromocion.Add(tipoPromocion);
                }
            }
            UtilDA.Close(cnx);
            return ListaPromocion;
        }

        public bool Insert(TipoPromocion datos)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoPromocion datos)
        {
            throw new NotImplementedException();
        }
    }
}
