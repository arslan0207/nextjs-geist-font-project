Imports System.Windows.Forms
Imports KashmirCarpentryAccounting.Classes

Namespace KashmirCarpentryAccounting.Forms
    Public Class MainForm
        Inherits Form

        Private currentUser As User
        Private WithEvents menuStrip As MenuStrip
        Private WithEvents statusStrip As StatusStrip
        Private WithEvents lblWelcome As Label
        Private WithEvents lblDate As Label
        Private WithEvents lblTime As Label
        Private WithEvents timer As Timer

        Public Sub New(user As User)
            InitializeComponent()
            Me.currentUser = user
            Me.Text = $"Kashmir Carpentry LLC - Welcome {user.FullName}"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.WindowState = FormWindowState.Maximized
            SetupMenu()
            SetupStatusBar()
            SetupTimer()
        End Sub

        Private Sub InitializeComponent()
            Me.lblWelcome = New Label()
            Me.lblDate = New Label()
            Me.lblTime = New Label()
            Me.SuspendLayout()

            ' lblWelcome
            Me.lblWelcome.AutoSize = True
            Me.lblWelcome.Font = New Drawing.Font("Microsoft Sans Serif", 16.0!, Drawing.FontStyle.Bold)
            Me.lblWelcome.Location = New Drawing.Point(12, 9)
            Me.lblWelcome.Name = "lblWelcome"
            Me.lblWelcome.Size = New Drawing.Size(400, 26)
            Me.lblWelcome.Text = "Welcome to Kashmir Carpentry LLC"

            ' lblDate
            Me.lblDate.AutoSize = True
            Me.lblDate.Font = New Drawing.Font("Microsoft Sans Serif", 12.0!)
            Me.lblDate.Location = New Drawing.Point(12, 50)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New Drawing.Size(200, 20)

            ' lblTime
            Me.lblTime.AutoSize = True
            Me.lblTime.Font = New Drawing.Font("Microsoft Sans Serif", 12.0!)
            Me.lblTime.Location = New Drawing.Point(12, 80)
            Me.lblTime.Name = "lblTime"
            Me.lblTime.Size = New Drawing.Size(200, 20)

            ' MainForm
            Me.ClientSize = New Drawing.Size(800, 600)
            Me.Controls.Add(Me.lblTime)
            Me.Controls.Add(Me.lblDate)
            Me.Controls.Add(Me.lblWelcome)
            Me.Name = "MainForm"
            Me.Text = "Kashmir Carpentry LLC"
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private Sub SetupMenu()
            menuStrip = New MenuStrip()

            ' File Menu
            Dim fileMenu As New ToolStripMenuItem("File")
            fileMenu.DropDownItems.Add("Exit", Nothing, AddressOf ExitApplication)

            ' Master Data Menu
            Dim masterMenu As New ToolStripMenuItem("Master Data")
            masterMenu.DropDownItems.Add("Customers", Nothing, AddressOf OpenCustomers)
            masterMenu.DropDownItems.Add("Suppliers", Nothing, AddressOf OpenSuppliers)
            masterMenu.DropDownItems.Add("Products", Nothing, AddressOf OpenProducts)
            masterMenu.DropDownItems.Add("Chart of Accounts", Nothing, AddressOf OpenChartOfAccounts)

            ' Transactions Menu
            Dim transactionsMenu As New ToolStripMenuItem("Transactions")
            transactionsMenu.DropDownItems.Add("Sales Invoice", Nothing, AddressOf OpenSalesInvoice)
            transactionsMenu.DropDownItems.Add("Purchase Order", Nothing, AddressOf OpenPurchaseOrder)
            transactionsMenu.DropDownItems.Add("Bank Transactions", Nothing, AddressOf OpenBankTransactions)

            ' Reports Menu
            Dim reportsMenu As New ToolStripMenuItem("Reports")
            reportsMenu.DropDownItems.Add("Sales Report", Nothing, AddressOf OpenSalesReport)
            reportsMenu.DropDownItems.Add("Purchase Report", Nothing, AddressOf OpenPurchaseReport)
            reportsMenu.DropDownItems.Add("VAT Report", Nothing, AddressOf OpenVATReport)
            reportsMenu.DropDownItems.Add("Profit & Loss", Nothing, AddressOf OpenProfitLossReport)

            ' User Management Menu (Admin only)
            If currentUser.Role = "Admin" Then
                Dim userMenu As New ToolStripMenuItem("User Management")
                userMenu.DropDownItems.Add("Users", Nothing, AddressOf OpenUserManagement)
                menuStrip.Items.Add(userMenu)
            End If

            ' Add menus to menu strip
            menuStrip.Items.AddRange(New ToolStripItem() {fileMenu, masterMenu, transactionsMenu, reportsMenu})

            Me.MainMenuStrip = menuStrip
            Me.Controls.Add(menuStrip)
        End Sub

        Private Sub SetupStatusBar()
            statusStrip = New StatusStrip()
            Dim statusLabel As New ToolStripStatusLabel($"Logged in as: {currentUser.FullName} ({currentUser.Role})")
            statusStrip.Items.Add(statusLabel)
            Me.Controls.Add(statusStrip)
        End Sub

        Private Sub SetupTimer()
            timer = New Timer()
            timer.Interval = 1000 ' 1 second
            AddHandler timer.Tick, AddressOf UpdateDateTime
            timer.Start()
            UpdateDateTime(Nothing, Nothing)
        End Sub

        Private Sub UpdateDateTime(sender As Object, e As EventArgs)
            lblDate.Text = $"Date: {DateTime.Now.ToString("dd/MM/yyyy")}"
            lblTime.Text = $"Time: {DateTime.Now.ToString("HH:mm:ss")}"
        End Sub

        ' Menu event handlers
        Private Sub ExitApplication(sender As Object, e As EventArgs)
            If MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        Private Sub OpenCustomers(sender As Object, e As EventArgs)
            MessageBox.Show("Customer management form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenSuppliers(sender As Object, e As EventArgs)
            MessageBox.Show("Supplier management form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenProducts(sender As Object, e As EventArgs)
            MessageBox.Show("Product management form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenChartOfAccounts(sender As Object, e As EventArgs)
            MessageBox.Show("Chart of accounts form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenSalesInvoice(sender As Object, e As EventArgs)
            MessageBox.Show("Sales invoice form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenPurchaseOrder(sender As Object, e As EventArgs)
            MessageBox.Show("Purchase order form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenBankTransactions(sender As Object, e As EventArgs)
            MessageBox.Show("Bank transactions form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenSalesReport(sender As Object, e As EventArgs)
            MessageBox.Show("Sales report will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenPurchaseReport(sender As Object, e As EventArgs)
            MessageBox.Show("Purchase report will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenVATReport(sender As Object, e As EventArgs)
            MessageBox.Show("VAT report will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenProfitLossReport(sender As Object, e As EventArgs)
            MessageBox.Show("Profit & Loss report will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OpenUserManagement(sender As Object, e As EventArgs)
            MessageBox.Show("User management form will open here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
            If e.CloseReason = CloseReason.UserClosing Then
                If MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Application.Restart()
                Else
                    e.Cancel = True
                End If
            End If
            MyBase.OnFormClosing(e)
        End Sub
    End Class
End Namespace
