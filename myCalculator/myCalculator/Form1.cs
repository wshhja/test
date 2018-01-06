using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            catch (Exception)
            {
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void button18_Click(object sender, EventArgs e)//=
        {
            try
            {
                Calculator cal = new Calculator(textBox1.Text);
                double t = cal.run();
                if (t == 0)
                {
                    textBox1.Text = "Error";
                }
                else
                {
                    textBox1.Text = t.ToString();
                }
            }
            catch (Exception)
            {
                textBox1.Text = "Error";
            }
        }

        private void button23_Click(object sender, EventArgs e)//1/x
        {
            try
            {
                double t = Convert.ToDouble(textBox1.Text);
                textBox1.Text = ((double)(1.0 / t)).ToString();
            }
            catch (Exception)
            {
                textBox1.Text = "Error";
            }
        }

        private void button22_Click(object sender, EventArgs e)//sqrt
        {
            try
            {
                double t = Convert.ToDouble(textBox1.Text);
                textBox1.Text = ((double)(Math.Sqrt(t))).ToString();
            }
            catch (Exception)
            {
                textBox1.Text = "Error";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Daikuan daikuan = new Daikuan();
            daikuan.Owner = this;
            daikuan.ShowDialog();
        }
    }
}
