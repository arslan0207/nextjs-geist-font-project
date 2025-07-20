Namespace KashmirCarpentryAccounting.Classes
    Public Class Transaction
        Public Property TransactionID As Integer
        Public Property TransactionNumber As String
        Public Property TransactionDate As DateTime
        Public Property TransactionType As String
        Public Property Description As String
        Public Property Amount As Decimal
        Public Property VATRate As Decimal
        Public Property VATAmount As Decimal
        Public Property TotalAmount As Decimal
        Public Property CreatedBy As Integer
        Public Property CreatedDate As DateTime

        Public Sub New()
            ' Default constructor
        End Sub

        Public Sub New(transactionNumber As String, transactionDate As DateTime, transactionType As String, description As String, amount As Decimal, vatRate As Decimal)
            Me.TransactionNumber = transactionNumber
            Me.TransactionDate = transactionDate
            Me.TransactionType = transactionType
            Me.Description = description
            Me.Amount = amount
            Me.VATRate = vatRate
            Me.VATAmount = Math.Round(amount * vatRate / 100, 2)
            Me.TotalAmount = amount + VATAmount
            Me.CreatedDate = DateTime.Now
        End Sub

        Public ReadOnly Property TotalWithVAT As Decimal
            Get
                Return Amount + VATAmount
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{TransactionNumber} - {TransactionType} - {TotalAmount:C}"
        End Function
    End Class
End Namespace
