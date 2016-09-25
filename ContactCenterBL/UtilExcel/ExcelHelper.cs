using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToExcel;
using System.Threading.Tasks;

namespace ContactCenterBL.UtilExcel
{
    public class ExcelHelper
    {
        public static List<ExcelModelMasivo> GetListaCargaMasiva(string path)
        {
            var book = new ExcelQueryFactory(path);
            var resultado = (from row in book.Worksheet("Formato")
                             let item = new ExcelModelMasivo
                             {
                                 Teatro = row["TEATRO"].Cast<string>(),
                                 Obra = row["OBRA"].Cast<string>(),
                                 FechaReserva = row["FECHA RESERVA"].Cast<DateTime>(),
                                 Funcion = row["FUNCION"].Cast<string>(),
                                 Zona = row["ZONA"].Cast<string>(),
                                 Fila = row["FILA"].Cast<string>(),
                                 Asiento = row["ASIENTO"].Cast<string>(),
                                 Promocion = row["PROMOCION"].Cast<string>(),
                                 Precio = row["PRECIO"].Cast<Single>(),
                                 Telefono = row["TELEFONO"].Cast<string>(),
                                 Nombre = row["NOMBRE"].Cast<string>(),
                                 Apellidos = row["APELLIDOS"].Cast<string>(),
                                 Correo = row["CORREO"].Cast<string>(),
                                 UsuarioRegistro = row["USUARIO REGISTRO"].Cast<string>()
                             }
                             select item).ToList();

            return resultado.Where(tx => tx.Teatro != null).ToList();
        }
    }
}
