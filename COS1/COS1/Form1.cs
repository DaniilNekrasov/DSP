using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace COS1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            comboBox1.SelectedIndex = 0;
            rewrite();
        }

        private void SinForm(float A, double f, float N, float phi)
        {
            for (double n = 0.0; n <= N; n += 1)
            {
                double x = 2 * Math.PI * f * (n / N) + phi;
                x %= 2 * Math.PI;
                double result = 0;
                double term = x;

                int i = 1;
                while (Math.Abs(term) >= 0.001) 
                {
                    result += term;

                    term *= -1 * x * x / ((2 * i) * (2 * i + 1));
                    i++;
                }

                result *= A;
                chart1.Series[0].Points.AddXY(n, result);
            }
        }

        private double Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        private void RectForm(float A, float T, float N, double dc, double phi)
        {
            double result = 0;
            for (double n = 0.0; n <= N; n+= 1)
            {
                if (((n / N) % T / T) < dc)
                {
                    result = A * Math.Sin(2 * Math.PI * (1 / T) * (n / N) + phi) + A;
                    chart1.Series[3].Points.AddXY(n, A);
                    chart1.Series[5].Points.AddXY(n, result);
                }
                else
                {
                    result = A * Math.Sin(2 * Math.PI * (1 / T) * (n / N) + phi) - A;
                    chart1.Series[3].Points.AddXY(n, -A);
                    chart1.Series[5].Points.AddXY(n, result);
                }
            }
        }


private void TriangForm(double A, double f, double N, double phi)
        {
            for (int n = 0; n <= N; n++)
            {
                double temp = Math.Sin(2 * Math.PI * f * (n / N) + phi);

                if ((temp >= -(Math.PI / 2)) && (temp <= (Math.PI / 2)))
                {
                    double result = (2 * A / Math.PI) * Math.Pow(Math.Sin(temp), -1);
                    chart1.Series[1].Points.AddXY(n, result);
                }
                else
                {
                    double result = (2 * A / Math.PI) * Math.Sin(temp);
                    chart1.Series[1].Points.AddXY(n, result);
                }
            }
        }

        private void SawForm(float A, float f, float N, float phi)
        {
            double result = 0;
            for (int n = 0; n <= N; n++)
            {
                result = (-2* A / Math.PI) * (Math.Atan(1 / Math.Tan(Math.PI * f * (n / N) + phi)));
                chart1.Series[2].Points.AddXY(n, result);
            }
        }

        private void NoiseForm(float A, float N)
        {
            double result = 0;
            Random rand = new Random();
            for (double n = 0.0; n <= N; n += 0.5)
            {
                result = A*((float)rand.Next(-1000,1000)/1000);
                chart1.Series[4].Points.AddXY(n, result);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rewrite();
        }


        private void rewrite()
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float num = (float)Math.Pow(2, comboBox1.SelectedIndex + 2);

            SinForm((float)trackBar1.Value, trackBar2.Value, num, (float)trackBar3.Value / 10);
            TriangForm((float)trackBar1.Value, trackBar2.Value, num, (float)trackBar3.Value / 10);
            SawForm((float)trackBar1.Value, trackBar2.Value, num, (float)trackBar3.Value / 10);
            RectForm((float)trackBar1.Value, (float)1/trackBar2.Value, num, (float)trackBar4.Value/100, (float)trackBar3.Value / 10);
            NoiseForm((float)trackBar1.Value, num);
            textBox1.Text = ((float)trackBar1.Value).ToString();
            textBox2.Text = ((float)trackBar2.Value).ToString();
            textBox3.Text = ((float)trackBar3.Value / 10).ToString();
            textBox4.Text = ((float)trackBar4.Value / 100).ToString();

            if (!checkBox1.Checked)
            {
                chart1.Series[0].Points.Clear();
            }
            if (!checkBox2.Checked)
            {
                chart1.Series[1].Points.Clear();
            }
            if (!checkBox3.Checked)
            {
                chart1.Series[2].Points.Clear();
            }
            if (!checkBox4.Checked)
            {
                chart1.Series[3].Points.Clear();
            }
            if (!checkBox5.Checked)
            {
                chart1.Series[4].Points.Clear();
            }
            if (!checkBox6.Checked)
            {
                chart1.Series[5].Points.Clear();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            rewrite();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            rewrite();
        }
    }
}
