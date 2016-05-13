using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;

namespace Paint
{
    public enum Shape { pencil, circle, rectangle, rubber, line, triangle, fill, trapezoid, Romb,hexagon,star, octagon, Endterm3, Bonus};
    
    class Drawer
    {
        public Graphics g;
        public GraphicsPath path;
        public Bitmap btm;
        public PictureBox picture;
        public Pen pen;
        public Pen rubber;
        public Shape shape;
        public Point prev;
        public bool paintStarted = false;
        public Color color = Color.Red;

        Queue<Point> q = new Queue<Point>();
        bool[,] used = new bool[443, 278];
        private object p;

        public Drawer(PictureBox p)
        {
            this.picture = p;
            OpenImage("");
            pen = new Pen(Color.Black);
            rubber = new Pen(Color.White);
            picture.Paint += Picture_paint;
        }

        public void SaveImage(string filename)
        {
            btm.Save(filename);
        }

        public void OpenImage(string filename)
        {
            if (filename == "") {
                btm = new Bitmap(picture.Width, picture.Height);
            } else btm = new Bitmap(filename);
            g = Graphics.FromImage(btm);
            picture.Image = btm;
        }

        public void Picture_paint(object sender, PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
        public void saveLastPath()
        {
            if (path != null)
            {
                g.DrawPath(pen, path);
            }
        }
        public void Draw(Point cur)
        {
            switch (shape)
            {
                case Shape.pencil:
                    g.DrawLine(pen, prev, cur);
                    prev = cur;
                    break;
                case Shape.rubber:
                    g.DrawLine(rubber, prev, cur);
                    prev = cur;
                    break;

                case Shape.circle:
                    path = new GraphicsPath();
                    path.AddEllipse(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                    break;
                case Shape.rectangle:
                    //path = new GraphicsPath();
                    ////path.AddRectangle(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));



                    //int width = Math.Abs(cur.X - prev.X), height = Math.Abs(cur.Y - prev.Y);

                    //int fx = prev.X;
                    //int fy = prev.Y;
                    //if (cur.X < prev.X)
                    //    fx = cur.X;
                    //if (cur.Y < prev.Y)
                    //    fy = cur.Y;
                    //path.AddRectangle(new Rectangle(fx, fy, width, height));
                    //break;
                    path = new GraphicsPath();
                    Point[] r = {
                            new Point(prev.X, prev.Y ),
                            new Point((cur.X-prev.X)+prev.X, prev.Y),
                            new Point(cur.X , cur.Y),
                            new Point(prev.X , cur.Y),

                    };
                    path.AddPolygon(r);
                    break;


                case Shape.line:
                    path = new GraphicsPath();
                    path.AddLine(prev, cur);
                    break;
                case Shape.triangle:
                    path = new GraphicsPath();
                    Point[] t =
                    {
                        new Point(prev.X+(cur.X-prev.X)/2,prev.Y),
                        new Point(cur.X, cur.Y),
                        new Point(prev.X,cur.Y),

                    };
                    path.AddPolygon(t);
                    break;
                case Shape.Romb:
                    path = new GraphicsPath();
                    Point[] arr2 ={
                        new Point(prev.X+(cur.X-prev.X)/2,prev.Y),
                        new Point(cur.X,prev.Y+(cur.Y-prev.Y)/2),
                        new Point(cur.X-(cur.X-prev.X)/2,cur.Y),
                        new Point(prev.X,cur.Y-(cur.Y-prev.Y)/2),
                    };
                    path.AddPolygon(arr2);
                    break;
                case Shape.trapezoid:
                    path = new GraphicsPath();
                    Point[] arr3 =
                    {
                        new Point(prev.X+(cur.X-prev.X)/3,prev.Y),
                        new Point(cur.X-(cur.X-prev.X)/3,prev.Y),
                        new Point(cur.X,cur.Y),
                        new Point(prev.X,cur.Y),
                    };
                    path.AddPolygon(arr3);
                    break;
                case Shape.hexagon:
                    path = new GraphicsPath();
                    Point[] arr4 =
                    {
                        new Point(prev.X+(cur.X-prev.X)/3,prev.Y),
                        new Point(cur.X-(cur.X-prev.X)/3,prev.Y),
                        new Point(cur.X,(cur.Y + prev.Y) / 2),
                        new Point(cur.X-(cur.X-prev.X)/3,cur.Y),
                        new Point(prev.X+(cur.X-prev.X)/3,cur.Y),
                        new Point(prev.X,(cur.Y + prev.Y) / 2),
                    };
                    path.AddPolygon(arr4);
                    break;
                case Shape.octagon:
                    path = new GraphicsPath();
                    Point[] arr5 =
                    {
                        new Point(prev.X+(cur.X-prev.X)/3,prev.Y),
                        new Point(cur.X-(cur.X-prev.X)/3,prev.Y),
                        new Point(cur.X,prev.Y+(cur.Y-prev.Y)/3),
                        new Point(cur.X,cur.Y-(cur.Y-prev.Y)/3),
                        new Point(cur.X-(cur.X-prev.X)/3,cur.Y),
                        new Point(prev.X+(cur.X - prev.X) / 3,cur.Y),
                        new Point(prev.X,cur.Y-(cur.Y-prev.Y)/3),
                        new Point(prev.X,prev.Y+(cur.Y-prev.Y)/3),
                    };
                    path.AddPolygon(arr5);
                    break;

                case Shape.star:
                    path = new GraphicsPath();
                    Point[] arr6 =
                    {
                        new Point(prev.X+(cur.X-prev.X)/2,prev.Y),
                        new Point(cur.X-(cur.X-prev.X)/4,prev.Y+(cur.Y-prev.Y)/4),
                        new Point(cur.X,prev.Y+(cur.Y-prev.Y)/2),
                        new Point(cur.X-(cur.X-prev.X)/4,cur.Y-(cur.Y-prev.Y)/2),
                        new Point(cur.X-(cur.X-prev.X)/5,cur.Y),
                        new Point(prev.X+(cur.X-prev.X)/2,cur.Y-(cur.Y-prev.Y)/5),
                        new Point(prev.X+(cur.X-prev.X)/4,cur.Y),
                        new Point(prev.X+(cur.X-prev.X)/4,prev.Y+(cur.Y-prev.Y)/2),
                        new Point(prev.X,prev.Y+(cur.Y-prev.Y)/2),
                        new Point(prev.X+(cur.X-prev.X)/4,prev.Y+(cur.Y-prev.Y)/3),
                    };
                    path.AddPolygon(arr6);
                    break;
                case Shape.Endterm3:
                    path = new GraphicsPath();
                    Point[] end =
                    {
                        new Point(prev.X+(cur.X-prev.X)/2,prev.Y),
                        new Point(cur.X,prev.Y+(cur.Y-prev.Y)/3),
                        new Point(cur.X,cur.Y-(cur.Y - prev.Y) / 3),
                        new Point(cur.X-(cur.X-prev.X)/2,cur.Y),
                        new Point(prev.X,cur.Y-(cur.Y-prev.Y)/3),
                        new Point(prev.X,prev.Y+(cur.Y - prev.Y) / 3),
                    };
                    path.AddPolygon(end);
                    break;
                case Shape.Bonus:
                    path = new GraphicsPath();
                    Point[] end1 =
                    {
                        new Point(prev.X+(cur.X-prev.X)/4,prev.Y),
                        new Point(cur.X,prev.Y),
                        new Point(cur.X,cur.Y-(cur.Y - prev.Y) / 4),
                        new Point(cur.X-(cur.X - prev.X) / 4,cur.Y),
                        new Point(prev.X,cur.Y),
                        new Point(prev.X,prev.Y+(cur.Y-prev.Y)/4),
                        
                    };
                    path.AddPolygon(end1);

                    Point[] end2 =
                    {
                        new Point(prev.X, prev.Y+(cur.Y-prev.Y)/4),
                        new Point(cur.X-(cur.X-prev.X)/4,prev.Y+(cur.Y-prev.Y)/4),
                        new Point(cur.X,prev.Y),
                        new Point(cur.X,cur.Y-(cur.Y - prev.Y) / 4),
                        new Point(cur.X-(cur.X - prev.X) / 4,cur.Y),
                        new Point(cur.X-(cur.X-prev.X)/4,prev.Y+(cur.Y-prev.Y)/4),

                    };
                    path.AddPolygon(end2);
                    Point[] end3 =
                   {
                        new Point(prev.X+(cur.X-prev.X)/4,prev.Y),
                        new Point(prev.X+(cur.X-prev.X)/4,cur.Y-(cur.Y-prev.Y)/4),
                        new Point(cur.X,cur.Y-(cur.Y - prev.Y) / 4),
                        new Point(cur.X-(cur.X - prev.X) / 4,cur.Y),
                        new Point(prev.X,cur.Y),
                        new Point(prev.X+(cur.X-prev.X)/4,cur.Y-(cur.Y-prev.Y)/4),
                    };
                    path.AddPolygon(end3);

                    break;
                    
            }
            picture.Refresh();

        }
        public void fill(Point cur)
        {
            for (int i = 0; i < 443; i++)

            {
                for (int j = 0; j < 278; j++)
                {
                    used[i, j] = false;
                }
            }

            Color clicked_color = btm.GetPixel(cur.X, cur.Y);
            checkNeighbors(cur.X, cur.Y, clicked_color);
            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                    checkNeighbors(p.X - 1, p.Y, clicked_color);
                    checkNeighbors(p.X + 1, p.Y, clicked_color);
                    checkNeighbors(p.X, p.Y + 1, clicked_color);
                    checkNeighbors(p.X, p.Y - 1, clicked_color);
                               
            }
            picture.Refresh();
        }
        public void checkNeighbors(int x, int y, Color clicked_color)
        {
            if (x > 0 && y > 0 && x < picture.Width && y < picture.Height)
            {
                if (used[x, y] == false && btm.GetPixel(x, y) == clicked_color)
                {
                    used[x, y] = true;
                    q.Enqueue(new Point(x,y));
                    btm.SetPixel(x,y,color);
                }
            }


        }
    }
}


