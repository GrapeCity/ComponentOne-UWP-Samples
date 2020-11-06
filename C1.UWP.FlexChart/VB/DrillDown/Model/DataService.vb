Public Class DataService
    Private rnd As New Random()
    Shared _default As DataService


    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance() As DataService
        Get
            If _default Is Nothing Then
                _default = New DataService()
            End If

            Return _default
        End Get
    End Property

    Public Function GetSunburstData() As List(Of DataItem)
        Dim list = New List(Of DataItem)()
        Dim years As New List(Of String)()
        Dim times As New List(Of List(Of String))() From {
            New List(Of String)() From {
                "Jan",
                "Feb",
                "Mar"
            },
            New List(Of String)() From {
                "Apr",
                "May",
                "June"
            },
            New List(Of String)() From {
                "Jul",
                "Aug",
                "Sep"
            },
            New List(Of String)() From {
                "Oct",
                "Nov",
                "Dec"
            }
        }

        Dim yearLen = Math.Max(CInt(Math.Round(Math.Abs(5 - Instance.rnd.NextDouble() * 10))), 3)
        Dim currentYear As Integer = DateTime.Now.Year
        For i As Integer = yearLen To 1 Step -1
            years.Add((currentYear - i).ToString())
        Next
        Dim quarterAdded = False

        years.ForEach(Function(y)
                          Dim i = years.IndexOf(y)
                          Dim addQuarter = Instance.rnd.NextDouble() > 0.5
                          If Not quarterAdded AndAlso i = years.Count - 1 Then
                              addQuarter = True
                          End If
                          Dim year = New DataItem() With {
                              .Year = y
                          }
                          If addQuarter Then
                              quarterAdded = True
                              times.ForEach(Function(q)
                                                Dim addMonth = Instance.rnd.NextDouble() > 0.5
                                                Dim idx As Integer = times.IndexOf(q)
                                                Dim quar = "Q" & (idx + 1)
                                                Dim quarters = New DataItem() With {
                                                    .Year = y,
                                                    .Quarter = quar
                                                }
                                                If addMonth Then
                                                    q.ForEach(Function(m)
                                                                  quarters.Items.Add(New DataItem() With {
                                                                      .Year = y,
                                                                      .Quarter = quar,
                                                                      .Month = m,
                                                                      .Value = rnd.Next(20, 30)
                                                                  })

                                                              End Function)
                                                Else
                                                    quarters.Value = rnd.Next(80, 100)
                                                End If
                                                year.Items.Add(quarters)

                                            End Function)
                          Else
                              year.Value = rnd.Next(80, 100)
                          End If
                          list.Add(year)

                      End Function)

        Return list
    End Function

    Public Function GetData(count As Integer) As List(Of Item)
        Dim data As New List(Of Item)()
        Dim countries = "US,Germany,UK,Japan,Italy,Greece".Split(",")
        Dim years = New Integer() {2010, 2011, 2012, 2013, 2014}
        Dim countriesLen = countries.Length
        Dim citiesByCountry = New Dictionary(Of String, String())()
        citiesByCountry.Add("US", New String() {"New York", "Los Angeles", "Chicago", "Phoenix", "Dallas"})
        citiesByCountry.Add("Germany", New String() {"Berlin", "Hamburg", "Munich", "Cologne", "Frankfurt"})
        citiesByCountry.Add("UK", New String() {"London", "Birmingham", "Leeds", "Glasgow", "Sheffield"})
        citiesByCountry.Add("Japan", New String() {"Tokyo", "Kanagawa", "Osaka", "Aichi", "Hokkaido"})
        citiesByCountry.Add("Italy", New String() {"Rome", "Milan", "Naples", "Turin", "Palermo"})
        citiesByCountry.Add("Greece", New String() {"Athens", "Thessaloniki", "Patras", "Heraklion", "Larissa"})
        For i As Integer = 0 To count - 1
            Dim yearIndex = rnd.Next(0, 5)
            Dim cityIndex = rnd.Next(0, 5)
            Dim countryIndex As Integer = i Mod countriesLen
            Dim country = countries(countryIndex)
            data.Add(New Item() With {
                .ID = i,
                .Country = country,
                .City = citiesByCountry(country)(cityIndex),
                .Year = years(yearIndex).ToString(),
                .Month = (i Mod 12 + 1).ToString(),
                .Day = (i Mod 27 + 1).ToString(),
                .Amount = Math.Floor(rnd.NextDouble() * 10000)
            })
        Next

        Return data
    End Function

    Private Function Rand() As Integer
        Return rnd.Next(10, 100)
    End Function
    Public Function GetTreemapData() As Leaf()
        Dim data = New Leaf() {New Leaf() With {
           .Type = "Music",
           .Items = New Leaf() {New Leaf() With {
                .Type = "Country",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Classic Country",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Cowboy Country",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Outlaw Country",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Western Swing",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Roadhouse Country",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Rock",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Hard Rock",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Blues Rock",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Funk Rock",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Rap Rock",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Guitar Rock",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Progressive Rock",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Classical",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Symphonies",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Chamber Music",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Soundtracks",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Movie Soundtracks",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Musical Soundtracks",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Jazz",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Smooth Jazz",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Vocal Jazz",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Jazz Fusion",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Swing Jazz",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Cool Jazz",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Traditional Jazz",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Electronic",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Electronica",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Disco",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "House",
                    .Sales = Rand()
                }}
            }}
        }, New Leaf() With {
            .Type = "Video",
            .Items = New Leaf() {New Leaf() With {
                .Type = "Movie",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Kid & Family",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Action & Adventure",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Animation",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Comedy",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Drama",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Romance",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "TV",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Science Fiction",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Documentary",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Fantasy",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Military & War",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Horror",
                    .Sales = Rand()
                }}
            }}
        }, New Leaf() With {
            .Type = "Books",
            .Items = New Leaf() {New Leaf() With {
                .Type = "Arts & Photography",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Architecture",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Graphic Design",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Drawing",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Photography",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Performing Arts",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Children's Books",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Beginning Readers",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Board Books",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Chapter Books",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Coloring Books",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Picture Books",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Sound Books",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "History",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Ancient",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Medieval",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Renaissance",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Mystery",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Mystery",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Thriller & Suspense",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Romance",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Action & Adventure",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Holidays",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Romantic Comedy",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Romantic Suspense",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Western",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Historical",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Sci-Fi & Fantasy",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Fantasy",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Gaming",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Science Fiction",
                    .Sales = Rand()
                }}
            }}
        }, New Leaf() With {
            .Type = "Electronics",
            .Items = New Leaf() {New Leaf() With {
                .Type = "Camera",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Digital Cameras",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Film Photography",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Lenses",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Video",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Accessories",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Headphones",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Earbud headphones",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Over-ear headphones",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "On-ear headphones",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Bluetooth headphones",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Noise-cancelling headphones",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Audiophile headphones",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Cell Phones",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Cell Phones",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Accessories",
                    .Items = New Leaf() {New Leaf() With {
                        .Type = "Batteries",
                        .Sales = Rand()
                    }, New Leaf() With {
                        .Type = "Bluetooth Headsets",
                        .Sales = Rand()
                    }, New Leaf() With {
                        .Type = "Bluetooth Speakers",
                        .Sales = Rand()
                    }, New Leaf() With {
                        .Type = "Chargers",
                        .Sales = Rand()
                    }, New Leaf() With {
                        .Type = "Screen Protectors",
                        .Sales = Rand()
                    }}
                }}
            }, New Leaf() With {
                .Type = "Wearable Technology",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "Activity Trackers",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Smart Watches",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Sports & GPS Watches",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Virtual Reality Headsets",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Wearable Cameras",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Smart Glasses",
                    .Sales = Rand()
                }}
            }}
        }, New Leaf() With {
            .Type = "Computers & Tablets",
            .Items = New Leaf() {New Leaf() With {
                .Type = "Desktops",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "All-in-ones",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Minis",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Towers",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Laptops",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "2 in 1 laptops",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Traditional laptops",
                    .Sales = Rand()
                }}
            }, New Leaf() With {
                .Type = "Tablets",
                .Items = New Leaf() {New Leaf() With {
                    .Type = "iOS",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Andriod",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Fire os",
                    .Sales = Rand()
                }, New Leaf() With {
                    .Type = "Windows",
                    .Sales = Rand()
                }}
            }}
        }}
        Return data
    End Function
End Class