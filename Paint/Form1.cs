using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Drawer drawer;
      
        public Form1()
        {
            InitializeComponent();
            drawer = new Drawer(pictureBox1);
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 20;

        }

        

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.OpenImage(openFileDialog1.FileName);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.rectangle;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.line;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.rubber;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.pencil;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.circle;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.triangle;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            colorDialog1.ShowDialog();
            drawer.pen = new Pen(colorDialog1.Color);
            drawer.color = colorDialog1.Color;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.Romb;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.fill;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawer.pen.Width = trackBar1.Value;
            drawer.rubber.Width = trackBar1.Value;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (drawer.paintStarted)
            {
                drawer.Draw(e.Location);
            }

        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                if (drawer.shape == Shape.fill)
                {
                    drawer.fill(e.Location);
                }
                else
                {
                    drawer.prev = e.Location;
                    drawer.paintStarted = true;
                }
            }

        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            drawer.paintStarted = false;
            drawer.saveLastPath();

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.SaveImage(saveFileDialog1.FileName);
            }

        }

        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawer.g.Clear(Color.White);

            pictureBox1.Refresh();

            drawer.picture.Refresh();
            drawer.path = null;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.trapezoid;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.hexagon;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.octagon;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.star;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.Endterm3;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            drawer.shape = Shape.Bonus;
        }

        private void button16_Click(object sender, EventArgs e)
        {
           // drawer.shape =Shape.Bonus
        }
    }
}
