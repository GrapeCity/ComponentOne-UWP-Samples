Imports System.Text
Imports System.Linq
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System

Class Entity
    Implements INotifyPropertyChanged
    Private _encodingText As String
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property EncodingText() As String
        Get
            Return _encodingText
        End Get
        Set
            _encodingText = Value
            OnPropertyChanged("EncodingText")
        End Set
    End Property

    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class

#Region "Email"
Class EmailEntity
    Inherits Entity
    Private _address As String = String.Empty
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set
            _address = Value
            EncodingText = ToString()
            OnPropertyChanged("Address")
        End Set
    End Property

    Public ReadOnly Property Caption() As String
        Get
            Return Strings.EmailCaptionValue
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _address
    End Function
End Class
#End Region

#Region "Url"
Class UrlEntity
    Inherits Entity
    Private _url As String = String.Empty
    Public Property Url() As String
        Get
            Return _url
        End Get
        Set
            _url = Value
            EncodingText = ToString()
            OnPropertyChanged("Url")
        End Set
    End Property

    Public ReadOnly Property Caption() As String
        Get
            Return Strings.UrlCaptionValue
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _url
    End Function
End Class
#End Region

#Region "Text"
Class TextEntity
    Inherits Entity
    Private _text As String = String.Empty
    Public Property Text() As String
        Get
            Return _text
        End Get
        Set
            _text = Value
            EncodingText = Value
            OnPropertyChanged("Text")
        End Set
    End Property

    Public ReadOnly Property Caption() As String
        Get
            Return Strings.TextCaptionValue
        End Get
    End Property
End Class
#End Region

#Region "VCard"
Class VCardEntity
    Inherits Entity
    Private _prefix As String
    Private _firstName As String
    Private _lastName As String
    Private _suffix As String
    Private _fullName As String
    Private _nickname As String
    Private _photo As String
    Private _title As String
    Private _role As String
    Private _organization As String
    Private _logo As String
    Private _homeAddress As String
    Private _homeCity As String
    Private _homeState As String
    Private _homeZip As String
    Private _homeCountry As String
    Private _officeAddress As String
    Private _officeCity As String
    Private _officeState As String
    Private _officeZip As String
    Private _officeCountry As String
    Private _homePhone As String
    Private _officePhone As String
    Private _fax As String
    Private _cell As String
    Private _email As String
    Private _website As String

    Public Property Prefix() As String
        Get
            Return _prefix
        End Get
        Set
            _prefix = Value
            EncodingText = ToString()
            OnPropertyChanged("Prefix")
        End Set
    End Property

    Public ReadOnly Property PrefixCaption() As String
        Get
            Return Strings.VcardPrefixCaptionValue
        End Get
    End Property
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set
            _firstName = Value
            EncodingText = ToString()
            OnPropertyChanged("FirstName")
        End Set
    End Property

    Public ReadOnly Property FirstNameCaption() As String
        Get
            Return Strings.VcardFirstNameCaptionValue
        End Get
    End Property

    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set
            _lastName = Value
            EncodingText = ToString()
            OnPropertyChanged("LastName")
        End Set
    End Property

    Public ReadOnly Property LastNameCaption() As String
        Get
            Return Strings.VcardLastNameCaptionValue
        End Get
    End Property

    Public Property Suffix() As String
        Get
            Return _suffix
        End Get
        Set
            _suffix = Value
            EncodingText = ToString()
            OnPropertyChanged("Suffix")
        End Set
    End Property

    Public ReadOnly Property SuffixCaption() As String
        Get
            Return Strings.VcardSuffixCaptionValue
        End Get
    End Property

    Public Property FullName() As String
        Get
            Return _fullName
        End Get
        Set
            _fullName = Value
            EncodingText = ToString()
            OnPropertyChanged("FullName")
        End Set
    End Property

    Public ReadOnly Property FullNameCaption() As String
        Get
            Return Strings.VcardFullNameCaptionValue
        End Get
    End Property

    Public Property Nickname() As String
        Get
            Return _nickname
        End Get
        Set
            _nickname = Value
            EncodingText = ToString()
            OnPropertyChanged("Nickname")
        End Set
    End Property

    Public ReadOnly Property NicknameCaption() As String
        Get
            Return Strings.VcardNicknameCaptionValue
        End Get
    End Property
    Public Property Photo() As String
        Get
            Return _photo
        End Get
        Set
            _photo = Value
            EncodingText = ToString()
            OnPropertyChanged("Photo")
        End Set
    End Property

    Public ReadOnly Property PhotoCaption() As String
        Get
            Return Strings.VcardPhotoCaptionValue
        End Get
    End Property

    Public Property Title() As String
        Get
            Return _title
        End Get
        Set
            _title = Value
            EncodingText = ToString()
            OnPropertyChanged("Title")
        End Set
    End Property

    Public ReadOnly Property TitleCaption() As String
        Get
            Return Strings.VcardTitleCaptionValue
        End Get
    End Property

    Public Property Role() As String
        Get
            Return _role
        End Get
        Set
            _role = Value
            EncodingText = ToString()
            OnPropertyChanged("Role")
        End Set
    End Property

    Public ReadOnly Property RoleCaption() As String
        Get
            Return Strings.VcardRoleCaptionValue
        End Get
    End Property

    Public Property Organization() As String
        Get
            Return _organization
        End Get
        Set
            _organization = Value
            EncodingText = ToString()
            OnPropertyChanged("Organization")
        End Set
    End Property

    Public ReadOnly Property OrganizationCaption() As String
        Get
            Return Strings.VcardOrganizationCaptionValue
        End Get
    End Property

    Public Property Logo() As String
        Get
            Return _logo
        End Get
        Set
            _logo = Value
            EncodingText = ToString()
            OnPropertyChanged("Logo")
        End Set
    End Property

    Public ReadOnly Property LogoCaption() As String
        Get
            Return Strings.VcardLogoCaptionValue
        End Get
    End Property

    Public Property HomeAddress() As String
        Get
            Return _homeAddress
        End Get
        Set
            _homeAddress = Value
            EncodingText = ToString()
            OnPropertyChanged("HomeAddress")
        End Set
    End Property

    Public ReadOnly Property HomeAddressCaption() As String
        Get
            Return Strings.VcardHomeAddressCaptionValue
        End Get
    End Property

    Public Property HomeCity() As String
        Get
            Return _homeCity
        End Get
        Set
            _homeCity = Value
            EncodingText = ToString()
            OnPropertyChanged("HomeCity")
        End Set
    End Property

    Public ReadOnly Property HomeCityCaption() As String
        Get
            Return Strings.VcardHomeCityCaptionValue
        End Get
    End Property

    Public Property HomeState() As String
        Get
            Return _homeState
        End Get
        Set
            _homeState = Value
            EncodingText = ToString()
            OnPropertyChanged("HomeState")
        End Set
    End Property

    Public ReadOnly Property HomeStateCaption() As String
        Get
            Return Strings.VcardHomeStateCaptionValue
        End Get
    End Property

    Public Property HomeZip() As String
        Get
            Return _homeZip
        End Get
        Set
            _homeZip = Value
            EncodingText = ToString()
            OnPropertyChanged("HomeZip")
        End Set
    End Property

    Public ReadOnly Property HomeZipCaption() As String
        Get
            Return Strings.VcardHomeZipCaptionValue
        End Get
    End Property

    Public Property HomeCountry() As String
        Get
            Return _homeCountry
        End Get
        Set
            _homeCountry = Value
            EncodingText = ToString()
            OnPropertyChanged("HomeCountry")
        End Set
    End Property

    Public ReadOnly Property HomeCountryCaption() As String
        Get
            Return Strings.VcardHomeCountryCaptionValue
        End Get
    End Property

    Public Property OfficeAddress() As String
        Get
            Return _officeAddress
        End Get
        Set
            _officeAddress = Value
            EncodingText = ToString()
            OnPropertyChanged("OfficeAddress")
        End Set
    End Property

    Public ReadOnly Property OfficeAddressCaption() As String
        Get
            Return Strings.VcardOfficeAddressCaptionValue
        End Get
    End Property

    Public Property OfficeCity() As String
        Get
            Return _officeCity
        End Get
        Set
            _officeCity = Value
            EncodingText = ToString()
            OnPropertyChanged("OfficeCity")
        End Set
    End Property

    Public ReadOnly Property OfficeCityCaption() As String
        Get
            Return Strings.VcardOfficeCityCaptionValue
        End Get
    End Property

    Public Property OfficeState() As String
        Get
            Return _officeState
        End Get
        Set
            _officeState = Value
            EncodingText = ToString()
            OnPropertyChanged("OfficeState")
        End Set
    End Property

    Public ReadOnly Property OfficeStateCaption() As String
        Get
            Return Strings.VcardOfficeStateCaptionValue
        End Get
    End Property

    Public Property OfficeZip() As String
        Get
            Return _officeZip
        End Get
        Set
            _officeZip = Value
            EncodingText = ToString()
            OnPropertyChanged("OfficeZip")
        End Set
    End Property

    Public ReadOnly Property OfficeZipCaption() As String
        Get
            Return Strings.VcardOfficeZipCaptionValue
        End Get
    End Property

    Public Property OfficeCountry() As String
        Get
            Return _officeCountry
        End Get
        Set
            _officeCountry = Value
            EncodingText = ToString()
            OnPropertyChanged("OfficeCountry")
        End Set
    End Property

    Public ReadOnly Property OfficeCountryCaption() As String
        Get
            Return Strings.VcardOfficeCountryCaptionValue
        End Get
    End Property

    Public Property HomePhone() As String
        Get
            Return _homePhone
        End Get
        Set
            _homePhone = Value
            EncodingText = ToString()
            OnPropertyChanged("HomePhone")
        End Set
    End Property

    Public ReadOnly Property HomePhoneCaption() As String
        Get
            Return Strings.VcardHomePhoneCaptionValue
        End Get
    End Property

    Public Property OfficePhone() As String
        Get
            Return _officePhone
        End Get
        Set
            _officePhone = Value
            EncodingText = ToString()
            OnPropertyChanged("OfficePhone")
        End Set
    End Property

    Public ReadOnly Property OfficePhoneCaption() As String
        Get
            Return Strings.VcardOfficePhoneCaptionValue
        End Get
    End Property

    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set
            _fax = Value
            EncodingText = ToString()
            OnPropertyChanged("Fax")
        End Set
    End Property

    Public ReadOnly Property FaxCaption() As String
        Get
            Return Strings.VcardFaxCaptionValue
        End Get
    End Property

    Public Property Cell() As String
        Get
            Return _cell
        End Get
        Set
            _cell = Value
            EncodingText = ToString()
            OnPropertyChanged("Cell")
        End Set
    End Property

    Public ReadOnly Property CellCaption() As String
        Get
            Return Strings.VcardCellCaptionValue
        End Get
    End Property

    Public Property Email() As String
        Get
            Return _email
        End Get
        Set
            _email = Value
            EncodingText = ToString()
            OnPropertyChanged("Email")
        End Set
    End Property

    Public ReadOnly Property EmailCaption() As String
        Get
            Return Strings.VcardEmailCaptionValue
        End Get
    End Property

    Public Property Website() As String
        Get
            Return _website
        End Get
        Set
            _website = Value
            EncodingText = ToString()
            OnPropertyChanged("Website")
        End Set
    End Property

    Public ReadOnly Property WebsiteCaption() As String
        Get
            Return Strings.VcardWebsiteCaptionValue
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim str As String = String.Empty
        str = If(String.IsNullOrEmpty(Prefix), str, str + Strings.StringPrefix + Prefix + " ")
        str = If(String.IsNullOrEmpty(FirstName), str, str + Strings.StringFirstName + FirstName + " ")
        str = If(String.IsNullOrEmpty(LastName), str, str + Strings.StringLastName + LastName + " ")
        str = If(String.IsNullOrEmpty(Suffix), str, str + Strings.StringSuffix + Suffix + " ")
        str = If(String.IsNullOrEmpty(FullName), str, str + Strings.StringFullName + FullName + " ")
        str = If(String.IsNullOrEmpty(Nickname), str, str + Strings.StringNickname + Nickname + " ")
        str = If(String.IsNullOrEmpty(Photo), str, str + Strings.StringPhoto + Photo + " ")
        str = If(String.IsNullOrEmpty(Title), str, str + Strings.StringTitle + Title + " ")
        str = If(String.IsNullOrEmpty(Role), str, str + Strings.StringRole + Role + " ")
        str = If(String.IsNullOrEmpty(Organization), str, str + Strings.StringOrganization + Organization + " ")
        str = If(String.IsNullOrEmpty(Logo), str, str + Strings.StringLogo + Logo + " ")
        str = If(String.IsNullOrEmpty(HomeAddress), str, str + Strings.StringHomeAddress + HomeAddress + " ")
        str = If(String.IsNullOrEmpty(HomeCity), str, str + Strings.StringHomeCity + HomeCity + " ")
        str = If(String.IsNullOrEmpty(HomeState), str, str + Strings.StringHomeState + HomeState + " ")
        str = If(String.IsNullOrEmpty(HomeZip), str, str + Strings.StringHomeZip + HomeZip + " ")
        str = If(String.IsNullOrEmpty(HomeCountry), str, str + Strings.StringHomeCountry + HomeCountry + " ")
        str = If(String.IsNullOrEmpty(OfficeAddress), str, str + Strings.StringOfficeAddress + OfficeAddress + " ")
        str = If(String.IsNullOrEmpty(OfficeCity), str, str + Strings.StringOfficeCity + OfficeCity + " ")
        str = If(String.IsNullOrEmpty(OfficeState), str, str + Strings.StringOfficeState + OfficeState + " ")
        str = If(String.IsNullOrEmpty(OfficeZip), str, str + Strings.StringOfficeZip + OfficeZip + " ")
        str = If(String.IsNullOrEmpty(OfficeCountry), str, str + Strings.StringOfficeCountry + OfficeCountry + " ")
        str = If(String.IsNullOrEmpty(HomePhone), str, str + Strings.StringHomePhone + HomePhone + " ")
        str = If(String.IsNullOrEmpty(OfficePhone), str, str + Strings.StringOfficePhone + OfficePhone + " ")
        str = If(String.IsNullOrEmpty(Fax), str, str + Strings.StringFax + Fax + " ")
        str = If(String.IsNullOrEmpty(Cell), str, str + Strings.StringCell + Cell + " ")
        str = If(String.IsNullOrEmpty(Email), str, str + Strings.StringEmail + Email + " ")
        str = If(String.IsNullOrEmpty(Website), str, str + Strings.StringWebsite + Website + " ")

        Return str
    End Function
End Class
#End Region

Public Enum Format
    Email
    Url
    VCard
    Text
End Enum