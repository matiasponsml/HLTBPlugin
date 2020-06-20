using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLTBPlugin
{
    public partial class frmHLTBGames : Form
    {
        public HLTBGame selectedGame { set; get; }

        public frmHLTBGames()
        {
            InitializeComponent();
        }

        private void lstGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGame = (HLTBGame)lstGames.SelectedItems[0].Tag;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstGames.Items.Clear();
            if (!String.IsNullOrWhiteSpace(txtGameTitle.Text))
            {
                List<HLTBGame> games = HLTBScraper.searchGame(txtGameTitle.Text);

                foreach (HLTBGame game in games)
                {
                    ListViewItem item = new ListViewItem(game.title);
                    item.SubItems.Add((game.mainStory > 0) ? game.mainStory.ToString() + " Hours" : "--");
                    item.SubItems.Add((game.mainExtra > 0) ? game.mainExtra.ToString() + " Hours" : "--");
                    item.SubItems.Add((game.completionist > 0) ? game.completionist.ToString() + " Hours" : "--");
                    item.Tag = game;
                    this.lstGames.Items.Add(item);
                }
            }
        }

        private void frmHLTBGames_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtGameTitle.Text))
            {
                btnSearch.PerformClick();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://howlongtobeat.com/");
        }
    }
}
