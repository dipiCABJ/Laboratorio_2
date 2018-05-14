﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks : Producto
    {
        //public Snacks(EMarca marca, string patente, ConsoleColor color) patente???????
        //    : base(patente, marca, color)
        public Snacks(EMarca marca, string codigo, ConsoleColor color):base(codigo, marca, color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        //public override sealed string Mostrar()
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SNACKS");
            //sb.AppendLine(base);
            //sb.AppendLine("CALORIAS : {0}", this.CantidadCalorias);

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
