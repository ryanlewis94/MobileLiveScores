using System;
using System.Collections.Generic;
using System.Text;

namespace MobileLiveScores.Classes
{
    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<League> leagueList { get; set; }
        public int rowHeight { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country_id { get; set; }
        public string scores { get; set; }
        public List<Match> matchList { get; set; }
        public List<Fixture> fixtureList { get; set; }
    }
    public class Match
    {
        public string id { get; set; }
        public string home_name { get; set; }
        public string away_name { get; set; }
        public string score { get; set; }
        public string ht_score { get; set; }
        public string ft_score { get; set; }
        public string et_score { get; set; }
        public string time { get; set; }
        public string league_id { get; set; }
        public string status { get; set; }
        public string added { get; set; }
        public string last_changed { get; set; }
        public string home_id { get; set; }
        public string away_id { get; set; }
        public string competition_id { get; set; }
        public string location { get; set; }
        public string fixture_id { get; set; }
        public string scheduled { get; set; }
        public string events { get; set; }
        public string league_name { get; set; }
        public string competition_name { get; set; }
    }
    public class Fixture
    {
        public string id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string round { get; set; }
        public string home_name { get; set; }
        public string away_name { get; set; }
        public string location { get; set; }
        public string league_id { get; set; }
        public string home_id { get; set; }
        public string away_id { get; set; }
        public string competition_id { get; set; }
    }
}
