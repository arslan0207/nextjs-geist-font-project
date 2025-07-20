Namespace KashmirCarpentryAccounting.Classes
    Public Class Product
        Public Property ProductID As Integer
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property Category As String
        Public Property Description As String
        Public Property UnitPrice As Decimal
        Public Property CostPrice As Decimal
        Public Property ReorderLevel As Integer
        Public Property CurrentStock As Integer
        Public Property IsActive As Boolean
        Public Property CreatedDate As DateTime

        Public Sub New()
            ' Default constructor
        End Sub

        Public Sub New(productCode As String, productName As String, category As String, description As String, unitPrice As Decimal, costPrice As Decimal, reorderLevel As Integer, currentStock As Integer)
            Me.ProductCode = productCode
            Me.ProductName = productName
            Me.Category = category
            Me.Description = description
            Me.UnitPrice = unitPrice
            Me.CostPrice = costPrice
            Me.ReorderLevel = reorderLevel
            Me.CurrentStock = currentStock
            Me.IsActive = True
            Me.CreatedDate = DateTime.Now
        End Sub

        Public ReadOnly Property StockValue As Decimal
            Get
                Return CurrentStock * CostPrice
            End Get
        End Property

        Public ReadOnly Property IsLowStock As Boolean
            Get
                Return CurrentStock <= ReorderLevel
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{ProductName} ({ProductCode})"
        End Function
    End Class
End Namespace
