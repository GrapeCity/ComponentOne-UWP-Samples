Imports C1.Xaml.RichTextBox.PdfFilter
Imports C1.Xaml.Pdf
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports C1.Xaml.RichTextBox
Imports Windows.UI.Xaml.Printing
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.Graphics.Printing
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Printing
    Inherits Page
    ''' <summary>
    ''' PrintDocument is used to prepare the pages for printing. 
    ''' Prepare the pages to print in the handlers for the Paginate, GetPreviewPage, and AddPages events.
    ''' </summary>
    Private printDocument As PrintDocument = Nothing
    ''' <summary>
    ''' Marker interface for document source
    ''' </summary>
    Private printDocumentSource As IPrintDocumentSource = Nothing
    ''' <summary>
    ''' A list of UIElements used to store the rtb pages. 
    ''' </summary>
    Friend pages As List(Of UIElement) = Nothing

    Public Sub New()
        Me.InitializeComponent()

        Dim asm As Assembly = GetType(Printing).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream("RichTextBoxSamples.dickens.htm")
        Dim sr As StreamReader = New StreamReader(stream)
        Dim html As String = sr.ReadToEnd()
        rtb.Html = html

        pages = New List(Of UIElement)()
        AddHandler Loaded, AddressOf Printing_Loaded
        AddHandler Unloaded, AddressOf Printing_Unloaded
        cmbViewMode.SelectedIndex = 1
    End Sub

#Region "event handlers"
    Sub Printing_Unloaded(sender As Object, e As RoutedEventArgs)
        UnregisterForPrinting()
    End Sub

    Sub Printing_Loaded(sender As Object, e As RoutedEventArgs)
        ' init printing 
        RegisterForPrinting()
    End Sub

    Private Async Sub btnPrint_Click(sender As Object, e As RoutedEventArgs)
        Await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync()
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Dim savePicker As New FileSavePicker()
        savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        savePicker.FileTypeChoices.Add(Strings.PdfFile, New List(Of String)() From {
            ".pdf"
        })
        savePicker.DefaultFileExtension = ".pdf"
        Dim file As StorageFile = Await savePicker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Dim pdf As New C1PdfDocument(PaperKind.[Custom])
            pdf.ConformanceLevel = PdfAConformanceLevel.PdfA2b
            Dim layout As C1PageLayout = TryCast(rtb.ViewManager.PresenterInfo, C1PageLayout)
            PdfFilter.PrintDocument(rtb.Document, pdf, layout.Padding)
            Await pdf.SaveAsync(file)
            Dim dlg As New MessageDialog(Strings.SaveMessage + file.Path, Strings.RtbSample)
            Await dlg.ShowAsync()
        End If
    End Sub

    Private Sub cmbViewMode_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cmbViewMode.SelectedIndex = 0 Then
            rtb.ViewMode = TextViewMode.Draft
        Else
            rtb.ViewMode = TextViewMode.Print
        End If
    End Sub

#End Region

#Region "implemention"
    ''' <summary>
    ''' This is the event handler for PrintManager.PrintTaskRequested.
    ''' </summary>
    ''' <param name="sender">PrintManager</param>
    ''' <param name="e">PrintTaskRequestedEventArgs </param>
    Private Sub PrintTaskRequested(sender As PrintManager, e As PrintTaskRequestedEventArgs)
        Dim printTask As PrintTask = Nothing
        printTask = e.Request.CreatePrintTask("Printing C1RichTextBox", Function(sourceRequested As PrintTaskSourceRequestedArgs)
                                                                            ' Print Task event handler is invoked when the print job is completed.
                                                                            AddHandler printTask.Completed, AddressOf OnComplete

                                                                            ' set print options like paper size and orientation
                                                                            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Function()
                                                                                                                                                   Dim layout As Object = TryCast(rtb.ViewManager.PresenterInfo, C1PageLayout)
                                                                                                                                                   If layout IsNot Nothing AndAlso layout.Width > layout.Height Then
                                                                                                                                                       printTask.Options.Orientation = PrintOrientation.Landscape
                                                                                                                                                   End If

                                                                                                                                               End Function)

                                                                            sourceRequested.SetSource(printDocumentSource)

                                                                        End Function)

    End Sub

    Private Async Sub OnComplete(sender As Object, args As PrintTaskCompletedEventArgs)
        If args.Completion = PrintTaskCompletion.Failed Then
            Await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Sub()
                                                                                         Dim dialog As New MessageDialog(Strings.PrintException)
                                                                                         dialog.ShowAsync()

                                                                                     End Sub)
        End If
    End Sub

    ''' <summary>
    ''' This method registers the app for printing with Windows and sets up the necessary event handlers for the print process.
    ''' </summary>
    Private Sub RegisterForPrinting()
        ' Create the PrintDocument.
        printDocument = New PrintDocument()

        ' Save the DocumentSource.
        printDocumentSource = printDocument.DocumentSource

        ' Add an event handler which sets up print preview.
        AddHandler printDocument.Paginate, AddressOf Paginate

        ' Add an event handler which provides a specified preview page.
        AddHandler printDocument.GetPreviewPage, AddressOf GetPrintPreviewPage

        ' Add an event handler which provides all final print pages.
        AddHandler printDocument.AddPages, AddressOf AddPrintPages

        ' Create a PrintManager and add a handler for printing initialization.
        Dim printMan As PrintManager = PrintManager.GetForCurrentView()
        AddHandler printMan.PrintTaskRequested, AddressOf PrintTaskRequested
    End Sub

    ''' <summary>
    ''' This method unregisters the app for printing with Windows.
    ''' </summary>
    Private Sub UnregisterForPrinting()
        If printDocument Is Nothing Then
            Return
        End If

        RemoveHandler printDocument.Paginate, AddressOf Paginate
        RemoveHandler printDocument.GetPreviewPage, AddressOf GetPrintPreviewPage
        RemoveHandler printDocument.AddPages, AddressOf AddPrintPages

        ' Remove the handler for printing initialization.
        Dim printMan As PrintManager = PrintManager.GetForCurrentView()
        RemoveHandler printMan.PrintTaskRequested, AddressOf PrintTaskRequested
    End Sub

    ''' <summary>
    ''' This is the event handler for PrintDocument.Paginate. 
    ''' It fires when the PrintManager requests print preview
    ''' </summary>
    ''' <param name="sender">PrintDocument</param>
    ''' <param name="e">Paginate Event Arguments</param>
    Private Sub Paginate(sender As Object, e As PaginateEventArgs)
        If pages.Count > 0 Then
            pages.Clear()
        End If
        Dim mgr As New C1RichTextViewManager() With {
            .Document = rtb.Document
        }
        Dim layout As C1PageLayout = TryCast(rtb.ViewManager.PresenterInfo, C1PageLayout)
        Dim contentSize As New Size(layout.Width - layout.Padding.Left - layout.Padding.Right, layout.Height - layout.Padding.Top - layout.Padding.Bottom)

        ' print the pages outside the visual tree
        Dim elements As List(Of UIElement) = mgr.OfflinePaint(contentSize).ToList()
        For Each el As UIElement In elements
            Dim page As Grid = CType(printTemplate.LoadContent(), Grid)
            Dim canvas As Canvas = TryCast(el, Canvas)
            If canvas IsNot Nothing Then
                canvas.Margin = layout.Padding
            End If
            page.Children.Clear()
            page.Children.Add(canvas)
            pages.Add(page)
        Next
        Dim printDoc As PrintDocument = CType(sender, PrintDocument)
        ' Report the number of preview pages
        printDoc.SetPreviewPageCount(pages.Count, PreviewPageCountType.Intermediate)
    End Sub

    ''' <summary>
    ''' This is the event handler for PrintDocument.GetPrintPreviewPage. It provides a specific print preview page,
    ''' in the form of an UIElement, to an instance of PrintDocument. PrintDocument subsequently converts the UIElement
    ''' into a page that the Windows print system can deal with.
    ''' </summary>
    ''' <param name="sender">PrintDocument</param>
    ''' <param name="e">Arguments containing the preview requested page</param>
    Private Sub GetPrintPreviewPage(sender As Object, e As GetPreviewPageEventArgs)
        Dim printDoc As PrintDocument = CType(sender, PrintDocument)
        printDoc.SetPreviewPage(e.PageNumber, pages(e.PageNumber - 1))
    End Sub

    ''' <summary>
    ''' This is the event handler for PrintDocument.AddPages. It provides all pages to be printed, in the form of
    ''' UIElements, to an instance of PrintDocument. PrintDocument subsequently converts the UIElements
    ''' into a pages that the Windows print system can deal with.
    ''' </summary>
    ''' <param name="sender">PrintDocument</param>
    ''' <param name="e">Add page event arguments containing a print task options reference</param>
    Private Sub AddPrintPages(sender As Object, e As AddPagesEventArgs)
        ' Loop over all of the pages and add each one to be printed
        For Each page As FrameworkElement In pages
            printDocument.AddPage(page)
        Next
        Dim printDoc As PrintDocument = CType(sender, PrintDocument)
        ' Indicate that all of the print pages have been provided
        printDoc.AddPagesComplete()
    End Sub
#End Region
End Class