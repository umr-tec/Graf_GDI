using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using UserControlAnimacion;
/*
    Actividad Cholo brinca:
        Leo, Hector, Paola, Victoria, Jorge, Roberto, Job, Brayan Paulina
 */
namespace Graf_2_Ejemplo1
{
    public partial class Form1 : Form
    {
        //InterpolationMode para aplicar al imagenes.
        private InterpolationMode interpolation = InterpolationMode.HighQualityBilinear;        
        UserControl1 cholo = new UserControl1();
        private int contador = 0;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            //agregar el cholo
            cholo.Top = 200;
            //cambiar valor de la variable contador
            contador = this.ClientSize.Width-80;
        }

        private void Form1_Load(object sender, EventArgs e)
        {            

        }       

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);           

            Font font = new Font("Arial", 7, FontStyle.Italic);
            //Objeto de tipo Pen, para dibujar las lineas
            Pen penLines = new Pen(Color.FromArgb(30,12, 81, 96));
            SolidBrush brushLines = new SolidBrush(Color.FromArgb(190, 12, 81, 96));

            //1. Degradar el fondo
            Rectangle rectangle = new Rectangle(0, 0, ClientSize.Width, (ClientSize.Height * 75) / 100);
            LinearGradientBrush gradientBrush = new
                LinearGradientBrush(rectangle, Color.Moccasin, Color.DeepSkyBlue, LinearGradientMode.ForwardDiagonal);
            e.Graphics.FillRectangle(gradientBrush, rectangle);
            //2. color para la franja de pasto
            e.Graphics.FillRectangle(Brushes.ForestGreen, 0, (ClientSize.Height * 75) / 100, ClientSize.Width, (ClientSize.Height * 100) / 100);

            
            Bitmap img = new Bitmap(@"C:\imas\UMR_ACADEMIC.png");
            //e.Graphics.DrawImage(img, 10, 10, 240, 240);
            img.MakeTransparent(Color.FromArgb(255, 255, 255));
            img.MakeTransparent(Color.FromArgb(22, 22, 22));
            e.Graphics.DrawImage(img, 400, 10, 40, 40);
            
            Bitmap imgTextura = new Bitmap(@"C:\imas\sw.jpg");
            TextureBrush texture = new TextureBrush(imgTextura);
            Font font1 = new Font("StarJedi Special Edition", 40);
            e.Graphics.DrawString("UMR", font1, texture, 10, (ClientSize.Height * 75) / 100);
            
            Point[] puntosSol = {
                new Point(80,0),
                new Point(105, 25),
                new Point(80,40),
                new Point(100,60),
                new Point(70,60),
                new Point(80,80),
                new Point(60,75),
                new Point(40,110),
                new Point(45,80),
                new Point(20,100),
                new Point(0,60)
            };

            e.Graphics.FillClosedCurve(Brushes.DarkOrange, puntosSol);
            e.Graphics.FillEllipse(Brushes.Moccasin, -20, -20, 90, 90);
            //Dibujar la imagen llamada maceta
            e.Graphics.InterpolationMode = interpolation;
            e.Graphics.DrawImage(Properties.Resources.maceta, contador, 260,80,80);

            for (int i = 0; i < this.Width; i += 20)
            {
                e.Graphics.DrawLine(penLines, i, 0, i, this.Height);
                e.Graphics.DrawString(i.ToString(), font,
                    brushLines, i, 0);
            }

            for (int y = 0; y < this.Height; y += 20)
            {
                e.Graphics.DrawLine(penLines, 0, y, this.Width, y);
                e.Graphics.DrawString(y.ToString(), font, brushLines, 0, y);
            }

            this.Controls.Add(cholo);
        }


        private void Form1_Click(object sender, EventArgs e)
        {
            Refresh();
            //using (Graphics graphics = CreateGraphics())
            //using (Font font = new Font("Arial", 6, FontStyle.Italic))
            //{
            //    for (int i = 0; i < this.Width; i += 20)
            //    {
            //        graphics.DrawLine(Pens.BlueViolet, i, 0, i, this.Height);
            //        graphics.DrawString(i.ToString(), font,
            //            Brushes.BlueViolet, i, 0);
            //    }
            //    for (int i = 0; i < this.Height; i += 20)
            //    {
            //        graphics.DrawLine(Pens.BlueViolet, 0, i, this.Width, i);
            //    }
            //}
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X.ToString() + " , " + e.Y.ToString());
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            //contador = contador + 10;
            contador -= 10;
            Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("enter");
            }
        }
    }
}
