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
    public partial class RatingControl : UserControl
    {
        private float rating;

        static Image full;
        static Image half;
        static Image empty;

        Panel[] panels = new Panel[5];

        public float Rating
        {
            get { return rating; }
            set { 
                rating = value;
                DisplayValueInStars(rating);
            }
        }

        public RatingControl()
        {
            InitializeComponent();
            InitImages();
            CreatePanels();
        }

        private void CreatePanels()
        {
            int size = 80;
            for(int i = 0; i < panels.Length; i++)
            {
                var panel = new Panel();
                panel.Size = new Size(size, size);
                panel.BackgroundImage = empty;
                panel.Location = new Point(i * size, 0);
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(panel);
                panels[i] = panel;
            }
        }

        private static void InitImages()
        {
            try
            {
                if (full == null)
                {
                    full = Properties.Resources.star_empty;
                    half = Properties.Resources.star_half;
                    empty = Properties.Resources.star_full;
                }
            }
             catch(System.IO.FileNotFoundException e)
            {
                MessageBox.Show("Nebyl nalezen obrázek " + e.Message);
            }
        }

        private void DisplayValueInStars(float stars)
        {

        }
    }
}
