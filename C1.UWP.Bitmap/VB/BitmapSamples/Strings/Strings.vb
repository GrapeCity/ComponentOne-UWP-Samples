Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("BitmapSamplesLib/Resources")

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property ImageFormatNotSupportedException() As String
        Get
            Return _loader.GetString("ImageFormatNotSupportedException")
        End Get
    End Property

    Public Shared ReadOnly Property EmptySelectionMessage() As String
        Get
            Return _loader.GetString("EmptySelectionMessage")
        End Get
    End Property

    Public Shared ReadOnly Property GifImageName() As String
        Get
            Return _loader.GetString("GifImageName")
        End Get
    End Property

    Public Shared ReadOnly Property GifImageTitle() As String
        Get
            Return _loader.GetString("GifImageTitle")
        End Get
    End Property

    Public Shared ReadOnly Property GifImagePlay() As String
        Get
            Return _loader.GetString("GifImagePlay")
        End Get
    End Property

    Public Shared ReadOnly Property GifImageStop() As String
        Get
            Return _loader.GetString("GifImageStop")
        End Get
    End Property

    Public Shared ReadOnly Property GifImageZoomIn() As String
        Get
            Return _loader.GetString("GifImageZoomIn")
        End Get
    End Property

    Public Shared ReadOnly Property GifImageZoomOut() As String
        Get
            Return _loader.GetString("GifImageZoomOut")
        End Get
    End Property

    Public Shared ReadOnly Property GifImageDescription() As String
        Get
            Return _loader.GetString("GifImageDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CropName() As String
        Get
            Return _loader.GetString("CropName")
        End Get
    End Property

    Public Shared ReadOnly Property CropTitle() As String
        Get
            Return _loader.GetString("CropTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CropDescription() As String
        Get
            Return _loader.GetString("CropDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FaceWarpName() As String
        Get
            Return _loader.GetString("FaceWarpName")
        End Get
    End Property

    Public Shared ReadOnly Property FaceWarpTitle() As String
        Get
            Return _loader.GetString("FaceWarpTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FaceWarpDescription() As String
        Get
            Return _loader.GetString("FaceWarpDescription")
        End Get
    End Property

    Public Shared ReadOnly Property TransformButtonText() As String
        Get
            Return _loader.GetString("TransformButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property TransformName() As String
        Get
            Return _loader.GetString("TransformName")
        End Get
    End Property

    Public Shared ReadOnly Property TransformTitle() As String
        Get
            Return _loader.GetString("TransformTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TransformDescription() As String
        Get
            Return _loader.GetString("TransformDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Export_Content() As String
        Get
            Return _loader.GetString("Export_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ExportSelection_Content() As String
        Get
            Return _loader.GetString("ExportSelection_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Load_Content() As String
        Get
            Return _loader.GetString("Load_Content")
        End Get
    End Property

    Public Shared ReadOnly Property LoadImage_Content() As String
        Get
            Return _loader.GetString("LoadImage_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Restart_Content() As String
        Get
            Return _loader.GetString("Restart_Content")
        End Get
    End Property

    Public Shared ReadOnly Property MenuCropToSelection() As String
        Get
            Return _loader.GetString("MenuCropToSelection")
        End Get
    End Property

    Public Shared ReadOnly Property MenuRotateCCW() As String
        Get
            Return _loader.GetString("MenuRotateCCW")
        End Get
    End Property

    Public Shared ReadOnly Property MenuRotateCW() As String
        Get
            Return _loader.GetString("MenuRotateCW")
        End Get
    End Property

    Public Shared ReadOnly Property MenuFlipHorizontal() As String
        Get
            Return _loader.GetString("MenuFlipHorizontal")
        End Get
    End Property

    Public Shared ReadOnly Property MenuFlipVertical() As String
        Get
            Return _loader.GetString("MenuFlipVertical")
        End Get
    End Property

    Public Shared ReadOnly Property MenuScaleIn() As String
        Get
            Return _loader.GetString("MenuScaleIn")
        End Get
    End Property

    Public Shared ReadOnly Property MenuScaleOut() As String
        Get
            Return _loader.GetString("MenuScaleOut")
        End Get
    End Property

End Class