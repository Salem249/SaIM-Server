Imports SaImServer.localhost

Public Class frmUnRegister
    Dim webServiceSaIm As New InstMsgServ()
    Private Sub cmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmdSearch.Click

        Dim strResult As String
        Dim strParam As String()
        Dim icode As Integer

        strResult = webServiceSaIm.Search(txtLogin.Text)

        strParam = New [String](strResult.Length - 1) {}

        icode = confarmation()
        If icode = 0 Then
            If strResult <> "1" Then
                cmdUnRegister.Enabled = True
                For i = 0 To strResult.Length - 1
                    If strResult.Length <> 0 Then
                        strParam(i) = strResult.Substring(0, strResult.IndexOf("-"))
                        strResult = strResult.Remove(0, strResult.IndexOf("-") + 1)
                    End If
                    txtAddress.Text = strParam(0)
                    txtPhone.Text = strParam(1)
                    txtEmail.Text = strParam(2)
                    txtCity.Text = strParam(3)
                    txtBirthDay.Text = strParam(4)
                    txtProfession.Text = strParam(5)
                Next
            Else
                MsgBox(" user doesn't exist", MsgBoxStyle.OkOnly, "Error")
                IMstatusBar.Text = "Error, user doesn't exist"
            End If


        End If
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Hide()
    End Sub

    Private Sub cmdUnRegister_Click(sender As System.Object, e As System.EventArgs) Handles cmdUnRegister.Click
        Dim iResult As Integer
        iResult = webServiceSaIm.Unregister(txtLogin.Text)
        Select Case iResult
            Case 0
                MsgBox(" The user have been deleted", MsgBoxStyle.OkOnly, "delete")
                IMstatusBar.Text = "delete sucsess"
                txtLogin.Text = ""
                txtAddress.Text = ""
                txtPhone.Text = ""
                txtEmail.Text = ""
                txtCity.Text = ""
                txtBirthDay.Text = ""
                txtProfession.Text = ""
                Exit Select
            Case 1
                MsgBox(" user doesn't exist", MsgBoxStyle.OkOnly, "Error")
                IMstatusBar.Text = "Error, user doesn't exist"
                Exit Select
            Case -1
                MsgBox(" please check IIS web service or database", MsgBoxStyle.OkOnly, "Error")
                IMstatusBar.Text = "Error, a user with the requested login name already exist"
                Exit Select
        End Select
        webServiceSaIm = Nothing
        iResult = 0


    End Sub

    Private Sub frmUnRegister_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmdUnRegister.Enabled = False
    End Sub

    Private Function confarmation() As Integer
        If txtLogin.Text.Trim() = "" Then
            MessageBox.Show("Login can't be empty")
            txtLogin.Focus()
            Return -1
        End If
        Return 0
    End Function

    Private Sub txtLogin_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLogin.TextChanged
        If txtLogin.Text.Trim = "" Then
            cmdSearch.Enabled = False
        Else
            cmdSearch.Enabled = True
        End If
    End Sub
End Class