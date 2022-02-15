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
        private Color color;
        private int x;
        private int y;

        private int size;

        public int X { 
            get { return x; }
            set { x = value; }
        }
        public int Y {
            get { return y; }
            set { y = value; }
        }

        public void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(color), x - size / 2, Y - size / 2, size, size);
        }
    }
}
