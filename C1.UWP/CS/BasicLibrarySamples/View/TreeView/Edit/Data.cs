using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace BasicLibrarySamples
{
    public class Data
    {
        public static List<CompanyItem> LoadData(Uri baseUri)
        {
            List<CompanyItem> data = new List<CompanyItem>()
            {
                new CompanyItem()
                {
                    Name = Strings.CouncilOfDirectors,
                    Icon = new Uri(baseUri, "../../../Assets/company/group.png"),
                    Children = new List<CompanyItem>()
                    {
                        new CompanyItem()
                        {
                            Name = Strings.Principal + " "+ Strings.AlexVera,
                            Icon = new Uri(baseUri, "../../../Assets/company/director.png"),
                            Children = new List<CompanyItem>()
                            {
                                new CompanyItem()
                                {
                                    Name = Strings.FinanceAdmin + " " + Strings.BrunoMaxtor,
                                    Icon = new Uri(baseUri, "../../../Assets/company/manager.png"),
                                    Children = new List<CompanyItem>()
                                    {
                                        new CompanyItem()
                                        {
                                            Name = Strings.FinanceOffice,
                                            Icon = new Uri(baseUri, "../../../Assets/company/group.png"),
                                            Children = new List<CompanyItem>()
                                            {
                                                new CompanyItem()
                                                {
                                                    Name = Strings.Manager + " " + Strings.BrunoGates,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    Children = new List<CompanyItem>() {}
                                                },
                                                new CompanyItem()
                                                {
                                                    Name = Strings.AssistantManager + " " + Strings.MichaelVera,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    Children = new List<CompanyItem>() {}
                                                }
                                            }
                                        },
                                        new CompanyItem()
                                        {
                                            Name = Strings.LegalAndProperty,
                                            Icon = new Uri(baseUri, "../../../Assets/company/group.png"),
                                            Children = new List<CompanyItem>()
                                            {
                                                 new CompanyItem()
                                                {
                                                    Name = Strings.Manager + " " + Strings.NoelaJohnson,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    Children = new List<CompanyItem>() {}
                                                },
                                                new CompanyItem()
                                                {
                                                    Name = Strings.AssistantManager + " " + Strings.MartinDay,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    Children = new List<CompanyItem>() {}
                                                }
                                            }
                                        },
                                        new CompanyItem()
                                        {
                                            Name = Strings.TravelOffice,
                                            Icon = new Uri(baseUri, "../../../Assets/company/group.png"),
                                            Children = new List<CompanyItem>()
                                            {
                                                 new CompanyItem()
                                                {
                                                    Name = Strings.Manager + " " + Strings.LeonardJhonson,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    Children = new List<CompanyItem>() {}
                                                },
                                                new CompanyItem()
                                                {
                                                    Name = Strings.AssistantManager + " " + Strings.RodrigoBeckham,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    Children = new List<CompanyItem>() {}
                                                }
                                            }
                                        }
                                    }
                                },
                                new CompanyItem()
                                {
                                    Name = Strings.DeanOfStudents + " " + Strings.BenSmith,
                                    Icon = new Uri(baseUri, "../../../Assets/company/manager.png"),
                                    Children = new List<CompanyItem>()
                                    {
                                        new CompanyItem()
                                        {
                                            Name = Strings.AssistantDean + " " + Strings.MaxDays,
                                            Icon = new Uri(baseUri, "../../../Assets/company/assistant.png"),
                                            Children = new List<CompanyItem>() {}
                                        },
                                        new CompanyItem()
                                        {
                                            Name = Strings.Counselling,
                                            Icon = new Uri(baseUri, "../../../Assets/company/group.png"),
                                            Children = new List<CompanyItem>()
                                            {
                                                 new CompanyItem()
                                                {
                                                    Name = Strings.Counselor + " " +Strings.SheelaAlvarez,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    Children = new List<CompanyItem>() {}
                                                },
                                                new CompanyItem()
                                                {
                                                    Name = Strings.AssistantCounselor + " " + Strings.JohnMaxto,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    Children = new List<CompanyItem>() {}
                                                }
                                            }
                                        },
                                        new CompanyItem()
                                        {
                                            Name = Strings.StudentServices,
                                            Icon = new Uri(baseUri, "../../../Assets/company/group.png"),
                                            Children = new List<CompanyItem>()
                                            {
                                                 new CompanyItem()
                                                {
                                                    Name = Strings.Manager + " " + Strings.PeterMeredith,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/manager.png"),
                                                    Children = new List<CompanyItem>() {}
                                                },
                                                new CompanyItem()
                                                {
                                                    Name = Strings.AssistantManager + " " + Strings.JeanJobs,
                                                    Icon = new Uri(baseUri, "../../../Assets/company/assistant.png"),
                                                    Children = new List<CompanyItem>() {}
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return data;
        }
    }

    public class CompanyItem : INotifyPropertyChanged, IEditableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private string _previousName;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public Uri Icon { get; set; }
        public List<CompanyItem> Children { get; set; }

        public void BeginEdit()
        {
            _previousName = Name;
        }

        public void CancelEdit()
        {
            Name = _previousName;
        }

        public void EndEdit()
        {
            _previousName = null;
        }
    }

}
