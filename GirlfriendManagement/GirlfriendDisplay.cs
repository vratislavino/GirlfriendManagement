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
    public partial class GirlfriendDisplay : UserControl
    {
        public event Action<GirlfriendDisplay> DeleteRequested;

        Girlfriend girlfriend;
        MapPoint mapPoint;

        public bool IsAvailable => checkbox1.IsChecked;

        public MapPoint MapPoint => mapPoint;

        public GirlfriendDisplay()
        {
            InitializeComponent();
        }

        public void AddData(Girlfriend data)
        {
            this.girlfriend = data;
            label1.Text = data.Name;
            mapPoint = new MapPoint() {
                X = data.X,
                Y = data.Y
            }; 
            ratingControl1.Enabled = false;
            ratingControl1.Rating = data.Rating - 0.5f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteRequested?.Invoke(this);
        }
    }
}
