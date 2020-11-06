Imports System.Reflection
Imports System.Collections.Generic
Imports System

''' <summary>
''' Represents a World Cup group
''' </summary>
Public Class WorldCupGroup
    Public Property GroupName() As String
    Public Property Teams() As List(Of WorldCupTeam)


    Public Shared ReadOnly Iterator Property Groups() As IEnumerable(Of WorldCupGroup)
        Get
            ' GROUP A
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupA,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "South Africa", .CountryName = Strings.SouthAfrica, .TopScorer = Strings.SouthAfricaTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Mexico", .CountryName = Strings.Mexico, .TopScorer = Strings.MexicoTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Uruguay", .CountryName = Strings.Uruguay, .TopScorer = Strings.UruguayTopScorerName, .WorldCupWon = 2},
                New WorldCupTeam() With {.ShortName = "France", .CountryName = Strings.France, .TopScorer = Strings.FranceTopScorerName, .WorldCupWon = 1}
                }
            }
            ' GROUP B
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupB,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "Argentina", .CountryName = Strings.Argentina, .TopScorer = Strings.ArgentinaTopScorerName, .WorldCupWon = 2},
                New WorldCupTeam() With {.ShortName = "Nigeria", .CountryName = Strings.Nigeria, .TopScorer = Strings.NigeriaTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Korea South", .CountryName = Strings.KoreaRepublic, .TopScorer = Strings.KoreaSouthTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Greece", .CountryName = Strings.Greece, .TopScorer = Strings.GreeceTopScorerName, .WorldCupWon = 0}
                }
            }
            ' GROUP C
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupC,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "England", .CountryName = Strings.England, .TopScorer = Strings.EnglandTopScorerName, .WorldCupWon = 1},
                New WorldCupTeam() With {.ShortName = "United States", .CountryName = Strings.USA, .TopScorer = Strings.UnitedStatesTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Algeria", .CountryName = Strings.Algeria, .TopScorer = Strings.AlgeriaTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Slovenia", .CountryName = Strings.Slovenia, .TopScorer = Strings.SloveniaTopScorerName, .WorldCupWon = 0}
                }
            }
            ' GROUP D
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupD,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "Germany", .CountryName = Strings.Germany, .TopScorer = Strings.GermanyTopScorerName, .WorldCupWon = 3},
                New WorldCupTeam() With {.ShortName = "Australia", .CountryName = Strings.Australia, .TopScorer = Strings.AustraliaTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Serbia", .CountryName = Strings.Serbia, .TopScorer = Strings.SerbiaTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Ghana", .CountryName = Strings.Ghana, .TopScorer = Strings.GhanaTopScorerName, .WorldCupWon = 0}
                }
            }
            ' GROUP E
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupE,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "Netherlands", .CountryName = Strings.NewZealand, .TopScorer = Strings.NetherlandsTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Denmark", .CountryName = Strings.Denmark, .TopScorer = Strings.DenmarkTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Japan", .CountryName = Strings.Japan, .TopScorer = Strings.JapanTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Cameroon", .CountryName = Strings.Cameroon, .TopScorer = Strings.CameroonTopScorerName, .WorldCupWon = 0}
                }
            }
            ' GROUP F
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupF,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "Italy", .CountryName = Strings.Italy, .TopScorer = Strings.ItalyTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Paraguay", .CountryName = Strings.Paraguay, .TopScorer = Strings.ParaguayTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "NewZealand", .CountryName = Strings.NewZealand, .TopScorer = Strings.NewZealandTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Slovak Republic", .CountryName = Strings.Slovakia, .TopScorer = Strings.SlovakRepublicTopScorerName, .WorldCupWon = 0}
                }
            }

            ' GROUP G
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupG,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "Brazil", .CountryName = Strings.Brazil, .TopScorer = Strings.BrazilTopScorerName, .WorldCupWon = 5},
                New WorldCupTeam() With {.ShortName = "Korea North", .CountryName = Strings.KoreaDPR, .TopScorer = Strings.KoreaNorthTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Cote Dlvoire", .CountryName = Strings.CoteDlvoire, .TopScorer = Strings.CoteDlvoireTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Portugal", .CountryName = Strings.Portugal, .TopScorer = Strings.PortugalTopScorerName, .WorldCupWon = 0}
                }
            }

            ' GROUP H
            Yield New WorldCupGroup() With {.GroupName = Strings.WorldCupGroupH,
                .Teams = New List(Of WorldCupTeam)() From {
                New WorldCupTeam() With {.ShortName = "Spain", .CountryName = Strings.Spain, .TopScorer = Strings.SpainTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Switzerland", .CountryName = Strings.Switzerland, .TopScorer = Strings.SwitzerlandTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Honduras", .CountryName = Strings.Honduras, .TopScorer = Strings.HondurasTopScorerName, .WorldCupWon = 0},
                New WorldCupTeam() With {.ShortName = "Chile", .CountryName = Strings.Chile, .TopScorer = Strings.ChileTopScorerName, .WorldCupWon = 0}
                }
            }
        End Get
    End Property
End Class

Public Class WorldCupGroupList
    Inherits List(Of WorldCupGroup)
End Class

''' <summary>
''' Represents a team
''' </summary>
Public Class WorldCupTeam
    Private _shortName As String

    Public Property ShortName() As String
        Get
            Return _shortName
        End Get
        Set
            _shortName = Value
            FlagUri = String.Format("../../../Assets/country/{0}.png", _shortName)
        End Set
    End Property
    Public Property CountryName() As String
    Public Property FlagUri() As String
    Public Property TopScorer() As String
    Public Property WorldCupWon() As Integer
End Class