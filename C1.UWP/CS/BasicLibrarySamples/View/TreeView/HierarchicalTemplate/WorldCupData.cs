using System;
using System.Collections.Generic;
using System.Reflection;

namespace BasicLibrarySamples
{
    /// <summary>
    /// Represents a World Cup group
    /// </summary>
    public class WorldCupGroup
    {
        public string GroupName { get; set; }
        public List<WorldCupTeam> Teams { get; set; }


        public static IEnumerable<WorldCupGroup> Groups
        {
            get
            {
                // GROUP A
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupA,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "South Africa",
                            CountryName = Strings.SouthAfrica,
                            TopScorer = Strings.SouthAfricaTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Mexico",
                            CountryName = Strings.Mexico,
                            TopScorer = Strings.MexicoTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Uruguay",
                            CountryName = Strings.Uruguay,
                            TopScorer = Strings.UruguayTopScorerName,
                            WorldCupWon = 2
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "France",
                            CountryName = Strings.France,
                            TopScorer = Strings.FranceTopScorerName,
                            WorldCupWon = 1
                        },
                    }
                };

                // GROUP B
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupB,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "Argentina",
                            CountryName = Strings.Argentina,
                            TopScorer = Strings.ArgentinaTopScorerName,
                            WorldCupWon = 2
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Nigeria",
                            CountryName = Strings.Nigeria,
                            TopScorer = Strings.NigeriaTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Korea South",
                            CountryName = Strings.KoreaRepublic,
                            TopScorer = Strings.KoreaSouthTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Greece",
                            CountryName = Strings.Greece,
                            TopScorer = Strings.GreeceTopScorerName,
                            WorldCupWon = 0
                        },
                    }
                };

                // GROUP C
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupC,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "England",
                            CountryName = Strings.England,
                            TopScorer = Strings.EnglandTopScorerName,
                            WorldCupWon = 1
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "United States",
                            CountryName = Strings.USA,
                            TopScorer = Strings.UnitedStatesTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Algeria",
                            CountryName = Strings.Algeria,
                            TopScorer = Strings.AlgeriaTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Slovenia",
                            CountryName = Strings.Slovenia,
                            TopScorer = Strings.SloveniaTopScorerName,
                            WorldCupWon = 0
                        },
                    }
                };

                // GROUP D
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupD,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "Germany",
                            CountryName = Strings.Germany,
                            TopScorer = Strings.GermanyTopScorerName,
                            WorldCupWon = 3
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Australia",
                            CountryName = Strings.Australia,
                            TopScorer = Strings.AustraliaTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Serbia",
                            CountryName = Strings.Serbia,
                            TopScorer = Strings.SerbiaTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Ghana",
                            CountryName = Strings.Ghana,
                            TopScorer = Strings.GhanaTopScorerName,
                            WorldCupWon = 0
                        },
                    }
                };

                // GROUP E
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupE,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "Netherlands",
                            CountryName = Strings.NewZealand,
                            TopScorer = Strings.NetherlandsTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Denmark",
                            CountryName = Strings.Denmark,
                            TopScorer = Strings.DenmarkTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Japan",
                            CountryName = Strings.Japan,
                            TopScorer = Strings.JapanTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Cameroon",
                            CountryName = Strings.Cameroon,
                            TopScorer = Strings.CameroonTopScorerName,
                            WorldCupWon = 0
                        },
                    }
                };


                // GROUP F
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupF,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "Italy",
                            CountryName = Strings.Italy,
                            TopScorer = Strings.ItalyTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Paraguay",
                            CountryName = Strings.Paraguay,
                            TopScorer = Strings.ParaguayTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "NewZealand",
                            CountryName = Strings.NewZealand,
                            TopScorer = Strings.NewZealandTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Slovak Republic",
                            CountryName = Strings.Slovakia,
                            TopScorer = Strings.SlovakRepublicTopScorerName,
                            WorldCupWon = 0
                        },
                    }
                };

                // GROUP G
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupG,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "Brazil",
                            CountryName = Strings.Brazil,
                            TopScorer = Strings.BrazilTopScorerName,
                            WorldCupWon = 5
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Korea North",
                            CountryName = Strings.KoreaDPR,
                            TopScorer = Strings.KoreaNorthTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Cote Dlvoire",
                            CountryName = Strings.CoteDlvoire,
                            TopScorer = Strings.CoteDlvoireTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Portugal",
                            CountryName = Strings.Portugal,
                            TopScorer = Strings.PortugalTopScorerName,
                            WorldCupWon = 0
                        },
                    }
                };

                // GROUP H
                yield return new WorldCupGroup()
                {
                    GroupName = Strings.WorldCupGroupH,
                    Teams = new List<WorldCupTeam>() 
                    {
                        new WorldCupTeam() 
                        {
                            ShortName = "Spain",
                            CountryName = Strings.Spain,
                            TopScorer = Strings.SpainTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Switzerland",
                            CountryName = Strings.Switzerland,
                            TopScorer = Strings.SwitzerlandTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Honduras",
                            CountryName = Strings.Honduras,
                            TopScorer = Strings.HondurasTopScorerName,
                            WorldCupWon = 0
                        },
                        new WorldCupTeam()
                        {
                            ShortName = "Chile",
                            CountryName = Strings.Chile,
                            TopScorer = Strings.ChileTopScorerName,
                            WorldCupWon = 0
                        },
                    }
                };
            }
        }
    }

    public class WorldCupGroupList : List<WorldCupGroup> { }

    /// <summary>
    /// Represents a team
    /// </summary>
    public class WorldCupTeam
    {
        private string _shortName;

        public string ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                _shortName = value;
                FlagUri = string.Format("../../../Assets/country/{0}.png", _shortName);
            }
        }
        public string CountryName { get; set; }
        public string FlagUri { get; set; }
        public string TopScorer { get; set; }
        public int WorldCupWon { get; set; }
    }
}
