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
        public event Action<RatingControl> RatingChanged;

        private float rating;

        static Image full;
        static Image half;
        static Image empty;

        Panel[] panels = new Panel[5];

        private int size = 80;

        public int MySize { get; set; } = 80;

        public float Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                DisplayValueInStars(rating);

                RatingChanged?.Invoke(this);
            }
        }

        public RatingControl()
        {
            InitializeComponent();
            InitImages();
            CreatePanels();
        }

        public RatingControl(int size) : this()
        {
            this.size = size;
        }

        private void CreatePanels()
        {
            this.Controls.Clear();
            this.size = MySize;
            for (int i = 0; i < panels.Length; i++)
            {
                var panel = new Panel();
                panel.Size = new Size(size, size);
                panel.BackgroundImage = empty;
                panel.Location = new Point(i * size, 0);
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                panel.MouseClick += OnStarClicked;
                this.Controls.Add(panel);
                panels[i] = panel;
            }
            this.Size = new Size(panels.Length * size, size);
        }

        private void OnStarClicked(object sender, MouseEventArgs e)
        {
            if (!Enabled)
                return;
            float newRating = 0;
            int index = -1;
            for (int i = 0; i < panels.Length; i++)
            {
                if(panels[i] == sender)
                {
                    index = i;
                    break;
                } 
            }
            if(e.X > panels[index].Width/2)
            {
                newRating = index + 0.5f;
            } else
            {
                newRating = index;
            }
            Rating = newRating;
        }

        private static void InitImages()
        {
            if (full == null)
            {
                full = Properties.Resources.star_full;
                half = Properties.Resources.star_half;
                empty = Properties.Resources.star_empty;
            }
        }

        private void DisplayValueInStars(float stars)
        {
            for(int i = 0; i < panels.Length; i++) { 
                if(i <= stars)
                {
                    if(i <= stars - 0.5f)
                    {
                        panels[i].BackgroundImage = full;
                    } else
                    {
                        panels[i].BackgroundImage = half;
                    }
                } else
                {
                    panels[i].BackgroundImage = empty;
                }
            }
        }

        private void RatingControl_SizeChanged(object sender, EventArgs e)
        {
            CreatePanels();
        }
    }
}
