''' <summary>
''' Represents a Category group
''' </summary>
Public Class Category
    Inherits DependencyObject

    Private m_Name As String
    Private m_Text As String
    Private m_ImageUri As String
    Private m_Reports As List(Of Report)

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set
            m_Text = Value
        End Set
    End Property

    Public Property ImageUri() As String
        Get
            Return m_ImageUri
        End Get
        Set
            m_ImageUri = Value
        End Set
    End Property

    Public Property Reports() As List(Of Report)
        Get
            Return m_Reports
        End Get
        Set
            m_Reports = Value
        End Set
    End Property

    Public Property IsExpanded() As Boolean
        Get
            Return CBool(GetValue(IsExpandedProperty))
        End Get
        Set
            SetValue(IsExpandedProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly IsExpandedProperty As DependencyProperty = DependencyProperty.Register("IsExpanded", GetType(Boolean), GetType(Category), New PropertyMetadata(False))
End Class

''' <summary>
''' Represents an Item of group
''' </summary>
Public Class Report
    Inherits DependencyObject

    Private m_CategoryName As String
    Private m_ReportName As String
    Private m_FileName As String
    Private m_ReportTitle As String
    Private m_ImageUri As String

    Public Property CategoryName() As String
        Get
            Return m_CategoryName
        End Get
        Set
            m_CategoryName = Value
        End Set
    End Property

    Public Property ReportName() As String
        Get
            Return m_ReportName
        End Get
        Set
            m_ReportName = Value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return m_FileName
        End Get
        Set
            m_FileName = Value
        End Set
    End Property

    Public Property ReportTitle() As String
        Get
            Return m_ReportTitle
        End Get
        Set
            m_ReportTitle = Value
        End Set
    End Property

    Public Property ImageUri() As String
        Get
            Return m_ImageUri
        End Get
        Set
            m_ImageUri = Value
        End Set
    End Property

    Public Property IsSelected() As Boolean
        Get
            Return CBool(GetValue(IsSelectedProperty))
        End Get
        Set
            SetValue(IsSelectedProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly IsSelectedProperty As DependencyProperty = DependencyProperty.Register("IsSelected", GetType(Boolean), GetType(Report), New PropertyMetadata(False))
End Class
