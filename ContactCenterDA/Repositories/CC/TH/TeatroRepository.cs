using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class TeatroRepository : ITeatroRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        public bool Delete(int id)
        {
            string sql = "UPDATE TH_TEATRO SET Estado = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IdTeatro = @IdTeatro";

            OleDbParameter idTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, fechaMod, userMod, idTeatro);
        }

        public Teatro GetById(int id)
        {
            Teatro teatro = null;
            string sql = "SELECT * FROM TH_TEATRO WHERE IdTeatro = @IdTeatro";
            OleDbParameter idTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, id);
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, idTeatro))
            {
                while (dtr.Read())
                {
                    teatro = new Teatro()
                    {
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        IdTeatro = DataConvert.ToInt(dtr["IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["Nombre"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]),
                        frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                    };
                }
            }
            UtilDA.Close(cnx);
            return teatro;
        }

        public IList<Teatro> GetLista()
        {
            List<Teatro> lTeatro = new List<Teatro>();
            Teatro teatro = null;
            string sql = "SELECT * FROM TH_TEATRO";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    teatro = new Teatro()
                    {
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        IdTeatro = DataConvert.ToInt(dtr["IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["Nombre"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]),
                        frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                    };
                    lTeatro.Add(teatro);
                }
            }
            UtilDA.Close(cnx);
            return lTeatro;
        }

        public bool Insert(Teatro datos)
        {
            string sql = "INSERT INTO TH_TEATRO (Estado,Nombre,FechaCrea,UserCrea,frmTeatro) " +
                         "VALUES (@Estado, @Nombre, @FechaCrea, @UserCrea,@frmTeatro)";

            OleDbParameter estado = UtilDA.SetParameters("@Estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter nombre = UtilDA.SetParameters("@Nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@FechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter userCrea = UtilDA.SetParameters("@UserCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter frmTeatro = UtilDA.SetParameters("@frmTeatro", OleDbType.VarChar, datos.frmTeatro);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, estado, nombre, fechaCrea, userCrea, frmTeatro);


        }

        public bool Update(Teatro datos)
        {
            string sql = "UPDATE TH_TEATRO SET Estado = @Estado, Nombre = @Nombre, FechaMod = @FechaMod," + 
                         "UserMod = @UserMod, frmTeatro = @frmTeatro WHERE IdTeatro = @IdTeatro";

            OleDbParameter estado = UtilDA.SetParameters("@Estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter nombre = UtilDA.SetParameters("@Nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, datos.IdTeatro);
            OleDbParameter frmTeatro = UtilDA.SetParameters("@frmTeatro", OleDbType.VarChar, datos.frmTeatro);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, estado, nombre, fechaMod, userMod, frmTeatro, idTeatro);


        }
    }
}
