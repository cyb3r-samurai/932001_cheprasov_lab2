using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const double k = 0.02;
        Random rand =  new Random();
        double priceDol, priceEu;
        int days = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (days == 0)
            {
                priceDol = (double)inputDol.Value;
                priceEu = (double)inputEu.Value;
                chart1.Series[0].Points.AddXY(0, priceDol);
                chart1.Series[1].Points.AddXY(0, priceEu);
            }
            if (timer1.Enabled) timer1.Stop(); else timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            days += 1;
            priceDol *= (1 + k * (rand.NextDouble() - 0.5));
            priceEu *= (1 + k * (rand.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(days, priceDol);
            chart1.Series[1].Points.AddXY(days, priceEu);
        }
    }
}
