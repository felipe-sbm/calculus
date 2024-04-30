using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora {
    public partial class frmCalculus : Form
    {
        double previousValue;
        string operation;
        bool frstOperation = true;
        double result;
        public frmCalculus()
        {
            InitializeComponent();
        }
        private void Clicou_Click(object sender, EventArgs e)
        {
            Button pressedBtn = (Button)sender;

            if (txtVisor.Text == "0")
            {
                txtVisor.Clear();
            }
            switch (pressedBtn.Name)
            {
                case "btnOne":
                    txtVisor.AppendText("1");
                    break;
                case "btnTwo":
                    txtVisor.Text += "2";
                    break;
                case "btnThree":
                    txtVisor.Text += "3";
                    break;
                case "btnFour":
                    txtVisor.Text += "4";
                    break;
                case "btnFive":
                    txtVisor.Text += "5";
                    break;
                case "btnSix":
                    txtVisor.Text += "6";
                    break;
                case "btnSeven":
                    txtVisor.Text += "7";
                    break;
                case "btnEight":
                    txtVisor.Text += "8";
                    break;
                case "btnNine":
                    txtVisor.Text += "9";
                    break;
                case "btnZero":
                    txtVisor.Text += "0";
                    break;
                case "btnDot":
                    if (txtVisor.Text == "")
                    {
                        txtVisor.Text += "0.";
                    }
                    else
                    {
                        txtVisor.Text += ".";
                    }
                    break;
            }
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            txtHistory.Clear();
            txtVisor.Text = "0";
            previousValue = 0;
            frstOperation = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "")
            {
                txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            double calculoAnterior;
            if (txtVisor.Text != "")
            {
                if (frstOperation == true)
                {
                    previousValue = double.Parse(txtVisor.Text);
                    txtHistory.Text += txtVisor.Text + "+";
                    txtVisor.Clear();
                    operation = "+";
                    frstOperation = false;
                }
                else if (operation == "√")
                {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text = valorRaiz + "+";

                    previousValue = valorRaiz;
                    operation = "+";
                }
                else
                {
                    calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "+";
                    txtVisor.Clear();
                    previousValue = calculoAnterior;
                    operation = "+";
                }
            }
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "")
            {
                if (frstOperation == true)
                {
                    previousValue = double.Parse(txtVisor.Text);
                    txtHistory.Text += txtVisor.Text + "-";
                    txtVisor.Clear();
                    operation = "-";
                    frstOperation = false;
                }
                else if (operation == "√")
                {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text = valorRaiz + "-";

                    previousValue = valorRaiz;
                    operation = "-";
                }
                else
                {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "-";
                    txtVisor.Clear();
                    previousValue = calculoAnterior;
                    operation = "-";
                }
            }
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "")
            {
                if (frstOperation == true)
                {
                    previousValue = double.Parse(txtVisor.Text);
                    txtHistory.Text = txtVisor.Text + "×";
                    txtVisor.Clear();
                    operation = "×";
                    frstOperation = false;

                }
                else if (operation == "√")
                {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text = valorRaiz + "×";

                    previousValue = valorRaiz;
                    operation = "×";

                }
                else
                {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "×";
                    txtVisor.Clear();
                    previousValue = calculoAnterior;
                    operation = "x";
                }
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "")
            {
                if (frstOperation == true)
                {
                    previousValue = double.Parse(txtVisor.Text);
                    txtHistory.Text = txtVisor.Text + "/";
                    txtVisor.Clear();
                    operation = "/";
                    frstOperation = false;

                }
                else if (operation == "√")
                {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text = valorRaiz + "/";

                    previousValue = valorRaiz;
                    operation = "/";

                }
                else
                {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "/";
                    txtVisor.Clear();
                    previousValue = calculoAnterior;
                    operation = "/";
                }
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "")
            {
                if (frstOperation == true)
                {
                    previousValue = double.Parse(txtVisor.Text);
                    txtHistory.Text = "Raiz " + txtVisor.Text;
                    operation = "√";
                    txtVisor.Text = Convert.ToString(Calculo());

                    frstOperation = false;

                }
                else
                {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = "Raiz " + calculoAnterior;
                    txtVisor.Text = Convert.ToString(Math.Sqrt(calculoAnterior));
                    previousValue = double.Parse(txtVisor.Text);
                    operation = "√";
                }
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            txtVisor.Text = Convert.ToString(Calculo());
            txtHistory.Clear();
            frstOperation = true;
        }
        public double Calculo()
        {
            double Valor = double.Parse(txtVisor.Text);
            switch (operation)
            {
                case "+":
                    result = previousValue + Valor;
                    break;
                case "-":
                    result = previousValue - Valor;
                    break;
                case "×":
                    result = previousValue * Valor;
                    break;
                case "/":
                    result = previousValue / Valor;
                    break;
                case "√":
                    result = Math.Sqrt(double.Parse(txtVisor.Text));
                    break;
            }
            return result;
        }

        private void frmCalculus_Load(object sender, EventArgs e)
        {

        }
    }
}
