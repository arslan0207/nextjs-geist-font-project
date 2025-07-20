Namespace KashmirCarpentryAccounting.Classes
    Public Class User
        Public Property UserID As Integer
        Public Property Username As String
        Public Property PasswordHash As String
        Public Property Role As String
        Public Property FullName As String
        Public Property Email As String
        Public Property Phone As String
        Public Property IsActive As Boolean
        Public Property CreatedDate As DateTime
        Public Property LastLoginDate As DateTime?

        Public Sub New()
            ' Default constructor
        End Sub

        Public Sub New(username As String, passwordHash As String, role As String, fullName As String, email As String, phone As String)
            Me.Username = username
            Me.PasswordHash = passwordHash
            Me.Role = role
            Me.FullName = fullName
            Me.Email = email
            Me.Phone = phone
            Me.IsActive = True
            Me.CreatedDate = DateTime.Now
        End Sub

        Public Overrides Function ToString() As String
            Return $"{FullName} ({Username}) - {Role}"
        End Function
    End Class
End Namespace
