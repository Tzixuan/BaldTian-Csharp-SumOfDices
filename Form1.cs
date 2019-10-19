using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;//添加chart的命名空间
namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitChart();
        }
        Random rnd = new Random();
        int temp1, temp2,temp;
        public void InitChart()//chart初始化
        {
            Series series = chart1.Series[0];
            Series series2 = chart2.Series[0];
            series.BorderWidth = 1;//柱状图 两数之和统计
            ChartArea chartarea = chart1.ChartAreas[0];
            chartarea.AxisX.Minimum = 2;
            chartarea.AxisX.Maximum = 12;
            chartarea.AxisY.Minimum = 0;
            chartarea.AxisY.Maximum = 1000;
            chartarea.AxisX.Interval = 1;

            series2.BorderWidth = 1;//点状图 两数之和分布图
            ChartArea chartarea2 = chart2.ChartAreas[0];
            chartarea2.AxisX.Minimum = 0;
            chartarea2.AxisX.Maximum = 500;
            chartarea2.AxisY.Minimum = 2;
            chartarea2.AxisY.Maximum = 12;
            chartarea2.AxisY.Interval = 1;

        }
        Queue<int> Q1 = new Queue<int>();
        int[] a=new int[13];
        //a[13]={0};
        public void Draw()
        {
            this.chart1.Series[0].Points.Clear();
            temp1 = rnd.Next(1, 7);//产生1-6的随机数
            temp2 = rnd.Next(1, 7);
            temp = temp1 + temp2;//色子的和
            for (int i = 2; i < 13; i++)
            {
                if (temp == i)//和计数
                    a[i]++;
                if (a[i] == 1000)//如果有一个达到1000，则停止
                {
                    timer1.Stop();
                    this.Text = "投掷两个色子，其和的最大可能性为"+i;
                }
            }
            for (int j = 1; j < 13; j++)//添加点
                chart1.Series[0].Points.AddY(a[j]);
           /* Q1.Enqueue(temp);
            if (Q1.Count > 2)
                Q1.Dequeue();*/
            /*for (int j = 0; j < 1; j++)*/
                chart2.Series[0].Points.AddY(temp);

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
