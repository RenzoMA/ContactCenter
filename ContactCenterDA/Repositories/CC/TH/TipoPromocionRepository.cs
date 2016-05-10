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
using ContactCenterBE.CC.Entidades.UsuarioBE;


namespace ContactCenterDA.Repositories.CC.TH
{
    public class TipoPromocionRepository : ITipoPromocionRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_TIPO_PROMOCION SET ESTADO = 'I', FECHAMOD = @fechaMod, USERMOD = @userMod WHERE IDTIPOPROMOCION = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@userMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, codigo);
        }

        public TipoPromocion GetById(int id)
        {
            TipoPromocion objTipoPromocion = null;
            String sql = "SELECT * FROM TH_TIPO_PROMOCION WHERE IDTIPOPROMOCION = @codigo";
            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objTipoPromocion = new TipoPromocion();
                objTipoPromocion.IdTipoPromocion = DataConvert.ToInt(dtr["IdTipoPromocion"]);
                objTipoPromocion.Descripcion = DataConvert.ToString(dtr["Descripcion"]);
                objTipoPromocion.Estado = DataConvert.ToString(dtr["Estado"]);
                objTipoPromocion.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                objTipoPromocion.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                objTipoPromocion.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                objTipoPromocion.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
            }
            UtilDA.Close(cnx);
            return objTipoPromocion;
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
            String sql = "INSERT INTO TH_TIPOPROMOCION(Descripcion, Estado, FechaCrea, UserCrea) VALUES(@descripcion, @estado, @fechaCrea, @userCrea";

            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter userCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, datos.UsuarioCreacion);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, descripcion, estado, fechaCrea, userCrea);
        }

        public bool Update(TipoPromocion datos)
        {
            String sql = "UPDATE TH_TIPOPROMOCION SET Descripcion = @descripcion, Estado = @estado, FechaMod = @fechaMod, UserMod = @userMod WHERE IDTIPOPROMOCION = @idTipoPromocion";

            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter userMod = UtilDA.SetParameters("@userMod", OleDbType.VarChar, datos.UsuarioCreacion);
            OleDbParameter codigo = UtilDA.SetParameters("@idTipoPromocion", OleDbType.Integer, datos.IdTipoPromocion);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, descripcion, estado, fechaMod, userMod, codigo);
        }
    }
}
