Imports SaImServer.localhost

Public Class frmRegister

    Private Sub cmdRegister_Click(sender As System.Object, e As System.EventArgs) Handles cmdRegister.Click
        Dim iCode As Integer
        iCode = confarmation()
        If iCode = 0 Then


            Dim webServiceSaIm As New InstMsgServ()
            Dim iResult As Integer
            iResult = webServiceSaIm.Register(txtLogin.Text, txtPass.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, txtBirtDay.Text, txtCity.Text, txtProfession.Text)
            Select Case iResult
                Case 0
                    MsgBox(" The user have been add", MsgBoxStyle.OkOnly, "Register sucsess")
                    IMstatusBar.Text = "Register sucsess"
                    Exit Select
                Case 1
                    MsgBox(" user with the requested login name already exist", MsgBoxStyle.OkOnly, "Error")
                    IMstatusBar.Text = "Error, a user with the requested login name already exist"
                    Exit Select
                Case -1
                    MsgBox(" please check IIS web service or database", MsgBoxStyle.OkOnly, "Error")
                    IMstatusBar.Text = "Error, a user with the requested login name already exist"
                    Exit Select
            End Select
            webServiceSaIm = Nothing
            iResult = 0
        End If
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Hide()
    End Sub

    Private Function confarmation() As Integer
        If txtLogin.Text.Trim() = "" Then
            MessageBox.Show("Login can't be empty")
            txtLogin.Focus()
            Return -1
        End If
        If txtPass.Text.Trim() = "" Then
            MessageBox.Show("Password can't be empty")
            txtPass.Focus()
            Return -1
        End If
        If txtConfirmPass.Text.Trim() = "" Then
            MessageBox.Show("Confirm Password can't be empty")
            txtConfirmPass.Focus()
            Return -1
        End If
        If txtPass.Text.CompareTo(txtConfirmPass.Text) <> 0 Then
            MessageBox.Show("Password mismatch")
            txtPass.Focus()
            Return -1
        End If
        Return 0
    End Function
End Class