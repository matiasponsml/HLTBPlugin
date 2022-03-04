using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;

namespace HLTBPlugin
{
    public struct HLTBGame
    {
        public string title { set; get; }
        public string img { set; get; }
        public int mainStory { set; get; }
        public int mainExtra { set; get; }
        public int completionist { set; get; }
    }

    public static class HLTBScraper
    {
        public static List<HLTBGame> searchGame(string gameTitle)
        {
            List<HLTBGame> gameList = new List<HLTBGame>();

            using (var webClient = new WebClient())
            {
                var values = new NameValueCollection();
                values["queryString"] = gameTitle;
                values["sorthead"] = "popular";
                values["t"] = "games";

                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.2; .NET CLR 1.0.3705;)");

                var response = webClient.UploadValues("https://howlongtobeat.com/search_results?page=1", "POST", values);

                var responseString = Encoding.Default.GetString(response);

                var games = responseString.Split(new String[] { "<li class=\"back_darkish\"" }, 20, StringSplitOptions.RemoveEmptyEntries);

                int divHoursStart, hoursEnd;
                string szHours;
                for (int i = 0; i< games.Count(); i++) {
                    if (games[i].IndexOf("<div class=\"search_list_details\">") > -1)
                    {
                        HLTBGame game = new HLTBGame();
                        int titleStart = games[i].IndexOf("title=\"") + 7;
                        game.title = games[i].Substring(titleStart, games[i].IndexOf("\"", titleStart) - titleStart);

                        //Scrap Main Story
                        int hoursStart = games[i].IndexOf(">Main Story<");
                        if (hoursStart > -1)
                        {
                            divHoursStart = games[i].IndexOf("search_list_tidbit", hoursStart);
                            hoursStart = games[i].IndexOf(">", divHoursStart) + 1;
                            hoursEnd = games[i].IndexOf("<", divHoursStart);
                            szHours = games[i].Substring(hoursStart, hoursEnd - hoursStart);
                            szHours = szHours.Replace("Hours", "").Replace("Hour", "").Replace("&#189;", "").Replace(" ", "").Trim();

                            if (int.TryParse(szHours, out int mainHours))
                            {
                                game.mainStory = mainHours;
                            }
                        }

                        //Scrap Main Story
                        hoursStart = games[i].IndexOf(">Main + Extra<");
                        if (hoursStart > -1)
                        {
                            divHoursStart = games[i].IndexOf("search_list_tidbit", hoursStart);
                            hoursStart = games[i].IndexOf(">", divHoursStart) + 1;
                            hoursEnd = games[i].IndexOf("<", divHoursStart);
                            szHours = games[i].Substring(hoursStart, hoursEnd - hoursStart);
                            szHours = szHours.Replace("Hours", "").Replace("Hour", "").Replace("&#189;", "").Replace(" ", "").Trim();

                            if (int.TryParse(szHours, out int extraHours))
                            {
                                game.mainExtra = extraHours;
                            }
                        }

                        //Scrap Completionist
                        hoursStart = games[i].IndexOf(">Completionist<");
                        if (hoursStart > -1)
                        {
                            divHoursStart = games[i].IndexOf("search_list_tidbit", hoursStart);
                            hoursStart = games[i].IndexOf(">", divHoursStart) + 1;
                            hoursEnd = games[i].IndexOf("<", divHoursStart);
                            szHours = games[i].Substring(hoursStart, hoursEnd - hoursStart);
                            szHours = szHours.Replace("Hours", "").Replace("Hour", "").Replace("&#189;", "").Replace(" ", "").Trim();

                            if (int.TryParse(szHours, out int compHours))
                            {
                                game.completionist = compHours;
                            }
                        }

                        gameList.Add(game);
                    }
                }

                return gameList;
            }
        }
    }
}
