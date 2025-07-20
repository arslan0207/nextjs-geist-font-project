Namespace KashmirCarpentryAccounting.Classes
    Public Class Customer
        Public Property CustomerID As Integer
        Public Property CustomerCode As String
        Public Property CustomerName As String
        Public Property ContactPerson As String
        Public Property Email As String
        Public Property Phone As String
        Public Property Address As String
        Public Property CreditLimit As Decimal
        Public Property VATNumber As String
        Public Property IsActive As Boolean
        Public Property CreatedDate As DateTime

        Public Sub New()
            ' Default constructor
        End Sub

        Public Sub New(customerCode As String, customerName As String, contactPerson As String, email As String, phone As String, address As String, creditLimit As Decimal, vatNumber As String)
            Me.CustomerCode = customerCode
            Me.CustomerName = customerName
            Me.ContactPerson = contactPerson
            Me.Email = email
            Me.Phone = phone
            Me.Address = address
            Me.CreditLimit = creditLimit
            Me.VATNumber = vatNumber
            Me.IsActive = True
            Me.CreatedDate = DateTime.Now
        End Sub

        Public Overrides Function ToString() As String
            Return $"{CustomerName} ({CustomerCode})"
        End Function
    End Class
End Namespace
