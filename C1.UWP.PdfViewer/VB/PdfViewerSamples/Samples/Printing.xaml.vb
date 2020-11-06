Imports Windows.UI.Xaml.Printing
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.ViewManagement
Imports Windows.UI.Popups
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Graphics.Printing
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System

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
    ''' A list of UIElements used to store the pdf pages.  This gives easy access
    ''' to any desired page without having to call c1PdfViewer.GetPages multiple times
    ''' </summary>
    Friend pages As List(Of FrameworkElement) = Nothing

    Public Sub New()
        Me.InitializeComponent()
        pages = New List(Of FrameworkElement)()
        AddHandler Loaded, AddressOf Printing_Loaded
        AddHandler Unloaded, AddressOf Printing_Unloaded
    End Sub

    Private Sub Printing_Loaded(sender As Object, e As RoutedEventArgs)
        Dim asm As Assembly = GetType(PdfViewerDemoPage).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream("PdfViewerSamples.PdfViewer.pdf")
        c1PdfViewer1.LoadDocument(stream)
        ' init printing 
        RegisterForPrinting()
    End Sub

    Private Sub Printing_Unloaded(sender As Object, e As RoutedEventArgs)
        UnregisterForPrinting()
        c1PdfViewer1.CloseDocument()
    End Sub

    Private Async Sub btnPrint_Click(sender As Object, e As RoutedEventArgs)
        Await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync()
    End Sub

    ''' <summary>
    ''' This is the event handler for PrintManager.PrintTaskRequested.
    ''' </summary>
    ''' <param name="sender">PrintManager</param>
    ''' <param name="e">PrintTaskRequestedEventArgs </param>
    Private Sub PrintTaskRequested(sender As PrintManager, e As PrintTaskRequestedEventArgs)
        Dim printTask As PrintTask = Nothing
        printTask = e.Request.CreatePrintTask("SamplePDF", Function(sourceRequested As PrintTaskSourceRequestedArgs)
                                                               ' Print Task event handler is invoked when the print job is completed.
                                                               AddHandler printTask.Completed, AddressOf OnComplete

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
        [option] = e.PrintTaskOptions
        Dim printDoc As PrintDocument = CType(sender, PrintDocument)

        ' Report the number of preview pages
        printDoc.SetPreviewPageCount(c1PdfViewer1.PageCount, PreviewPageCountType.Intermediate)
    End Sub

    Private [option] As PrintTaskOptions = Nothing
    ''' <summary>
    ''' This is the event handler for PrintDocument.GetPrintPreviewPage. It provides a specific print preview page,
    ''' in the form of an UIElement, to an instance of PrintDocument. PrintDocument subsequently converts the UIElement
    ''' into a page that the Windows print system can deal with.
    ''' </summary>
    ''' <param name="sender">PrintDocument</param>
    ''' <param name="e">Arguments containing the preview requested page</param>
    Private Async Sub GetPrintPreviewPage(sender As Object, e As GetPreviewPageEventArgs)
        Dim printDoc As PrintDocument = CType(sender, PrintDocument)
        Dim paperSize As Size = [option].GetPageDescription(CType(e.PageNumber, UInteger)).PageSize
        Dim rate As Double = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel
        paperSize = New Size(paperSize.Width / rate, paperSize.Height / rate)
        printDoc.SetPreviewPage(e.PageNumber, Await c1PdfViewer1.GetPage(e.PageNumber, paperSize))
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
        pages.Clear()
        For Each page As FrameworkElement In c1PdfViewer1.GetPages()
            pages.Add(page)
        Next

        For Each page As FrameworkElement In pages
            printDocument.AddPage(page)
        Next

        Dim printDoc As PrintDocument = CType(sender, PrintDocument)

        ' Indicate that all of the print pages have been provided
        printDoc.AddPagesComplete()
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As Windows.UI.Xaml.RoutedEventArgs)
        Dim openPicker As New FileOpenPicker()
        openPicker.FileTypeFilter.Add(".pdf")

        Dim file As StorageFile = Await openPicker.PickSingleFileAsync()
        If file IsNot Nothing Then
            Dim stream As Stream = Await file.OpenStreamForReadAsync()
            c1PdfViewer1.LoadDocument(stream)
        End If

    End Sub
End Class