using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class TarifaRepository : ITarifaRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_Tarifa SET Estado = 'I', FechaMod = @fechaMod, UserMod = @userMod where IdTarifa = @idTarifa";

            OleDbParameter idTarifa = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, idTarifa);

        }

        public Tarifa GetById(int id)
        {
            Tarifa objTarifa = null;

            String sql = "SELECT * FROM TH_Tarifa T INNER JOIN TH_OBRA O ON O.IdObra = T.IdObra INNER JOIN TH_ZONA Z ON Z.IdZona = T.IdZona INNER JOIN TH_TEATRO TE ON TE.IdTeatro = Z.IdTeatro" +
                            " WHERE IdTarifa = @idTarifa";

            OleDbParameter idTarifa = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, idTarifa))
            {
                objTarifa = new Tarifa();
                objTarifa.IdTarifa = DataConvert.ToInt(dtr["T.IdTarifa"]);
                objTarifa.Zona = new Zona()
                {
                    IdZona = DataConvert.ToInt(dtr["Z.IdZona"]),
                    Nombre = DataConvert.ToString(dtr["Z.Nombre"]),
                    Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]),
                    Estado = DataConvert.ToString(dtr["Z.Estado"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["TE.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["TE.Nombre"]),
                        Estado = DataConvert.ToString(dtr["TE.Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["TE.frmTeatro"])
                    }
                };

                objTarifa.Obra = new Obra()
                {
                    Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                    FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]),
                    FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]),
                    Descripcion = DataConvert.ToString(dtr["O.Descripcion"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["TE.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["TE.Nombre"]),
                        Estado = DataConvert.ToString(dtr["TE.Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["TE.frmTeatro"])
                    }
                };
                    objTarifa.FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]);
                    objTarifa.UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]);
                    objTarifa.FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]);
                    objTarifa.UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]);
            }
            UtilDA.Close(cnx);
            return objTarifa;
        }
        

        public IList<Tarifa> GetLista()
        {

            List<Tarifa> listTarifa = null;

            String sql = "SELECT * FROM TH_Tarifa T INNER JOIN TH_OBRA O ON O.IdObra = T.IdObra INNER JOIN TH_ZONA Z ON Z.IdZona = T.IdZona INNER JOIN TH_TEATRO TE ON TE.IdTeatro = Z.IdTeatro";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                Tarifa objTarifa = new Tarifa();
                objTarifa.IdTarifa = DataConvert.ToInt(dtr["T.IdTarifa"]);
                objTarifa.Zona = new Zona()
                {
                    IdZona = DataConvert.ToInt(dtr["Z.IdZona"]),
                    Nombre = DataConvert.ToString(dtr["Z.Nombre"]),
                    Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]),
                    Estado = DataConvert.ToString(dtr["Z.Estado"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["TE.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["TE.Nombre"]),
                        Estado = DataConvert.ToString(dtr["TE.Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["TE.frmTeatro"])
                    }
                };

                objTarifa.Obra = new Obra()
                {
                    Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                    FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]),
                    FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]),
                    Descripcion = DataConvert.ToString(dtr["O.Descripcion"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["TE.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["TE.Nombre"]),
                        Estado = DataConvert.ToString(dtr["TE.Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["TE.frmTeatro"])
                    }
                };
                objTarifa.FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]);
                objTarifa.UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]);
                objTarifa.FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]);
                objTarifa.UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]);
                listTarifa.Add(objTarifa);
            }
            UtilDA.Close(cnx);
            return listTarifa;
        }

        public bool Insert(Tarifa datos)
        {
            String sql = "INSERT INTO TH_Tarifa(IdZona, IdObra, Precio, FechaCrea, UserCrea" +
                        " VALUES(@idZona, @idObra, @precio, @fechaCrea, @userCrea";

            OleDbParameter idZona = UtilDA.SetParameters("@idZona", OleDbType.Integer, datos.Zona.IdZona);
            OleDbParameter idObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, datos.Obra.IdObra);
            OleDbParameter precio = UtilDA.SetParameters("@precio", OleDbType.Single, datos.Precio);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter userCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, datos.UsuarioCreacion);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, idZona, idObra, precio, fechaCrea, userCrea);
        }

        public bool Update(Tarifa datos)
        {
            String sql = "UPDATE TH_Tarifa SET IdZona = @idZona, IdObra = @idObra, Precio = @precio, FechaMod = @fechaMod, UserMod = @userMod WHERE IdTarifa = @idTarifa";

            OleDbParameter idZona = UtilDA.SetParameters("@idZona", OleDbType.Integer, datos.Zona.IdZona);
            OleDbParameter idObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, datos.Obra.IdObra);
            OleDbParameter precio = UtilDA.SetParameters("@precio", OleDbType.Single, datos.Precio);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter userCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, datos.UsuarioCreacion);
            OleDbParameter idTarifa = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, datos.IdTarifa);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, idZona, idObra, precio, fechaCrea, userCrea, idTarifa);
        }

        public List<Tarifa> GetListaByTeatroObra(int IdObra)
        {
            List<Tarifa> listTarifa = new List<Tarifa>();
            String sql = "SELECT * FROM((TH_Tarifa T INNER JOIN TH_OBRA O ON O.IdObra = T.IdObra) INNER JOIN TH_ZONA Z ON Z.IdZona = T.IdZona) INNER JOIN TH_TEATRO TE ON TE.IdTeatro = Z.IdTeatro WHERE T.IDOBRA = @idObra";

            OleDbParameter codigoObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, IdObra);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigoObra))
            {
                Tarifa objTarifa = new Tarifa()
                {
                    IdTarifa = DataConvert.ToInt(dtr["T.IdTarifa"]),
                    Zona = new Zona()
                    {
                        IdZona = DataConvert.ToInt(dtr["Z.IdZona"]),
                        Nombre = DataConvert.ToString(dtr["Z.Nombre"]),
                        Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]),
                        Estado = DataConvert.ToString(dtr["Z.Estado"]),
                        Teatro = new Teatro()
                        {
                            IdTeatro = DataConvert.ToInt(dtr["TE.IdTeatro"]),
                            Nombre = DataConvert.ToString(dtr["TE.Nombre"]),
                            Estado = DataConvert.ToString(dtr["TE.Estado"]),
                            frmTeatro = DataConvert.ToString(dtr["TE.frmTeatro"])
                        }
                    },
                    Obra = new Obra()
                    {
                        IdObra = DataConvert.ToInt(dtr["O.IdObra"]),
                        Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]),
                        Descripcion = DataConvert.ToString(dtr["O.Descripcion"]),
                        Teatro = new Teatro()
                        {
                            IdTeatro = DataConvert.ToInt(dtr["TE.IdTeatro"]),
                            Nombre = DataConvert.ToString(dtr["TE.Nombre"]),
                            Estado = DataConvert.ToString(dtr["TE.Estado"]),
                            frmTeatro = DataConvert.ToString(dtr["TE.frmTeatro"])
                        }
                    },
                    FechaCreacion = DataConvert.ToDateTime(dtr["T.FechaCrea"]),
                    UsuarioCreacion = DataConvert.ToString(dtr["T.UserCrea"]),
                    FechaModificacion = DataConvert.ToDateTime(dtr["T.FechaMod"]),
                    UsuarioModificacion = DataConvert.ToString(dtr["T.UserMod"])
                };
                    listTarifa.Add(objTarifa);
            }
            UtilDA.Close(cnx);
            return listTarifa;
        }
    }
}
