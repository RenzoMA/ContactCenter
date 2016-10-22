using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;


namespace ContactCenterDA.Repositories.CC.TH
{
    public class EmpresaRepository : IEmpresaRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            string sql = "UPDATE TH_EMPRESA SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IdEmpresa = @codigo";

            OleDbParameter FechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter UserMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, FechaMod, UserMod, codigo);
        }

        public Empresa GetById(int id)
        {
            string sql = "SELECT * FROM TH_EMPRESA WHERE IdEmpresa = @codigo";
            Empresa empresa = null;

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                if (dtr.HasRows)
                {
                    dtr.Read();
                    empresa = new Empresa()
                    {
                        CantidadCorteisas = DataConvert.ToInt(dtr["CantidadCortesias"]),
                        Cortesias = DataConvert.ToBool(dtr["Cortesias"]),
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        IdEmpresa = DataConvert.ToInt(dtr["IdEmpresa"]),
                        Nombre = DataConvert.ToString(dtr["Nombre"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"])
                    };
                }
            }
            UtilDA.Close(cnx);
            return empresa;

        }

        public IList<Empresa> GetLista()
        {
            string sql = "SELECT * FROM TH_EMPRESA";
            List<Empresa> listaEmpresa = new List<Empresa>();

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    Empresa empresa = new Empresa()
                    {
                        CantidadCorteisas = DataConvert.ToInt(dtr["CantidadCortesias"]),
                        Cortesias = DataConvert.ToBool(dtr["Cortesias"]),
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        IdEmpresa = DataConvert.ToInt(dtr["IdEmpresa"]),
                        Nombre = DataConvert.ToString(dtr["Nombre"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"])
                    };
                    listaEmpresa.Add(empresa);
                }
            }
            UtilDA.Close(cnx);
            return listaEmpresa;
        }

        public bool Insert(Empresa datos)
        {
            string sql = "INSERT INTO TH_EMPRESA (Nombre,Cortesias,CantidadCortesias,Estado,FechaCrea,UserCrea) VALUES (@Nombre,@Cortesias,@CantidadCortesias,@Estado,@FechaCrea,@UserCrea)";
            //@Nombre,@Cortesias,@CantidadCortesias,@Estado,@FechaCrea,@UserCrea
            OleDbParameter pNombre = UtilDA.SetParameters("@Nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter pCortesias = UtilDA.SetParameters("@Cortesias", OleDbType.Boolean, datos.Cortesias);
            OleDbParameter pCantidadCortesias = UtilDA.SetParameters("@CantidadCortesias", OleDbType.Integer, datos.CantidadCorteisas);
            OleDbParameter pEstado = UtilDA.SetParameters("@Estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter pFechaCrea = UtilDA.SetParameters("@FechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter pUserCrea = UtilDA.SetParameters("@UserCrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pNombre, pCortesias, pCantidadCortesias, pEstado, pFechaCrea, pUserCrea);

        }

        public bool Update(Empresa datos)
        {
            string sql = "UPDATE TH_EMPRESA SET Nombre = @Nombre, Cortesias = @Cortesias, CantidadCortesias = @CantidadCortesias, Estado = @Estado, FechaMod = @FechaMod, UserMod = @UserMod WHERE IdEmpresa = @IdEmpresa";
            OleDbParameter pNombre = UtilDA.SetParameters("@Nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter pCortesias = UtilDA.SetParameters("@Cortesias", OleDbType.Boolean, datos.Cortesias);
            OleDbParameter pCantidadCortesias = UtilDA.SetParameters("@CantidadCortesias", OleDbType.Integer, datos.CantidadCorteisas);
            OleDbParameter pEstado = UtilDA.SetParameters("@Estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter pFechaCrea = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter pUserCrea = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pIdEmpresa = UtilDA.SetParameters("@IdEmpresa", OleDbType.Integer, datos.IdEmpresa);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pNombre, pCortesias, pCantidadCortesias, pEstado, pFechaCrea, pUserCrea, pIdEmpresa);
        }
    }
}
