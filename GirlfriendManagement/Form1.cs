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

            girlfriends.Add(girlfriendDisplay);
            flowLayoutPanel1.Controls.Add(girlfriendDisplay);
        }
    }
}
