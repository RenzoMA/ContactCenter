using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterCommon
{
    public static class Constantes
    {
        public static class Mails
        {
            public const string TeatroConfirmacionReserva = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> " +
"   <html xmlns='http://www.w3.org/1999/xhtml'>     " +
"   <head>      " +
"       <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />       " +
"       <title>mail</title>     " +
"       <meta name='viewport' content='width=device-width, initial-scale=1.0'/>     " +

"   </head>     " +

"   <body>      " +
"     <table  style='width:100%;margin:auto;text-align:center;font-family:sans-serif;padding:0;min-width:450px;max-width:600px;'>		" +
"       <tr style='width:100%;'>        " +
"           <td colspan='2' style='width:100%;'>      " +
"                <img style='width:100%; min-width:450px;max-width:600px; display:block; border=0;' src='cid:Cabecera'>        " +
"           </td>   " +
"       </tr>       " +
"       <tr style='width:100%;'>     " +
"           <td style='width: 100%; padding:10px;'>      " +
"               <table  style='width:100%;text-align:center;'>        " +
"                   <tr >        " +
"                       <td style ='font-size:19px;font-weight:bold;'> %Nombre </td>        " +
"                   </tr>       " +
"                   <tr>        " +
"                       <td>Ha realizado una reserva para la obra <b> %Obra  </b> el <b> %Fecha  </b> </td>     " +
"                   </tr>       " +
"                   <tr>        " +
"                       <td>en el Teatro <b> %Teatro </b> a las <b> %Hora </b> Hora </td>     " +
"                   </tr>       " +
"                   <tr>        " +
"                       <td>  </td>     " +
"                   </tr>       " +
"                   <tr>        " +
"                       <td>  </td>     " +
"                   </tr>       " +
"                   <tr>        " +
"                       <td>    " +
"                           <table style='margin:auto;'>     " +
"								varDetalle	" +
"                               <tr>        " +
"                                   <td style= 'text-align:right;'> Total de reservas </td>        " +
"                                   <td>:</td>    " +
"                                   <td></td>    " +
"                                   <td></td>    " +
"                                   <td style= 'text-align:left;'> %Total </td>       " +
"                               </tr>       " +
"                               <tr>        " +
"                                   <td style= 'text-align:right;'> Monto total </td>       " +
"                                   <td>:</td>      " +
"                                   <td></td>    " +
"                                   <td></td>    " +
"                                   <td style= 'text-align:left;'> %Precio </td>      " +
"                               </tr>       " +
"                           </table>        " +
"                       </td>       " +
"                   </tr>       " +
"               </table> " +
"           </td> " +
"       </tr>     " +
"       <tr style='width:100%;margin:auto;'>      " +
"           <td style='width: 100%;'>        " +
"               <img style='width:100%; min-width:450px;' src= 'cid:ImagenObra'>      " +
"           </td>       " +
"       </tr>       " +
"       <tr style='width:100%; background-color:black;'>        " +
"         <td style='width: 100%;'>        " +
"           <table style='margin:auto;text-align:center;font-family: sans-serif;padding:10px;color:white;'>        " +
"               <tr> " +
"                   <td style='font-size:12px;'> GRACIAS POR LLAMARNOS, NO OLVIDES LLEGAR UNA HORA ANTES DE LA FUNCIÓN PARA HACER EFECTIVA TU RESERVA.</td>     " +
"               </tr>       " +
"               <tr>        " +
"                   <td style ='font-size:15px;  font-weight: bold;'> ¡QUE TE DIVIERTAS! </td>      " +
"               </tr>       " +
"           </table>        " +
"         </td>        " +
"       </tr>       " +
"        <tr>   " +
"            <td style='padding:5px;'>        " +
"                <p style='text-align:justify; font-size:11px; color:gray;'>    " +
"           LA RESERVA SÓLO SERÁ VALIDA HASTA UNA HORA ANTES DE LA FUNCIÓN, PASADA ESTA HORA SE PROCEDERÁ A LIBERAR LOS ESPACIOS RESERVADOS. ESTA RESERVA ESTÁ BASADA EN LA CONFIANZA, POR LO QUE EL TEATRO LA PLAZA Y LOS PRODUCTORES SE RESERVAN EL DERECHO DE VOLVER A RESERVAR EN CASO NO ASISTA A LA RESERVA PROGRAMADA.    " +
"            </p>    " +
"            </td>    " +
"        </tr>        " +
"    </table>        " +
" </body>   " +
"</html>   ";
        }

        public static class Subjects
        {
            public const string TeatroConfirmacionReserva = "Confirmación de Reserva";
        }
    }
}
