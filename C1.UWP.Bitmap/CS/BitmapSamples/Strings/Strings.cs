﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace BitmapSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("BitmapSamplesLib/Resources");

        public static string UniqueIdItemsArgumentException
        {
            get { return _loader.GetString("UniqueIdItemsArgumentException"); }
        }

        public static string SessionStateKeyErrorMessage
        {
            get { return _loader.GetString("SessionStateKeyErrorMessage"); }
        }

        public static string SessionStateErrorMessage
        {
            get { return _loader.GetString("SessionStateErrorMessage"); }
        }

        public static string SuspensionManagerErrorMessage
        {
            get { return _loader.GetString("SuspensionManagerErrorMessage"); }
        }

        public static string InitializationException
        {
            get { return _loader.GetString("InitializationException"); }
        }

        public static string ImageFormatNotSupportedException
        {
            get { return _loader.GetString("ImageFormatNotSupportedException"); }
        }

        public static string EmptySelectionMessage
        {
            get { return _loader.GetString("EmptySelectionMessage"); }
        }

        public static string GifImageName
        {
            get { return _loader.GetString("GifImageName"); }
        }

        public static string GifImageTitle
        {
            get { return _loader.GetString("GifImageTitle"); }
        }

        public static string GifImagePlay
        {
            get { return _loader.GetString("GifImagePlay"); }
        }

        public static string GifImageStop
        {
            get { return _loader.GetString("GifImageStop"); }
        }

        public static string GifImageZoomIn
        {
            get { return _loader.GetString("GifImageZoomIn"); }
        }

        public static string GifImageZoomOut
        {
            get { return _loader.GetString("GifImageZoomOut"); }
        }

        public static string GifImageDescription
        {
            get { return _loader.GetString("GifImageDescription"); }
        }

        public static string CropName
        {
            get { return _loader.GetString("CropName"); }
        }

        public static string CropTitle
        {
            get { return _loader.GetString("CropTitle"); }
        }

        public static string CropDescription
        {
            get { return _loader.GetString("CropDescription"); }
        }

        public static string FaceWarpName
        {
            get { return _loader.GetString("FaceWarpName"); }
        }

        public static string FaceWarpTitle
        {
            get { return _loader.GetString("FaceWarpTitle"); }
        }

        public static string FaceWarpDescription
        {
            get { return _loader.GetString("FaceWarpDescription"); }
        }

        public static string TransformButtonText
        {
            get { return _loader.GetString("TransformButtonText"); }
        }

        public static string TransformName
        {
            get { return _loader.GetString("TransformName"); }
        }

        public static string TransformTitle
        {
            get { return _loader.GetString("TransformTitle"); }
        }

        public static string TransformDescription
        {
            get { return _loader.GetString("TransformDescription"); }
        }

        public static string AppName_Text
        {
            get { return _loader.GetString("AppName_Text"); }
        }

        public static string Export_Content
        {
            get { return _loader.GetString("Export_Content"); }
        }

        public static string ExportSelection_Content
        {
            get { return _loader.GetString("ExportSelection_Content"); }
        }

        public static string Load_Content
        {
            get { return _loader.GetString("Load_Content"); }
        }

        public static string LoadImage_Content
        {
            get { return _loader.GetString("LoadImage_Content"); }
        }

        public static string Restart_Content
        {
            get { return _loader.GetString("Restart_Content"); }
        }

        public static string MenuCropToSelection
        {
            get { return _loader.GetString("MenuCropToSelection"); }
        }

        public static string MenuRotateCCW
        {
            get { return _loader.GetString("MenuRotateCCW"); }
        }

        public static string MenuRotateCW
        {
            get { return _loader.GetString("MenuRotateCW"); }
        }

        public static string MenuFlipHorizontal
        {
            get { return _loader.GetString("MenuFlipHorizontal"); }
        }

        public static string MenuFlipVertical
        {
            get { return _loader.GetString("MenuFlipVertical"); }
        }

        public static string MenuScaleIn
        {
            get { return _loader.GetString("MenuScaleIn"); }
        }

        public static string MenuScaleOut
        {
            get { return _loader.GetString("MenuScaleOut"); }
        }
    }
}
