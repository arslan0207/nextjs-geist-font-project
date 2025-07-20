@echo off
echo Setting up Kashmir Carpentry LLC Accounting Database...
echo.

REM Check if SQL Server is running
sqlcmd -S (LocalDB)\MSSQLLocalDB -Q "SELECT @@VERSION" >nul 2>&1
if %errorlevel% neq 0 (
    echo ERROR: SQL Server LocalDB is not running or not installed.
    echo Please install SQL Server LocalDB or start the SQL Server service.
    pause
    exit /b 1
)

REM Create database
sqlcmd -S (LocalDB)\MSSQLLocalDB -i CreateDatabase.sql
if %errorlevel% neq 0 (
    echo ERROR: Failed to create database.
    pause
    exit /b 1
)

REM Insert sample data
sqlcmd -S (LocalDB)\MSSQLLocalDB -d KashmirCarpentryDB -i InsertSampleData.sql
if %errorlevel% neq 0 (
    echo ERROR: Failed to insert sample data.
    pause
    exit /b 1
)

echo.
echo Database setup completed successfully!
echo.
echo Default login credentials:
echo Username: admin
echo Password: admin
echo.
echo Username: accountant
echo Password: accountant
echo.
echo Username: sales
echo Password: sales
echo.
pause
