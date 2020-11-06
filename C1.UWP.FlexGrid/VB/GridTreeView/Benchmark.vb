Imports Windows.UI.Xaml.Controls
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' Benchmarking helper class
''' </summary>
Class Benchmark
    Implements IDisposable
    Private _msg As String
    Private _start As DateTime
    Private _tb As TextBlock

    Public Sub New(msg As String, tb As TextBlock)
        _msg = msg
        _start = DateTime.Now
        _tb = tb
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        _tb.Text = String.Format("{0}: {1:n0} ms", _msg, DateTime.Now.Subtract(_start).TotalMilliseconds)
    End Sub
End Class