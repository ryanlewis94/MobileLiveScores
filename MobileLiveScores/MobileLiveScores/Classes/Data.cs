using System;
using System.Collections.Generic;
using System.Text;

namespace MobileLiveScores.Classes
{
    public class Data
    {
        public List<Country> country { get; set; }
        public List<League> league { get; set; }
        public List<Match> match { get; set; }
        public List<Fixture> fixtures { get; set; }
    }
}
