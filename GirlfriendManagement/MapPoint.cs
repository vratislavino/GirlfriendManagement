using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlfriendManagement
{
    public class MapPoint
    {
        protected Pen pen = new Pen(Color.Red, 3f);
        protected int x;
        protected int y;

        protected int size = 12;

        public int X { 
            get { return x; }
            set { x = value; }
        }
        public int Y {
            get { return y; }
            set { y = value; }
        }

        public bool Highlight { get; set; }

        public void Draw(Graphics g)
        {
            if(Highlight)
            {
                g.FillEllipse(Brushes.Red, x - size / 2, y - size / 2, size, size);
            } else
            {
                g.DrawEllipse(pen, x - size / 2, y - size / 2, size, size);
            }
        }

        public float GetDistance(Point mouse)
        {
            return (float)Math.Sqrt(Math.Pow(mouse.X - x, 2) + Math.Pow(mouse.Y - y, 2));
        }

        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}
