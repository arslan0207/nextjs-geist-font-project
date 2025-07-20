Imports System.Data.SqlClient
Imports KashmirCarpentryAccounting.Classes

Namespace KashmirCarpentryAccounting.Modules
    Public Module CustomerManager
        ' Get all customers
        Public Function GetAllCustomers() As DataTable
            Dim query As String = "SELECT CustomerID, CustomerCode, CustomerName, ContactPerson, Email, Phone, Address, CreditLimit, VATNumber, IsActive FROM Customers ORDER BY CustomerName"
            Return DatabaseConnection.ExecuteQuery(query, Nothing)
        End Function

        ' Get customer by ID
        Public Function GetCustomerById(customerId As Integer) As Customer
            Dim query As String = "SELECT * FROM Customers WHERE CustomerID = @CustomerID"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@CustomerID", customerId)
            }

            Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Return New Customer() With {
                    .CustomerID = Convert.ToInt32(row("CustomerID")),
                    .CustomerCode = row("CustomerCode").ToString(),
                    .CustomerName = row("CustomerName").ToString(),
                    .ContactPerson = If(row("ContactPerson") IsNot DBNull.Value, row("ContactPerson").ToString(), ""),
                    .Email = If(row("Email") IsNot DBNull.Value, row("Email").ToString(), ""),
                    .Phone = If(row("Phone") IsNot DBNull.Value, row("Phone").ToString(), ""),
                    .Address = If(row("Address") IsNot DBNull.Value, row("Address").ToString(), ""),
                    .CreditLimit = Convert.ToDecimal(row("CreditLimit")),
                    .VATNumber = If(row("VATNumber") IsNot DBNull.Value, row("VATNumber").ToString(), ""),
                    .IsActive = Convert.ToBoolean(row("IsActive")),
                    .CreatedDate = Convert.ToDateTime(row("CreatedDate"))
                }
            End If
            Return Nothing
        End Function

        ' Get customer by code
        Public Function GetCustomerByCode(customerCode As String) As Customer
            Dim query As String = "SELECT * FROM Customers WHERE CustomerCode = @CustomerCode"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@CustomerCode", customerCode)
            }

            Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Return New Customer() With {
                    .CustomerID = Convert.ToInt32(row("CustomerID")),
                    .CustomerCode = row("CustomerCode").ToString(),
                    .CustomerName = row("CustomerName").ToString(),
                    .ContactPerson = If(row("ContactPerson") IsNot DBNull.Value, row("ContactPerson").ToString(), ""),
                    .Email = If(row("Email") IsNot DBNull.Value, row("Email").ToString(), ""),
                    .Phone = If(row("Phone") IsNot DBNull.Value, row("Phone").ToString(), ""),
                    .Address = If(row("Address") IsNot DBNull.Value, row("Address").ToString(), ""),
                    .CreditLimit = Convert.ToDecimal(row("CreditLimit")),
                    .VATNumber = If(row("VATNumber") IsNot DBNull.Value, row("VATNumber").ToString(), ""),
                    .IsActive = Convert.ToBoolean(row("IsActive")),
                    .CreatedDate = Convert.ToDateTime(row("CreatedDate"))
                }
            End If
            Return Nothing
        End Function

        ' Search customers
        Public Function SearchCustomers(searchTerm As String) As DataTable
            Dim query As String = "SELECT CustomerID, CustomerCode, CustomerName, ContactPerson, Email, Phone, Address, CreditLimit, VATNumber, IsActive " &
                                "FROM Customers WHERE CustomerCode LIKE @SearchTerm OR CustomerName LIKE @SearchTerm OR ContactPerson LIKE @SearchTerm " &
                                "ORDER BY CustomerName"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@SearchTerm", "%" & searchTerm & "%")
            }
            Return DatabaseConnection.ExecuteQuery(query, parameters)
        End Function

        ' Get customer balance
