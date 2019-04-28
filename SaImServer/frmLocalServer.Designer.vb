
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocalServer
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
        Me.components = New System.ComponentModel.Container()
        Me.panelIM = New System.Windows.Forms.Panel()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.statusBarIM = New System.Windows.Forms.StatusBar()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdAddUser = New System.Windows.Forms.Button()
        Me.cmdDeleteUser = New System.Windows.Forms.Button()
        Me.panelIM.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelIM
        '
        Me.panelIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelIM.Controls.Add(Me.cmdStart)
        Me.panelIM.Controls.Add(Me.lblStatus)
        Me.panelIM.Controls.Add(Me.cmdStop)
        Me.panelIM.Controls.Add(Me.label1)
        Me.panelIM.Controls.Add(Me.label2)
        Me.panelIM.Location = New System.Drawing.Point(8, 24)
        Me.panelIM.Name = "panelIM"
        Me.panelIM.Size = New System.Drawing.Size(264, 112)
        Me.panelIM.TabIndex = 1
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(56, 16)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(40, 24)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = ">>"
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(56, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(168, 16)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "0 Connections"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(56, 48)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(40, 24)
        Me.cmdStop.TabIndex = 1
        Me.cmdStop.Text = "#"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(104, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 24)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Start Server"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(104, 56)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(88, 24)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Stop Server"
        '
        'label3
        '
        Me.label3.ForeColor = System.Drawing.Color.Blue
        Me.label3.Location = New System.Drawing.Point(8, 8)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(232, 16)
        Me.label3.TabIndex = 2
        Me.label3.Text = "SalemIM"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'statusBarIM
        '
        Me.statusBarIM.Location = New System.Drawing.Point(0, 212)
        Me.statusBarIM.Name = "statusBarIM"
        Me.statusBarIM.Size = New System.Drawing.Size(288, 16)
        Me.statusBarIM.TabIndex = 5
        Me.statusBarIM.Text = "Ready"
        '
        'timer1
        '
        Me.timer1.Enabled = True
        '
        'cmdAddUser
        '
        Me.cmdAddUser.Enabled = False
        Me.cmdAddUser.Location = New System.Drawing.Point(31, 169)
        Me.cmdAddUser.Name = "cmdAddUser"
        Me.cmdAddUser.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddUser.TabIndex = 6
        Me.cmdAddUser.Text = "Add User"
        Me.cmdAddUser.UseVisualStyleBackColor = True
        '
        'cmdDeleteUser
        '
        Me.cmdDeleteUser.Enabled = False
        Me.cmdDeleteUser.Location = New System.Drawing.Point(165, 169)
        Me.cmdDeleteUser.Name = "cmdDeleteUser"
        Me.cmdDeleteUser.Size = New System.Drawing.Size(75, 23)
        Me.cmdDeleteUser.TabIndex = 7
        Me.cmdDeleteUser.Text = "Delete User"
        Me.cmdDeleteUser.UseVisualStyleBackColor = True
        '
        'frmLocalServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 228)
        Me.Controls.Add(Me.cmdDeleteUser)
        Me.Controls.Add(Me.cmdAddUser)
        Me.Controls.Add(Me.statusBarIM)
        Me.Controls.Add(Me.panelIM)
        Me.Controls.Add(Me.label3)
        Me.Name = "frmLocalServer"
        Me.Text = "frmLocalServer"
        Me.panelIM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents panelIM As System.Windows.Forms.Panel
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents statusBarIM As System.Windows.Forms.StatusBar
    Friend WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdAddUser As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteUser As System.Windows.Forms.Button
End Class
