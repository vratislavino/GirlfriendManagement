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
    public partial class AddGirlfriendForm : Form
    {
        private string name;
        private int x;
        private int y;
        private float rating;

        private Girlfriend newGirlfriend;
        public Girlfriend NewGirlfriend => newGirlfriend;

        public AddGirlfriendForm()
        {
            InitializeComponent();
            ratingControl1.RatingChanged += OnRatingChanged;
        }

        private void OnRatingChanged(RatingControl obj)
        {
            rating = obj.Rating;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            x = r.Next(0, 500);
            y = r.Next(0, 300);

            textBox2.Text = x.ToString();
            textBox3.Text = y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out x))
            {
                if (int.TryParse(textBox3.Text, out y))
                {
                    if (!string.IsNullOrEmpty(textBox1.Text)
                        && !string.IsNullOrEmpty(textBox2.Text)
                        && !string.IsNullOrEmpty(textBox3.Text)
                        && rating != 0)
                    {
                        newGirlfriend = new Girlfriend()
                        {
                            Name = textBox1.Text,
                            Rating = rating,
                            X = x,
                            Y = y
                        };
                    }
                }
            }
        }
    }
}
