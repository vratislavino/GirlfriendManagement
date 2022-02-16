using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirlfriendManagement
{
    public partial class Canvas : UserControl
    {
        public event Action<MapPoint> MapPointHighlighted;

        private IEnumerable<MapPoint> mapPoints = new List<MapPoint>();

        private Point mousePosition = Point.Empty;
        private MapPoint lastHighlight = null;
        
        public Canvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void UpdateMapPoints(IEnumerable<MapPoint> points)
        {
            this.mapPoints = points;
            Refresh();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Vykreslení mapy
            // Vykreslení bodů
            foreach (var mapPoint in mapPoints)
            {
                mapPoint.Draw(e.Graphics);

            }
            // Vykreslení cesty
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = e.Location;
            var point = mapPoints.FirstOrDefault(p => p.GetDistance(mousePosition) < 15);
            if (point != null)
            {
                if (lastHighlight != point)
                {
                    if (lastHighlight != null)
                    {
                        lastHighlight.Highlight = false;
                    }
                    point.Highlight = true;
                    lastHighlight = point;
                    MapPointHighlighted?.Invoke(point);
                    Refresh();
                }
            }
            else
            {
                if (lastHighlight != null)
                {
                    lastHighlight.Highlight = false;
                    lastHighlight = null;
                    Refresh();
                }
            }
        }
    }
}
