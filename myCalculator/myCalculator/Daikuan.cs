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
    public partial class Daikuan : Form
    {
        public Daikuan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {//4月均还款
            //5利息总额
            //6还款总额
            if (radioButton1.Checked == true)//本息
            {
                double time = Convert.ToDouble(textBox1.Text);//月数
                time *= 12;
                double mon = Convert.ToDouble(textBox2.Text);//贷款金额
                double bonus = Convert.ToDouble(textBox3.Text);//贷款利率
                bonus = bonus/1200;
                double Sum_re = mon * bonus * Math.Pow(1 + bonus, time) / (Math.Pow(1+bonus,time)-1);//
                textBox4.Text = Convert.ToString(Sum_re * 10000);//月均还款
                textBox6.Text = Convert.ToString(Sum_re * time * 10000);
                double Sum_bonus =Sum_re*time-mon;//总利息
                textBox5.Text = Convert.ToString(Sum_bonus * 10000);
            }
            else
            {
                
                double time = Convert.ToDouble(textBox1.Text);//月数
                time *= 12;
                double mon = Convert.ToDouble(textBox2.Text);//贷款金额
                double bonus = Convert.ToDouble(textBox3.Text);//贷款利率
                bonus /= 1200;
                double Sum_re = (time+1)*mon*bonus/2+mon;//还款总额
                textBox4.Text = Convert.ToString(Sum_re / time*10000);//月均还款
                textBox6.Text = Convert.ToString(Sum_re * 10000);
                double Sum_bonus = (time+1)*mon*bonus/2;//总利息
                textBox5.Text = Convert.ToString(Sum_bonus * 10000);
            }
        }
    }
}
