Imports System.Net.Sockets
Imports System.Threading
Imports SaImServer.localhost

Public Class frmLocalServer
    Private sck As SckListener
    Public Shared bStop As Boolean
    Public Shared iTotalConn As Integer

    Public Shared webServiceSaIm As InstMsgServ = Nothing

    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' TODO: Add any constructor code after InitializeComponent call
        ' 
        bStop = True
        iTotalConn = 0
    End Sub

    Private Sub cmdStop_Click(sender As Object, e As System.EventArgs) Handles cmdStop.Click
        If bStop Then
            statusBarIM.Text = "Server already closed"
            Return
        End If
        bStop = True

        Try
            'close Web Services.
            webServiceSaIm.Dispose()
            webServiceSaIm = Nothing

            statusBarIM.Text = "Listener Stoped......."
            Thread.Sleep(1000)
            statusBarIM.Text = "Closing Socket connections & Threads"

            Thread.Sleep(1000)
            statusBarIM.Text = "Server Stopped........"
            sck.[Stop]()
            cmdAddUser.Enabled = False
            cmdDeleteUser.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error : Closing Application")
            Application.Exit()
            Return
        End Try
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As System.EventArgs) Handles cmdStart.Click
        If Not bStop Then
            statusBarIM.Text = "Server already running"
            Return
        End If

        webServiceSaIm = New InstMsgServ()
        'web obj. created once for the server
        If Not webServiceSaIm.IsConnected() Then
            MessageBox.Show("Database connection failed.", "Closing Application")
            'this.Close();
            Application.Exit()
            Return
        End If
        

        Try
            sck = New SckListener(5555)
            sck.Start()
            statusBarIM.Text = "Server Started........"
            bStop = False

            Dim thrd As New Thread(New ThreadStart(AddressOf StartConn))
            thrd.Start()
            cmdAddUser.Enabled = True
            cmdDeleteUser.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Closing Application.")
            'this.Close();
            Application.[Exit]()
            Return
        End Try
    End Sub

    Private Sub StartConn()
        While Not bStop
            Try
                Dim sock As Socket
                While True
                    'wait for connection request.
                    Thread.Sleep(10)
                    Application.DoEvents()
                    If bStop Then
                        Return
                    End If
                    'break on new conn req.
                    If sck.Pending() Then
                        Exit While
                    End If
                End While


                sock = sck.AcceptSocket()
                'accept connection required
                Dim sckThrd As New SocketThread(sock)
                'assign it to a new thread
                Dim thrd As New Thread(New ThreadStart(AddressOf sckThrd.StartSession))
                thrd.Start()
                Thread.Sleep(100)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error : Closing Listener Thread.")
                Return
            End Try
        End While
    End Sub

    Private Sub timer1_Tick(sender As Object, e As System.EventArgs) Handles timer1.Tick
        lblStatus.Text = iTotalConn.ToString() & " Connection(s)"
    End Sub

    Private Sub frmLocalServer_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If Not bStop Then
            cmdStop_Click(sender, e)
        End If
    End Sub


    
    Private Sub cmdAddUser_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddUser.Click
        frmRegister.Show()
    End Sub

    Private Sub cmdDeleteUser_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeleteUser.Click
        frmUnRegister.Show()
    End Sub
End Class