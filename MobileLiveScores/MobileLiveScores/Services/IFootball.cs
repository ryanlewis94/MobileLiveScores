using MobileLiveScores.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileLiveScores.Services
{
    public interface IFootball
    {
        Task<List<Country>> LoadCountry();
        Task<List<Fixture>> LoadFixture(int pageNo);
        Task<List<League>> LoadLeague();
        Task<List<Match>> LoadLive();
    }
}
