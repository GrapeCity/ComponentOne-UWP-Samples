Imports Windows.UI

Public Class SampleViewModel
    Private _data As List(Of DataItem)
    Private _cosData As List(Of DataItem)

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = New List(Of DataItem)()
                _data.Add(New DataItem() With {.X = 1, .Y = 50})
                _data.Add(New DataItem() With {.X = 2, .Y = 30})
                _data.Add(New DataItem() With {.X = 3, .Y = 40})
                _data.Add(New DataItem() With {.X = 4, .Y = 60})
                _data.Add(New DataItem() With {.X = 5, .Y = 90})
                _data.Add(New DataItem() With {.X = 6, .Y = 80})
                _data.Add(New DataItem() With {.X = 7, .Y = 56})
                _data.Add(New DataItem() With {.X = 8, .Y = 56})
                _data.Add(New DataItem() With {.X = 9, .Y = 50})
                _data.Add(New DataItem() With {.X = 10, .Y = 70})
            End If
            Return _data
        End Get
    End Property

    Public ReadOnly Property CosData() As List(Of DataItem)
        Get
            If _cosData Is Nothing Then
                _cosData = New List(Of DataItem)()
                Dim i As Integer = 1
                While i < 300
                    _cosData.Add(New DataItem() With {
                        .X = 0.16 * i, .Y = Math.Cos(0.12 * i)
                    })
                    i += 1
                End While
            End If

            Return _cosData
        End Get
    End Property

    Public Shared ReadOnly Property SmartPhoneVendors() As List(Of SmartPhoneVendor)
        Get
            Dim vendors As List(Of SmartPhoneVendor) = New List(Of SmartPhoneVendor)()
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "Apple",
                    .Color = Color.FromArgb(255, 136, 189, 230),
                    .Shipments = 215.2
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "Huawei",
                    .Color = Color.FromArgb(255, 251, 178, 88),
                    .Shipments = 139
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "Lenovo",
                    .Color = Color.FromArgb(255, 144, 205, 151),
                    .Shipments = 50.7
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "LG",
                    .Color = Color.FromArgb(255, 246, 170, 201),
                    .Shipments = 55.1
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "Oppo",
                    .Color = Color.FromArgb(255, 191, 165, 84),
                    .Shipments = 92.5
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "Samsung",
                    .Color = Color.FromArgb(255, 188, 153, 199),
                    .Shipments = 310.3
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "Vivo",
                    .Color = Color.FromArgb(255, 237, 221, 70),
                    .Shipments = 71.7
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "Xiaomi",
                    .Color = Color.FromArgb(255, 240, 126, 110),
                    .Shipments = 61
                })
            vendors.Add(New SmartPhoneVendor() With
                {
                    .Name = "ZTE",
                    .Color = Color.FromArgb(255, 140, 140, 140),
                    .Shipments = 61.9
                })

            Return vendors
        End Get
    End Property

    Public Shared ReadOnly Property USStatesTemperatureRecords() As List(Of TemperatureRecord)
        Get
            Dim records As List(Of TemperatureRecord) = New List(Of TemperatureRecord)()
            records.Add(New TemperatureRecord() With {.Place = "Alabama", .High = 112})
            records.Add(New TemperatureRecord() With {.Place = "Alaska", .High = 100})
            records.Add(New TemperatureRecord() With {.Place = "Arizona", .High = 128})
            records.Add(New TemperatureRecord() With {.Place = "Arkansas", .High = 120})
            records.Add(New TemperatureRecord() With {.Place = "California", .High = 134})
            records.Add(New TemperatureRecord() With {.Place = "Colorado", .High = 114})
            records.Add(New TemperatureRecord() With {.Place = "Connecticut", .High = 106})
            records.Add(New TemperatureRecord() With {.Place = "Delaware", .High = 110})
            records.Add(New TemperatureRecord() With {.Place = "District of Columbia", .High = 106})
            records.Add(New TemperatureRecord() With {.Place = "Florida", .High = 109})
            records.Add(New TemperatureRecord() With {.Place = "Georgia", .High = 112})
            records.Add(New TemperatureRecord() With {.Place = "Hawaii", .High = 98})
            records.Add(New TemperatureRecord() With {.Place = "Idaho", .High = 118})
            records.Add(New TemperatureRecord() With {.Place = "Illinois", .High = 117})
            records.Add(New TemperatureRecord() With {.Place = "Indiana", .High = 116})
            records.Add(New TemperatureRecord() With {.Place = "Iowa", .High = 118})
            records.Add(New TemperatureRecord() With {.Place = "Kansas", .High = 121})
            records.Add(New TemperatureRecord() With {.Place = "Kentucky", .High = 114})
            records.Add(New TemperatureRecord() With {.Place = "Louisiana", .High = 114})
            records.Add(New TemperatureRecord() With {.Place = "Maine", .High = 105})
            records.Add(New TemperatureRecord() With {.Place = "Maryland", .High = 109})
            records.Add(New TemperatureRecord() With {.Place = "Massachusetts", .High = 107})
            records.Add(New TemperatureRecord() With {.Place = "Michigan", .High = 112})
            records.Add(New TemperatureRecord() With {.Place = "Minnesota", .High = 115})
            records.Add(New TemperatureRecord() With {.Place = "Mississippi", .High = 115})
            records.Add(New TemperatureRecord() With {.Place = "Missouri", .High = 118})
            records.Add(New TemperatureRecord() With {.Place = "Montana", .High = 117})
            records.Add(New TemperatureRecord() With {.Place = "Nebraska", .High = 118})
            records.Add(New TemperatureRecord() With {.Place = "Nevada", .High = 125})
            records.Add(New TemperatureRecord() With {.Place = "New Hampshire", .High = 106})
            records.Add(New TemperatureRecord() With {.Place = "New Jersey", .High = 110})
            records.Add(New TemperatureRecord() With {.Place = "New Mexico", .High = 122})
            records.Add(New TemperatureRecord() With {.Place = "New York", .High = 109})
            records.Add(New TemperatureRecord() With {.Place = "North Carolina", .High = 110})
            records.Add(New TemperatureRecord() With {.Place = "North Dakota", .High = 121})
            records.Add(New TemperatureRecord() With {.Place = "Ohio", .High = 113})
            records.Add(New TemperatureRecord() With {.Place = "Oklahoma", .High = 120})
            records.Add(New TemperatureRecord() With {.Place = "Oregon", .High = 117})
            records.Add(New TemperatureRecord() With {.Place = "Pennsylvania", .High = 111})
            records.Add(New TemperatureRecord() With {.Place = "Rhode Island", .High = 104})
            records.Add(New TemperatureRecord() With {.Place = "South Carolina", .High = 113})
            records.Add(New TemperatureRecord() With {.Place = "South Dakota", .High = 120})
            records.Add(New TemperatureRecord() With {.Place = "Tennessee", .High = 113})
            records.Add(New TemperatureRecord() With {.Place = "Texas", .High = 120})
            records.Add(New TemperatureRecord() With {.Place = "Utah", .High = 117})
            records.Add(New TemperatureRecord() With {.Place = "Vermont", .High = 105})
            records.Add(New TemperatureRecord() With {.Place = "Virginia", .High = 110})
            records.Add(New TemperatureRecord() With {.Place = "Washington", .High = 118})
            records.Add(New TemperatureRecord() With {.Place = "West Virginia", .High = 112})
            records.Add(New TemperatureRecord() With {.Place = "Wisconsin", .High = 114})
            records.Add(New TemperatureRecord() With {.Place = "Wyoming", .High = 115})
            Return records
        End Get
    End Property

End Class