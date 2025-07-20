# Kashmir Carpentry LLC Accounting Software

## Project Overview
A comprehensive accounting software solution tailored specifically for Kashmir Carpentry LLC, built using Visual Basic .NET with SQL Server database backend.

## Features Implemented
- ✅ User Management System
- ✅ Database Connection Module
- ✅ Basic Project Structure
- ✅ Login System
- ✅ Database Schema Design

## Project Structure
```
KashmirCarpentryAccounting/
├── KashmirCarpentryAccounting.sln
├── KashmirCarpentryAccounting/
│   ├── KashmirCarpentryAccounting.vbproj
│   ├── Program.vb
│   ├── App.config
│   ├── Forms/
│   │   ├── LoginForm.vb
│   │   └── MainForm.vb
│   ├── Modules/
│   │   └── DatabaseConnection.vb
│   ├── Classes/
│   │   ├── User.vb
│   │   ├── Customer.vb
│   │   ├── Supplier.vb
│   │   ├── Product.vb
│   │   └── Transaction.vb
│   └── Resources/
├── Database/
│   ├── CreateDatabase.sql
│   └── KashmirCarpentryDB.mdf
└── README.md
```

## Database Schema
The database includes:
- **Users**: User management and authentication
- **ChartOfAccounts**: Complete chart of accounts
- **Customers**: Customer management
- **Suppliers**: Supplier management
- **Products**: Product and inventory management
- **SalesInvoices**: Sales invoice processing
- **PurchaseOrders**: Purchase order management
- **BankAccounts**: Bank account management
- **BankTransactions**: Transaction tracking
- **VATTransactions**: VAT management
- **AuditLog**: Audit trail

## Getting Started

### Prerequisites
- Visual Studio 2022 or later
- .NET Framework 4.8
- SQL Server Express or LocalDB

### Setup Instructions
1. Open the solution file `KashmirCarpentryAccounting.sln` in Visual Studio
2. Run the database creation script `CreateDatabase.sql` in SQL Server
3. Build and run the project
4. Use the login form to access the system

### Configuration
The connection string is configured in `App.config`:
```xml
<connectionStrings>
    <add name="KashmirCarpentryDB" 
         connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\KashmirCarpentryDB.mdf;Integrated Security=True" />
</connectionStrings>
```

## Next Steps
1. Implement the remaining forms (MainForm, Dashboard, etc.)
2. Add business logic for accounting operations
3. Implement reporting functionality
4. Add tax calculation modules
5. Create inventory management features
6. Add backup and security features

## Development Status
- ✅ Project structure created
- ✅ Database schema designed
- ✅ Basic classes implemented
- ✅ Database connection module
- ✅ Login form created
- 🔄 Ready for business logic implementation
