''' <summary>
''' Represents a Category group
''' </summary>
Public Class Category
    Private Shared _categories As List(Of Category) = Nothing
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set
            m_Text = Value
        End Set
    End Property
    Private m_Text As String
    Public Property ImageUri() As String
        Get
            Return m_ImageUri
        End Get
        Set
            m_ImageUri = Value
        End Set
    End Property
    Private m_ImageUri As String
    Public Property SubCategories() As List(Of SubCategory)
        Get
            Return m_SubCategories
        End Get
        Set
            m_SubCategories = Value
        End Set
    End Property
    Private m_SubCategories As List(Of SubCategory)

    Public Property IsVisible() As Boolean
        Get
            Return m_IsVisible
        End Get
        Set
            m_IsVisible = Value
        End Set
    End Property
    Private m_IsVisible As Boolean
    Public Shared ReadOnly Property Categories() As List(Of Category)
        Get
            If _categories Is Nothing Then
                _categories = GetAll()
            End If
            Return _categories
        End Get
    End Property

    Friend Shared Function GetAll() As List(Of Category)
        Dim listToReturn As New List(Of Category)()
        ' load the report catalog
        Dim xdoc As New XDocument()
        Using fs As Stream = File.OpenRead("Assets/EatablesInfo.xml")
            xdoc = XDocument.Load(fs)
        End Using

        ' prepare the list of reports for the TreeView
        Dim xelems As IEnumerable(Of XElement) = xdoc.Descendants("Category")
        listToReturn = New List(Of Category)()
        For Each xelem As XElement In xelems
            Dim category As New Category() With {
                    .IsVisible = Convert.ToBoolean(xelem.Attribute("IsVisible").Value)
                }
            If Not category.IsVisible Then
                Continue For
            End If
            category.Name = xelem.Attribute("Name").Value
            category.Text = xelem.Attribute("DisplayText").Value
            category.ImageUri = "ms-appx:///Assets/Images/Categories/" + category.Name + "/" + xelem.Attribute("Image").Value + ".png"
            Dim subCategories As New List(Of SubCategory)()
            Dim subCategory As New SubCategory() With {
                    .IsVisible = True,
                    .CategoryName = category.Name,
                    .Name = "All",
                    .Text = "All",
                    .Items = New List(Of Item)()
                }
            subCategories.Add(subCategory)
            For Each childCategory As XElement In xelem.Descendants("SubCategory")
                subCategory = New SubCategory() With {
                        .IsVisible = Convert.ToBoolean(childCategory.Attribute("IsVisible").Value)
                    }
                If Not subCategory.IsVisible Then
                    Continue For
                End If
                subCategory.CategoryName = category.Name
                subCategory.Name = childCategory.Attribute("Name").Value
                subCategory.Text = childCategory.Attribute("DisplayText").Value
                subCategories.Add(subCategory)
                Dim items As New List(Of Item)()
                For Each childItem As XElement In childCategory.Descendants("Item")
                    Dim item As New Item() With {
                            .IsVisible = Convert.ToBoolean(childItem.Descendants("IsVisible").FirstOrDefault().Value)
                        }
                    If Not item.IsVisible Then
                        Continue For
                    End If
                    item.Id = Convert.ToInt32(childItem.Descendants("Id").FirstOrDefault().Value)
                    item.SubCategoryName = subCategory.Name
                    item.Name = childItem.Descendants("Name").FirstOrDefault().Value
                    item.Text = childItem.Descendants("DisplayText").FirstOrDefault().Value
                    item.Description = childItem.Descendants("Description").FirstOrDefault().Value
                    item.Units = Convert.ToInt32(childItem.Descendants("AvailableUnit").FirstOrDefault().Value)
                    item.PrizeRegular = Convert.ToInt32(childItem.Descendants("PrizeRegular").FirstOrDefault().Value)
                    item.PrizeMedium = Convert.ToInt32(childItem.Descendants("PrizeMedium").FirstOrDefault().Value)
                    item.PrizeLarge = Convert.ToInt32(childItem.Descendants("PrizeLarge").FirstOrDefault().Value)
                    item.DiscountinPercent = Convert.ToDouble(childItem.Descendants("DscountInPercent").FirstOrDefault().Value)
                    item.Rating = Convert.ToInt32(childItem.Descendants("Rating").FirstOrDefault().Value)
                    item.IsVeg = Convert.ToBoolean(childItem.Descendants("IsVeg").FirstOrDefault().Value)
                    item.IsSpecial = Convert.ToBoolean(childItem.Descendants("IsSpecial").FirstOrDefault().Value)
                    item.ImageUri = "Assets/Images/Categories/" + category.Name + "/" + subCategory.Name + "/" + childItem.Descendants("ImageName").FirstOrDefault().Value
                    items.Add(item)
                Next
                subCategory.Items = items
            Next
            category.SubCategories = subCategories
            listToReturn.Add(category)
        Next
        Return listToReturn
    End Function
End Class

''' <summary>
''' Represents a sub group of group
''' </summary>
Public Class SubCategory
    Public Property CategoryName() As String
        Get
            Return m_CategoryName
        End Get
        Set
            m_CategoryName = Value
        End Set
    End Property
    Private m_CategoryName As String
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set
            m_Text = Value
        End Set
    End Property
    Private m_Text As String
    Public Property ImageUri() As String
        Get
            Return m_ImageUri
        End Get
        Set
            m_ImageUri = Value
        End Set
    End Property
    Private m_ImageUri As String
    Public Property Items() As List(Of Item)
        Get
            Return m_Items
        End Get
        Set
            m_Items = Value
        End Set
    End Property
    Private m_Items As List(Of Item)
    Public Property IsVisible() As Boolean
        Get
            Return m_IsVisible
        End Get
        Set
            m_IsVisible = Value
        End Set
    End Property
    Private m_IsVisible As Boolean
End Class

''' <summary>
''' Represents an item
''' </summary>
Public Class Item
    Public Event PropertyChanged As PropertyChangedEventHandler
    Private _isEnabled As Boolean = True
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
    Public Property SubCategoryName() As String
        Get
            Return m_SubCategoryName
        End Get
        Set
            m_SubCategoryName = Value
        End Set
    End Property
    Private m_SubCategoryName As String
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set
            m_Text = Value
        End Set
    End Property
    Private m_Text As String
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set
            m_Description = Value
        End Set
    End Property
    Private m_Description As String
    Public Property ImageUri() As String
        Get
            Return m_ImageUri
        End Get
        Set
            m_ImageUri = Value
        End Set
    End Property
    Private m_ImageUri As String
    Public Property PrizeRegular() As Double
        Get
            Return m_PrizeRegular
        End Get
        Set
            m_PrizeRegular = Value
        End Set
    End Property
    Private m_PrizeRegular As Double
    Public Property PrizeMedium() As Double
        Get
            Return m_PrizeMedium
        End Get
        Set
            m_PrizeMedium = Value
        End Set
    End Property
    Private m_PrizeMedium As Double
    Public Property PrizeLarge() As Double
        Get
            Return m_PrizeLarge
        End Get
        Set
            m_PrizeLarge = Value
        End Set
    End Property
    Private m_PrizeLarge As Double
    Public Property Units() As Integer
        Get
            Return m_Units
        End Get
        Set
            m_Units = Value
        End Set
    End Property
    Private m_Units As Integer
    Public Property DiscountinPercent() As Double
        Get
            Return m_DiscountinPercent
        End Get
        Set
            m_DiscountinPercent = Value
        End Set
    End Property
    Private m_DiscountinPercent As Double
    Public Property IsVisible() As Boolean
        Get
            Return m_IsVisible
        End Get
        Set
            m_IsVisible = Value
        End Set
    End Property
    Private m_IsVisible As Boolean
    Public Property Rating() As Integer
        Get
            Return m_Rating
        End Get
        Set
            m_Rating = Value
        End Set
    End Property
    Private m_Rating As Integer
    Public Property IsVeg() As Boolean
        Get
            Return m_IsVeg
        End Get
        Set
            m_IsVeg = Value
        End Set
    End Property
    Private m_IsVeg As Boolean
    Public Property IsSpecial() As Boolean
        Get
            Return m_IsSpecial
        End Get
        Set
            m_IsSpecial = Value
        End Set
    End Property
    Private m_IsSpecial As Boolean
    Public Property IsEnabled() As Boolean
        Get
            Return _isEnabled
        End Get
        Set
            If _isEnabled <> value Then
                _isEnabled = value
                OnPropertyChanged(Me, New PropertyChangedEventArgs("IsEnabled"))
            End If
        End Set
    End Property
    Public Sub OnPropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        ' Not Implemented
        ' PropertyChanged?.Invoke(sender, e);
    End Sub
End Class

#Region "CartItem"
Public Class CartItem
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set
            m_Description = Value
        End Set
    End Property
    Private m_Description As String
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
    Public Property ImgUri() As String
        Get
            Return m_ImgUri
        End Get
        Set
            m_ImgUri = Value
        End Set
    End Property
    Private m_ImgUri As String
    Public Property PrizePerUnit() As Double
        Get
            Return m_PrizePerUnit
        End Get
        Set
            m_PrizePerUnit = Value
        End Set
    End Property
    Private m_PrizePerUnit As Double
    Public Property Quantity() As Integer
        Get
            Return m_Quantity
        End Get
        Set
            m_Quantity = Value
        End Set
    End Property
    Private m_Quantity As Integer
    Public Property Size() As Object
        Get
            Return m_Size
        End Get
        Set
            m_Size = Value
        End Set
    End Property
    Private m_Size As Object
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set
            m_Text = Value
        End Set
    End Property
    Private m_Text As String
    Public Property TotalPrize() As Double
        Get
            Return m_TotalPrize
        End Get
        Set
            m_TotalPrize = Value
        End Set
    End Property
    Private m_TotalPrize As Double
End Class
#End Region

#Region "Enums"
Enum SizeEnum
    Regular = 1
    Medium = 2
    Large = 3
End Enum
#End Region
