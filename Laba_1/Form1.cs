using System;
using System.Windows.Forms;

namespace Laba_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            Modelling mod = new Modelling(1000, rnd);
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("", "R[i]");
            dataGridView1.Columns.Add("", "Z[i]");
            dataGridView1.Columns.Add("", "T[k]");

            dataGridView1.RowCount = 1000;


            mod.Z_i = mod.GetInterval(mod.Lambda, mod.R_i);
            mod.T_k = mod.GetMometns(mod.Z_i);

            mod.XCoord = mod.GetXCoord(mod.T_k);
            dataGridView2.ColumnCount = mod.XCoord.Length;


            mod.CallNumber(mod.XCoord);
            dataGridView3.ColumnCount = mod.N.Length;
            dataGridView4.ColumnCount = mod.Pi.Length;
            dataGridView4.RowCount = 2;


            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            for (int j = 0; j < mod.Length; j++)
                            {
                                dataGridView1.Rows[j].Cells[i].Value = mod.R_i[j];
                            }
                            break;
                        }
                    case 1:
                        {
                            for (int j = 0; j < mod.Length; j++)
                            {
                                dataGridView1.Rows[j].Cells[i].Value = mod.Z_i[j];
                            }
                            break;
                        }
                    case 2:
                        {
                            for (int j = 0; j < mod.Length; j++)
                            {
                                dataGridView1.Rows[j].Cells[i].Value = mod.T_k[j];
                            }
                            break;
                        }
                }

            }

            for (int i = 0; i < mod.XCoord.Length; i++)
            {
                dataGridView2.Columns[i].HeaderText = i.ToString();
                dataGridView2.Rows[0].Cells[i].Value = mod.XCoord[i];
            }


            for (int i = 0; i < mod.N.Length; i++)
            {
                dataGridView3.Columns[i].HeaderText = mod.MinMax[i].ToString();
                dataGridView3.Rows[0].Cells[i].Value = mod.N[i];
            }


            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            for (int j = 0; j < mod.Pi.Length; j++)
                            {
                                dataGridView4.Rows[i].Cells[j].Value = mod.Pi[j];
                            }
                            break;
                        }
                    case 1:
                        {
                            for (int j = 0; j < mod.Pi.Length; j++)
                            {
                                dataGridView4.Rows[i].Cells[j].Value = mod.NotPi[j];
                            }
                            break;
                        }

                }

            }

            for (int i = 0; i < mod.Pi.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i, mod.Pi[i]);
            }
            for (int i = 0; i < mod.Pi.Length; i++)
            {
                chart1.Series[1].Points.AddXY(i, mod.NotPi[i]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            Modelling mod1 = new Modelling(1000, rnd);

            mod1.Z_i = mod1.GetInterval(mod1.GetLambda(10), mod1.R_i);
            mod1.T_k = mod1.GetMometns(mod1.Z_i);

            int[] x1 = mod1.GetXCoord(mod1.T_k);

            mod1.Z_i = mod1.GetInterval(mod1.GetLambda(15), mod1.R_i);
            mod1.T_k = mod1.GetMometns(mod1.Z_i);

            int[] x2 = mod1.GetXCoord(mod1.T_k);

            int[] sumX1X2 = new int[x1.Length];

            for (int i = 0; i < sumX1X2.Length; i++)
            {
                if (i<x2.Length)
                {
                    sumX1X2[i] = x1[i] + x2[i];
                }
                else
                {
                    sumX1X2[i] = x1[i];
                }
            }

            for (int i = 0; i < x1.Length; i++)
            {
                if (i < x2.Length)
                {
                    chart2.Series[0].Points.AddXY(i, x1[i]);
                    chart2.Series[1].Points.AddXY(i, x2[i]);
                    chart2.Series[2].Points.AddXY(i, sumX1X2[i]);
                }
                else
                {
                    chart2.Series[0].Points.AddXY(i, x1[i]);
                    chart2.Series[1].Points.AddXY(i,0);
                    chart2.Series[2].Points.AddXY(i, sumX1X2[i]);
                }
                
            }

        }
    }
}
