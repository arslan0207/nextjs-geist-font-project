Imports System.Security.Cryptography
Imports System.Text

Namespace KashmirCarpentryAccounting.Modules
    Public Module Security
        ' Hash a password using SHA256
        Public Function HashPassword(password As String) As String
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
                Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
                Return Convert.ToBase64String(hashBytes)
            End Using
        End Function

        ' Verify password against hash
        Public Function VerifyPassword(password As String, hashedPassword As String) As Boolean
            Return HashPassword(password) = hashedPassword
        End Function

        ' Generate random password
        Public Function GenerateRandomPassword(length As Integer) As String
            Const validChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
            Dim random As New Random()
            Dim password As New StringBuilder()

            For i As Integer = 0 To length - 1
                password.Append(validChars(random.Next(validChars.Length)))
            Next

            Return password.ToString()
        End Function

        ' Validate password strength
        Public Function IsPasswordStrong(password As String) As Boolean
            If password.Length < 8 Then Return False
            If Not password.Any(Function(c) Char.IsUpper(c)) Then Return False
            If Not password.Any(Function(c) Char.IsLower(c)) Then Return False
            If Not password.Any(Function(c) Char.IsDigit(c)) Then Return False
            If Not password.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then Return False
            Return True
        End Function
    End Module
End Namespace
