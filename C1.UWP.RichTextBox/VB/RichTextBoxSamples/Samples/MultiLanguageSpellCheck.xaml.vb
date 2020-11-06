Imports System.IO.Compression
Imports Windows.Storage.Streams
Imports Windows.Storage
Imports C1.C1Zip
Imports System.Net.Http
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports C1.Xaml.SpellChecker
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class MultiLanguageSpellCheck
    Inherits Page
    Private _c1SpellChecker As New C1SpellChecker()

    Public Sub New()
        Me.InitializeComponent()
        rtb.Text = Strings.SpellCheck
        AddHandler Loaded, New RoutedEventHandler(AddressOf MultiLanguageSpellCheck_Loaded)
    End Sub

    Sub MultiLanguageSpellCheck_Loaded(sender As Object, e As RoutedEventArgs)
        AddHandler cmbLanguage.SelectionChanged, New SelectionChangedEventHandler(AddressOf cmbLanguage_SelectionChanged)
        cmbLanguage.ItemTemplate = CType(Resources("DictionaryTemplate"), DataTemplate)
        cmbLanguage.ItemsSource = SpellDictionaryWrapper.GetLanguages()
        cmbLanguage.SelectedIndex = 0
    End Sub

    Sub cmbLanguage_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        GetDictionaryFromServer()
    End Sub

    Private Async Sub GetDictionaryFromServer()
        Dim dctWrapper As SpellDictionaryWrapper = CType(cmbLanguage.SelectedItem, SpellDictionaryWrapper)

        If dctWrapper Is Nothing Then
            Return
        End If

        ' load the dictionary from the server
        Dim client As New HttpClient()
        Try
            loading.Visibility = Visibility.Visible
            rtb.IsEnabled = False

            'Get the dictionary as stream from server.
            Dim serverRoot As String = "http://demos.componentone.com/dictionaries/"
            Dim stream As Stream = Await client.GetStreamAsync(New Uri(serverRoot + dctWrapper.Address, UriKind.Absolute))

            Dim outputStream As New MemoryStream()
            Await stream.CopyToAsync(outputStream)

            rtb.SpellChecker = _c1SpellChecker
            Await _c1SpellChecker.MainDictionary.LoadAsync(outputStream)

            loading.Visibility = Visibility.Collapsed
            rtb.IsEnabled = True
        Catch e As Exception
            Dim dialog As New Windows.UI.Popups.MessageDialog(e.Message)
            dialog.ShowAsync()
            loading.Visibility = Visibility.Collapsed
            rtb.IsEnabled = True
        End Try
    End Sub

#Region "SpellDictionaryWrapper"

    Public Class SpellDictionaryWrapper
        Public Shared Function GetLanguages() As List(Of SpellDictionaryWrapper)
            Dim list As New List(Of SpellDictionaryWrapper)()
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_da-DK.dct",
                .Name = Strings.Denmark,
                .FlagUri = "../Assets/Flags/Denmark.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_de-CH.dct",
                .Name = Strings.Switzerland,
                .FlagUri = "../Assets/Flags/Switzerland.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_de-DE.dct",
                .Name = Strings.Germany,
                .FlagUri = "../Assets/Flags/Germany.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_el-GR.dct",
                .Name = Strings.Greece,
                .FlagUri = "../Assets/Flags/Greece.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_en-CA.dct",
                .Name = Strings.Canada,
                .FlagUri = "../Assets/Flags/Canada.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_en-GB.dct",
                .Name = Strings.UK,
                .FlagUri = "../Assets/Flags/United_Kingdom.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_en-US.dct",
                .Name = Strings.US,
                .FlagUri = "../Assets/Flags/United_States.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_es-AR.dct",
                .Name = Strings.Argentina,
                .FlagUri = "../Assets/Flags/Argentina.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_es-ES.dct",
                .Name = Strings.Spain,
                .FlagUri = "../Assets/Flags/Spain.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_es-MX.dct",
                .Name = Strings.Mexico,
                .FlagUri = "../Assets/Flags/Mexico.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_fr-CA.dct",
                .Name = Strings.CanadaFrench,
                .FlagUri = "../Assets/Flags/Canada.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_fr-FR.dct",
                .Name = Strings.France,
                .FlagUri = "../Assets/Flags/France.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_it-IT.dct",
                .Name = Strings.Italy,
                .FlagUri = "../Assets/Flags/Italy.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_nb-NO.dct",
                .Name = Strings.Bokmal,
                .FlagUri = "../Assets/Flags/Norway.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_nl-NL.dct",
                .Name = Strings.Netherlands,
                .FlagUri = "../Assets/Flags/Netherlands.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_pt-BR.dct",
                .Name = Strings.Brazil,
                .FlagUri = "../Assets/Flags/Brazil.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_pt-PT.dct",
                .Name = Strings.Portugal,
                .FlagUri = "../Assets/Flags/Portugal.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_ru-RU.dct",
                .Name = Strings.Russia,
                .FlagUri = "../Assets/Flags/Russia.png"
            })
            list.Add(New SpellDictionaryWrapper() With {
                .Address = "C1Spell_sv-SE.dct",
                .Name = Strings.Sweden,
                .FlagUri = "../Assets/Flags/Sweden.png"
            })
            Return list
        End Function

        Public Property Address() As String
        Public Property Name() As String
        Public Property FlagUri() As String
    End Class

#End Region
End Class