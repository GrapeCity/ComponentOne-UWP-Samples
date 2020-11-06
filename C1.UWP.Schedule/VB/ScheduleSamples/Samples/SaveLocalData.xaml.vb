Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Storage.Streams
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports Windows.Storage

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class SaveLocalData
    Inherits Page
    'IRandomAccessStream stream;
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Unloaded, AddressOf SaveLocalData_Unloaded

        Try
            ' set toast notifier for C1Schedule to show toast notifications instead of embedded reminder dialog
            ' note, notifications might not be shown if end-user disabled them for some reason
            ' also, toast notifications are disabled when application is running in simulator
            sched1.ToastNotifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier()
            ' if application manifest doesn't allow toast notifications, then above code will fail
        Catch
        End Try
    End Sub

    Private Async Sub SaveLocalData_Unloaded(sender As Object, e As RoutedEventArgs)
        ' Export XML to app local folder
        Dim folder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
        Dim file As StorageFile = Await folder.CreateFileAsync(Strings.ExportFileName, Windows.Storage.CreationCollisionOption.OpenIfExists)
        Dim stream As IRandomAccessStream = Await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite)
        Await sched1.DataStorage.ExportAsync(stream.AsStreamForWrite(), C1.C1Schedule.FileFormatEnum.XML)
        Await stream.FlushAsync()
        stream.Dispose()
    End Sub

    Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
        ' Import XML from app local folder
        Dim folder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
        Try
            Dim file As StorageFile = Await folder.GetFileAsync(Strings.ImportFileName)
            Dim stream As IRandomAccessStream = Await file.OpenAsync(Windows.Storage.FileAccessMode.Read)
            Await sched1.DataStorage.ImportAsync(stream.AsStreamForRead(), C1.C1Schedule.FileFormatEnum.XML)
            stream.Dispose()
        Catch
        End Try
    End Sub

    Private Sub DayClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.OneDayStyle)
    End Sub
    Private Sub WorkWeekClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.WorkingWeekStyle)
    End Sub
    Private Sub WeekClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.WeekStyle)
    End Sub

    Private Sub MonthClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.MonthStyle)
    End Sub

    Private Sub Add_Click(sender As Object, e As RoutedEventArgs)
        sched1.NewAppointmentDialog()
    End Sub

    Private Sub View_Click(sender As Object, e As RoutedEventArgs)
        If sched1.ViewType = C1.Xaml.Schedule.ViewType.Month Then
            sched1.ViewType = C1.Xaml.Schedule.ViewType.Day
            ViewButton.Label = Strings.MonthView
        Else
            sched1.ViewType = C1.Xaml.Schedule.ViewType.Month
            ViewButton.Label = Strings.DayView
        End If
    End Sub

    Private Sub Today_Click(sender As Object, e As RoutedEventArgs)
        sched1.SelectedDateTime = DateTime.Now
    End Sub
End Class