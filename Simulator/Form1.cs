using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            radioButton2.Checked = true;
            radioButton5.Checked = true;
            textBox19.Text = Environment.CurrentDirectory;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void Observation(bool flag)
        {
            if (flag)
            {
                //groupBox11.Visible = true;

                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;

                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;

                groupBox10.Text = "Географические координаты наблюдателя";

                //groupBox10.Visible = false;

                textBox11.Visible = false;
            }
            else
            {
                //groupBox10.Visible = true;

                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;

                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;

                groupBox10.Text = "TLE  спутника — наблюдателя";
                //groupBox11.Visible = false;

                textBox11.Visible = true;
            }
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            Observation(radioButton2.Checked);
        }

        private void RadioButton1_Click(object sender, EventArgs e)
        {
            Observation(!radioButton1.Checked);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBox19.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox19.Text = folderBrowserDialog1.SelectedPath + "\\";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
        }
    }
}