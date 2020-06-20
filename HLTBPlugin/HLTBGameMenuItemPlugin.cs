using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace HLTBPlugin
{
    public class HLTBSearch : IGameMenuItemPlugin
    {
        private string MAIN_STORY = "Main Story Length";
        private string MAIN_EXTRA = "Main + Extra Length";
        private string COMPLETIONIST = "Completionist Length";
        private const string PLUGIN_NAME = "Search Game Length";
        private bool MainStoryEnabled;
        private bool MainExtraEnabled;
        private bool CompletionistEnabled;

        public HLTBSearch()
        {
            MainStoryEnabled = true;
            MainExtraEnabled = true;
            CompletionistEnabled = true;

            try
            {
                XmlDocument settings = new XmlDocument();
                settings.Load("Plugins\\HLTBPlugin\\HLTBPlugin.xml");

                MainStoryEnabled = bool.Parse(settings.DocumentElement.SelectSingleNode("/HLTBPlugin/MainStoryLength").InnerText);
                MainExtraEnabled = bool.Parse(settings.DocumentElement.SelectSingleNode("/HLTBPlugin/MainExtraLength").InnerText);
                CompletionistEnabled = bool.Parse(settings.DocumentElement.SelectSingleNode("/HLTBPlugin/CompletionistLength").InnerText);

                MAIN_STORY = settings.DocumentElement.SelectSingleNode("/HLTBPlugin/MainStoryFieldName").InnerText;
                MAIN_EXTRA = settings.DocumentElement.SelectSingleNode("/HLTBPlugin/MainExtraFieldName").InnerText;
                COMPLETIONIST = settings.DocumentElement.SelectSingleNode("/HLTBPlugin/CompletionistFieldName").InnerText;
            }
            catch
            {
                //Error reading XML- Use default
            }
        }

        public bool SupportsMultipleGames
        {
            get
            {
                return false;
            }
        }

        public string Caption
        {
            get
            {
                return PLUGIN_NAME;
            }
        }

        public System.Drawing.Image IconImage
        {
            get
            {
                var img = HLTBPlugin.Properties.Resources.hltb_brand;
                return img;
            }
        }

        public bool ShowInLaunchBox
        {
            get
            {
                return true;
            }
        }

        public bool ShowInBigBox
        {
            get
            {
                return false;
            }
        }

        public bool GetIsValidForGame(IGame selectedGame)
        {
            return true;
        }

        public bool GetIsValidForGames(IGame[] selectedGames)
        {
            return false;
        }

        public void OnSelected(IGame selectedGame)
        {
            frmHLTBGames frm = new frmHLTBGames();
            frm.txtGameTitle.Text = selectedGame.Title;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var oldfields = selectedGame.GetAllCustomFields();
                foreach (var field in oldfields)
                {
                    if (field.Name == MAIN_STORY || field.Name == MAIN_EXTRA || field.Name == COMPLETIONIST)
                    {
                        selectedGame.TryRemoveCustomField(field);
                    }
                }

                if (MainStoryEnabled && frm.selectedGame.mainStory > 0)
                {
                    var mainStory = selectedGame.AddNewCustomField();
                    mainStory.Name = MAIN_STORY;
                    mainStory.Value = frm.selectedGame.mainStory.ToString().PadLeft(3, '0') + " Hours";
                }

                if (MainExtraEnabled && frm.selectedGame.mainExtra > 0)
                {
                    var mainStory = selectedGame.AddNewCustomField();
                    mainStory.Name = MAIN_EXTRA;
                    mainStory.Value = frm.selectedGame.mainExtra.ToString().PadLeft(3, '0') + " Hours";
                }

                if (CompletionistEnabled && frm.selectedGame.completionist > 0)
                {
                    var mainStory = selectedGame.AddNewCustomField();
                    mainStory.Name = COMPLETIONIST;
                    mainStory.Value = frm.selectedGame.completionist.ToString().PadLeft(3, '0') + " Hours";
                }
            }

            PluginHelper.DataManager.Save();
        }

        public void OnSelected(IGame[] selectedGames)
        {
            return;
        }
    }
}
