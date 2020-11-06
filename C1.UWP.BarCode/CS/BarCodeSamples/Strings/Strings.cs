using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace BarCodeSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("BarCodeSamplesLib/Resources");

        public static string BarCodeSamplesDescription
        {
            get
            {
                return _loader.GetString("BarCodeSamplesDescription");
            }
        }

        public static string BarCodeSamplesName
        {
            get
            {
                return _loader.GetString("BarCodeSamplesName");
            }
        }

        public static string BarCodeSamplesTitle
        {
            get
            {
                return _loader.GetString("BarCodeSamplesTitle");
            }
        }

        public static string SessionStateErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateErrorMessage");
            }
        }

        public static string SessionStateKeyErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateKeyErrorMessage");
            }
        }

        public static string SuspensionManagerErrorMessage
        {
            get
            {
                return _loader.GetString("SuspensionManagerErrorMessage");
            }
        }

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }

        public static string UrlInitialValue
        {
            get
            {
                return _loader.GetString("UrlInitialValue");
            }
        }

        public static string TextInitialValue
        {
            get
            {
                return _loader.GetString("TextInitialValue");
            }
        }

        public static string EmailAddressInitialValue
        {
            get
            {
                return _loader.GetString("EmailAddressInitialValue");
            }
        }

        public static string VCardPrefixInitialValue
        {
            get
            {
                return _loader.GetString("VCardPrefixInitialValue");
            }
        }

        public static string VCardFirstNameInitialValue
        {
            get
            {
                return _loader.GetString("VCardFirstNameInitialValue");
            }
        }

        public static string VCardLastNameInitialValue
        {
            get
            {
                return _loader.GetString("VCardLastNameInitialValue");
            }
        }

        public static string VCardHomeCountryInitialValue
        {
            get
            {
                return _loader.GetString("VCardHomeCountryInitialValue");
            }
        }

        public static string VCardFullNameSuffixInitialValue
        {
            get
            {
                return _loader.GetString("VCardFullNameSuffixInitialValue");
            }
        }

        public static string VCardSuffixInitialValue
        {
            get
            {
                return _loader.GetString("VCardSuffixInitialValue");
            }
        }

        public static string VCardTitleInitialValue
        {
            get
            {
                return _loader.GetString("VCardTitleInitialValue");
            }
        }

        public static string VCardRoleInitialValue
        {
            get
            {
                return _loader.GetString("VCardRoleInitialValue");
            }
        }

        public static string VCardNicknameInitialValue
        {
            get
            {
                return _loader.GetString("VCardNicknameInitialValue");
            }
        }

        public static string EmailCaptionValue
        {
            get
            {
                return _loader.GetString("EmailCaptionValue");
            }
        }

        public static string UrlCaptionValue
        {
            get
            {
                return _loader.GetString("UrlCaptionValue");
            }
        }

        public static string TextCaptionValue
        {
            get
            {
                return _loader.GetString("TextCaptionValue");
            }
        }

        public static string VcardPrefixCaptionValue
        {
            get
            {
                return _loader.GetString("VcardPrefixCaptionValue");
            }
        }

        public static string VcardFirstNameCaptionValue
        {
            get
            {
                return _loader.GetString("VcardFirstNameCaptionValue");
            }
        }

        public static string VcardLastNameCaptionValue
        {
            get
            {
                return _loader.GetString("VcardLastNameCaptionValue");
            }
        }

        public static string VcardSuffixCaptionValue
        {
            get
            {
                return _loader.GetString("VcardSuffixCaptionValue");
            }
        }

        public static string VcardFullNameCaptionValue
        {
            get
            {
                return _loader.GetString("VcardFullNameCaptionValue");
            }
        }

        public static string VcardNicknameCaptionValue
        {
            get
            {
                return _loader.GetString("VcardNicknameCaptionValue");
            }
        }

        public static string VcardPhotoCaptionValue
        {
            get
            {
                return _loader.GetString("VcardPhotoCaptionValue");
            }
        }

        public static string VcardTitleCaptionValue
        {
            get
            {
                return _loader.GetString("VcardTitleCaptionValue");
            }
        }

        public static string VcardRoleCaptionValue
        {
            get
            {
                return _loader.GetString("VcardRoleCaptionValue");
            }
        }

        public static string VcardOrganizationCaptionValue
        {
            get
            {
                return _loader.GetString("VcardOrganizationCaptionValue");
            }
        }

        public static string VcardLogoCaptionValue
        {
            get
            {
                return _loader.GetString("VcardLogoCaptionValue");
            }
        }

        public static string VcardHomeAddressCaptionValue
        {
            get
            {
                return _loader.GetString("VcardHomeAddressCaptionValue");
            }
        }

        public static string VcardHomeCityCaptionValue
        {
            get
            {
                return _loader.GetString("VcardHomeCityCaptionValue");
            }
        }

        public static string VcardHomeStateCaptionValue
        {
            get
            {
                return _loader.GetString("VcardHomeStateCaptionValue");
            }
        }

        public static string VcardHomeZipCaptionValue
        {
            get
            {
                return _loader.GetString("VcardHomeZipCaptionValue");
            }
        }

        public static string VcardHomeCountryCaptionValue
        {
            get
            {
                return _loader.GetString("VcardHomeCountryCaptionValue");
            }
        }

        public static string VcardOfficeAddressCaptionValue
        {
            get
            {
                return _loader.GetString("VcardOfficeAddressCaptionValue");
            }
        }

        public static string VcardOfficeCityCaptionValue
        {
            get
            {
                return _loader.GetString("VcardOfficeCityCaptionValue");
            }
        }

        public static string VcardOfficeStateCaptionValue
        {
            get
            {
                return _loader.GetString("VcardOfficeStateCaptionValue");
            }
        }

        public static string VcardOfficeZipCaptionValue
        {
            get
            {
                return _loader.GetString("VcardOfficeZipCaptionValue");
            }
        }

        public static string VcardOfficeCountryCaptionValue
        {
            get
            {
                return _loader.GetString("VcardOfficeCountryCaptionValue");
            }
        }

        public static string VcardHomePhoneCaptionValue
        {
            get
            {
                return _loader.GetString("VcardHomePhoneCaptionValue");
            }
        }

        public static string VcardOfficePhoneCaptionValue
        {
            get
            {
                return _loader.GetString("VcardOfficePhoneCaptionValue");
            }
        }

        public static string VcardFaxCaptionValue
        {
            get
            {
                return _loader.GetString("VcardFaxCaptionValue");
            }
        }

        public static string VcardCellCaptionValue
        {
            get
            {
                return _loader.GetString("VcardCellCaptionValue");
            }
        }

        public static string VcardEmailCaptionValue
        {
            get
            {
                return _loader.GetString("VcardEmailCaptionValue");
            }
        }

        public static string VcardWebsiteCaptionValue
        {
            get
            {
                return _loader.GetString("VcardWebsiteCaptionValue");
            }
        }

        public static string StringPrefix
        {
            get
            {
                return _loader.GetString("StringPrefix");
            }
        }

        public static string StringFirstName
        {
            get
            {
                return _loader.GetString("StringFirstName");
            }
        }

        public static string StringLastName
        {
            get
            {
                return _loader.GetString("StringLastName");
            }
        }

        public static string StringSuffix
        {
            get
            {
                return _loader.GetString("StringSuffix");
            }
        }

        public static string StringFullName
        {
            get
            {
                return _loader.GetString("StringFullName");
            }
        }

        public static string StringNickname
        {
            get
            {
                return _loader.GetString("StringNickname");
            }
        }

        public static string StringPhoto
        {
            get
            {
                return _loader.GetString("StringPhoto");
            }
        }

        public static string StringTitle
        {
            get
            {
                return _loader.GetString("StringTitle");
            }
        }

        public static string StringRole
        {
            get
            {
                return _loader.GetString("StringRole");
            }
        }

        public static string StringOrganization
        {
            get
            {
                return _loader.GetString("StringOrganization");
            }
        }

        public static string StringLogo
        {
            get
            {
                return _loader.GetString("StringLogo");
            }
        }

        public static string StringHomeAddress
        {
            get
            {
                return _loader.GetString("StringHomeAddress");
            }
        }

        public static string StringHomeCity
        {
            get
            {
                return _loader.GetString("StringHomeCity");
            }
        }

        public static string StringHomeState
        {
            get
            {
                return _loader.GetString("StringHomeState");
            }
        }

        public static string StringHomeZip
        {
            get
            {
                return _loader.GetString("StringHomeZip");
            }
        }

        public static string StringHomeCountry
        {
            get
            {
                return _loader.GetString("StringHomeCountry");
            }
        }

        public static string StringOfficeAddress
        {
            get
            {
                return _loader.GetString("StringOfficeAddress");
            }
        }

        public static string StringOfficeCity
        {
            get
            {
                return _loader.GetString("StringOfficeCity");
            }
        }

        public static string StringOfficeState
        {
            get
            {
                return _loader.GetString("StringOfficeState");
            }
        }

        public static string StringOfficeZip
        {
            get
            {
                return _loader.GetString("StringOfficeZip");
            }
        }

        public static string StringOfficeCountry
        {
            get
            {
                return _loader.GetString("StringOfficeCountry");
            }
        }

        public static string StringHomePhone
        {
            get
            {
                return _loader.GetString("StringHomePhone");
            }
        }

        public static string StringOfficePhone
        {
            get
            {
                return _loader.GetString("StringOfficePhone");
            }
        }

        public static string StringFax
        {
            get
            {
                return _loader.GetString("StringFax");
            }
        }

        public static string StringCell
        {
            get
            {
                return _loader.GetString("StringCell");
            }
        }

        public static string StringEmail
        {
            get
            {
                return _loader.GetString("StringEmail");
            }
        }

        public static string StringWebsite
        {
            get
            {
                return _loader.GetString("StringWebsite");
            }
        }

        public static string EmailMark
        {
            get
            {
                return _loader.GetString("EmailMark");
            }
        }

        public static string TextMark
        {
            get
            {
                return _loader.GetString("TextMark");
            }
        }

        public static string UrlMark
        {
            get
            {
                return _loader.GetString("UrlMark");
            }
        }

        public static string VCardMark
        {
            get
            {
                return _loader.GetString("VCardMark");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string BarCode_Text
        {
            get
            {
                return _loader.GetString("BarCode_Text");
            }
        }

        public static string BarCodeImage_Text
        {
            get
            {
                return _loader.GetString("BarCodeImage_Text");
            }
        }

        public static string Generate_Content
        {
            get
            {
                return _loader.GetString("Generate_Content");
            }
        }

        public static string SaveImage_Content
        {
            get
            {
                return _loader.GetString("SaveImage_Content");
            }
        }

        public static string BarcodeType_Text
        {
            get
            {
                return _loader.GetString("BarcodeType_Text");
            }
        }

        public static string BarcodeText_Text
        {
            get
            {
                return _loader.GetString("BarcodeText_Text");
            }
        }

        public static string EmptyDataError
        {
            get
            {
                return _loader.GetString("EmptyDataError");
            }
        }

        public static string NewBarCodeSamplesTitle
        {
            get
            {
                return _loader.GetString("NewBarCodeSamplesTitle");
            }
        }

        public static string NewBarCodeSamplesName
        {
            get
            {
                return _loader.GetString("NewBarCodeSamplesName");
            }
        }

        public static string NewBarCodeSamplesDescription
        {
            get
            {
                return _loader.GetString("NewBarCodeSamplesDescription");
            }
        }
    }
}
