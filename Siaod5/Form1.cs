using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siaod5
{
    public partial class Form1 : Form
    {
        Bitmap Box;
        Node ND = new Node();
        int N, M, Chance, CB = 10000, Green, Orange, Red, Iter, Iter_from_start = 0, ClickLogick = 1;
        bool Check = false, Flag_Start = true;
        Point p;





        //для формы с графиком
        Bitmap TMP = new Bitmap(810, 400);
        Form2 newForm = new Form2();
        int OsX = 770, OsY = 360,
            lastX = 20, lastY_G = 380, lastY_O = 380, lastY_R = 380,
            DistOnY, ShagOnX = 10;

        // для формы с информацией
        ObUzle OU = new ObUzle();
        int X, Y, IterToReg, IterToImm;
        string status, DefString = "---";

        private void скрытьУзелToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickLogick = 2;
        }

        private void выводToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickLogick = 3;
            OU.Show();
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm AF = new AboutForm();
            AF.Show();
        }

        private void удалениеПоКликуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickLogick = 1;
        }

        Pen pen = new Pen(Color.Black);
        Pen pen_G = new Pen(Color.Green,3);
        Pen pen_O = new Pen(Color.Orange,3);
        Pen pen_R = new Pen(Color.Red,3);

        Pen blackPen = new Pen(Color.Black, 1);
        


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            p = pictureBox1.PointToClient(Cursor.Position);

            if (ClickLogick != 3)
            {
                Box = ND.Click(Box, p.X, p.Y, Iter, ClickLogick);
                pictureBox1.Image = Box;
            }
        }               // нажатие на пикчер-бокс

        private void открытьОкноСПостроениемГрафикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm.Show();
        }

        



        private void timer1_Tick(object sender, EventArgs e)                    // таймер
        {
            ND.Infection(Chance, N, M, Iter);
            ND.Kol_vo(out Green, out Orange, out Red);
            ND.Regen(Iter);

            label9.Text = Green.ToString();
            label11.Text = Orange.ToString();
            label13.Text = Red.ToString();

            newForm.pictureBox2.Image = DrawGraph(Green, Orange, Red, TMP);
            newForm.label_vsego.Text = (N * M).ToString();
            newForm.label_g.Text = Green.ToString();
            newForm.label_O.Text = Orange.ToString();
            newForm.label_R.Text = Red.ToString();
            if (N*M == Green)
            {
                Form3 f3 = new Form3();
                Flag_Start = true;
                f3.Show();
                timer1.Enabled = false;
                
                button2.Text = "Старт";
            }

            if (ClickLogick == 3)
            {
                ND.Info(p.X, p.Y, Iter, out X, out Y, out status, out IterToReg, out IterToImm);
                OU.label8.Text = X.ToString();
                OU.label9.Text = Y.ToString();
                OU.label2.Text = status;
                OU.label4.Text = IterToReg.ToString();
                OU.label6.Text = IterToImm.ToString();

            }

            Iter_from_start++;
            label16.Text = Iter_from_start.ToString();

            pictureBox1.Image = ND.RefreshBox(Box);
        }

        private void button2_Click(object sender, EventArgs e) //   старт/стоп
        {
            if (Flag_Start)
            {
                Flag_Start = false;
                button2.Text = "Стоп";
                Chance = Convert.ToInt32(textBox3.Text);
                Iter = Convert.ToInt32(textBox4.Text);
                ComBoxSpeed();
                timer1.Interval = 10000 - CB;
                label15.Visible = true;
                label16.Visible = true;
                timer1.Enabled = true;
                
            }

            else
            {
                Flag_Start = true;
                button2.Text = "Старт";
                timer1.Enabled = false;
               
            }

        }

      
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)        //построить сеть
        {
            button2.Enabled = true;
            N = Convert.ToInt32(textBox1.Text);
            M = Convert.ToInt32(textBox2.Text);
            if (checkBox1.Checked == true)
                Check = true;
            Box = ND.Draw(N, M, Check);
            pictureBox1.Image = Box;
            label7.Text = (N * M).ToString();
            DistOnY = (int) OsY / (N * M);
            newForm.pictureBox2.Image = DrawOs(TMP);
        }

        private Bitmap DrawGraph(int G, int O, int R, Bitmap TMP)
        {
            Graphics Gr = Graphics.FromImage(TMP);

            Gr.DrawLine(pen_G, lastX, lastY_G, lastX + ShagOnX, 380 - DistOnY * G);
            lastY_G = 380 - DistOnY * G;
            Gr.DrawLine(pen_O, lastX, lastY_O, lastX + ShagOnX, 380 - DistOnY * O);
            lastY_O = 380 - DistOnY * O;
            Gr.DrawLine(pen_R, lastX, lastY_R, lastX + ShagOnX, 380 - DistOnY * R);
            lastY_R = 380 - DistOnY * R;
            lastX += ShagOnX;

            return TMP;
        }

        private Bitmap DrawOs(Bitmap TMP)
        {
            Graphics Gr = Graphics.FromImage(TMP);
            blackPen.DashStyle = DashStyle.Dash;
            Gr.DrawLine(pen, 20, 400 - 20, 790, 400 - 20);   //ось х
            Gr.DrawLine(pen, 790, 380, 785, 385);
            Gr.DrawLine(pen, 790, 380, 785, 375);

            Gr.DrawLine(pen, 20, 20, 20, 380);   //ось у
            Gr.DrawLine(pen, 20, 20, 25, 25);
            Gr.DrawLine(pen, 20, 20, 15, 25);

            Gr.DrawString("i", new Font("Microsoft Sans Serif", 8), Brushes.Black, 795, 375);
            Gr.DrawString("n", new Font("Microsoft Sans Serif", 8), Brushes.Black, 25, 15);

            int i = 30;
            while (i <= 780)
            {
                Gr.DrawLine(blackPen, i, 380, i, 20);
                i += 10;
            }
            Gr.DrawLine(blackPen, 20, 380 - DistOnY * N * M * 25 / 100, 790, 380 - DistOnY * N * M * 25 / 100);
            Gr.DrawString("25%", new Font("Microsoft Sans Serif", 7), Brushes.Black,0, 380 - DistOnY * N * M * 25 / 100);

            Gr.DrawLine(blackPen, 20, 380 - DistOnY * N * M * 50 / 100, 790, 380 - DistOnY * N * M * 50 / 100);
            Gr.DrawString("50%", new Font("Microsoft Sans Serif", 7), Brushes.Black, 0, 380 - DistOnY * N * M * 50 / 100);

            Gr.DrawLine(blackPen, 20, 380 - DistOnY * N * M * 75 / 100, 790, 380 - DistOnY * N * M * 75 / 100);
            Gr.DrawString("75%", new Font("Microsoft Sans Serif",7), Brushes.Black,0, 380 - DistOnY * N * M * 75 / 100);

            Gr.DrawLine(blackPen, 20, 380 - DistOnY * N * M, 790, 380 - DistOnY * N * M);
            Gr.DrawString("100%", new Font("Microsoft Sans Serif", 7),Brushes.Black, 0, 380 - DistOnY * N * M);
            return TMP;
        }
        private void ComBoxSpeed()
        {
            switch (comboBox1.Text)
            {
                case "1x":
                    CB = 0;
                    break;
                case "2x":
                    CB = 5000;
                    break;
                case "3x":
                    CB = 6666;
                    break;
                case "4x":
                    CB = 7500;
                    break;
                case "5x":
                    CB = 8000;
                    break;
                case "6x":
                    CB = 8333;
                    break;
                case "7x":
                    CB = 8571;
                    break;
                case "8x":
                    CB = 8750;
                    break;
                case "9x":
                    CB = 8888;
                    break;
                case "10x":
                    CB = 9990;
                    break;
            }
        }

    }


    public class Node
    {
        int i, j, Lenght, Status, flag, Time;
        float X, Y;
        int[] DotsX = new int[63];
        int[] DotsY = new int[63];
        List<Node> Nodes = new List<Node>();   // создание листа 
        SolidBrush Brush_G = new SolidBrush(Color.Green);
        SolidBrush Brush_O = new SolidBrush(Color.DarkOrange);
        SolidBrush Brush_R = new SolidBrush(Color.Red);
        SolidBrush Brush_B = new SolidBrush(Color.Black);
        SolidBrush Brush_W = new SolidBrush(Color.GhostWhite);
        Pen pen = new Pen(Color.Black);

        public Node()
        { }
        public Node(int i, int j, float X, float Y, int Status, int Time, int flag)
        {
            this.i = i;
            this.j = j;
            this.X = X;
            this.Y = Y;
            this.Status = Status;
            this.Time = Time;
            this.flag = flag;
        }


        public Bitmap Draw(int n, int m, bool chech)                                         //первоначальная прорисовка
        {
            int jNodes = 0;
            Bitmap bmp = new Bitmap(400, 400);
            Graphics g = Graphics.FromImage(bmp);

            if (400 / (n + 1) > 400 / (m + 1))
                Lenght = 400 / (m + 1);
            else
                Lenght = 400 / (n + 1);

            for (var i = 0; i < m; i++)
                DotsX[i] = Lenght / 2 + Lenght * i;
            for (var i = 0; i < n; i++)
                DotsY[i] = Lenght / 2 + Lenght * i;



            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    Nodes.Add(new Node(i, j, DotsX[j], DotsY[i], 2, 0, 0));                        // добавление точек в лист через конструктор класса
                }
            }


            for (int i = 0; i < Nodes.Count - 1; i++)                                             // отрисовка горизонтальных линий
            {
                jNodes++;
                if (jNodes == m)
                {
                    jNodes = 0;
                }
                else
                    g.DrawLine(pen, Nodes[i].X + 5, Nodes[i].Y + 5, Nodes[i + 1].X + 5, Nodes[i + 1].Y + 5);
            }

            for (int i = 0; i < Nodes.Count; i++)                                                             // отрисовка вертикальных линий
            {
                if (i >= m)
                    g.DrawLine(pen, Nodes[i].X + 5, Nodes[i].Y + 5, Nodes[i - m].X + 5, Nodes[i - m].Y + 5);

            }

            for (int i = 0; i < Nodes.Count; i++)                                                              // отрисовка точек
                g.FillEllipse(Brush_O, Nodes[i].X, Nodes[i].Y, 10, 10);

            if (chech == true)                                                                              // отрисовка номеров точек
            {
                for (int i = 0; i < Nodes.Count; i++)
                    g.DrawString("(" + Nodes[i].i + " | " + Nodes[i].j + ")",
                    new Font("Microsoft Sans Serif", 8), Brushes.Black, Nodes[i].X + 8, Nodes[i].Y -
                    15);
            }
            return bmp;

        }
        public Bitmap Click(Bitmap BTM, int X, int Y, int Iter, int Logic)                              //нажатие на бокс
        {
            double min = 10000;
            int MinI = -1;


            for (int i = 0; i < Nodes.Count; i++)                                   //минимальное расстояние
            {
                if (Math.Sqrt((Nodes[i].X - X - 5) * (Nodes[i].X - X - 5) + (Nodes[i].Y - Y - 5) * (Nodes[i].Y - Y - 5)) < min)
                {
                    min = Math.Sqrt((Nodes[i].X - X) * (Nodes[i].X - X) + (Nodes[i].Y - Y) * (Nodes[i].Y - Y));
                    MinI = i;
                }
            }
            if (Logic == 1)
            {
                try
                {                                                                       //смена статуса при нажатии
                    if (Nodes[MinI].Status == 3)
                    {
                        Graphics.FromImage(BTM).FillEllipse(Brush_G, Nodes[MinI].X, Nodes[MinI].Y, 10, 10);
                        Nodes[MinI].Status = 1;
                        Nodes[MinI].flag = 1;
                        Nodes[MinI].Time = 0;
                    }
                    else
                    if ((Nodes[MinI].Status == 1) || (Nodes[MinI].Status == 2))
                    {
                        Graphics.FromImage(BTM).FillEllipse(Brush_R, Nodes[MinI].X, Nodes[MinI].Y, 10, 10);
                        Nodes[MinI].Status = 3;
                        Nodes[MinI].Time = Iter;
                    }

                }
                catch (IndexOutOfRangeException)
                { }
            }
            if (Logic == 2)
            {
                Nodes[MinI].Status = - Nodes[MinI].Status; 
            }

            return BTM;

        }

        public void Infection(int chance, int n, int m, int Iter)                            //заражение
        {
            Random rnd = new Random();
            int R;

            for (int i = 1; i < Nodes.Count - 1; i++)
            {
                R = rnd.Next(0, 100);
                if (Nodes[i].Status == 3)
                {
                    if ((R <= chance) && (Nodes[i + 1].Status == 2) && (Nodes[i + 1].Status != 1))
                    {
                        Nodes[i + 1].Status = 3;
                        Nodes[i + 1].flag = 1;
                        R = rnd.Next(0, 100);
                        Nodes[i + 1].Time = Iter;
                    }
                    if ((R <= chance) && (Nodes[i - 1].Status == 2) && (Nodes[i - 1].Status != 1))
                    {
                        Nodes[i - 1].Status = 3;
                        Nodes[i - 1].flag = 1;
                        R = rnd.Next(0, 100);
                        Nodes[i - 1].Time = Iter;
                    }
                    try
                    {
                        if ((R <= chance) && (Nodes[i + m].Status == 2) && (Nodes[i + m].Status != 1))
                        {
                            Nodes[i + m].Status = 3;
                            Nodes[i + m].flag = 1;
                            R = rnd.Next(0, 100);
                            Nodes[i + m].Time = Iter;
                        }
                        if ((R <= chance) && (Nodes[i - m].Status == 2) && (Nodes[i - m].Status != 1))
                        {
                            Nodes[i - m].Status = 3;
                            Nodes[i - m].flag = 1;
                            R = rnd.Next(0, 100);
                            Nodes[i - m].Time = Iter;
                        }
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
        }

        public Bitmap RefreshBox(Bitmap PictureBox)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].Status == 1)
                    Graphics.FromImage(PictureBox).FillEllipse(Brush_G, Nodes[i].X, Nodes[i].Y, 10, 10);
                if (Nodes[i].Status == 2)
                    Graphics.FromImage(PictureBox).FillEllipse(Brush_O, Nodes[i].X, Nodes[i].Y, 10, 10);
                if (Nodes[i].Status == 3)
                    Graphics.FromImage(PictureBox).FillEllipse(Brush_R, Nodes[i].X, Nodes[i].Y, 10, 10);
                if (Nodes[i].Status < 0)
                    Graphics.FromImage(PictureBox).FillEllipse(Brush_W, Nodes[i].X, Nodes[i].Y, 10, 10);
            }
            return PictureBox;
        }

        public void Kol_vo(out int Green, out int Orange, out int Red) //кол-во узлов
        {
            Green = 0; Orange = 0; Red = 0;

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].Status == 1)
                    Green++;
                if (Nodes[i].Status == 2)
                    Orange++;
                if (Nodes[i].Status == 3)
                    Red++;
            }
        }

        public void Regen(int Iter)      //восстановление узлов 
        {
            for (int i = 0; i < Nodes.Count; i++)                         //для зараженной
            {
                if (Nodes[i].Status == 3)
                    Nodes[i].Time--;
            }
            for (int i = 0; i < Nodes.Count; i++)                       //смена статуса с красной на оранжевый 
            {
                if ((Nodes[i].Time <= 0) && (Nodes[i].Status == 3))
                    Nodes[i].Status = 2;
            }
            for (int i = 0; i < Nodes.Count; i++)                       //для оранжевой
            {
                if ((Nodes[i].Status == 2) && (Nodes[i].flag == 1))
                    Nodes[i].Time--;
            }
            for (int i = 0; i < Nodes.Count; i++)                       //смена с оранжевого на зеленый
            {
                if ((Nodes[i].Time <= -Iter) && (Nodes[i].Status == 2) && (Nodes[i].flag == 1))
                    Nodes[i].Status = 1;
            }
        }


        public void Info (int x, int y, int Iter, out int X, out int Y, out string status, out int IterToReg, out int IterToImm)
        {
            double min = 10000;
            int MinI = -1;
            X = -1; Y = -1; status = "";IterToReg = -1; IterToImm = -1;
           
            for (int i = 0; i < Nodes.Count; i++)                                   //минимальное расстояние
            {
                if (Math.Sqrt((Nodes[i].X - x - 5) * (Nodes[i].X - x - 5) + (Nodes[i].Y - y - 5) * (Nodes[i].Y - y - 5)) < min)
                {
                    min = Math.Sqrt((Nodes[i].X - x) * (Nodes[i].X - x) + (Nodes[i].Y - y) * (Nodes[i].Y - y));
                    MinI = i;
                }
            }

            X = Nodes[MinI].i;
            Y = Nodes[MinI].j;

            switch (Nodes[MinI].Status)
            {
                case 1:
                    status = "Узел с наличием иммунитета";
                    break;
                case 2:
                    status = "Узел восприимчив";
                    break;
                case 3:
                    status = "Узел заражён";
                    break;
                case -1:
                    status = "Узел с наличием иммунитета (скрытый)";
                    break;
                case -2:
                    status = "Узел восприимчи (скрытый)";
                    break;
                case -3:
                    status = "Узел заражён (скрытый)";
                    break;
                
            }
            
            if (Nodes[MinI].Time > 0)
            {
                IterToReg = Nodes[MinI].Time;
                IterToImm = Nodes[MinI].Time + Iter;
            }
            else
            {
                IterToReg = 0;
                IterToImm = Iter + Nodes[MinI].Time;
            }

        }
    }
}
