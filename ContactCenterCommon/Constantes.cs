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
            public const string TeatroConfirmacionReserva = @"	 <!DOCTYPE html>	" +
"	<html lang='ES'>	" +

"	<head>	" +
"       <meta charset='utf-8'> " +
"       <meta http-equiv='X-UA-Compatible' content='IE=edge'> " +
"       <meta name = 'viewport' content='initial-scale=1, maximum-scale=1'> " +
"	</head>	" +

"	<body>	" +
"	    <div style='font-family: 'Arial'; '>	" +
"	        <div style='background-color:black;box-sizing: border-box;padding: 20px; width: 100%'>	" +
"	            <h1 style='color: white; text-align: center;'> TU RESERVA HA SIDO CONFIRMADA</h1>	" +
"	        </div>	" +
"		" +
"	        <div style='display: flex;'>	" +
"		" +
"	            <div style ='width :60%;'>	" +
"		" +
"	                <p style='font-weight: bold;    font-size: 30px;    text-align: center;'> %Nombre </p> </br>	" +
"		" +
"	                <p style='text-align: center;    font-size: 20px;'> Ha realizado una reserva para la obra %Obra el %Fecha </br>	" +
"	                en el teatro %Teatro a las %Hora </p>	" +
"		" +
"	                <p style='text-align: center;'> Total de reservas    : 	%Total</p>	" +
"	                <p style='text-align: center;'> Zona               		:	%Zona</p>	" +
"	                <p style='text-align: center;'> Ubicaciones        	: 	%Ubicacion</p>	" +
"	                <p style='text-align: center;'> Precio            		: 	%Precio</p>	" +
"	            </div>	" +
"		" +
"	            <div style='width:30%'>	" +
"	                <img src='cid:ImagenObra' alt='obra' />	" +
"	            </div>	" +
"		" +
"	        </div>	" +
"	        <div>	" +
"	            <h2 style='color: gray;    text-align: center;'>	" +
"	            GRACIAS POR LLAMARNOS, NO OLVIDES LLEGAR UNA HORA <br>	" +
"	            ANTES DE LA FUNCIÓN PARA HACER EFECTIVA TU RESERVA.	" +
"	            </h2>	" +
"	            <h3 style='color: gray;    text-align: center;    font-weight: bold;'>	" +
"	            ¡QUÉ TE DIVIERTAS!	" +
"	            </h3>	" +
"	        </div>	" +
"	    </div>	" +
"	</body>	" +
"	</html>	";
        }

        public static class Subjects
        {
            public const string TeatroConfirmacionReserva = "Confirmación de Reserva";
        }
    }
}
