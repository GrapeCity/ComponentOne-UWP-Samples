Imports Windows.UI.Xaml.Controls
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System

Public Class Data
    Public Shared Function LoadData(baseUri As Uri) As List(Of CompanyItem)
        Dim data As New List(Of CompanyItem)() From {
           New CompanyItem() With {
                    .Name = Strings.CouncilOfDirectors,
                    .Icon = New Uri(baseUri, "../../../Assets/company/group.png"),
                    .Children = New List(Of CompanyItem)() From {
                       New CompanyItem() With {
                            .Name = Strings.Principal + " " + Strings.AlexVera,
                            .Icon = New Uri(baseUri, "../../../Assets/company/director.png"),
                            .Children = New List(Of CompanyItem)() From {
                               New CompanyItem() With {
                                    .Name = Strings.FinanceAdmin + " " + Strings.BrunoMaxtor,
                                    .Icon = New Uri(baseUri, "../../../Assets/company/manager.png"),
                                    .Children = New List(Of CompanyItem)() From {
                                       New CompanyItem() With {
                                            .Name = Strings.FinanceOffice,
                                            .Icon = New Uri(baseUri, "../../../Assets/company/group.png"),
                                            .Children = New List(Of CompanyItem)() From {
                                               New CompanyItem() With {
                                                    .Name = Strings.Manager + " " + Strings.BrunoGates,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                },
                                                New CompanyItem() With {
                                                    .Name = Strings.AssistantManager + " " + Strings.MichaelVera,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                }
                                            }
                                        },
                                        New CompanyItem() With {
                                            .Name = Strings.LegalAndProperty,
                                            .Icon = New Uri(baseUri, "../../../Assets/company/group.png"),
                                            .Children = New List(Of CompanyItem)() From {
                                               New CompanyItem() With {
                                                    .Name = Strings.Manager + " " + Strings.NoelaJohnson,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                },
                                                New CompanyItem() With {
                                                    .Name = Strings.AssistantManager + " " + Strings.MartinDay,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                }
                                            }
                                        },
                                        New CompanyItem() With {
                                            .Name = Strings.TravelOffice,
                                            .Icon = New Uri(baseUri, "../../../Assets/company/group.png"),
                                            .Children = New List(Of CompanyItem)() From {
                                               New CompanyItem() With {
                                                    .Name = Strings.Manager + " " + Strings.LeonardJhonson,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                },
                                                New CompanyItem() With {
                                                    .Name = Strings.AssistantManager + " " + Strings.RodrigoBeckham,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                New CompanyItem() With {
                                    .Name = Strings.DeanOfStudents + " " + Strings.BenSmith,
                                    .Icon = New Uri(baseUri, "../../../Assets/company/manager.png"),
                                    .Children = New List(Of CompanyItem)() From {
                                        New CompanyItem() With {
                                            .Name = Strings.AssistantDean + " " + Strings.MaxDays,
                                            .Icon = New Uri(baseUri, "../../../Assets/company/assistant.png"),
                                            .Children = New List(Of CompanyItem)() From {
                                            }
                                        },
                                        New CompanyItem() With {
                                            .Name = Strings.Counselling,
                                            .Icon = New Uri(baseUri, "../../../Assets/company/group.png"),
                                            .Children = New List(Of CompanyItem)() From {
                                                New CompanyItem() With {
                                                    .Name = Strings.Counselor + " " + Strings.SheelaAlvarez,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                },
                                                New CompanyItem() With {
                                                    .Name = Strings.AssistantCounselor + " " + Strings.JohnMaxto,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                }
                                            }
                                        },
                                        New CompanyItem() With {
                                            .Name = Strings.StudentServices,
                                            .Icon = New Uri(baseUri, "../../../Assets/company/group.png"),
                                            .Children = New List(Of CompanyItem)() From {
                                                New CompanyItem() With {
                                                    .Name = Strings.Manager + " " + Strings.PeterMeredith,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                },
                                                New CompanyItem() With {
                                                    .Name = Strings.AssistantManager + " " + Strings.JeanJobs,
                                                    .Icon = New Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    .Children = New List(Of CompanyItem)() From {
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        Return data
    End Function
End Class

Public Class CompanyItem
    Implements INotifyPropertyChanged
    Implements IEditableObject
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _name As String
    Private _previousName As String

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set
            _name = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Name"))
        End Set
    End Property

    Public Property Icon() As Uri
    Public Property Children() As List(Of CompanyItem)

    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        _previousName = Name
    End Sub

    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        Name = _previousName
    End Sub

    Public Sub EndEdit() Implements IEditableObject.EndEdit
        _previousName = Nothing
    End Sub
End Class
