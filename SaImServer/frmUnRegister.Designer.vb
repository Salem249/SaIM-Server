<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnRegister
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpBxRegister = New System.Windows.Forms.GroupBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdUnRegister = New System.Windows.Forms.Button()
        Me.txtProfession = New System.Windows.Forms.TextBox()
        Me.txtBirthDay = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.txtBirtDay = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.IMstatusBar = New System.Windows.Forms.StatusBar()
        Me.grpBxRegister.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBxRegister
        '
        Me.grpBxRegister.Controls.Add(Me.cmdSearch)
        Me.grpBxRegister.Controls.Add(Me.cmdExit)
        Me.grpBxRegister.Controls.Add(Me.cmdUnRegister)
        Me.grpBxRegister.Controls.Add(Me.txtProfession)
        Me.grpBxRegister.Controls.Add(Me.txtBirthDay)
        Me.grpBxRegister.Controls.Add(Me.txtCity)
        Me.grpBxRegister.Controls.Add(Me.txtEmail)
        Me.grpBxRegister.Controls.Add(Me.txtPhone)
        Me.grpBxRegister.Controls.Add(Me.txtAddress)
        Me.grpBxRegister.Controls.Add(Me.txtLogin)
        Me.grpBxRegister.Controls.Add(Me.label12)
        Me.grpBxRegister.Controls.Add(Me.txtBirtDay)
        Me.grpBxRegister.Controls.Add(Me.label10)
        Me.grpBxRegister.Controls.Add(Me.label8)
        Me.grpBxRegister.Controls.Add(Me.label6)
        Me.grpBxRegister.Controls.Add(Me.label4)
        Me.grpBxRegister.Controls.Add(Me.label1)
        Me.grpBxRegister.Location = New System.Drawing.Point(6, 17)
        Me.grpBxRegister.Name = "grpBxRegister"
        Me.grpBxRegister.Size = New System.Drawing.Size(440, 208)
        Me.grpBxRegister.TabIndex = 1
        Me.grpBxRegister.TabStop = False
        '
        'cmdSearch
        '
        Me.cmdSearch.Enabled = False
        Me.cmdSearch.Location = New System.Drawing.Point(45, 183)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(88, 24)
        Me.cmdSearch.TabIndex = 15
        Me.cmdSearch.Text = "&Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(271, 182)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(88, 24)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdUnRegister
        '
        Me.cmdUnRegister.Location = New System.Drawing.Point(155, 183)
        Me.cmdUnRegister.Name = "cmdUnRegister"
        Me.cmdUnRegister.Size = New System.Drawing.Size(88, 24)
        Me.cmdUnRegister.TabIndex = 13
        Me.cmdUnRegister.Text = "&UnRegister"
        '
        'txtProfession
        '
        Me.txtProfession.Location = New System.Drawing.Point(96, 128)
        Me.txtProfession.MaxLength = 20
        Me.txtProfession.Name = "txtProfession"
        Me.txtProfession.ReadOnly = True
        Me.txtProfession.Size = New System.Drawing.Size(100, 20)
        Me.txtProfession.TabIndex = 12
        '
        'txtBirthDay
        '
        Me.txtBirthDay.Location = New System.Drawing.Point(293, 128)
        Me.txtBirthDay.MaxLength = 20
        Me.txtBirthDay.Name = "txtBirthDay"
        Me.txtBirthDay.ReadOnly = True
        Me.txtBirthDay.Size = New System.Drawing.Size(100, 20)
        Me.txtBirthDay.TabIndex = 11
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(293, 95)
        Me.txtCity.MaxLength = 20
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReadOnly = True
        Me.txtCity.Size = New System.Drawing.Size(100, 20)
        Me.txtCity.TabIndex = 10
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(96, 96)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(100, 20)
        Me.txtEmail.TabIndex = 8
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(293, 63)
        Me.txtPhone.MaxLength = 20
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReadOnly = True
        Me.txtPhone.Size = New System.Drawing.Size(100, 20)
        Me.txtPhone.TabIndex = 6
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(96, 64)
        Me.txtAddress.MaxLength = 100
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(100, 20)
        Me.txtAddress.TabIndex = 4
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(96, 24)
        Me.txtLogin.MaxLength = 20
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(104, 20)
        Me.txtLogin.TabIndex = 1
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(32, 128)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(80, 16)
        Me.label12.TabIndex = 11
        Me.label12.Text = "Profession"
        Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBirtDay
        '
        Me.txtBirtDay.AutoSize = True
        Me.txtBirtDay.Location = New System.Drawing.Point(229, 128)
        Me.txtBirtDay.Name = "txtBirtDay"
        Me.txtBirtDay.Size = New System.Drawing.Size(51, 13)
        Me.txtBirtDay.TabIndex = 10
        Me.txtBirtDay.Text = "Birth Day"
        Me.txtBirtDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(229, 95)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(26, 13)
        Me.label10.TabIndex = 9
        Me.label10.Text = "City"
        Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(32, 96)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(104, 16)
        Me.label8.TabIndex = 7
        Me.label8.Text = "Email"
        Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(229, 63)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(37, 13)
        Me.label6.TabIndex = 5
        Me.label6.Text = "Phone"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(32, 64)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(96, 16)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Address"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(32, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 16)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Login Name"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IMstatusBar
        '
        Me.IMstatusBar.Location = New System.Drawing.Point(0, 253)
        Me.IMstatusBar.Name = "IMstatusBar"
        Me.IMstatusBar.Size = New System.Drawing.Size(466, 16)
        Me.IMstatusBar.TabIndex = 3
        '
        'frmUnRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 269)
        Me.Controls.Add(Me.grpBxRegister)
        Me.Controls.Add(Me.IMstatusBar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUnRegister"
        Me.Text = "frmUnregister"
        Me.grpBxRegister.ResumeLayout(False)
        Me.grpBxRegister.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBxRegister As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUnRegister As System.Windows.Forms.Button
    Friend WithEvents txtProfession As System.Windows.Forms.TextBox
    Friend WithEvents txtBirthDay As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Private WithEvents txtEmail As System.Windows.Forms.TextBox
    Private WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents txtBirtDay As System.Windows.Forms.Label
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents IMstatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button

End Class
