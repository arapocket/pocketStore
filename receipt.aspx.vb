Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Threading
Imports System.ComponentModel



Partial Class receipt
    Inherits System.Web.UI.Page

    Private Shared mailSent As Boolean = False
    Public strOrderID As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''*** get OrderID
        If Not HttpContext.Current.Request.Cookies("OrderID") Is Nothing Then
            Dim CookieBack2 As HttpCookie
            CookieBack2 = HttpContext.Current.Request.Cookies("OrderID")
            strOrderID = CookieBack2.Value
            SqlDSCart2.SelectCommand = "Select * From OrderHead Where OrderID = '" & strOrderID & "'"
            Response.Write(SqlDSCart2.SelectCommand)
            'Response.Redirect("https://google.com")

        End If


        Dim strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PocketStore.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim strSQL As String = "Select email FROM OrderHead Where OrderID = '" & strOrderID & "'"
        Dim email As String
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        email = cmdCart.ExecuteScalar().ToString


        '' Command line argument must the the SMTP host.
        'Dim client As New SmtpClient()
        '' Specify the e-mail sender.
        '' Create a mailing address that includes a UTF8 character
        '' in the display name.
        'Dim [from] As New MailAddress("pocketare@gmail.com", "Ara " & ChrW(&HD8) & " Pocket", System.Text.Encoding.UTF8)
        '' Set destinations for the e-mail message.
        'Dim [to] As New MailAddress(email)
        '' Specify the message content.
        'Dim message As New MailMessage([from], [to])
        'message.Body = "This is a test e-mail message sent by an application. "
        '' Include some non-ASCII characters in body and subject.
        'Dim someArrows As New String(New Char() {ChrW(&H2190), ChrW(&H2191), ChrW(&H2192), ChrW(&H2193)})
        'message.Body += Environment.NewLine & someArrows
        'message.BodyEncoding = System.Text.Encoding.UTF8
        'message.Subject = "test message 1" & someArrows
        'message.SubjectEncoding = System.Text.Encoding.UTF8
        '' Set the method that is called back when the send operation ends.
        'AddHandler client.SendCompleted, AddressOf SendCompletedCallback
        '' The userState can be any object that allows your callback 
        '' method to identify this send operation.
        '' For this example, the userToken is a string constant.
        'Dim userState As String = "test message1"
        'client.SendAsync(message, userState)
        'Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.")
        'Dim answer As String = Console.ReadLine()
        '' If the user canceled the send, and mail hasn't been sent yet,
        '' then cancel the pending operation.
        'If answer.StartsWith("c") AndAlso mailSent = False Then
        '    client.SendAsyncCancel()
        'End If
        '' Clean up.
        'message.Dispose()
        'Console.WriteLine("Goodbye.")


        'Dim strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PocketStore.mdf;Integrated Security=True;Connect Timeout=30"
        'Dim connCart As SqlConnection
        'Dim strSQL As String = "Select * FROM OrderHead WHERE OrderID = '" & strOrderID & "'"
        'connCart = New SqlConnection(strConn)
        'connCart.Close()


    End Sub


    Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        ' Get the unique identifier for this asynchronous operation.
        Dim token As String = CStr(e.UserState)

        If e.Cancelled Then
            Console.WriteLine("[{0}] Send canceled.", token)
        End If
        If e.Error IsNot Nothing Then
            Console.WriteLine("[{0}] {1}", token, e.Error.ToString())
        Else
            Console.WriteLine("Message sent.")
        End If
        mailSent = True
    End Sub

End Class
