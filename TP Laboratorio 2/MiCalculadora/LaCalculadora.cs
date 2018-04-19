using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //EVENTOS
        private void Form1_Load(object sender, EventArgs e)
        {
            //FormBorderStyle = BorderStyle.FixedSingle;
            //StartPosition = StartPosition.CenterScreen;
            //lblResultado.TabIndex = 10;
            //lblResultado.BorderStyle = BorderStyle.Fixed3D;
            //MaximizeBox = false;
            //MinimizeBox = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro que desea cerrar la aplicación?","Atención!!",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
               this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            
            if (!(ValidarIngresos(txtNumero1, txtNumero2, cmbOperador)))
            {
                MessageBox.Show("Debe ingresar los operandos y el operador!!");
            }
            else
            {
                if(!(ValidarDivisor(txtNumero2, cmbOperador)))
                {
                    MessageBox.Show("No se puede dividir por 0!!! ");
                }
                else
                {
                    //De esta manera utilizo los 3 constructores
                    double xResult;
                    string numero1 = txtNumero1.Text;
                    string numero2 = txtNumero2.Text;
                    Numero xNumero1 = new Numero(Convert.ToDouble(numero1));
                    Numero xNumero2 = new Numero(Convert.ToDouble(numero2));
                    
                    //De esta manera utilizo 2 constructores
                    //Numero xNumero1 = new Numero(txtNumero1.Text);
                    //Numero xNumero2 = new Numero(txtNumero2.Text);
                    xResult = Operar(xNumero1, xNumero2, cmbOperador.SelectedItem.ToString());
                    lblResultado.Text = xResult.ToString();
                }

            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = "";
            if (lblResultado.Text != "")
            {
                resultado = Numero.BinarioDecimal(lblResultado.Text);
                if (resultado.StartsWith("Valor"))
                    MessageBox.Show(resultado);
                else
                    lblResultado.Text = resultado.ToString();
            }
            else
                MessageBox.Show("Debe haber un resultado para llevar adelante la conversión!!");
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = "";
            if (lblResultado.Text != "")
            {
                resultado = Numero.DecimalBinario(lblResultado.Text);
                if (resultado.StartsWith("Valor"))
                    MessageBox.Show(resultado);
                else
                    lblResultado.Text = resultado.ToString();
            }
            else
                MessageBox.Show("Debe haber un resultado para llevar adelante la conversión!!");

        }

        //METODOS
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            return Calculadora.Operar(num1, num2, operador);
        }

        public void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = -1;
        }

        //VALIDACIONES AGREGADAS
        public bool ValidarIngresos(TextBox txt1, TextBox txt2, ComboBox cmb1)
        {
            bool ret = false;
            string xOP = "";
            if(!(object.ReferenceEquals(cmb1.SelectedItem,null)))
                xOP = cmb1.SelectedItem.ToString();
            if (txt1.Text != "" && txt2.Text != "" && xOP != "")
                ret = true;
            return ret;
        }

        public static bool ValidarDivisor(TextBox txt2, ComboBox cmb1)
        {
            bool xreturn = true;
            if (txt2.Text == "0" && cmb1.SelectedItem.ToString() == "/")
                xreturn = false;
            return xreturn;
        }
    }
}
