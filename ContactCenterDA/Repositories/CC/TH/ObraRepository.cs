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
            throw new NotImplementedException();
        }

        public Obra GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Obra> GetLista()
        {
            throw new NotImplementedException();
        }

        public List<Obra> GetListaTeatro(int idTeatro)
        {
            List<Obra> lObra = new List<Obra>();
            Obra obra = null;
            string sql = "SELECT O.IDOBRA,O.DESCRIPCION,O.FECHACREA,O.FECHAFIN,O.FECHAINICIO,O.FECHAMOD,O.NOMBRE,O.USERCREA,O.USERMOD,O.Estado,O.IdTeatro, " +
                         "T.IdTeatro,T.Estado,T.FechaCrea,T.FechaMod,T.frmTeatro,T.Nombre,T.UserCrea,T.UserMod " +
                         "FROM TH_OBRA O INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @IdTeatro";

            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdTeatro))
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
            throw new NotImplementedException();
        }

        public bool Update(Obra datos)
        {
            throw new NotImplementedException();
        }
    }
}
