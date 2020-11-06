using System;
using System.Diagnostics;

using Windows.ApplicationModel.Resources;

namespace Direct2DEffects
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

        public static string EffectsButtonText
        {
            get { return _loader.GetString("EffectsButtonText"); }
        }

        public static string OriginalButtonText
        {
            get { return _loader.GetString("OriginalButtonText"); }
        }

        public static string GaussianBlurButtonText
        {
            get { return _loader.GetString("GaussianBlurButtonText"); }
        }

        public static string SharpenButtonText
        {
            get { return _loader.GetString("SharpenButtonText"); }
        }

        public static string HorizontalSmearButtonText
        {
            get { return _loader.GetString("HorizontalSmearButtonText"); }
        }

        public static string ShadowButtonText
        {
            get { return _loader.GetString("ShadowButtonText"); }
        }

        public static string DisplacementMapButtonText
        {
            get { return _loader.GetString("DisplacementMapButtonText"); }
        }

        public static string EmbossButtonText
        {
            get { return _loader.GetString("EmbossButtonText"); }
        }

        public static string EdgeDetectButtonText
        {
            get { return _loader.GetString("EdgeDetectButtonText"); }
        }

        public static string SepiaButtonText
        {
            get { return _loader.GetString("SepiaButtonText"); }
        }

        public static string ExportButtonText
        {
            get { return _loader.GetString("ExportButtonText"); }
        }

        public static string StoneInscription
        {
            get { return _loader.GetString("StoneInscription"); }
        }
    }
}
