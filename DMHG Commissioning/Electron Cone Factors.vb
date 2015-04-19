Public Class Form_ECF

    Private Sub Electron_Cone_Factors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button_Back_Click(sender As Object, e As EventArgs) Handles Button_Back.Click
        DataToCollect.Show()
        Me.Close()
    End Sub

    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Dim ExitYN As System.Windows.Forms.DialogResult
        ExitYN = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)
        If ExitYN = MsgBoxResult.Yes Then
            Application.Exit()
            End
        Else
        End If
    End Sub
End Class