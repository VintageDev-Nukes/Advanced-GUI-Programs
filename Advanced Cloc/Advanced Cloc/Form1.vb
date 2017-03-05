Imports System.Diagnostics

Public Class frmMain

    Dim OutputFile As String = System.IO.Path.GetTempPath & "File.txt"
    Dim WithEvents Proceso As New Process
    Dim pInfo As ProcessStartInfo

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Not TextBox1.Text.Equals(String.Empty) Then
            Analizar(TextBox1.Text)
        Else
            MsgBox("Debe seleccionar una carpeta antes de buscar", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub Analizar(ByVal Directory As String)

        pInfo = New ProcessStartInfo("cloc.bat", """" & Application.StartupPath & """ """ & Directory & """ """ & OutputFile & """")
        Proceso.EnableRaisingEvents = True
        pInfo.WindowStyle = ProcessWindowStyle.Hidden
        Proceso.StartInfo = pInfo
        Proceso.Start()

    End Sub

    Private Sub Acabado() Handles Proceso.Exited
        Process.Start(OutputFile)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' Configuración del FolderBrowserDialog
            With FolderBrowserDialog1

                .Reset() ' resetea

                ' leyenda
                .Description = " Seleccione la carpeta del proyecto a calcular "
                ' Path " Mis documentos "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' deshabilita el botón " crear nueva carpeta "
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop
                '.RootFolder = Environment.SpecialFolder.StartMenu

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = Windows.Forms.DialogResult.OK Then

                    TextBox1.Text = .SelectedPath

                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
