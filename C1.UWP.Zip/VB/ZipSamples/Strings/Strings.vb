Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
		Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("ZipSamplesLib/Resources")

		Public Shared ReadOnly Property AppName_Text() As String
			Get
				Return _loader.GetString(" AppName_Text ")
			End Get
		End Property

		Public Shared ReadOnly Property Clear_Content() As String
			Get
				Return _loader.GetString(" Clear_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property Close_Content() As String
			Get
				Return _loader.GetString(" Close_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property Compress_Text() As String
			Get
				Return _loader.GetString(" Compress_Text ")
			End Get
		End Property

		Public Shared ReadOnly Property CompressButton_Content() As String
			Get
				Return _loader.GetString(" CompressButton_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property CompressMessage() As String
			Get
				Return _loader.GetString(" CompressMessage ")
			End Get
		End Property

		Public Shared ReadOnly Property DemoZipDescription() As String
			Get
				Return _loader.GetString(" DemoZipDescription ")
			End Get
		End Property

		Public Shared ReadOnly Property DemoZipName() As String
			Get
				Return _loader.GetString(" DemoZipName ")
			End Get
		End Property

		Public Shared ReadOnly Property DemoZipTitle() As String
			Get
				Return _loader.GetString(" DemoZipTitle ")
			End Get
		End Property

		Public Shared ReadOnly Property Extract_Text() As String
			Get
				Return _loader.GetString(" Extract_Text ")
			End Get
		End Property

		Public Shared ReadOnly Property ExtractButton_Content() As String
			Get
				Return _loader.GetString(" ExtractButton_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property ExtractMessage() As String
			Get
				Return _loader.GetString(" ExtractMessage ")
			End Get
		End Property

		Public Shared ReadOnly Property InitializationException() As String
			Get
				Return _loader.GetString(" InitializationException ")
			End Get
		End Property

		Public Shared ReadOnly Property NewFolder() As String
			Get
				Return _loader.GetString(" NewFolder ")
			End Get
		End Property

		Public Shared ReadOnly Property Open_Content() As String
			Get
				Return _loader.GetString(" Open_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property PickFiles_Content() As String
			Get
				Return _loader.GetString(" PickFiles_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property PickSingleFolder_Content() As String
			Get
				Return _loader.GetString(" PickSingleFolder_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property Preview_Text() As String
			Get
				Return _loader.GetString(" Preview_Text ")
			End Get
		End Property

		Public Shared ReadOnly Property Remove_Content() As String
			Get
				Return _loader.GetString(" Remove_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property Save() As String
			Get
				Return _loader.GetString(" Save ")
			End Get
		End Property

		Public Shared ReadOnly Property Star() As String
			Get
				Return _loader.GetString(" Star ")
			End Get
		End Property

		Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
			Get
				Return _loader.GetString(" UniqueIdItemsArgumentException ")
			End Get
		End Property

		Public Shared ReadOnly Property View_Content() As String
			Get
				Return _loader.GetString(" View_Content ")
			End Get
		End Property

		Public Shared ReadOnly Property ZipFile() As String
			Get
				Return _loader.GetString(" ZipFile ")
			End Get
		End Property


End Class