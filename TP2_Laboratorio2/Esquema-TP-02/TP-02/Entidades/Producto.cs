﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    //public sealed class Producto
    public abstract class Producto
    {
        //enum EMarca
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        //Cantidad de ruedas????
        /// </summary>
        //abstract short CantidadCalorias { get; set;}
        protected abstract short CantidadCalorias { get;}


        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        //sealed string Mostrar()
        public virtual string Mostrar()
        {
            return (string)this;
        }

        //private static explicit operator string(Producto p)
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            //sb.AppendLine("MARCA          : {0}\r\n", p._marca.ToString());
            //sb.AppendLine("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }

        public Producto(string codigoBarras, EMarca marca, ConsoleColor color)
        {
            this._codigoDeBarras = codigoBarras;
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
        }
    }
}
