Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports KashmirCarpentryAccounting.Classes
Imports KashmirCarpentryAccounting.Modules

Namespace KashmirCarpentryAccounting.Forms
    Public Class CustomerForm
        Inherits Form

        Private WithEvents dgvCustomers As DataGridView
        Private WithEvents txtCustomerCode As TextBox
        Private WithEvents txtCustomerName As TextBox
        Private WithEvents txtContactPerson As TextBox
        Private WithEvents txtEmail As TextBox
        Private WithEvents txtPhone As TextBox
        Private WithEvents txtAddress As TextBox
        Private WithEvents txtCreditLimit As TextBox
        Private WithEvents txtVATNumber As TextBox
        Private WithEvents chkIsActive As CheckBox
        Private WithEvents btnSave As Button
        Private WithEvents btnNew As Button
        Private WithEvents btnDelete As Button
        Private WithEvents btnClose As Button
        Private WithEvents lblCustomerCode As Label
        Private WithEvents lblCustomerName As Label
        Private WithEvents lblContactPerson As Label
        Private WithEvents lblEmail As Label
        Private WithEvents lblPhone As Label
        Private WithEvents lblAddress As Label
        Private WithEvents lblCreditLimit As Label
        Private WithEvents lblVATNumber As Label
        Private WithEvents lblTitle As Label

        Private currentCustomerId As Integer = -1

        Public Sub New()
            InitializeComponent()
            Me.Text = "Customer Management - Kashmir Carpentry LLC"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            LoadCustomers()
        End Sub

        Private Sub InitializeComponent()
            ' Initialize components
            Me.dgvCustomers = New DataGridView()
            Me.txtCustomerCode = New TextBox()
            Me.txtCustomerName = New TextBox()
            Me.txtContactPerson = New TextBox()
            Me.txtEmail = New TextBox()
            Me.txtPhone = New TextBox()
            Me.txtAddress = New TextBox()
            Me.txtCreditLimit = New TextBox()
            Me.txtVATNumber = New TextBox()
            Me.chkIsActive = New CheckBox()
            Me.btnSave = New Button()
            Me.btnNew = New Button()
            Me.btnDelete = New Button()
            Me.btnClose = New Button()
            Me.lblCustomerCode = New Label()
            Me.lblCustomerName = New Label()
            Me.lblContactPerson = New Label()
            Me.lblEmail = New Label()
            Me.lblPhone = New Label()
            Me.lblAddress = New Label()
            Me.lblCreditLimit = New Label()
            Me.lblVATNumber = New Label()
            Me.lblTitle = New Label()
            CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()

            ' lblTitle
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New Drawing.Font("Microsoft Sans Serif", 14.0!, Drawing.FontStyle.Bold)
            Me.lblTitle.Location = New Drawing.Point(12, 9)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New Drawing.Size(200, 24)
            Me.lblTitle.Text = "Customer Management"

            ' dgvCustomers
            Me.dgvCustomers.AllowUserToAddRows = False
            Me.dgvCustomers.AllowUserToDeleteRows = False
            Me.dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvCustomers.Location = New Drawing.Point(12, 45)
            Me.dgvCustomers.Name = "dgvCustomers"
            Me.dgvCustomers.ReadOnly = True
            Me.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvCustomers.Size = New Drawing.Size(760, 200)

            ' lblCustomerCode
            Me.lblCustomerCode.AutoSize = True
            Me.lblCustomerCode.Location = New Drawing.Point(12, 260)
            Me.lblCustomerCode.Name = "lblCustomerCode"
            Me.lblCustomerCode.Size = New Drawing.Size(83, 13)
            Me.lblCustomerCode.Text = "Customer Code:"

            ' txtCustomerCode
            Me.txtCustomerCode.Location = New Drawing.Point(12, 276)
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.txtCustomerCode.Size = New Drawing.Size(150, 20)

            ' lblCustomerName
            Me.lblCustomerName.AutoSize = True
            Me.lblCustomerName.Location = New Drawing.Point(12, 306)
            Me.lblCustomerName.Name = "lblCustomerName"
            Me.lblCustomerName.Size = New Drawing.Size(85, 13)
            Me.lblCustomerName.Text = "Customer Name:"

            ' txtCustomerName
            Me.txtCustomerName.Location = New Drawing.Point(12, 322)
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.Size = New Drawing.Size(300, 20)

            ' lblContactPerson
            Me.lblContactPerson.AutoSize = True
            Me.lblContactPerson.Location = New Drawing.Point(12, 352)
            Me.lblContactPerson.Name = "lblContactPerson"
            Me.lblContactPerson.Size = New Drawing.Size(80, 13)
            Me.lblContactPerson.Text = "Contact Person:"

            ' txtContactPerson
            Me.txtContactPerson.Location = New Drawing.Point(12, 368)
            Me.txtContactPerson.Name = "txtContactPerson"
            Me.txtContactPerson.Size = New Drawing.Size(300, 20)

            ' lblEmail
            Me.lblEmail.AutoSize = True
            Me.lblEmail.Location = New Drawing.Point(330, 260)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New Drawing.Size(35, 13)
            Me.lblEmail.Text = "Email:"

            ' txtEmail
            Me.txtEmail.Location = New Drawing.Point(330, 276)
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.Size = New Drawing.Size(200, 20)

            ' lblPhone
            Me.lblPhone.AutoSize = True
            Me.lblPhone.Location = New Drawing.Point(330, 306)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New Drawing.Size(41, 13)
            Me.lblPhone.Text = "Phone:"

            ' txtPhone
            Me.txtPhone.Location = New Drawing.Point(330, 322)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New Drawing.Size(200, 20)

            ' lblAddress
            Me.lblAddress.AutoSize = True
            Me.lblAddress.Location = New Drawing.Point(330, 352)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New Drawing.Size(48, 13)
            Me.lblAddress.Text = "Address:"

            ' txtAddress
            Me.txtAddress.Location = New Drawing.Point(330, 368)
            Me.txtAddress.Multiline = True
            Me.txtAddress.Name = "txtAddress"
            Me.txtAddress.Size = New Drawing.Size(200, 60)

            ' lblCreditLimit
            Me.lblCreditLimit.AutoSize = True
            Me.lblCreditLimit.Location = New Drawing.Point(550, 260)
            Me.lblCreditLimit.Name = "lblCreditLimit"
            Me.lblCreditLimit.Size = New Drawing.Size(65, 13)
            Me.lblCreditLimit.Text = "Credit Limit:"

            ' txtCreditLimit
            Me.txtCreditLimit.Location = New Drawing.Point(550, 276)
            Me.txtCreditLimit.Name = "txtCreditLimit"
            Me.txtCreditLimit.Size = New Drawing.Size(150, 20)
            Me.txtCreditLimit.Text = "0.00"

            ' lblVATNumber
            Me.lblVATNumber.AutoSize = True
            Me.lblVATNumber.Location = New Drawing.Point(550, 306)
            Me.lblVATNumber.Name = "lblVATNumber"
            Me.lblVATNumber.Size = New Drawing.Size(68, 13)
            Me.lblVATNumber.Text = "VAT Number:"

            ' txtVATNumber
            Me.txtVATNumber.Location = New Drawing.Point(550, 322)
            Me.txtVATNumber.Name = "txtVATNumber"
            Me.txtVATNumber.Size = New Drawing.Size(150, 20)

            ' chkIsActive
            Me.chkIsActive.AutoSize = True
            Me.chkIsActive.Checked = True
            Me.chkIsActive.CheckState = CheckState.Checked
            Me.chkIsActive.Location = New Drawing.Point(550, 352)
            Me.chkIsActive.Name = "chkIsActive"
            Me.chkIsActive.Size = New Drawing.Size(67, 17)
            Me.chkIsActive.Text = "Is Active"

            ' btnSave
            Me.btnSave.Location = New Drawing.Point(550, 400)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New Drawing.Size(75, 23)
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True

            ' btnNew
            Me.btnNew.Location = New Drawing.Point(469, 400)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New Drawing.Size(75, 23)
            Me.btnNew.Text = "New"
            Me.btnNew.UseVisualStyleBackColor = True

            ' btnDelete
            Me.btnDelete.Location = New Drawing.Point(388, 400)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New Drawing.Size(75, 23)
            Me.btnDelete.Text = "Delete"
            Me.btnDelete.UseVisualStyleBackColor = True

            ' btnClose
            Me.btnClose.Location = New Drawing.Point(697, 400)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New Drawing.Size(75, 23)
            Me.btnClose.Text = "Close"
            Me.btnClose.UseVisualStyleBackColor = True

            ' CustomerForm
            Me.ClientSize = New Drawing.Size(784, 435)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnDelete)
            Me.Controls.Add(Me.btnNew)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.chkIsActive)
            Me.Controls.Add(Me.txtVATNumber)
            Me.Controls.Add(Me.lblVATNumber)
            Me.Controls.Add(Me.txtCreditLimit)
            Me.Controls.Add(Me.lblCreditLimit)
            Me.Controls.Add(Me.txtAddress)
            Me.Controls.Add(Me.lblAddress)
            Me.Controls.Add(Me.txtPhone)
            Me.Controls.Add(Me.lblPhone)
            Me.Controls.Add(Me.txtEmail)
            Me.Controls.Add(Me.lblEmail)
            Me.Controls.Add(Me.txtContactPerson)
            Me.Controls.Add(Me.lblContactPerson)
            Me.Controls.Add(Me.txtCustomerName)
            Me.Controls.Add(Me.lblCustomerName)
            Me.Controls.Add(Me.txtCustomerCode)
            Me.Controls.Add(Me.lblCustomerCode)
            Me.Controls.Add(Me.dgvCustomers)
            Me.Controls.Add(Me.lblTitle)
            Me.Name = "CustomerForm"
            Me.Text = "Customer Management"
            CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private Sub LoadCustomers()
            Try
                Dim query As String = "SELECT CustomerID, CustomerCode, CustomerName, ContactPerson, Email, Phone, Address, CreditLimit, VATNumber, IsActive FROM Customers ORDER BY CustomerName"
                Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, Nothing)
                dgvCustomers.DataSource = dt

                ' Configure DataGridView
                dgvCustomers.Columns("CustomerID").Visible = False
                dgvCustomers.Columns("CustomerCode").HeaderText = "Code"
                dgvCustomers.Columns("CustomerName").HeaderText = "Name"
                dgvCustomers.Columns("ContactPerson").HeaderText = "Contact"
                dgvCustomers.Columns("Email").HeaderText = "Email"
                dgvCustomers.Columns("Phone").HeaderText = "Phone"
                dgvCustomers.Columns("Address").HeaderText = "Address"
                dgvCustomers.Columns("CreditLimit").HeaderText = "Credit Limit"
                dgvCustomers.Columns("VATNumber").HeaderText = "VAT Number"
                dgvCustomers.Columns("IsActive").HeaderText = "Active"

                ' Auto-size columns
                dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ClearFields()
            currentCustomerId = -1
            txtCustomerCode.Clear()
            txtCustomerName.Clear()
            txtContactPerson.Clear()
            txtEmail.Clear()
            txtPhone.Clear()
            txtAddress.Clear()
            txtCreditLimit.Text = "0.00"
            txtVATNumber.Clear()
            chkIsActive.Checked = True
            txtCustomerCode.Focus()
        End Sub

        Private Sub LoadCustomerToForm(customerId As Integer)
            Try
                Dim query As String = "SELECT * FROM Customers WHERE CustomerID = @CustomerID"
                Dim parameters As SqlParameter() = {
                    New SqlParameter("@CustomerID", customerId)
                }

                Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
                If dt.Rows.Count > 0 Then
                    Dim row As DataRow = dt.Rows(0)
                    currentCustomerId = Convert.ToInt32(row("CustomerID"))
                    txtCustomerCode.Text = row("CustomerCode").ToString()
                    txtCustomerName.Text = row("CustomerName").ToString()
                    txtContactPerson.Text = If(row("ContactPerson") IsNot DBNull.Value, row("ContactPerson").ToString(), "")
                    txtEmail.Text = If(row("Email") IsNot DBNull.Value, row("Email").ToString(), "")
                    txtPhone.Text = If(row("Phone") IsNot DBNull.Value, row("Phone").ToString(), "")
                    txtAddress.Text = If(row("Address") IsNot DBNull.Value, row("Address").ToString(), "")
                    txtCreditLimit.Text = Convert.ToDecimal(row("CreditLimit")).ToString("0.00")
                    txtVATNumber.Text = If(row("VATNumber") IsNot DBNull.Value, row("VATNumber").ToString(), "")
                    chkIsActive.Checked = Convert.ToBoolean(row("IsActive"))
                End If
            Catch ex As Exception
                MessageBox.Show($"Error loading customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SaveCustomer()
            If Not ValidateInput() Then Return

            Try
                Dim customerCode As String = txtCustomerCode.Text.Trim()
                Dim customerName As String = txtCustomerName.Text.Trim()
                Dim contactPerson As String = txtContactPerson.Text.Trim()
                Dim email As String = txtEmail.Text.Trim()
                Dim phone As String = txtPhone.Text.Trim()
                Dim address As String = txtAddress.Text.Trim()
                Dim creditLimit As Decimal = Decimal.Parse(txtCreditLimit.Text)
                Dim vatNumber As String = txtVATNumber.Text.Trim()
                Dim isActive As Boolean = chkIsActive.Checked

                Dim query As String
                Dim parameters As SqlParameter()

                If currentCustomerId = -1 Then
                    ' Insert new customer
                    query = "INSERT INTO Customers (CustomerCode, CustomerName, ContactPerson, Email, Phone, Address, CreditLimit, VATNumber, IsActive, CreatedDate) " &
                            "VALUES (@CustomerCode, @CustomerName, @ContactPerson, @Email, @Phone, @Address, @CreditLimit, @VATNumber, @IsActive, GETDATE())"
                    parameters = {
                        New SqlParameter("@CustomerCode", customerCode),
                        New SqlParameter("@CustomerName", customerName),
                        New SqlParameter("@ContactPerson", If(String.IsNullOrEmpty(contactPerson), DBNull.Value, contactPerson)),
                        New SqlParameter("@Email", If(String.IsNullOrEmpty(email), DBNull.Value, email)),
                        New SqlParameter("@Phone", If(String.IsNullOrEmpty(phone), DBNull.Value, phone)),
                        New SqlParameter("@Address", If(String.IsNullOrEmpty(address), DBNull.Value, address)),
                        New SqlParameter("@CreditLimit", creditLimit),
                        New SqlParameter("@VATNumber", If(String.IsNullOrEmpty(vatNumber), DBNull.Value, vatNumber)),
                        New SqlParameter("@IsActive", isActive)
                    }
                Else
                    ' Update existing customer
                    query = "UPDATE Customers SET CustomerCode = @CustomerCode, CustomerName = @CustomerName, " &
                            "ContactPerson = @ContactPerson, Email = @Email, Phone = @Phone, Address = @Address, " &
                            "CreditLimit = @CreditLimit, VATNumber = @VATNumber, IsActive = @IsActive " &
                            "WHERE CustomerID = @CustomerID"
                    parameters = {
                        New SqlParameter("@CustomerCode", customerCode),
                        New SqlParameter("@CustomerName", customerName),
                        New SqlParameter("@ContactPerson", If(String.IsNullOrEmpty(contactPerson), DBNull.Value, contactPerson)),
                        New SqlParameter("@Email", If(String.IsNullOrEmpty(email), DBNull.Value, email)),
                        New SqlParameter("@Phone", If(String.IsNullOrEmpty(phone), DBNull.Value, phone)),
                        New SqlParameter("@Address", If(String.IsNullOrEmpty(address), DBNull.Value, address)),
                        New SqlParameter("@CreditLimit", creditLimit),
                        New SqlParameter("@VATNumber", If(String.IsNullOrEmpty(vatNumber), DBNull.Value, vatNumber)),
                        New SqlParameter("@IsActive", isActive),
                        New SqlParameter("@CustomerID", currentCustomerId)
                    }
                End If

                Dim rowsAffected As Integer = DatabaseConnection.ExecuteNonQuery(query, parameters)
                If rowsAffected > 0 Then
                    MessageBox.Show("Customer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCustomers()
                    ClearFields()
                Else
                    MessageBox.Show("Failed to save customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub DeleteCustomer()
            If currentCustomerId = -1 Then
                MessageBox.Show("Please select a customer to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    Dim query As String = "DELETE FROM Customers WHERE CustomerID = @CustomerID"
                    Dim parameters As SqlParameter() = {
                        New SqlParameter("@CustomerID", currentCustomerId)
                    }

                    Dim rowsAffected As Integer = DatabaseConnection.ExecuteNonQuery(query, parameters)
                    If rowsAffected > 0 Then
                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadCustomers()
                        ClearFields()
                    Else
                        MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Function ValidateInput() As Boolean
            If String.IsNullOrWhiteSpace(txtCustomerCode.Text) Then
                MessageBox.Show("Please enter customer code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerCode.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
                MessageBox.Show("Please enter customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerName.Focus()
                Return False
            End If

            If Not Decimal.TryParse(txtCreditLimit.Text, Nothing) Then
                MessageBox.Show("Please enter a valid credit limit amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCreditLimit.Focus()
                Return False
            End If

            Return True
        End Function

        ' Event handlers
        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            SaveCustomer()
        End Sub

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            ClearFields()
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            DeleteCustomer()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub dgvCustomers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellClick
            If e.RowIndex >= 0 Then
                Dim customerId As Integer = Convert.ToInt32(dgvCustomers.Rows(e.RowIndex).Cells("CustomerID").Value)
                LoadCustomerToForm(customerId)
            End If
        End Sub

        Private Sub txtCreditLimit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCreditLimit.KeyPress
            If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "." Then
                e.Handled = True
            End If
        End Sub
    End Class
End Namespace
