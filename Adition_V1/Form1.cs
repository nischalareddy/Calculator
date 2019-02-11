using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adition_V1
{
    public partial class Form1 : Form
    {
        int result = 0;
        bool firstoperation = false;
        bool newinput = false;
        string lastoperator = "";


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        public void LastOperator(int tbvalue)
        {
            if (lastoperator == "*")
                result = result * tbvalue;
            else if (lastoperator == "+")
                result = result + tbvalue;
            else if (lastoperator == "")
                result = tbvalue;
            tbArg.Text = result.ToString();
        }

        public void Calculate(string input)
        {
            if (input == "+")
            {

                if (firstoperation == false)
                {
                    result = 0;
                    firstoperation = true;
                }
                newinput = true;
                int tbvalue = 0;
                int.TryParse(tbArg.Text, out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "+";

            }
            else if (input == "*")
            {
                if (firstoperation == false)
                {
                    result = 1;
                    firstoperation = true;
                }

                newinput = true;
                int tbvalue = 1;
                int.TryParse(tbArg.Text, out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "*";
            }
            else if (input == "=")
            {
                int tbvalue = 0;
                int.TryParse(tbArg.Text, out tbvalue);
                LastOperator(tbvalue);

            }
            else
            {
                if (newinput == true)
                {
                    tbArg.Text = input;
                    newinput = false;
                }
                else
                    tbArg.Text = tbArg.Text + input;

            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Calculate(button.Text);
        }

        private void KeyPres(object sender, KeyPressEventArgs e)
        {
            int inputvalue;
            if( e.KeyChar >= '0' && e.KeyChar <= '9' )
            {
                Calculate(e.KeyChar.ToString());
            }
            else if ( e.KeyChar == '+' || e.KeyChar == '*' || e.KeyChar == '=')
            {
                Calculate(e.KeyChar.ToString());
            }
        }
    }
}
