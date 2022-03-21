using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double valueOfResult = 0;
        String operation;

        public Form1()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button button =(Button)sender;

            if (resultTextBox.Text == "0" )
                resultTextBox.Clear();

            if (button.Text == ".")
            {
                if (!resultTextBox.Text.Contains("."))
                {
                    resultTextBox.Text = resultTextBox.Text + button.Text;
                }
            }
            else
            {
                resultTextBox.Text = resultTextBox.Text + button.Text;
            }
            
            
        }

        private void Click_operator(object sender, EventArgs e)
        {
            
            if (valueOfResult != 0)
            {
                buttonEquals.PerformClick();
                OperatorFunction(sender, e);
            }
            else
            {
                OperatorFunction(sender, e);
            }
        }

        private void OperatorFunction(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            valueOfResult = Double.Parse(resultTextBox.Text);
            labelForOperation.Text = valueOfResult + " " + operation;
            resultTextBox.Clear();
        }

        private void Click_clear(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            labelForOperation.Text = "";
            valueOfResult= 0;
        }

        private void Click_equals(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    resultTextBox.Text = (valueOfResult + Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "-":
                    resultTextBox.Text = (valueOfResult - Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "*":
                    resultTextBox.Text = (valueOfResult * Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "/":
                    resultTextBox.Text = (valueOfResult / Double.Parse(resultTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            valueOfResult=Double.Parse(resultTextBox.Text);
            labelForOperation.Text = "";
            valueOfResult = 0;
        }
    }
}
