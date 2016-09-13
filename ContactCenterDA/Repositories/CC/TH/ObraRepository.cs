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
            String sql = "UPDATE TH_OBRA SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IdObra = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, codigo);
        }

        public Obra GetById(int id)
        {
            Obra objObra = null;

            String sql = "SELECT * FROM TH_OBRA O INNER JOIN TH_TEATRO T ON O.IDTEATRO = T.IDTEATRO WHERE IDOBRA = @codigo ";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objObra = new Obra();
                objObra.IdObra = DataConvert.ToInt(dtr["IdObra"]);
                objObra.Nombre = DataConvert.ToString(dtr["O.Nombre"]);
                objObra.FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]);
                objObra.FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]);
                objObra.Descripcion = DataConvert.ToString(dtr["Descripcion"]);
                objObra.Estado = DataConvert.ToString(dtr["O.Estado"]);
                objObra.Teatro = new Teatro()
                {
                    IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                    Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                    Estado = DataConvert.ToString(dtr["T.Estado"]),
                    frmTeatro = DataConvert.ToString(dtr["T.frmTeatro"])
                };
                objObra.FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]);
                objObra.UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]);
                objObra.FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]);
                objObra.UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]);
                objObra.Image = DataConvert.ToByteArrayNull(dtr["Imagen"]);
            }
            UtilDA.Close(cnx);
            return objObra;
        }

        public IList<Obra> GetLista()
        {
            
            String sql = "SELECT * FROM TH_OBRA O INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO";
            Obra obra = null;
            List<Obra> ListaObra = new List<Obra>();
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    obra = new Obra()
                    {
                        IdObra = DataConvert.ToInt(dtr["IdObra"]),
                        Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Estado = DataConvert.ToString(dtr["O.Estado"]),
                        Teatro = new Teatro()
                        {
                            IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                            Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                            Estado = DataConvert.ToString(dtr["T.Estado"]),
                            frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                        },
                        FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]),
                        Image = DataConvert.ToByteArrayNull(dtr["Imagen"])
                };
                    ListaObra.Add(obra);
                }
            }
            UtilDA.Close(cnx);
            return ListaObra;
        }

        public List<Obra> ComboManGetListaTeatro(int idTeatro)
        {
            List<Obra> lObra = new List<Obra>();
            Obra obra = null;
            string sql = "SELECT O.IDOBRA,O.DESCRIPCION,O.FECHACREA,O.FECHAFIN,O.FECHAINICIO,O.FECHAMOD,O.NOMBRE,O.USERCREA,O.USERMOD,O.Estado,O.IdTeatro, " +
                         "T.IdTeatro,T.Estado,T.FechaCrea,T.FechaMod,T.frmTeatro,T.Nombre,T.UserCrea,T.UserMod, O.Imagen " +
                         "FROM TH_OBRA O INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @IdTeatro";

            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);
            OleDbParameter pFechaActual = UtilDA.SetParameters("@fechaActual", OleDbType.Date, DateTime.Today);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdTeatro, pFechaActual))
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
                        UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]),
                        //Image = DataConvert.ToByteArrayNull(dtr["Imagen"])
                    };
                    lObra.Add(obra);
                }

            }
            UtilDA.Close(cnx);
            return lObra;

        }

        public List<Obra> GetListaTeatro(int idTeatro)
        {
            List<Obra> lObra = new List<Obra>();
            Obra obra = null;
            string sql = "SELECT O.IDOBRA,O.DESCRIPCION,O.FECHACREA,O.FECHAFIN,O.FECHAINICIO,O.FECHAMOD,O.NOMBRE,O.USERCREA,O.USERMOD,O.Estado,O.IdTeatro, " +
                         "T.IdTeatro,T.Estado,T.FechaCrea,T.FechaMod,T.frmTeatro,T.Nombre,T.UserCrea,T.UserMod, O.Imagen " +
                         "FROM TH_OBRA O INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @IdTeatro AND (@fechaActual BETWEEN FECHAINICIO AND FECHAFIN) AND O.ESTADO = 'A'";

            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);
            OleDbParameter pFechaActual = UtilDA.SetParameters("@fechaActual", OleDbType.Date, DateTime.Today);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdTeatro,pFechaActual))
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
                        UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]),
                        //Image = DataConvert.ToByteArrayNull(dtr["Imagen"])
                    };
                    lObra.Add(obra);
                }
                
            }
            UtilDA.Close(cnx);
            return lObra;

        }

        public bool Insert(Obra datos)
        {
            String sql = "INSERT INTO TH_OBRA(Nombre, FechaInicio, FechaFin, Descripcion, Estado, IdTeatro, FechaCrea, UserCrea, Imagen) " +
                        "VALUES(@nombre, @fechaini, @fechafin, @descripcion, @estado, @idTeatro, @fechaCrea, @userCrea, @imagen)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter fechaini = UtilDA.SetParameters("@fechaini", OleDbType.Date, datos.FechaInicio);
            OleDbParameter fechafin = UtilDA.SetParameters("@fechafin", OleDbType.Date, datos.FechaFin);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idTeatro = UtilDA.SetParameters("@idTeatro", OleDbType.Integer, datos.Teatro.IdTeatro);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pImagen = UtilDA.SetParameters("@imagen", OleDbType.VarBinary, datos.Image);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, fechaini, fechafin, descripcion, estado, idTeatro, fechaCreacion, usuarioCrea, pImagen);
        }

        public bool Update(Obra datos)
        {
            String sql = "UPDATE TH_OBRA SET Nombre = @nombre, FechaInicio = @fechaini, FechaFin = @fechafin, Descripcion = @descripcion, Estado = @estado, IdTeatro = @idteatro, FechaMod = @fechaMod, UserMod = @usuarioMod, Imagen = @imagen WHERE IdObra = @idobra";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter fechaini = UtilDA.SetParameters("@fechaini", OleDbType.Date, datos.FechaInicio);
            OleDbParameter fechafin = UtilDA.SetParameters("@fechafin", OleDbType.Date, datos.FechaFin);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idteatro = UtilDA.SetParameters("@idteatro", OleDbType.Integer, datos.Teatro.IdTeatro);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pImagen = UtilDA.SetParameters("@imagen", OleDbType.VarBinary, datos.Image);
            OleDbParameter idObra = UtilDA.SetParameters("@idobra", OleDbType.Integer, datos.IdObra);
            
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, fechaini, fechafin, descripcion, estado, idteatro, fechaMod, usuarioMod, pImagen, idObra);
        }

        public Obra GetbyName(string name)
        {
            Obra objObra = null;

            String sql = "SELECT * FROM TH_OBRA O INNER JOIN TH_TEATRO T ON O.IDTEATRO = T.IDTEATRO WHERE O.NOMBRE = @nombre";

            OleDbParameter codigo = UtilDA.SetParameters("@nombre", OleDbType.VarChar, name);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objObra = new Obra();
                objObra.IdObra = DataConvert.ToInt(dtr["IdObra"]);
                objObra.Nombre = DataConvert.ToString(dtr["O.Nombre"]);
                objObra.FechaInicio = DataConvert.ToDateTime(dtr["O.FechaInicio"]);
                objObra.FechaFin = DataConvert.ToDateTime(dtr["O.FechaFin"]);
                objObra.Descripcion = DataConvert.ToString(dtr["O.Descripcion"]);
                objObra.Estado = DataConvert.ToString(dtr["O.Estado"]);
                objObra.Teatro = new Teatro()
                {
                    IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                    Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                    Estado = DataConvert.ToString(dtr["T.Estado"]),
                    frmTeatro = DataConvert.ToString(dtr["T.frmTeatro"])
                };
                objObra.FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]);
                objObra.UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]);
                objObra.FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]);
                objObra.UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]);
                objObra.Image = DataConvert.ToByteArrayNull(dtr["Imagen"]);
            }
            UtilDA.Close(cnx);
            return objObra;
        }

        public Obra GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Obra> ListarObraByTeatro(int idTeatro)
        {
            string SQL = "SELECT * FROM TH_OBRA O INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @Idteatro";

            OleDbParameter obra_ = UtilDA.SetParameters("@Idteatro", OleDbType.Integer, idTeatro);
            Obra obra = null;
            List<Obra> ListaObra = new List<Obra>();

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, SQL, cnx, obra_))
            {
                while (dtr.Read())
                {
                     obra = new Obra()
                    {
                    IdObra = DataConvert.ToInt(dtr["IdObra"]),
                    Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                    FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                    FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                    Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                    Estado = DataConvert.ToString(dtr["O.Estado"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"]),
                        frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                    },
                    FechaCreacion = DataConvert.ToDateTime(dtr["O.FechaCrea"]),
                    UsuarioCreacion = DataConvert.ToString(dtr["O.UserCrea"]),
                    FechaModificacion = DataConvert.ToDateTime(dtr["O.FechaMod"]),
                    UsuarioModificacion = DataConvert.ToString(dtr["O.UserMod"]),
                     Image = DataConvert.ToByteArrayNull(dtr["Imagen"])
                    };

                    ListaObra.Add(obra);
                }
            }
            UtilDA.Close(cnx);
            return ListaObra;
        }
    }
}
