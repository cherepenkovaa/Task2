using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача_1
{
    public partial class Form1 : Form
    {
        int x, y;
        bool flag;
        bool stop;
        int index = 0;
        Figuri arr;
        static Form1()
        {
            
        }
        public Form1()
        {
            InitializeComponent();
            flag = false;
            //index = 0;
            stop = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //SolidBrush br = new SolidBrush(co);
            if (flag)
            {
                arr.DrawFigure(e.Graphics);        
            }  
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (flag && arr.Check(e.X, e.Y))  // && 
            {
                /*if (e.Button == MouseButtons.Left)
                {*/
                    x = e.X - arr.SetX;
                    y = e.Y - arr.SetY;
                    stop = false;
               /* }
                if (e.Button == MouseButtons.Right)
                {
                    arr = null;
                    flag = false;
                }*/
            }


            else
            {
                flag = true;
                switch (index)
                {
                    case 1: arr = new Ellipse(e.X, e.Y); break;
                    case 2: arr = new Rectangle(e.X, e.Y); break;
                    case 3: arr = new Triangle(e.X, e.Y); break;
                    default: arr = new Rectangle(e.X, e.Y); break;
                }
            }

            this.Invalidate();
        }

        private void КругToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void КвадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void ТреугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void КругToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (stop != true)
            {
                x = e.X;
                y = e.Y;
                this.Invalidate();
            }*/
            if (stop == false)
            {
                arr.SetX = e.X - x;
                arr.SetY = e.Y - y;
                this.Invalidate();
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            stop = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            flag = false;
            Invalidate();
        }

        /*private void Form1_MouseLeave(object sender, EventArgs e)
        {
            flag = false;
            
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }
    }
}
