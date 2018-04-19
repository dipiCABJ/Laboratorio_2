using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Numero
    {
        //ATRIBUTO
        private double numero;

        //CONSTRUCTORES CON SOBRECARGA Y REUTILIZACION DE CODIGO
        public Numero()
        {

        }

        public Numero(double xNumero):this(xNumero.ToString())
        {

        }

        public Numero(string xNumero) : this()
        {
           this.SetNumero = xNumero;
        }
        
        //PROPIEDAD SETTER
       private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }   
        }
        
        //METODOS
        private double ValidarNumero(string strNumero)
        {
            double xRetorno = 0D;
            if(double.TryParse(strNumero,out double result))
               xRetorno = result;
            return xRetorno;
        }

        public static string BinarioDecimal(string binario)
        {
            string xReturn = "";
            int xLength = binario.Length - 1;
            double xBin = 0, xDecimal = -1, cont = 0;
            bool xFlag = false;
            while (xLength >= 0)
            {
                if (binario.Substring(xLength, 1) == "1")
                {
                    if (!(xFlag))
                    {
                        xDecimal = 0;
                        xFlag = true;
                    }
                    xBin = Convert.ToDouble(binario.Substring(xLength, 1));
                    xDecimal += Convert.ToDouble(Math.Pow(2, cont));
                    xBin = 0;
                }
                else
                {
                    if (binario.Substring(xLength, 1) != "0")
                    {
                        xDecimal = -1;
                        break;
                    }
                }
                xLength--;
                cont++;
            }
            if (xDecimal == -1)
                xReturn = String.Copy("Valor inválido");
            else
                xReturn = xDecimal.ToString();
            return xReturn;
        }

        public static string DecimalBinario(double xNum)
        {
            string xStrBin = "";
            int xNum1 = (int)xNum;
            while (xNum1 > 0)
            {
                if ((xNum1 % 2) == 0)
                    xStrBin = "0" + xStrBin;
                else
                    xStrBin = "1" + xStrBin;

                xNum1 = (xNum1 / 2);
            }
            return xStrBin;
        }

        public static string DecimalBinario(string xNum)
        {
            string xStrBin = "";
            if (double.TryParse(xNum, out double result)&& result >= 0)
                xStrBin = DecimalBinario(result);
            else
                xStrBin = String.Copy("Valor inválido");
            return xStrBin;
        }

        //OPERADORES
        public static double operator +(Numero xNum1, Numero xNum2)
        {
            return xNum1.numero + xNum2.numero;
        }

        public static double operator -(Numero xNum1, Numero xNum2)
        {
            return xNum1.numero - xNum2.numero;
        }

        public static double operator *(Numero xNum1, Numero xNum2)
        {
            return xNum1.numero * xNum2.numero;
        }

        public static double operator /(Numero xNum1, Numero xNum2)
        {
            return xNum1.numero / xNum2.numero;
        }
    }
}
