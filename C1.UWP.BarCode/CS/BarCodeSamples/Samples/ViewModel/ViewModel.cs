using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BarCodeSamples
{
    class Entity : INotifyPropertyChanged
    {
        private string _encodingText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EncodingText
        {
            get
            {
                return _encodingText;
            }
            set
            {
                _encodingText = value;
                OnPropertyChanged("EncodingText");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    #region Email
    class EmailEntity : Entity
    {
        private string _address = string.Empty;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                EncodingText = ToString();
                OnPropertyChanged("Address");
            }
        }

        public string Caption
        {
            get
            {
                return Strings.EmailCaptionValue;
            }
        }

        public override string ToString()
        {
            return _address;
        }
    }
    #endregion

    #region Url
    class UrlEntity : Entity
    {
        private string _url = string.Empty;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                EncodingText = ToString();
                OnPropertyChanged("Url");
            }
        }

        public string Caption
        {
            get
            {
                return Strings.UrlCaptionValue;
            }
        }

        public override string ToString()
        {
            return _url;
        }
    }
    #endregion

    #region Text
    class TextEntity : Entity
    {
        private string _text = string.Empty;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                EncodingText = value;
                OnPropertyChanged("Text");
            }
        }

        public string Caption
        {
            get
            {
                return Strings.TextCaptionValue;
            }
        }
    }
    #endregion

    #region VCard
    class VCardEntity : Entity
    {
        private string _prefix;
        private string _firstName;
        private string _lastName;
        private string _suffix;
        private string _fullName;
        private string _nickname;
        private string _photo;
        private string _title;
        private string _role;
        private string _organization;
        private string _logo;
        private string _homeAddress;
        private string _homeCity;
        private string _homeState;
        private string _homeZip;
        private string _homeCountry;
        private string _officeAddress;
        private string _officeCity;
        private string _officeState;
        private string _officeZip;
        private string _officeCountry;
        private string _homePhone;
        private string _officePhone;
        private string _fax;
        private string _cell;
        private string _email;
        private string _website;

        public string Prefix
        {
            get
            {
                return _prefix;
            }
            set
            {
                _prefix = value;
                EncodingText = ToString();
                OnPropertyChanged("Prefix");
            }
        }

        public string PrefixCaption
        {
            get
            {
                return Strings.VcardPrefixCaptionValue;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                EncodingText = ToString();
                OnPropertyChanged("FirstName");
            }
        }

        public string FirstNameCaption
        {
            get
            {
                return Strings.VcardFirstNameCaptionValue;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                EncodingText = ToString();
                OnPropertyChanged("LastName");
            }
        }

        public string LastNameCaption
        {
            get
            {
                return Strings.VcardLastNameCaptionValue;
            }
        }

        public string Suffix
        {
            get
            {
                return _suffix;
            }
            set
            {
                _suffix = value;
                EncodingText = ToString();
                OnPropertyChanged("Suffix");
            }
        }

        public string SuffixCaption
        {
            get
            {
                return Strings.VcardSuffixCaptionValue;
            }
        }

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                EncodingText = ToString();
                OnPropertyChanged("FullName");
            }
        }

        public string FullNameCaption
        {
            get
            {
                return Strings.VcardFullNameCaptionValue;
            }
        }

        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
                EncodingText = ToString();
                OnPropertyChanged("Nickname");
            }
        }

        public string NicknameCaption
        {
            get
            {
                return Strings.VcardNicknameCaptionValue;
            }
        }
        public string Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                EncodingText = ToString();
                OnPropertyChanged("Photo");
            }
        }

        public string PhotoCaption
        {
            get
            {
                return Strings.VcardPhotoCaptionValue;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                EncodingText = ToString();
                OnPropertyChanged("Title");
            }
        }

        public string TitleCaption
        {
            get
            {
                return Strings.VcardTitleCaptionValue;
            }
        }

        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                EncodingText = ToString();
                OnPropertyChanged("Role");
            }
        }

        public string RoleCaption
        {
            get
            {
                return Strings.VcardRoleCaptionValue;
            }
        }

        public string Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
                EncodingText = ToString();
                OnPropertyChanged("Organization");
            }
        }

        public string OrganizationCaption
        {
            get
            {
                return Strings.VcardOrganizationCaptionValue;
            }
        }

        public string Logo
        {
            get
            {
                return _logo;
            }
            set
            {
                _logo = value;
                EncodingText = ToString();
                OnPropertyChanged("Logo");
            }
        }

        public string LogoCaption
        {
            get
            {
                return Strings.VcardLogoCaptionValue;
            }
        }

        public string HomeAddress
        {
            get
            {
                return _homeAddress;
            }
            set
            {
                _homeAddress = value;
                EncodingText = ToString();
                OnPropertyChanged("HomeAddress");
            }
        }

        public string HomeAddressCaption
        {
            get
            {
                return Strings.VcardHomeAddressCaptionValue;
            }
        }

        public string HomeCity
        {
            get
            {
                return _homeCity;
            }
            set
            {
                _homeCity = value;
                EncodingText = ToString();
                OnPropertyChanged("HomeCity");
            }
        }

        public string HomeCityCaption
        {
            get
            {
                return Strings.VcardHomeCityCaptionValue;
            }
        }

        public string HomeState
        {
            get
            {
                return _homeState;
            }
            set
            {
                _homeState = value;
                EncodingText = ToString();
                OnPropertyChanged("HomeState");
            }
        }

        public string HomeStateCaption
        {
            get
            {
                return Strings.VcardHomeStateCaptionValue;
            }
        }

        public string HomeZip
        {
            get
            {
                return _homeZip;
            }
            set
            {
                _homeZip = value;
                EncodingText = ToString();
                OnPropertyChanged("HomeZip");
            }
        }

        public string HomeZipCaption
        {
            get
            {
                return Strings.VcardHomeZipCaptionValue;
            }
        }

        public string HomeCountry
        {
            get
            {
                return _homeCountry;
            }
            set
            {
                _homeCountry = value;
                EncodingText = ToString();
                OnPropertyChanged("HomeCountry");
            }
        }

        public string HomeCountryCaption
        {
            get
            {
                return Strings.VcardHomeCountryCaptionValue;
            }
        }

        public string OfficeAddress
        {
            get
            {
                return _officeAddress;
            }
            set
            {
                _officeAddress = value;
                EncodingText = ToString();
                OnPropertyChanged("OfficeAddress");
            }
        }

        public string OfficeAddressCaption
        {
            get
            {
                return Strings.VcardOfficeAddressCaptionValue;
            }
        }

        public string OfficeCity
        {
            get
            {
                return _officeCity;
            }
            set
            {
                _officeCity = value;
                EncodingText = ToString();
                OnPropertyChanged("OfficeCity");
            }
        }

        public string OfficeCityCaption
        {
            get
            {
                return Strings.VcardOfficeCityCaptionValue;
            }
        }

        public string OfficeState
        {
            get
            {
                return _officeState;
            }
            set
            {
                _officeState = value;
                EncodingText = ToString();
                OnPropertyChanged("OfficeState");
            }
        }

        public string OfficeStateCaption
        {
            get
            {
                return Strings.VcardOfficeStateCaptionValue;
            }
        }

        public string OfficeZip
        {
            get
            {
                return _officeZip;
            }
            set
            {
                _officeZip = value;
                EncodingText = ToString();
                OnPropertyChanged("OfficeZip");
            }
        }

        public string OfficeZipCaption
        {
            get
            {
                return Strings.VcardOfficeZipCaptionValue;
            }
        }

        public string OfficeCountry
        {
            get
            {
                return _officeCountry;
            }
            set
            {
                _officeCountry = value;
                EncodingText = ToString();
                OnPropertyChanged("OfficeCountry");
            }
        }

        public string OfficeCountryCaption
        {
            get
            {
                return Strings.VcardOfficeCountryCaptionValue;
            }
        }

        public string HomePhone
        {
            get
            {
                return _homePhone;
            }
            set
            {
                _homePhone = value;
                EncodingText = ToString();
                OnPropertyChanged("HomePhone");
            }
        }

        public string HomePhoneCaption
        {
            get
            {
                return Strings.VcardHomePhoneCaptionValue;
            }
        }

        public string OfficePhone
        {
            get
            {
                return _officePhone;
            }
            set
            {
                _officePhone = value;
                EncodingText = ToString();
                OnPropertyChanged("OfficePhone");
            }
        }

        public string OfficePhoneCaption
        {
            get
            {
                return Strings.VcardOfficePhoneCaptionValue;
            }
        }

        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                _fax = value;
                EncodingText = ToString();
                OnPropertyChanged("Fax");
            }
        }

        public string FaxCaption
        {
            get
            {
                return Strings.VcardFaxCaptionValue;
            }
        }

        public string Cell
        {
            get
            {
                return _cell;
            }
            set
            {
                _cell = value;
                EncodingText = ToString();
                OnPropertyChanged("Cell");
            }
        }

        public string CellCaption
        {
            get
            {
                return Strings.VcardCellCaptionValue;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                EncodingText = ToString();
                OnPropertyChanged("Email");
            }
        }

        public string EmailCaption
        {
            get
            {
                return Strings.VcardEmailCaptionValue;
            }
        }

        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
                EncodingText = ToString();
                OnPropertyChanged("Website");
            }
        }

        public string WebsiteCaption
        {
            get
            {
                return Strings.VcardWebsiteCaptionValue;
            }
        }

        public override string ToString()
        {
            string str = string.Empty;
            str = string.IsNullOrEmpty(Prefix) ? str : str + Strings.StringPrefix + Prefix + " ";
            str = string.IsNullOrEmpty(FirstName) ? str : str + Strings.StringFirstName + FirstName + " ";
            str = string.IsNullOrEmpty(LastName) ? str : str + Strings.StringLastName + LastName + " ";
            str = string.IsNullOrEmpty(Suffix) ? str : str + Strings.StringSuffix + Suffix + " ";
            str = string.IsNullOrEmpty(FullName) ? str : str + Strings.StringFullName + FullName + " ";
            str = string.IsNullOrEmpty(Nickname) ? str : str + Strings.StringNickname + Nickname + " ";
            str = string.IsNullOrEmpty(Photo) ? str : str + Strings.StringPhoto + Photo + " ";
            str = string.IsNullOrEmpty(Title) ? str : str + Strings.StringTitle + Title + " ";
            str = string.IsNullOrEmpty(Role) ? str : str + Strings.StringRole + Role + " ";
            str = string.IsNullOrEmpty(Organization) ? str : str + Strings.StringOrganization + Organization + " ";
            str = string.IsNullOrEmpty(Logo) ? str : str + Strings.StringLogo + Logo + " ";
            str = string.IsNullOrEmpty(HomeAddress) ? str : str + Strings.StringHomeAddress + HomeAddress + " ";
            str = string.IsNullOrEmpty(HomeCity) ? str : str + Strings.StringHomeCity + HomeCity + " ";
            str = string.IsNullOrEmpty(HomeState) ? str : str + Strings.StringHomeState + HomeState + " ";
            str = string.IsNullOrEmpty(HomeZip) ? str : str + Strings.StringHomeZip + HomeZip + " ";
            str = string.IsNullOrEmpty(HomeCountry) ? str : str + Strings.StringHomeCountry + HomeCountry + " ";
            str = string.IsNullOrEmpty(OfficeAddress) ? str : str + Strings.StringOfficeAddress + OfficeAddress + " ";
            str = string.IsNullOrEmpty(OfficeCity) ? str : str + Strings.StringOfficeCity + OfficeCity + " ";
            str = string.IsNullOrEmpty(OfficeState) ? str : str + Strings.StringOfficeState + OfficeState + " ";
            str = string.IsNullOrEmpty(OfficeZip) ? str : str + Strings.StringOfficeZip + OfficeZip + " ";
            str = string.IsNullOrEmpty(OfficeCountry) ? str : str + Strings.StringOfficeCountry + OfficeCountry + " ";
            str = string.IsNullOrEmpty(HomePhone) ? str : str + Strings.StringHomePhone + HomePhone + " ";
            str = string.IsNullOrEmpty(OfficePhone) ? str : str + Strings.StringOfficePhone + OfficePhone + " ";
            str = string.IsNullOrEmpty(Fax) ? str : str + Strings.StringFax + Fax + " ";
            str = string.IsNullOrEmpty(Cell) ? str : str + Strings.StringCell + Cell + " ";
            str = string.IsNullOrEmpty(Email) ? str : str + Strings.StringEmail + Email + " ";
            str = string.IsNullOrEmpty(Website) ? str : str + Strings.StringWebsite + Website + " ";

            return str;
        }
    }
    #endregion

    public enum Format
    {
        Email,
        Url,
        VCard,
        Text
    }
}
