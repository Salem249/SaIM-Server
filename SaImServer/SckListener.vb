Imports System.Net.Sockets

Public Class SckListener
    Inherits System.Net.Sockets.TcpListener
    Public Sub New(port As Integer)
        'this(port);
        MyBase.New(port)
    End Sub
    Public Function IsConnected() As Boolean
        Return Me.Active
    End Function
End Class