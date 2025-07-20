Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports KashmirCarpentryAccounting.Modules
Imports KashmirCarpentryAccounting.Classes

Namespace KashmirCarpentryAccounting.Forms
    Public Class LoginForm
        Inherits Form

        Private WithEvents txtUsername As TextBox
        Private WithEvents txtPassword As TextBox
        Private WithEvents btnLogin As Button
        Private WithEvents btnCancel As Button
        Private WithEvents lblUsername As Label
        Private WithEvents lblPassword As Label
        Private WithEvents lblTitle As Label

        Public Sub New()
            InitializeComponent()
            Me.Text = "Kashmir Carpentry LLC - Login"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
        End Sub

        Private Sub InitializeComponent()
            ' Initialize components
            Me.lblTitle = New Label()
            Me.lblUsername = New Label()
            Me.lblPassword = New Label()
            Me.txtUsername = New TextBox()
            Me.txtPassword = New TextBox()
            Me.btnLogin = New Button()
            Me.btnCancel = New Button()

            ' lblTitle
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New Drawing.Font("Microsoft Sans Serif", 14.0!, Drawing.FontStyle.Bold)
            Me.lblTitle.Location = New Drawing.Point(12, 9)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New Drawing.Size(280, 24)
            Me.lblTitle.Text = "Kashmir Carpentry LLC Login"

            ' lblUsername
            Me.lblUsername.AutoSize = True
            Me.lblUsername.Location = New Drawing.Point(12, 50)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New Drawing.Size(58, 13)
            Me.lblUsername.Text = "Username:"

            ' txtUsername
            Me.txtUsername.Location = New Drawing.Point(12, 66)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New Drawing.Size(280, 20)

            ' lblPassword
            Me.lblPassword.AutoSize = True
            Me.lblPassword.Location = New Drawing.Point(12, 92)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New Drawing.Size(56, 13)
            Me.lblPassword.Text = "Password:"

            ' txtPassword
            Me.txtPassword.Location = New Drawing.Point(12, 108)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = "*"c
            Me.txtPassword.Size = New Drawing.Size(280, 20)

            ' btnLogin
            Me.btnLogin.Location = New Drawing.Point(12, 140)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New Drawing.Size(75, 23)
            Me.btnLogin.Text = "Login"
            Me.btnLogin.UseVisualStyleBackColor = True

            ' btnCancel
            Me.btnCancel.Location = New Drawing.Point(217, 140)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New Drawing.Size(75, 23)
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True

            ' LoginForm
            Me.ClientSize = New Drawing.Size(304, 181)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnLogin)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.lblPassword)
            Me.Controls.Add(Me.txtUsername)
            Me.Controls.Add(Me.lblUsername)
            Me.Controls.Add(Me.lblTitle)
            Me.Name = "LoginForm"
            Me.Text = "Login"
        End Sub

        Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                Dim user As User = AuthenticateUser(txtUsername.Text, txtPassword.Text)
                If user IsNot Nothing Then
                    MessageBox.Show($"Welcome {user.FullName}!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    
                    ' Update last login
                    UpdateLastLogin(user.UserID)
                    
                    ' Open main form
                    Dim mainForm As New MainForm(user)
                    mainForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Application.Exit()
        End Sub

        Private Function AuthenticateUser(username As String, password As String) As User
            Dim query As String = "SELECT UserID, Username, Role, FullName, Email, Phone, IsActive FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash AND IsActive = 1"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@Username", username),
                New SqlParameter("@PasswordHash", password) ' In real implementation, use hashed passwords
            }

            Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Return New User() With {
                    .UserID = Convert.ToInt32(row("UserID")),
                    .Username = row("Username").ToString(),
                    .Role = row("Role").ToString(),
                    .FullName = row("FullName").ToString(),
                    .Email = If(row("Email") IsNot DBNull.Value, row("Email").ToString(), ""),
                    .Phone = If(row("Phone") IsNot DBNull.Value, row("Phone").ToString(), ""),
                    .IsActive = Convert.ToBoolean(row("IsActive"))
                }
            End If
            Return Nothing
        End Function

        Private Sub UpdateLastLogin(userId As Integer)
            Dim query As String = "UPDATE Users SET LastLoginDate = GETDATE() WHERE UserID = @UserID"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@UserID", userId)
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)
        End Sub
    End Class
End Namespace
