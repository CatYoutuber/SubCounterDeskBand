using System;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using CSDeskBand;
using CSDeskBand.ContextMenu;
using Newtonsoft.Json.Linq;

namespace SubscriberCounterDeskBand
{
    [ComVisible(true)]
    [Guid("f23b02b2-ea07-47c8-91b1-210393849742")]
    [CSDeskBandRegistration(Name = "Subscriber Counter", ShowDeskBand = true)]
    public class Band : CSDeskBandWin
    {
	//Gde vzyat API Klych: https://blog.hubspot.com/website/how-to-get-youtube-api-key
        public static string API_KEY = "pisat api klyuch suda";
        public static string 
            urlStat = "https://www.googleapis.com/youtube/v3/channels?part=statistics&key=" + API_KEY + "&id=",
            urlSnippet = "https://www.googleapis.com/youtube/v3/channels?part=snippet&key=" + API_KEY + "&id=";

        private static BandControl _control;
        private static WebClient webClient;
        protected override Control Control => _control;

        public Band()
        {
            webClient = new WebClient();
            using (RegistryKey software = Registry.CurrentUser.OpenSubKey("Software", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (!software.GetSubKeyNames().Contains("CatYoutuber"))
                {
                    software.CreateSubKey(@"CatYoutuber\SubCounterDeskBand").SetValue("ChannelID",PromptChannelID());
                    software.Close();
                }
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\CatYoutuber\SubCounterDeskBand", RegistryKeyPermissionCheck.ReadWriteSubTree);

            Options.MinHorizontalSize = new Size(128, 32);
            DeskBandMenuAction ccid = new DeskBandMenuAction("Change Channel ID");
            ccid.Clicked += (s, e) =>
            {
                string prompt = PromptChannelID();
                if (prompt.Length < 1) return;
                RegistryKey pd = Registry.CurrentUser.OpenSubKey(@"Software\CatYoutuber\SubCounterDeskBand", RegistryKeyPermissionCheck.ReadWriteSubTree);
                pd.SetValue("ChannelID", prompt);
            };
            Options.ContextMenuItems.Add(ccid);
            DeskBandMenuAction ua = new DeskBandMenuAction("Update");
            ua.Clicked += (s, e) => Update();
            Options.ContextMenuItems.Add(ua);
            _control = new BandControl();
            SetCompositionState(true);
            Update();
        }
        private string PromptChannelID() => Interaction.InputBox("Write here your channel ID\nsth that goes after www.youtube.com/channel/", "Subscriber Counter DeskBand");
        private string GetChannelID() => Registry.CurrentUser.OpenSubKey(@"Software\CatYoutuber\SubCounterDeskBand").GetValue("ChannelID").ToString();
        private void Update()
        {
            if(GetChannelID().Length < 1)
            {
                MessageBox.Show("Channel ID is empty, Chanege it in DeskBand's context menu", "Subscriber Counter DeskBand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string data1 = "empty", data2 = "empty";
                data1 = webClient.DownloadString(urlStat + GetChannelID());
                data2 = webClient.DownloadString(urlSnippet + GetChannelID());

                JObject obj1 = JObject.Parse(data1);
                JToken token1 = obj1["items"].Children().ToList()[0]["statistics"];
                uint subs = 0;
                bool hidden = false;
                if (!(hidden = bool.Parse(token1["hiddenSubscriberCount"].ToString())))
                    subs = uint.Parse(token1["subscriberCount"].ToString());

                JObject obj2 = JObject.Parse(data2);
                JToken token2 = obj2["items"].Children().ToList()[0]["snippet"];
                string title = token2["title"].ToString();
                string thumbnailURL = token2["thumbnails"]["default"]["url"].ToString();

                WebRequest request = WebRequest.Create(thumbnailURL);
                Bitmap thumbnail = new Bitmap(request.GetResponse().GetResponseStream());
                _control.infoLabel.Text = string.Format("{0}\n{1}", title, hidden ? "subs hidden" : subs.ToString());
                _control.avatarPic.BackgroundImage = thumbnail;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
