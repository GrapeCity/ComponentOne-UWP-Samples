Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.System.Threading
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class Clock
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        If Not Windows.ApplicationModel.DesignMode.DesignModeEnabled Then
            Task.Run(New Action(AddressOf RunClock))
        End If
    End Sub
    Private Delegate Sub UpdateUIDelegate()
    Private _timer As ThreadPoolTimer

    Private Sub RunClock()
        _timer = ThreadPoolTimer.CreatePeriodicTimer(New TimerElapsedHandler(Function(target)
                                                                                 Dispatcher.RunAsync(CoreDispatcherPriority.Normal, AddressOf UpdateClock)

                                                                             End Function), TimeSpan.FromSeconds(1))

    End Sub

    Private Sub UpdateClock()
        Dim now As DateTime = DateTime.Now
        clockHours.Value = now.Hour Mod 12 + now.Minute / 60.0
        clockMins.Value = now.Minute
        clockSecs.Value = now.Second
    End Sub
End Class
