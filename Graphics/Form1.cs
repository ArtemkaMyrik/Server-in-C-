using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphics
{
    public partial class Form1 : Form
    {
        bool Activ = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\AAMyr\Server\ЦП.txt.txt";
            string[] lines = File.ReadAllLines(path);

            string[] Indicators = { "Начальная память", "Испальзуемая паять", "Максимальный объем памяти", "Фиксированная память" };
            double[] numberOfIndicators = { Convert.ToDouble(lines[1]), Convert.ToDouble(lines[2]), Convert.ToDouble(lines[3]), Convert.ToDouble(lines[4]) };
            label2.Text = lines[6];

            for (int i = 0; i < Indicators.Length; i++)
            {
                chart.Series[Indicators[i]].Points.Add(numberOfIndicators[i]);
            }
        }
        private void Conclusion()
        {
            while (Activ)
            {
                string path = @"C:\Users\AAMyr\Server\ЦП.txt.txt";
                string[] lines = File.ReadAllLines(path);

                string[] Indicators = { "Начальная память", "Испальзуемая паять", "Максимальный объем памяти", "Фиксированная память" };
                double[] numberOfIndicators = { Convert.ToDouble(lines[1]), Convert.ToDouble(lines[2]), Convert.ToDouble(lines[3]), Convert.ToDouble(lines[4]) };

                for (int i = 0; i < Indicators.Length; i++)
                {
                    chart.Series[Indicators[i]].Points.Add(numberOfIndicators[i]);
                }

                Thread.Sleep(1000);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!Activ)
            {
                Activ = true;
                button1.Text = "Остоновить";
                button1.BackColor = Color.Maroon;
                Thread myThread = new Thread(Conclusion);
                myThread.Start();
            }
            else
            {
                Activ = false;
                button1.Text = "Запустить";
                button1.BackColor = Color.LawnGreen;
            }     
        }
    }
}
