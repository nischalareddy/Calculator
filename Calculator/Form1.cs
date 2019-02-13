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
        public string RemoveDigitSeperator(string num)
        {
            string modifiedNum = "";
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != ',')
                    modifiedNum = modifiedNum + num[i];

            }
            return modifiedNum;
        }

        public string AddDigitSeperator(string num)
        {
            string rnum = "";
            for (int i = num.Length - 1; i >= 0; i--)
            {
                rnum = rnum + num[i];
            }
            string modifiedNum = "";
            for (int i = 0, count = 1; i < rnum.Length; i++, count++)
            {
                modifiedNum = modifiedNum + rnum[i];
                if (count % 3 == 0 && i != rnum.Length - 1)
                    modifiedNum = modifiedNum + ",";
            }
            num = modifiedNum;
            rnum = "";
            for (int i = num.Length - 1; i >= 0; i--)
            {
                rnum = rnum + num[i];
            }
            return rnum;

        }
        public void LastOperator(int tbvalue)
        {
            if (lastoperator == "*")
                result = result * tbvalue;
            else if (lastoperator == "+")
                result = result + tbvalue;
            else if (lastoperator == "-")
                result = result - tbvalue;
            else if (lastoperator == "/")
            {
                if (tbvalue == 0)
                {
                    tbArg.Text = "Invalid Input";
                    return;
                }
                else
                    result = result / tbvalue;

            }
            else if (lastoperator == "")
                result = tbvalue;

            tbArg.Text = AddDigitSeperator(RemoveDigitSeperator(result.ToString()));
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
                int.TryParse(RemoveDigitSeperator(tbArg.Text), out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "+";

            }

            else if (input == "-")
            {

                if (firstoperation == false)
                {
                    result = 0;
                    firstoperation = true;
                }
                newinput = true;
                int tbvalue = 0;
                int.TryParse(RemoveDigitSeperator(tbArg.Text), out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "-";

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
                
                int.TryParse(RemoveDigitSeperator(tbArg.Text), out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "*";
            }
            else if (input == "/")
            {
                if (firstoperation == false)
                {
                    result = 1;
                    firstoperation = true;
                }

                newinput = true;
                int tbvalue = 1;

                int.TryParse(RemoveDigitSeperator(tbArg.Text), out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "/";
            }
            else if (input == "=")
            {
                int tbvalue = 0;
                int.TryParse(RemoveDigitSeperator(tbArg.Text), out tbvalue);
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
                {

                    tbArg.Text = AddDigitSeperator(RemoveDigitSeperator(tbArg.Text) + input);
                }
                  //  tbArg.Text = tbArg.Text + input;

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Calculate(button.Text);
        }

        public void SetButtonFocus(char keychar)
        {
            switch(keychar)
            {
                case '1': b1.Select();
                    break;
                case '2':
                    b2.Select();
                    break;
                case '3':
                    b3.Select();
                    break;
                case '4':
                    b4.Select();
                    break;
                case '5':
                    b5.Select();
                    break;
                case '6':
                    b6.Select();
                    break;
                case '7':
                    b7.Select();
                    break;
                case '8':
                    b8.Select();
                    break;
                case '9':
                    b9.Select();
                    break;
                case '0':
                    b0.Select();
                    break;
                case '+':
                    bAdd.Select();
                    break;
                case '-':
                    bSub.Select();
                    break;
                case '/':
                    bDivide.Select();
                    break;
                case '*':
                    bmul.Select();
                    break;
                case '=':
                    bEqual.Select();
                    break;
            }
        }
        private void KeyPres(object sender, KeyPressEventArgs e)
        {

            if( e.KeyChar >= '0' && e.KeyChar <= '9' )
            {
                SetButtonFocus(e.KeyChar);
                Calculate(e.KeyChar.ToString());
            }
            else if ( e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/'|| e.KeyChar == '=')
            {
                SetButtonFocus(e.KeyChar);
                Calculate(e.KeyChar.ToString());
            }
        }
    }
}
