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
            //prueba
            throw new NotImplementedException();
        }

        public Funcion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Funcion> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Funcion datos)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
