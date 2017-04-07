Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient







Partial Class checkout
    Inherits System.Web.UI.Page

    Public strCartID As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not HttpContext.Current.Request.Cookies("CartID") Is Nothing Then
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            SqlDSCart2.SelectCommand = "Select * From CartLine Where CartID = '" & strCartID & "'"
            Response.Write(SqlDSCart2.SelectCommand)

        End If


        Dim strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PocketStore.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim strSQL As String = "Select SUM(Price * Quantity) FROM Cartline WHERE CartID= '" & strCartID & "'"
        Dim cartTotal As String
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        cartTotal = cmdCart.ExecuteScalar().ToString
        subtotal.Text = cartTotal


        connCart.Close()

        If state.Text = "CA" Then
            tax.Text = "08.75"

            Dim finalprice As String
            Dim strSQL2 As String = "SELECT SUM(Price* Quantity) + " & tax.Text & " FROM Cartline WHERE CartID= '" & strCartID & "'"
            cmdCart = New SqlCommand(strSQL2, connCart)
            connCart.Open()
            finalprice = cmdCart.ExecuteScalar().ToString
            total.Text = finalprice


        Else

            tax.Text = "0"
            total.Text = subtotal.Text

        End If

        Select Case (cctype.SelectedValue.ToString())

            Case "VISA"
                ccvalid.ValidationExpression = "[4][0-9]{12}[0-9]?[0-9]?[0-9]?"

            Case "MASTERCARD"
                ccvalid.ValidationExpression = "[5]\d{15}"

            Case "DISCOVER"
                ccvalid.ValidationExpression = "[6][0][1][1][0-9]{12}"

            Case "AMERICAN EXPRESS"
                ccvalid.ValidationExpression = "3[47]{1}[0-9]{13}"

        End Select


    End Sub

    Protected Sub backtocartbutton_Click(sender As Object, e As EventArgs) Handles backtocartbutton.Click

        Response.Redirect("ViewCart.aspx")

    End Sub


    Protected Sub submitButton_Click(sender As Object, e As EventArgs) Handles submitbutton.Click


        namereq.Validate()
        lastnamereq.Validate()
        phonereq.Validate()
        addressreq.Validate()
        cityreq.Validate()
        zipreq.Validate()
        ccreq.Validate()
        expreq.Validate()
        emailreq.Validate()
        firstnamevalid.Validate()
        lastnamevalid.Validate()
        phonevalid.Validate()
        addressvalid.Validate()
        cityvalid.Validate()
        zipvalid.Validate()
        ccvalid.Validate()
        expvalid.Validate()
        emailvalid.Validate()


        If namereq.IsValid And lastnamereq.IsValid And phonereq.IsValid And addressreq.IsValid And cityreq.IsValid And zipreq.IsValid And ccreq.IsValid And expreq.IsValid And emailreq.IsValid And firstnamevalid.IsValid And lastnamevalid.IsValid And phonevalid.IsValid And addressvalid.IsValid And cityvalid.IsValid And zipvalid.IsValid And ccvalid.IsValid And expvalid.IsValid And emailvalid.IsValid Then



            Dim post_values As New Dictionary(Of String, String)
            post_values.Add("x_card_num", ccfield.Text)
            post_values.Add("x_amount", total.Text)
            post_values.Add("x_login", "7YguC74tk")  ' your login ID
            post_values.Add("x_tran_key", "5vy8U598pQmz4vU7")  ' your transaction key
            post_values.Add("x_delim_data", "TRUE")
            post_values.Add("x_delim_char", ",")
            post_values.Add("x_relay_response", "FALSE")
            post_values.Add("x_type", "AUTH_CAPTURE")
            post_values.Add("x_method", "CC")
            post_values.Add("x_exp_date", ccexp.Text)
            post_values.Add("x_description", "Sample Transaction. Sike we actually charged you.")
            post_values.Add("x_first_name", firstname.Text)
            post_values.Add("x_last_name", lastname.Text)
            post_values.Add("x_address", address.Text)
            post_values.Add("x_state", state.Text)
            post_values.Add("x_zip", zip.Text)
            post_values.Add("x_email", email.Text)

            ' test server
            Dim post_url As String = "https://test.authorize.net/gateway/transact.dll"


            ' converts them to the proper format "x_login=username&x_tran_key=a1B2c3D4"
            Dim post_string As String = ""
            For Each field As KeyValuePair(Of String, String) In post_values
                post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
            Next
            post_string = Left(post_string, Len(post_string) - 1)

            ' create an HttpWebRequest object to communicate with Authorize.net
            Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
            objRequest.Method = "POST"
            objRequest.ContentLength = post_string.Length
            objRequest.ContentType = "application/x-www-form-urlencoded"

            ' send the data in a stream
            Dim myWriter As StreamWriter = Nothing
            myWriter = New StreamWriter(objRequest.GetRequestStream())
            myWriter.Write(post_string)
            myWriter.Close()

            ' create an HttpWebRequest object to process the returned values in a stream and convert it into a string
            Dim objResponse As HttpWebResponse = CType(objRequest.GetResponse(), HttpWebResponse)
            Dim responseStream As New StreamReader(objResponse.GetResponseStream())
            Dim post_response As String = responseStream.ReadToEnd()
            responseStream.Close()

            ' break the response string into an array
            Dim response_array As Array = Split(post_response, post_values("x_delim_char"), -1)

            ' the results are output to the screen in the form of an html numbered list.
            Response.Write("<OL>")
            For Each value In response_array
                Response.Write("<LI>" & value & "&nbsp;</LI>" & vbCrLf)
                'resultSpan.InnerHtml += "<LI>" & value & "&nbsp;</LI>" & vbCrLf
            Next
            Response.Write("</OL>")




            Dim drCartLine As SqlDataReader
            Dim strSQLStatement As String
            Dim cmdSQL As SqlCommand
            Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("PocketStoreConnectionString").ConnectionString
            Dim conn As New SqlConnection(strConnectionString)


            Dim strOrderID As String
            If HttpContext.Current.Request.Cookies("OrderID") Is Nothing Then
                'Response.Redirect("https://yahoo.com")

                strOrderID = GenerateRandomString(10, False)
                Dim Cookie2 As New HttpCookie("OrderID", strOrderID)
                HttpContext.Current.Response.Cookies.Add(Cookie2)

            Else
                'Response.Redirect("https://google.com")
                Dim CookieBack2 As HttpCookie
                CookieBack2 = HttpContext.Current.Request.Cookies("OrderID")
                strOrderID = CookieBack2.Value
            End If



            strSQLStatement = "IF NOT EXISTS (SELECT * FROM OrderHead WHERE OrderID = '" & strOrderID & "') BEGIN INSERT INTO OrderHead (OrderID, firstname, lastname, email, phone, address, city, zip, state, subtotal, tax, total) values('" & strOrderID & "','" & firstname.Text & "', '" & lastname.Text & " ', '" & email.Text & "', '" & phone.Text & "', '" & address.Text & "', '" & city.Text & "', '" & zip.Text & "', '" & state.Text & "', '" & CInt(subtotal.Text) & "' ,'" & CInt(tax.Text) & "', '" & CInt(total.Text) & "' ) END"
            cmdSQL = New SqlCommand(strSQLStatement, conn)
            conn.Open()
            drCartLine = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
            Response.Redirect("receipt.aspx")

        End If








    End Sub




    Public Function GenerateRandomString(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)
    End Function


End Class
