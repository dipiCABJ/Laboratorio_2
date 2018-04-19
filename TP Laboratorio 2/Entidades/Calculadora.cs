using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        //METODOS
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double xReturn;
            switch (ValidarOperador(operador))
            {
                case "*":
                    xReturn = n1 * n2;
                    break;

                case "/":
                    xReturn = n1 / n2;
                    break;

                case "-":
                    xReturn = n1 - n2;
                    break;

                default:
                    xReturn = n1 + n2;
                    break;
            }
            return xReturn;
        }

        private static string ValidarOperador(string operador)
        {
            string xStrReturn = "";
            switch(operador)
            {
                case "-":
                    xStrReturn = "-";
                    break;
                case "/":
                    xStrReturn = "/";
                    break;
                case "*":
                    xStrReturn = "*";
                    break;
                default:
                    xStrReturn = "+";
                    break;
            }
            //Se valida de esta manera, con una variable string auxiliar para tener un solo return
            return xStrReturn;
        }
    }
}
