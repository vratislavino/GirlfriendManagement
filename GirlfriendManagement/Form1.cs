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
    public partial class Form1 : Form
    {
        List<GirlfriendDisplay> girlfriends = new List<GirlfriendDisplay>();

        public Form1()
        {
            InitializeComponent();
            canvas1.MapPointHighlighted += OnMapPointHighlighted;
            ProcessNewGirlfriend(new Girlfriend() { Name = "Alenka", X = 50, Y = 279, Rating = 3.5f });
            ProcessNewGirlfriend(new Girlfriend() { Name = "Zuzana", X = 258, Y = 431, Rating = 1.5f });
            ProcessNewGirlfriend(new Girlfriend() { Name = "Kunhuta", X = 685, Y = 18, Rating = 4f });
            ProcessNewGirlfriend(new Girlfriend() { Name = "Lenka", X = 722, Y = 125, Rating = 2f });
        }

        private void OnMapPointHighlighted(MapPoint point)
        {
            foreach (var gfd in girlfriends)
            {
                gfd.BackColor = gfd.MapPoint == point ? Color.Green : Color.White;
            }
        } 

        private void AddGirlfriend(GirlfriendDisplay gfd)
        {
            girlfriends.Add(gfd);
            canvas1.UpdateMapPoints(girlfriends.Select(x=>x.MapPoint));
        }

        private void RemoveGirlfriend(GirlfriendDisplay gfd)
        {
            girlfriends.Remove(gfd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddGirlfriendForm form = new AddGirlfriendForm();
            form.FormClosing += (evt, args) => { 
                if(form.NewGirlfriend != null)
                {
                    ProcessNewGirlfriend(form.NewGirlfriend);
                }
            }; 
            form.ShowDialog();
        }

        private void ProcessNewGirlfriend(Girlfriend gf)
        {
            GirlfriendDisplay girlfriendDisplay = new GirlfriendDisplay();
            girlfriendDisplay.AddData(gf);

            AddGirlfriend(girlfriendDisplay); //girlfriends.Add(girlfriendDisplay);

            flowLayoutPanel1.Controls.Add(girlfriendDisplay);
        }
    }
}
