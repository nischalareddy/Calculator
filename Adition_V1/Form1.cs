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
        //int resultMul = 1;
        int count = 0;
        bool flag = false;
        string lastoperator = "";


        public Form1()
        {
            InitializeComponent();

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
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if( button.Text == "+")
            {

                if (count == 0)
                {
                    result = 0;
                    count++;
                }
                flag = true;
                int tbvalue = 0;
                int.TryParse(tbArg.Text, out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "+";

            }
            else if( button.Text == "*")
            {
                if (count == 0)
                {
                    result = 1;
                    count++;
                }

                flag = true;
                int tbvalue = 1;
                int.TryParse(tbArg.Text, out tbvalue);
                LastOperator(tbvalue);
                lastoperator = "*";
            }
            else if( button.Text == "=")
            {
                int tbvalue = 0;
                int.TryParse(tbArg.Text, out tbvalue);
                LastOperator(tbvalue);
        
            }
            else
            {
                if (flag == true)
                {
                    tbArg.Text = button.Text;
                    flag = false;
                }
                else
                    tbArg.Text = tbArg.Text + button.Text;

            }

        }
    }
}
