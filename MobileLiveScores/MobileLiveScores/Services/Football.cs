using MobileLiveScores.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileLiveScores.Services
{
    public class Football : IFootball
    {
        public async Task<List<Country>> LoadCountry()
        {

            string url = "https://livescore-api.com/api-client/countries/list.json?key=1OCIT6FNkAWmgIRp&secret=41WQJvxTJEY5uDkvrWdk3T7nt4KKNB9S";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Model country = await response.Content.ReadAsAsync<Model>();

                    return country.data.country;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<League>> LoadLeague()
        {
            string url = $"http://livescore-api.com/api-client/leagues/list.json?key=1OCIT6FNkAWmgIRp&secret=41WQJvxTJEY5uDkvrWdk3T7nt4KKNB9S";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Model league = await response.Content.ReadAsAsync<Model>();

                    return league.data.league;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<Match>> LoadLive()
        {
            string url = $"http://livescore-api.com/api-client/scores/live.json?key=1OCIT6FNkAWmgIRp&secret=41WQJvxTJEY5uDkvrWdk3T7nt4KKNB9S";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Model match = await response.Content.ReadAsAsync<Model>();

                    return match.data.match;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<Fixture>> LoadFixture(int pageNo)
        {

            string url = $"http://livescore-api.com/api-client/fixtures/matches.json?key=1OCIT6FNkAWmgIRp&secret=41WQJvxTJEY5uDkvrWdk3T7nt4KKNB9S&date=2019-10-05&page={pageNo}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Model fixture = await response.Content.ReadAsAsync<Model>();

                    return fixture.data.fixtures;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
