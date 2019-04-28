Imports System.Net.Sockets
Imports System.Threading



Public Class SocketThread
    Private sck As Socket
    Shared arrUser As New ArrayList()
    Private strXmlElements As String() = Nothing
    Private bLogin As Boolean
    Private strLogin As String = ""

    Private msgQueue As New Queue()

    Private sckJabber As TcpClient = Nothing
    Private thrdReadMsg As Thread = Nothing
    Private netStream As NetworkStream = Nothing
    Private bAvailable As Boolean = False
    Private Shared iStFileNo As Integer = 0
    Private iFileNo As Integer
    Private strId As String = "", strType As String = "", strTo As String = "", strFrom As String = "", strMessage As String = "", strStatus As String = "", strXmlns As String = ""
    Private strSubscription As String() = Nothing
    Private bClose As Boolean

    Public Sub New(sck As Socket)
        Me.sck = sck
        frmLocalServer.iTotalConn += 1
        iFileNo = iStFileNo
        iStFileNo += 1
    End Sub

    Private Sub AddUser()
        Dim queUser As New UserQueue()
        queUser.strUserName = strLogin
        queUser.refQueue = Me.msgQueue
        arrUser.Add(DirectCast(queUser, Object))
    End Sub

    Private Sub DeleteUser()
        For Each queUser As UserQueue In arrUser
            If queUser.strUserName.Trim().ToUpper() = strLogin.Trim().ToUpper() Then
                queUser.refQueue = Nothing
                arrUser.Remove(queUser)
                Return
            End If
        Next
    End Sub

    Private Sub AddMessage(strMessage As String, strMsgFor As String)
        For Each obj As Object In arrUser
            If DirectCast(obj, UserQueue).strUserName.Trim().ToUpper() = strMsgFor.Trim().ToUpper() Then
                DirectCast(obj, UserQueue).refQueue.Enqueue(DirectCast(strMessage, Object))
            End If
        Next
    End Sub

    Private Function RetrieveMessage() As Object
        If msgQueue.Count > 0 Then
            Return msgQueue.Dequeue()
        Else
            Return Nothing
        End If
    End Function

    Public Sub StartSession()
        Dim id As Integer = 0, pid As Integer = 0, iCode As Integer = -1, iPCode As Integer = -1
        Dim iDataAvailable As Integer = 0
        Dim bData As Byte() = Nothing
        Dim strMsg As String = "", match As String = "</InstantMessenger>", str As String = ""
        Dim chWhiteSpace As Char() = {" "c, ControlChars.Tab, ControlChars.Cr, ControlChars.Lf}

        'while((!frmLocalServer.bStop) && (!bQuit))
        While True
            Thread.Sleep(10)
            Application.DoEvents()

            If frmLocalServer.bStop Then
                CloseClientConnection(sck)
                'MessageBox.Show("socket close on server stopped")
                Return
            End If

            Try
                If sck.Available > 0 Then
                    iDataAvailable = sck.Available
                    Thread.Sleep(10)
                    Application.DoEvents()
                    bData = Nothing
                    bData = New Byte(iDataAvailable - 1) {}

                    sck.Receive(bData)
                    For i As Integer = 0 To iDataAvailable - 1
                        strMsg += (ChrW(bData(i))).ToString()
                    Next


                    id = 0
                    pid = 0
                    While pid < strMsg.Length
                        str = ""

                        id = strMsg.IndexOf(match, pid)
                        If id <> -1 Then
                            str = strMsg.Substring(pid, id - pid + match.Length)
                            pid = id + match.Length

                            Dim streamXml As System.IO.StreamWriter
                            If System.IO.File.Exists("temp" & iFileNo.ToString() & ".xml") Then
                                System.IO.File.Delete("temp" & iFileNo.ToString() & ".xml")
                            End If
                            streamXml = System.IO.File.CreateText("temp" & iFileNo.ToString() & ".xml")


                            str = str.TrimStart(chWhiteSpace)
                            streamXml.Write(str)
                            streamXml.Close()

                            iCode = parseXml("temp" & iFileNo.ToString() & ".xml")

                            If iCode <> -1 Then
                                iPCode = processXml(iCode)
                                If iPCode = 1 Then
                                    'On quit close the session.
                                    While bAvailable
                                        Thread.Sleep(10)
                                    End While
                                    CloseClientConnection(sck)
                                    'MessageBox.Show("Socket close ", "Server")
                                    Return
                                End If
                            End If
                        Else
                            Exit While
                        End If
                    End While
                    strMsg = strMsg.Substring(pid)
                    If id <> -1 Then
                        If strMsg.Trim() = "" Then
                            strMsg = ""
                        End If
                    End If
                    bData = Nothing
                    bData = New Byte(511) {}

                Else
                End If

                Dim objMsg As Object = RetrieveMessage()

                If objMsg IsNot Nothing Then
                    'Retrieve message from the user's queue.
                    'send it to the user.
                    SendMsg(DirectCast(objMsg, String))
                End If
            Catch ex As Exception
                CloseClientConnection(sck)
                'MessageBox.Show("Socket close on exception","Server");
                Return
            End Try
        End While
    End Sub

    Private Sub CloseClientConnection(sck As Socket)
        If sck IsNot Nothing AndAlso sck.Connected Then
            sck.Close()
        End If
        sck = Nothing
        frmLocalServer.iTotalConn -= 1
    End Sub

    Private Function SendMsg(strMsg As String) As Integer
        'to local client
        If Not sck.Poll(100, SelectMode.SelectWrite) Then
            Return 1
        End If

        Dim len As Integer = strMsg.Length
        Dim chData As Char() = New [Char](len - 1) {}
        Dim bData As Byte() = New Byte(len - 1) {}

        chData = strMsg.ToCharArray()
        For i As Integer = 0 To len - 1
            bData(i) = CByte(AscW(chData(i)))
        Next
        Try
            sck.Send(bData)
        Catch
            '(Exception ex)
            bData = Nothing
            chData = Nothing
            Return 1
        End Try
        bData = Nothing
        chData = Nothing
        Return 0
    End Function

    Private Function parseXml(strFile As String) As Integer
        Dim xmlDoc As New System.Xml.XmlDocument()
        Dim xNode As System.Xml.XmlNode

        strXmlElements = Nothing

        Try
            xmlDoc.Load(strFile)
            If xmlDoc.ChildNodes.Count < 2 Then
                'invalid Xml.
                Return (-1)
            End If
            xNode = xmlDoc.ChildNodes.Item(1)
            If xNode.Name.Trim().ToUpper().CompareTo("INSTANTMESSENGER") <> 0 Then
                Return (-1)
            End If

            If xNode.FirstChild.Name.ToUpper().CompareTo("AUTH") = 0 Then
                strXmlElements = New String(1) {}
                strXmlElements(0) = ""
                strXmlElements(1) = ""

                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("USERNAME") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("PASSWORD") = 0 Then
                        strXmlElements(1) = xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim()
                    End If
                Next
                Return 0

            
            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("MSG") = 0 Then
                strXmlElements = New String(2) {}
                strXmlElements(0) = ""
                strXmlElements(1) = ""
                strXmlElements(2) = ""
                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("TARGET") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("SOURCE") = 0 Then
                        strXmlElements(1) = xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim()
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("TEXT") = 0 Then
                        strXmlElements(2) = xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim()
                    End If
                Next
                Return 2

            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("ADDFRIEND") = 0 Then
                strXmlElements = New String(1) {}
                strXmlElements(0) = ""
                strXmlElements(1) = ""
                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("USERNAME") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("FRIENDNAME") = 0 Then
                        strXmlElements(1) = xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim()
                    End If
                Next
                Return 3

            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("DELETEFRIEND") = 0 Then
                strXmlElements = New String(1) {}
                strXmlElements(0) = ""
                strXmlElements(1) = ""
                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("USERNAME") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("FRIENDNAME") = 0 Then
                        strXmlElements(1) = xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim()
                    End If
                Next
                Return 4


            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("ACCEPTFRIEND") = 0 Then
                strXmlElements = New String(2) {}
                strXmlElements(0) = ""
                strXmlElements(1) = ""
                strXmlElements(2) = ""
                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("USERNAME") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("FRIENDNAME") = 0 Then
                        strXmlElements(1) = xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim()
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("STATUS") = 0 Then
                        strXmlElements(2) = xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim()
                    End If
                Next
                Return 5


            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("QUIT") = 0 Then
                strXmlElements = New String(0) {}
                If xNode.FirstChild.ChildNodes.Item(0).Name.ToUpper().CompareTo("USERNAME") = 0 Then
                    strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(0).InnerText
                End If
                'MessageBox.Show(strXmlElements[0],"quit from server")
                Return 8

            End If

        Catch ex As Exception
            Return (-1)
        End Try
        Return -1
    End Function

    Private Function processXml(iXmlType As Integer) As Integer
        Dim xmlLocalResult As XmlFormat = Nothing
        Dim strParam As String() = Nothing
        Dim iResult As Integer = -1, iIdx As Integer = -1
        Dim strResult As String = Nothing, strNotify As String = "", strJabberXml As String = ""
        Dim xmlMsg As XmlFormat

        Try

            Select Case iXmlType
                'Xml Type
                Case 0
                    'Auth.
                    iResult = frmLocalServer.webServiceSaIm.Login(strXmlElements(0), strXmlElements(1))
                    If iResult = 0 Then
                        strLogin = strXmlElements(0)
                        bLogin = True
                        AddUser()

                    End If

                    strParam = New [String](0) {}
                    strParam(0) = iResult.ToString()

                    xmlLocalResult = New XmlFormat("AUTH", strParam)
                    SendMsg(xmlLocalResult.GetXml())

                    strParam = frmLocalServer.webServiceSaIm.FriendsList(strLogin)
                    xmlLocalResult = New XmlFormat("FRIENDLIST", strParam)
                    SendMsg(xmlLocalResult.GetXml())

                    strNotify = frmLocalServer.webServiceSaIm.FriendsToNotify(strLogin)
                    ' the value 1 in lower sub mean the user is online
                    NotifyFriends(strNotify, "1")

                   

                    Return 0
                    Exit Select
             
                Case 2
                    'Msg
                    If Not bLogin Then
                        Return -1
                    End If

                    If arrUser IsNot Nothing Then
                        For Each queUser As UserQueue In arrUser
                            'if target user is found in local list then
                            'send msg locally
                            If queUser.strUserName.Trim().ToUpper() = strXmlElements(0).Trim().ToUpper() Then
                                xmlMsg = New XmlFormat("MSG", strXmlElements)
                                AddMessage(xmlMsg.GetXml(), strXmlElements(0))
                                xmlMsg = Nothing
                                Return 0
                            End If
                        Next
                    End If
                   
                    Return 0
                    Exit Select
                Case 3
                    'add local
                    Dim strParam2 As String() = Nothing
                    If Not bLogin Then
                        Return -1
                    End If

                    strParam = New [String](1) {}
                    strParam2 = New [String](2) {}


                    strResult = frmLocalServer.webServiceSaIm.Addfriend(strXmlElements(0), strXmlElements(1))

                    strParam(0) = strXmlElements(0)
                    strParam(1) = "2"

                    strParam2(0) = strXmlElements(1)
                    strParam2(1) = strResult.Substring(1)
                    strParam2(2) = strResult.Substring(0, 1)

                   


                    'strParam(0) = strLogin
                    'strParam(1) = status
                    xmlLocalResult = New XmlFormat("FRIENDSTATUS", strParam2)
                    iResult = SendMsg(xmlLocalResult.GetXml())

                    xmlLocalResult = New XmlFormat("NOTIFYFRIENDS", strParam)
                    AddMessage(xmlLocalResult.GetXml(), strXmlElements(1))



                    Return 0
                    Exit Select
                Case 4
                    'del local
                    If Not bLogin Then
                        Return -1
                    End If

                    strParam = New [String](2) {}
                    iResult = frmLocalServer.webServiceSaIm.DeleteFriend(strXmlElements(0), strXmlElements(1))

                    If iResult <> 2 Then
                        strParam = New [String](1) {}
                        strParam(0) = strXmlElements(1)
                        strParam(1) = iResult.ToString()

                        xmlLocalResult = New XmlFormat("DELETESTATUS", strParam)
                        iResult = SendMsg(xmlLocalResult.GetXml())

                        strParam(0) = strXmlElements(0)
                        xmlLocalResult = New XmlFormat("DELETESTATUS", strParam)
                        AddMessage(xmlLocalResult.GetXml(), strXmlElements(1))

                   
                    End If
                    Return 0
                    Exit Select
                Case 5
                    'accept
                    If Not bLogin Then
                        Return -1
                    End If
                    If bLogin Then
                        iResult = frmLocalServer.webServiceSaIm.ConfirmAddfriend(strXmlElements(0), strXmlElements(1), strXmlElements(2))

                        If iResult = 0 And strXmlElements(2) = "0" Then
                            Dim sStatusResult As String

                            sStatusResult = frmLocalServer.webServiceSaIm.GetStatus(strXmlElements(1))
                            AddNotifyFriends(strXmlElements(1), sStatusResult, strXmlElements(0))

                            sStatusResult = frmLocalServer.webServiceSaIm.GetStatus(strXmlElements(0)).ToString
                            AddNotifyFriends(strXmlElements(0), sStatusResult, strXmlElements(1))

                        ElseIf iResult = 0 And strXmlElements(2) = "1" Then
                            strParam = New [String](1) {}
                            strParam(0) = strXmlElements(0)
                            strParam(1) = "0"

                            xmlLocalResult = New XmlFormat("DELETESTATUS", strParam)
                            AddMessage(xmlLocalResult.GetXml(), strXmlElements(1).Trim().ToUpper())

                            strParam(0) = strXmlElements(1)
                            strParam(1) = "0"
                            xmlLocalResult = New XmlFormat("DELETESTATUS", strParam)
                            AddMessage(xmlLocalResult.GetXml(), strXmlElements(0).Trim().ToUpper())

                            'iResult = SendMsg(xmlLocalResult.GetXml())
                        End If

                    End If
                    Return 0
                    Exit Select
                Case 8
                    'quit
                    If Not bLogin Then
                        Return -1
                    End If

                    iResult = frmLocalServer.webServiceSaIm.Logout(strXmlElements(0))

                    strNotify = frmLocalServer.webServiceSaIm.FriendsToNotify(strLogin)
                    ' the value 0 in lower sub mean the user is offline
                    NotifyFriends(strNotify, "0")

                    DeleteUser()
                   
                    Return 1
                    Exit Select
                
                    Exit Select
            End Select

        Catch ex As Exception
        End Try
        Return -1
    End Function

    Private Sub NotifyFriends(strNotify As String, status As String)
If strNotify Is Nothing Then
            Return
        End If

        Dim strParam As String() = New String(1) {}
        Dim iNotifyIndex As Integer = strNotify.IndexOf("^")

        While iNotifyIndex <> -1
            strParam(0) = strLogin
            strParam(1) = status
            Dim xmlLocalResult As New XmlFormat("NOTIFYFRIENDS", strParam)
            AddMessage(xmlLocalResult.GetXml(), strNotify.Substring(0, iNotifyIndex).ToUpper())

            strNotify = strNotify.Substring(iNotifyIndex + 1)
            iNotifyIndex = strNotify.IndexOf("^")
        End While
    End Sub

    Private Sub AddNotifyFriends(strNotifyFrom As String, status As String, strNotifyFor As String)
        If strNotifyFrom Is Nothing Then
            Return
        End If

        Dim strParam As String() = New String(1) {}

        strParam(0) = strNotifyFrom
        strParam(1) = status
        Dim xmlLocalResult As New XmlFormat("NOTIFYFRIENDS", strParam)
        AddMessage(xmlLocalResult.GetXml(), strNotifyFor.ToUpper())


        strParam(0) = strNotifyFor
        strParam(1) = status
        xmlLocalResult = New XmlFormat("NOTIFYFRIENDS", strParam)
        AddMessage(xmlLocalResult.GetXml(), strNotifyFrom.ToUpper())

    End Sub


    'Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
    '    target = value
    '    Return value
    'End Function
End Class

Public Class UserQueue
    Public strUserName As String
    Public refQueue As Queue
End Class