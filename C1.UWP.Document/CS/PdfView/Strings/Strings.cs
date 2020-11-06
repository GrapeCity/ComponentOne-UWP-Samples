using System;
using Windows.ApplicationModel.Resources;
using System.Diagnostics;

namespace PdfView
{
    public class Strings
    {
        static ResourceLoader _loader;

        static Strings()
        {
            try
            {
                _loader = ResourceLoader.GetForCurrentView("Resources");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static string OpenToolLabel
        {
            get { return _loader.GetString("OpenToolLabel"); }
        }

        public static string CloseToolLabel
        {
            get { return _loader.GetString("CloseToolLabel"); }
        }

        public static string UseSystemRenderingToolLabel
        {
            get { return _loader.GetString("UseSystemRendering"); }
        }

        public static string ErrorTitle
        {
            get { return _loader.GetString("ErrorTitle"); }
        }

        public static string PdfErrorFormat
        {
            get { return _loader.GetString("PdfErrorFormat"); }
        }

        public static string PasswordTitleLabel
        {
            get { return _loader.GetString("PasswordTitleLabel"); }
        }

        public static string PasswordOpenLabel
        {
            get { return _loader.GetString("PasswordOpenLabel"); }
        }

        public static string PasswordCancelLabel
        {
            get { return _loader.GetString("PasswordCancelLabel"); }
        }

        public static string ShowPasswordCheck
        {
            get { return _loader.GetString("ShowPasswordCheck"); }
        }
    }
}
