using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
        //public Dulce(EMarca marca, string patente, ConsoleColor color) patente???????
        public Dulce(EMarca marca, string codigo, ConsoleColor color):base(codigo, marca,color)
        {
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        //private override sealed string Mostrar()
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("DULCE");
            //sb.AppendLine(this.Mostrar());
            //sb.AppendLine("CALORIAS : {0}", this.CantidadCalorias);
            //sb.AppendLine("");
            //sb.AppendLine("---------------------");

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
