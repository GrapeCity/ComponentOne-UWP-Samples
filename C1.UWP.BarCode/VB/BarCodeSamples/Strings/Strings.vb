Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("BarCodeSamplesLib/Resources")

    Public Shared ReadOnly Property BarCodeSamplesDescription() As String
        Get
            Return _loader.GetString("BarCodeSamplesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BarCodeSamplesName() As String
        Get
            Return _loader.GetString("BarCodeSamplesName")
        End Get
    End Property

    Public Shared ReadOnly Property BarCodeSamplesTitle() As String
        Get
            Return _loader.GetString("BarCodeSamplesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property UrlInitialValue() As String
        Get
            Return _loader.GetString("UrlInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property TextInitialValue() As String
        Get
            Return _loader.GetString("TextInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property EmailAddressInitialValue() As String
        Get
            Return _loader.GetString("EmailAddressInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardPrefixInitialValue() As String
        Get
            Return _loader.GetString("VCardPrefixInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardFirstNameInitialValue() As String
        Get
            Return _loader.GetString("VCardFirstNameInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardLastNameInitialValue() As String
        Get
            Return _loader.GetString("VCardLastNameInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardHomeCountryInitialValue() As String
        Get
            Return _loader.GetString("VCardHomeCountryInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardFullNameSuffixInitialValue() As String
        Get
            Return _loader.GetString("VCardFullNameSuffixInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardSuffixInitialValue() As String
        Get
            Return _loader.GetString("VCardSuffixInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardTitleInitialValue() As String
        Get
            Return _loader.GetString("VCardTitleInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardRoleInitialValue() As String
        Get
            Return _loader.GetString("VCardRoleInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property VCardNicknameInitialValue() As String
        Get
            Return _loader.GetString("VCardNicknameInitialValue")
        End Get
    End Property

    Public Shared ReadOnly Property EmailCaptionValue() As String
        Get
            Return _loader.GetString("EmailCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property UrlCaptionValue() As String
        Get
            Return _loader.GetString("UrlCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property TextCaptionValue() As String
        Get
            Return _loader.GetString("TextCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardPrefixCaptionValue() As String
        Get
            Return _loader.GetString("VcardPrefixCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardFirstNameCaptionValue() As String
        Get
            Return _loader.GetString("VcardFirstNameCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardLastNameCaptionValue() As String
        Get
            Return _loader.GetString("VcardLastNameCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardSuffixCaptionValue() As String
        Get
            Return _loader.GetString("VcardSuffixCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardFullNameCaptionValue() As String
        Get
            Return _loader.GetString("VcardFullNameCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardNicknameCaptionValue() As String
        Get
            Return _loader.GetString("VcardNicknameCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardPhotoCaptionValue() As String
        Get
            Return _loader.GetString("VcardPhotoCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardTitleCaptionValue() As String
        Get
            Return _loader.GetString("VcardTitleCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardRoleCaptionValue() As String
        Get
            Return _loader.GetString("VcardRoleCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardOrganizationCaptionValue() As String
        Get
            Return _loader.GetString("VcardOrganizationCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardLogoCaptionValue() As String
        Get
            Return _loader.GetString("VcardLogoCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardHomeAddressCaptionValue() As String
        Get
            Return _loader.GetString("VcardHomeAddressCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardHomeCityCaptionValue() As String
        Get
            Return _loader.GetString("VcardHomeCityCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardHomeStateCaptionValue() As String
        Get
            Return _loader.GetString("VcardHomeStateCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardHomeZipCaptionValue() As String
        Get
            Return _loader.GetString("VcardHomeZipCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardHomeCountryCaptionValue() As String
        Get
            Return _loader.GetString("VcardHomeCountryCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardOfficeAddressCaptionValue() As String
        Get
            Return _loader.GetString("VcardOfficeAddressCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardOfficeCityCaptionValue() As String
        Get
            Return _loader.GetString("VcardOfficeCityCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardOfficeStateCaptionValue() As String
        Get
            Return _loader.GetString("VcardOfficeStateCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardOfficeZipCaptionValue() As String
        Get
            Return _loader.GetString("VcardOfficeZipCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardOfficeCountryCaptionValue() As String
        Get
            Return _loader.GetString("VcardOfficeCountryCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardHomePhoneCaptionValue() As String
        Get
            Return _loader.GetString("VcardHomePhoneCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardOfficePhoneCaptionValue() As String
        Get
            Return _loader.GetString("VcardOfficePhoneCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardFaxCaptionValue() As String
        Get
            Return _loader.GetString("VcardFaxCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardCellCaptionValue() As String
        Get
            Return _loader.GetString("VcardCellCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardEmailCaptionValue() As String
        Get
            Return _loader.GetString("VcardEmailCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property VcardWebsiteCaptionValue() As String
        Get
            Return _loader.GetString("VcardWebsiteCaptionValue")
        End Get
    End Property

    Public Shared ReadOnly Property StringPrefix() As String
        Get
            Return _loader.GetString("StringPrefix")
        End Get
    End Property

    Public Shared ReadOnly Property StringFirstName() As String
        Get
            Return _loader.GetString("StringFirstName")
        End Get
    End Property

    Public Shared ReadOnly Property StringLastName() As String
        Get
            Return _loader.GetString("StringLastName")
        End Get
    End Property

    Public Shared ReadOnly Property StringSuffix() As String
        Get
            Return _loader.GetString("StringSuffix")
        End Get
    End Property

    Public Shared ReadOnly Property StringFullName() As String
        Get
            Return _loader.GetString("StringFullName")
        End Get
    End Property

    Public Shared ReadOnly Property StringNickname() As String
        Get
            Return _loader.GetString("StringNickname")
        End Get
    End Property

    Public Shared ReadOnly Property StringPhoto() As String
        Get
            Return _loader.GetString("StringPhoto")
        End Get
    End Property

    Public Shared ReadOnly Property StringTitle() As String
        Get
            Return _loader.GetString("StringTitle")
        End Get
    End Property

    Public Shared ReadOnly Property StringRole() As String
        Get
            Return _loader.GetString("StringRole")
        End Get
    End Property

    Public Shared ReadOnly Property StringOrganization() As String
        Get
            Return _loader.GetString("StringOrganization")
        End Get
    End Property

    Public Shared ReadOnly Property StringLogo() As String
        Get
            Return _loader.GetString("StringLogo")
        End Get
    End Property

    Public Shared ReadOnly Property StringHomeAddress() As String
        Get
            Return _loader.GetString("StringHomeAddress")
        End Get
    End Property

    Public Shared ReadOnly Property StringHomeCity() As String
        Get
            Return _loader.GetString("StringHomeCity")
        End Get
    End Property

    Public Shared ReadOnly Property StringHomeState() As String
        Get
            Return _loader.GetString("StringHomeState")
        End Get
    End Property

    Public Shared ReadOnly Property StringHomeZip() As String
        Get
            Return _loader.GetString("StringHomeZip")
        End Get
    End Property

    Public Shared ReadOnly Property StringHomeCountry() As String
        Get
            Return _loader.GetString("StringHomeCountry")
        End Get
    End Property

    Public Shared ReadOnly Property StringOfficeAddress() As String
        Get
            Return _loader.GetString("StringOfficeAddress")
        End Get
    End Property

    Public Shared ReadOnly Property StringOfficeCity() As String
        Get
            Return _loader.GetString("StringOfficeCity")
        End Get
    End Property

    Public Shared ReadOnly Property StringOfficeState() As String
        Get
            Return _loader.GetString("StringOfficeState")
        End Get
    End Property

    Public Shared ReadOnly Property StringOfficeZip() As String
        Get
            Return _loader.GetString("StringOfficeZip")
        End Get
    End Property

    Public Shared ReadOnly Property StringOfficeCountry() As String
        Get
            Return _loader.GetString("StringOfficeCountry")
        End Get
    End Property

    Public Shared ReadOnly Property StringHomePhone() As String
        Get
            Return _loader.GetString("StringHomePhone")
        End Get
    End Property

    Public Shared ReadOnly Property StringOfficePhone() As String
        Get
            Return _loader.GetString("StringOfficePhone")
        End Get
    End Property

    Public Shared ReadOnly Property StringFax() As String
        Get
            Return _loader.GetString("StringFax")
        End Get
    End Property

    Public Shared ReadOnly Property StringCell() As String
        Get
            Return _loader.GetString("StringCell")
        End Get
    End Property

    Public Shared ReadOnly Property StringEmail() As String
        Get
            Return _loader.GetString("StringEmail")
        End Get
    End Property

    Public Shared ReadOnly Property StringWebsite() As String
        Get
            Return _loader.GetString("StringWebsite")
        End Get
    End Property

    Public Shared ReadOnly Property EmailMark() As String
        Get
            Return _loader.GetString("EmailMark")
        End Get
    End Property

    Public Shared ReadOnly Property TextMark() As String
        Get
            Return _loader.GetString("TextMark")
        End Get
    End Property

    Public Shared ReadOnly Property UrlMark() As String
        Get
            Return _loader.GetString("UrlMark")
        End Get
    End Property

    Public Shared ReadOnly Property VCardMark() As String
        Get
            Return _loader.GetString("VCardMark")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property BarCode_Text() As String
        Get
            Return _loader.GetString("BarCode_Text")
        End Get
    End Property

    Public Shared ReadOnly Property BarCodeImage_Text() As String
        Get
            Return _loader.GetString("BarCodeImage_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Generate_Content() As String
        Get
            Return _loader.GetString("Generate_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SaveImage_Content() As String
        Get
            Return _loader.GetString("SaveImage_Content")
        End Get
    End Property

    Public Shared ReadOnly Property BarcodeType_Text() As String
        Get
            Return _loader.GetString("BarcodeType_Text")
        End Get
    End Property

    Public Shared ReadOnly Property BarcodeText_Text() As String
        Get
            Return _loader.GetString("BarcodeText_Text")
        End Get
    End Property

    Public Shared ReadOnly Property EmptyDataError() As String
        Get
            Return _loader.GetString("EmptyDataError")
        End Get
    End Property


    Public Shared ReadOnly Property NewBarCodeSamplesTitle() As String
        Get
            Return _loader.GetString("NewBarCodeSamplesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property NewBarCodeSamplesName() As String
        Get
            Return _loader.GetString("NewBarCodeSamplesName")
        End Get
    End Property
    Public Shared ReadOnly Property NewBarCodeSamplesDescription() As String
        Get
            Return _loader.GetString("NewBarCodeSamplesDescription")
        End Get
    End Property
End Class