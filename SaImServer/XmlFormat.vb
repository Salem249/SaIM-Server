
Public Class XmlFormat
    Private strXml As String
    '
    ' TODO: Add constructor logic here
    '
    Public Sub New()
    End Sub
    'overloaded constructor
    Public Sub New(strType As String, param As String())
        strXml = "<?xml version='1.0' encoding='utf-8'?><InstantMessenger>"

        If strType.ToUpper().CompareTo("AUTH") = 0 Then
            AuthXML(param)
        ElseIf strType.ToUpper().CompareTo("REGISTER") = 0 Then
            RegisterXML(param)
        ElseIf strType.ToUpper().CompareTo("FRIENDLIST") = 0 Then
            FriendListXML(param)
        ElseIf strType.ToUpper().CompareTo("MSG") = 0 Then
            MessageXML(param)
        ElseIf strType.ToUpper().CompareTo("ROSTER") = 0 Then
            RosterXML(param)
        ElseIf strType.ToUpper().CompareTo("NOTIFYFRIENDS") = 0 Then
            NotifyFriendsXML(param)
        ElseIf strType.ToUpper().CompareTo("FRIENDSTATUS") = 0 Then
            FriendStatusXML(param)
        ElseIf strType.ToUpper().CompareTo("DELETESTATUS") = 0 Then
            DeleteStatusXML(param)
        ElseIf strType.ToUpper().CompareTo("UNREGISTER") = 0 Then
            UnRegisterXML(param)
        ElseIf strType.ToUpper().CompareTo("ADDGATEWAY") = 0 Then
            AddGatewayXML(param)
        End If

        strXml += "</InstantMessenger>"
    End Sub
    Private Sub AuthXML(param As [String]())
        strXml += "<auth>"
        strXml += "<int>" & param(0) & "</int>"
        strXml += "</auth>"
    End Sub

    Private Sub RegisterXML(param As [String]())
        strXml += "<Register>"
        strXml += "<int>" & param(0) & "</int>"
        strXml += "</Register>"
    End Sub

    Private Sub FriendListXML(param As [String]())
        strXml += "<FriendList>"
        strXml += "<username>" & param(0) & "</username>"

        For i As Integer = 1 To param.Length - 1 Step 4
            strXml += "<FriendName>" & param(i) & "</FriendName>"
            strXml += "<Presence>" & param(i + 1) & "</Presence>"
            strXml += "<Subscription>" & param(i + 2) & "</Subscription>"
            strXml += "<status>" & param(i + 3) & "</status>"
        Next
        strXml += "</FriendList>"
    End Sub

    Private Sub MessageXML(param As [String]())
        strXml += "<MSG>"
        strXml += "<Target>" & param(0) & "</Target>"
        strXml += "<Source>" & param(1) & "</Source>"
        strXml += "<Text>" & param(2) & "</Text>"
        strXml += "</MSG>"
    End Sub

    Private Sub RosterXML(param As [String]())
        strXml += "<Roster>"
        For i As Integer = 0 To param.Length - 1 Step 2
            'DON'T SEND MSN ITEM IN ROSTER LIST and null values.
            If (param(i).ToUpper().IndexOf("MSN.JABBER.ORG/") <> 0) AndAlso param(i) <> "" Then
                strXml += "<FriendId>" & param(i) & "</FriendId>"
                strXml += "<Subscription>" & param(i + 1) & "</Subscription>"
            End If
        Next
        strXml += "</Roster>"
    End Sub

    Private Sub NotifyFriendsXML(param As [String]())
        strXml += "<NotifyFriends>"
        For i As Integer = 0 To param.Length - 1 Step 2
            strXml += "<UserName>" & param(i) & "</UserName>"
            Select Case param(i + 1).ToCharArray()(0)
                Case "0"c
                    strXml += "<Status>OFF-LINE</Status>"
                    Exit Select
                Case "1"c
                    strXml += "<Status>ON-LINE</Status>"
                    Exit Select
                Case "2"c
                    strXml += "<Status>SUBSCRIBE</Status>"
                    Exit Select
                Case "3"c
                    strXml += "<Status>SUBSCRIBED</Status>"
                    Exit Select
                Case "4"c
                    strXml += "<Status>UNSUBSCRIBE</Status>"
                    Exit Select
                Case "5"c
                    strXml += "<Status>UNSUBSCRIBED</Status>"
                    Exit Select
            End Select
        Next
        strXml += "</NotifyFriends>"
    End Sub

    Private Sub FriendStatusXML(param As [String]())
        strXml += "<FriendStatus>"
        strXml += "<FriendName>" & param(0) & "</FriendName>"
        strXml += "<Status>" & param(1) & "</Status>"
        strXml += "<OnLine>" & param(2) & "</OnLine>"
        strXml += "</FriendStatus>"
    End Sub

    Private Sub DeleteStatusXML(param As [String]())
        strXml += "<DeleteStatus>"
        strXml += "<FriendName>" & param(0) & "</FriendName>"
        strXml += "<Status>" & param(1) & "</Status>"
        strXml += "</DeleteStatus>"
    End Sub
    Private Sub UnRegisterXML(param As [String]())
        strXml += "<UnRegister>"
        strXml += param(0)
        strXml += "</UnRegister>"
    End Sub
    Private Sub AddGatewayXML(param As [String]())
        strXml += "<AddGateway>"
        strXml += param(0)
        strXml += "</AddGateway>"
    End Sub

    Public Function GetXml() As String
        Return strXml
    End Function
End Class