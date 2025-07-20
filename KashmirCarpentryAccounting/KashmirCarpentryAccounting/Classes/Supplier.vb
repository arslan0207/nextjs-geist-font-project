Namespace KashmirCarpentryAccounting.Classes
    Public Class Supplier
        Public Property SupplierID As Integer
        Public Property SupplierCode As String
        Public Property SupplierName As String
        Public Property ContactPerson As String
        Public Property Email As String
        Public Property Phone As String
        Public Property Address As String
        Public Property VATNumber As String
        Public Property IsActive As Boolean
        Public Property CreatedDate As DateTime

        Public Sub New()
            ' Default constructor
        End Sub

        Public Sub New(supplierCode As String, supplierName As String, contactPerson As String, email As String, phone As String, address As String, vatNumber As String)
            Me.SupplierCode = supplierCode
            Me.SupplierName = supplierName
            Me.ContactPerson = contactPerson
            Me.Email = email
            Me.Phone = phone
            Me.Address = address
            Me.VATNumber = vatNumber
            Me.IsActive = True
            Me.CreatedDate = DateTime.Now
        End Sub

        Public Overrides Function ToString() As String
            Return $"{SupplierName} ({SupplierCode})"
        End Function
    End Class
End Namespace
