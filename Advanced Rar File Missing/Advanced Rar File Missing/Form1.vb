Imports System.Diagnostics

Public Class frmMain

    Private ReadOnly OutputFile As String = IO.Path.GetTempFileName

    Private pInfo As ProcessStartInfo = New ProcessStartInfo
    Dim WithEvents Proceso As New Process

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With OpenFileDialog1

            .Reset() ' resetea  


            Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

            ' si se presionó el botón aceptar ...  
            If ret = Windows.Forms.DialogResult.OK Then

                Dim str_result As String = .InitialDirectory & .FileName

                TextBox1.Text = str_result

            End If

            .Dispose()

        End With

    End Sub

    Private Sub Analizar(ByVal File As String)

        With pInfo
            .FileName = "Proyecto1.exe"
            .Arguments = String.Format("{0} {1} {2} --out={3}", File, "Listar", Convert.ToInt32(CheckBox1.Checked), Me.OutputFile)
            .CreateNoWindow = True
            .UseShellExecute = False
            '.RedirectStandardOutput = True
            '.RedirectStandardError = True
        End With

        With Proceso
            .EnableRaisingEvents = True
            .StartInfo = pInfo
        End With

        Proceso.Start()

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Not TextBox1.Text.Equals(String.Empty) Then
            Analizar(TextBox1.Text)
        Else
            MsgBox("Debe introducir un archivo para poder ejecutar la aplicación correctamente", MsgBoxStyle.Critical, "Error")
        End If

    End Sub
End Class
