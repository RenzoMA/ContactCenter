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
            public const string TeatroConfirmacionReserva =@"	<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> " +
"   <html xmlns='http://www.w3.org/1999/xhtml'>     " +

"   <head>      " +
"       <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />       " +
"       <title>mail</title>     " +
"       <meta name='viewport' content='width=device-width, initial-scale=1.0'/>     " +

"   </head>     " +

"   <body>      " +
"     <table width:'100%' style='margin:auto; text-align:center;  font-family: sans-serif;'>        " +

"       <tr style='width:100%; background-color:black;'>        " +
"           <td colspan='2' style='width:100%; font-size: 30px; color:white; padding:10px;'>TU RESERVA HA SIDO CONFIRMADA</td>      " +
"       </tr>       " +

"       <tr style='width:100%'>     " +
"           <td id='p1' style='width: 100%; padding:10px;'>      " +
"               <table width:'100%'>        " +
"                   <tr>        " +
"                       <td style ='font-size:19px;  font-weight: bold;'> %Nombre </td>        " +
"                   </tr>       " +
"                   <tr>        " +
"                       <td>Ha realizado una reserva para la obra <b> %Obra  </b> el <b> %Fecha  </b> en el teatro <b> %Teatro </b> a las <b> %Hora </b> </td>     " +
"                   </tr>       " +
"                   <tr>        " +
"                       <td>    " +
"                           <table style = 'margin:auto;'>     " +
"                               <tr>        " +
"                                   <td style='font-weight: bold;'> Total de Reservas </td>        " +
"                                   <td style='font-weight: bold;'>:</td>    " +
"                                   <td> %Total </td>       " +
"                               </tr>       " +
//"                               <tr>        " +
//"                                   <td> Zona </td>     " +
//"                                   <td>:</td>      " +
//"                                   <td> %Zona </td>        " +
//"                               </tr>       " +
"                               <tr>        " +
"                                   <td style='font-weight: bold;'> Ubicaciones </td> " +
"                                   <td style='font-weight: bold;'>:</td>      " +
"                                   <td> %Ubicacion </td>       " +
"                               </tr>       " +
"                               <tr>        " +
"                                   <td style='font-weight: bold;'> Precio </td>       " +
"                                   <td style='font-weight: bold;'>:</td>      " +
"                                   <td> %Precio </td>      " +
"                               </tr>       " +
"                           </table>        " +
"                       </td>       " +
"                   </tr>       " +
"               </table> " +
"           </td> " +
//"           <td id='p2' style='width: 40%;'>        " +
//"               <img src= 'cid:ImagenObra'>     " +
//"           </td>       " +
"       </tr>     " +
"       <tr style='width:100%; margin:auto;'>      " +
"           <td>        " +
"               <img src= 'cid:ImagenObra'>      " +
"           </td>       " +
"       </tr>       " +
"       <tr style='width:100%;'>        " +
"           <table style='margin:auto; text-align:center;  font-family: sans-serif; padding:10px; color:gray;'>        " +
"               <tr> " +
"                   <td style='font-size:20px;'> GRACIAS POR LLAMARNOS, NO OLVIDES LLEGAR UNA HORA ANTES DE LA FUNCIÓN PARA HACER EFECTIVA TU RESERVA.</td>     " +
"               </tr>       " +
"               <tr>        " +
"                   <td style ='font-size:19px;  font-weight: bold;'> ¡QUÉ TE DIVIERTAS! </td>      " +
"               </tr>       " +
"           </table>        " +
"       </tr>       " +
" </body>   " +

 "</html>   ";
        }

        public static class Subjects
        {
            public const string TeatroConfirmacionReserva = "Confirmación de Reserva";
        }
    }
}
