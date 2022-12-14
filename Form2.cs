using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4_Michuta
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Font font = new Font(Name, 12);
            Graphics graphics = pictureBox1.CreateGraphics();
            Random random = new Random();
            Form1 form1 = new Form1();
            Pen pen = new Pen(Color.Black, 2);
            int ij = form1.ij;
            graphics.Clear(Color.White);
            PointF []point = new PointF[6];

            for (int i = 0; i < ij; i++)
            {
                graphics.build_V(font, random.Next(15, 585), random.Next(15, 385), form1.abc[i]);
            }
            graphics.DrawCircle(pen, random.Next(15, 585), random.Next(15, 285), 15);
            // Draw polygon curve to screen.
            //graphics.DrawPolygon(blackPen, point);
        }
    }
    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
        public static void build_V(this Graphics g, Font font, float centerX, float centerY, char V)
        {
            Pen pen = new Pen(Color.Black, 2);
            string v = Convert.ToString(V);
            Brush brush = Brushes.Black;
            g.DrawCircle(pen, centerX, centerY, 15);
            g.DrawString(v, font, brush, centerX - 8, centerY - 8);
        }
    }

}
