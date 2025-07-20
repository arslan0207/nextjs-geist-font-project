Imports System
Imports System.Windows.Forms

Namespace KashmirCarpentryAccounting
    Module Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()>
        Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New LoginForm())
        End Sub
    End Module
End Namespace
