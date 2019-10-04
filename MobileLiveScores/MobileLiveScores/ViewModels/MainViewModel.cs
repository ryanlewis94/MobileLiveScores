using MobileLiveScores.Classes;
using MobileLiveScores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileLiveScores.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IFootball repository;

        #region Properties

        private List<Country> _countryList;
        public List<Country> CountryList
        {
            get { return _countryList; }
            set { SetProperty(ref _countryList, value); }
        }

        private List<Country> _sortCountryList;
        public List<Country> SortCountryList
        {
            get { return _sortCountryList; }
            set { SetProperty(ref _sortCountryList, value); }
        }

        private List<League> _allLeagueList;
        public List<League> AllLeagueList
        {
            get { return _allLeagueList; }
            set { SetProperty(ref _allLeagueList, value); }
        }

        private List<Match> _matchList;
        public List<Match> MatchList
        {
            get { return _matchList; }
            set { SetProperty(ref _matchList, value); }
        }

        private List<Fixture> _fixtureList;
        public List<Fixture> FixtureList
        {
            get { return _fixtureList; }
            set { SetProperty(ref _fixtureList, value); }
        }

        private List<Fixture> _fixturePageList;
        public List<Fixture> FixturePageList
        {
            get { return _fixturePageList; }
            set { SetProperty(ref _fixturePageList, value); }
        }

        //private Country _selectedCountry;
        //public Country SelectedCountry
        //{
        //    get { return _selectedCountry; }
        //    set
        //    {
        //        SetProperty(ref _selectedCountry, value);
        //        CountrySelected();
        //    }
        //}

        #endregion

        public MainViewModel()
        {
            repository = new Football();
            LoadCountries();
        }

        private async void LoadCountries()
        {
            CountryList = await repository.LoadCountry();
            AllLeagueList = await repository.LoadLeague();
            MatchList = await repository.LoadLive();

            int i = 0;
            FixturePageList = new List<Fixture>();
            do
            {
                i = i + 1;

                FixtureList = await repository.LoadFixture(i);
                FixturePageList = FixturePageList.Concat(FixtureList).ToList();

            } while (FixtureList.Count == 30);
            FixtureList = FixturePageList;
            Console.WriteLine(FixtureList.Count);

            CreateGroupedList();
        }

        private void CreateGroupedList()
        {
            SortCountryList = new List<Country>();

            foreach (Country country in CountryList)
            {
                country.leagueList = new List<League>();
                foreach (League league in AllLeagueList)
                {
                    league.matchList = new List<Match>();
                    league.fixtureList = new List<Fixture>();
                    if (country.id == league.country_id)
                    {
                        foreach (Match match in MatchList)
                        {
                            if (league.id.ToString() == match.league_id)
                            {
                                league.matchList.Add(match);
                            }
                        }
                        foreach (Fixture fixture in FixtureList)
                        {
                            if (league.id.ToString() == fixture.league_id)
                            {
                                league.fixtureList.Add(fixture);
                            }
                        }
                        if (league.matchList.Count != 0 || league.fixtureList.Count != 0)
                        {
                            country.leagueList.Add(league);
                        }
                    }
                }
                if (country.leagueList.Count != 0)
                {
                    country.leagueList = country.leagueList.OrderBy(l => l.id).ToList();
                    country.rowHeight = country.leagueList.Count * 100;
                    SortCountryList.Add(country);
                }
            }
            CountryList = SortCountryList;
            CountryList = CountryList.OrderByDescending(c => c.leagueList.Count).ToList();
        }

        //private void CountrySelected()
        //{
        //    if (SelectedCountry != null)
        //    {
        //        Console.WriteLine(SelectedCountry.name);
        //    }
              
        //}
    }
}
