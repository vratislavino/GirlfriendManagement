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
    public partial class Checkbox : UserControl
    {
        public event Action CheckedChanged;

        static Pen outlinePen = new Pen(Color.Black, 2);
        static Pen checkPen = new Pen(Color.Black, 6)
        {
            EndCap = System.Drawing.Drawing2D.LineCap.Round,
            StartCap = System.Drawing.Drawing2D.LineCap.Round,
        };

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set { 
                isChecked = value;
                CheckedChanged?.Invoke();
            }  
        }

        public Checkbox()
        {
            InitializeComponent();
            CheckedChanged += OnCheckedChanged;
        }

        private void Checkbox_Click(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }

        private void OnCheckedChanged()
        {
            Refresh();
        }

        private void Checkbox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawRectangle(outlinePen, 0,0, Width, Height);
            if(IsChecked)
            {
                e.Graphics.DrawLines(checkPen, new Point[] { 
                    new Point(Width/5, Height/5*3),
                    new Point(Width/5*2, Height-Height/5),
                    new Point(Width-Width/5, Height/3)
                });
            }
        }
    }
}
