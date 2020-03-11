using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformarNumeroALetra
{
    public sealed class Util
    {

        private static string[] UNIDADES = { 
            "uno",
            "dos",
            "tres",
            "cuatro",
            "cinco",
            "seis",
            "siete",
            "ocho",
            "nueve"
        };

        private static string[] ONCES = {
            "once",
            "doce",
            "trece",
            "catorce",
            "quince",
            "dieciseis",
            "diecisiete",
            "dieciocho",
            "diecinueve"
        };

        private static string[] DECENAS = {
            "diez",
            "veinte",
            "treinta",
            "cuarenta",
            "cincuenta",
            "sesenta",
            "setenta",
            "ochenta",
            "noventa"
        };

        private static string[] CENTENAS = {
            "cien",
            "doscientos",
            "trescientos",
            "cuatrocientos",
            "quinientos",
            "seiscientos",
            "setecientos",
            "ochocientos",
            "novecientos"
        };

        public static string NumberToWord(int number)
        {

            if (number == 0) return "Zero";

            string response = "",aux;

            int cientos = number % 1_000,
                millones = number / 1_000_000,
                miles = Math.Abs(((millones * 1_000_000) - number) / 1_000);
               
            if (!((aux = numberCentenaToString(millones)).Equals(String.Empty)))
            {
                if(millones == 1)
                {
                    response += "Un millón ";
                }
                else
                {
                    response += aux + " millones ";
                }
            }

            if (!((aux = numberCentenaToString(miles)).Equals(String.Empty)))
            {
                if(miles == 1)
                {
                    response += " mil ";
                }
                else
                {
                    response += aux + " mil ";
                }
            }

            if (!((aux = numberCentenaToString(cientos)).Equals(String.Empty)))
            {
                response += aux;
            }

            return response.Trim();
        }

        public static String numberCentenaToString(int number) {

            int unidades = number % 10;
            int decenas = number / 10 % 10;
            int centenas = number / 100;

            string response = "";

            if (centenas > 0)
            {
                if(centenas == 1 && (decenas != 0 || unidades != 0))
                {
                    response += "ciento ";
                }
                else
                {
                    response += Util.CENTENAS[centenas - 1] + " ";
                }
            }

            if(decenas > 0)
            {

                if(decenas == 1)
                {

                    //deberiamos de evaluar el siguiente número

                    response += unidades == 0 ? Util.DECENAS[0] : Util.ONCES[unidades - 1];

                    return response;

                }
                else
                {

                    response += Util.DECENAS[decenas - 1];

                }

                response += " ";

            }
            
            if(unidades > 0)
            {

                response += (decenas > 1?"y ":"") + Util.UNIDADES[unidades - 1];

            }

            return response.Trim();

        }

    }

}
