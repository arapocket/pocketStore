Imports System.Data
Imports System.Data.SqlClient
Partial Class ViewCart
    Inherits System.Web.UI.Page
    Public strCartID As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '*** get CartID
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
        lbltotal.Text = "$" & cartTotal
        connCart.Close()


    End Sub

    Protected Sub lvCart_OnItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)

        If e.CommandName = "cmdUpdateQuantity" Then


            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "Update CartLine set quantity = " & CInt(tbQuantity.Text) & " where cartid = '" & strCartID & "' and productid = " & CInt(e.CommandArgument)
            ' update
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("pocketstoreConnectionString").ConnectionString
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            SqlDSCart2.DataBind()
            lvCart.DataBind()


            'Change the subtotal on bottom when you click the update for a single item
            Dim strConn2 As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PocketStore.mdf;Integrated Security=True;Connect Timeout=30"
            Dim connCart2 As SqlConnection
            Dim cmdCart2 As SqlCommand
            Dim strSQL2 As String = "Select SUM(Price * Quantity) FROM Cartline WHERE CartID= '" & strCartID & "'"
            Dim cartTotal As String
            connCart2 = New SqlConnection(strConn2)
            cmdCart2 = New SqlCommand(strSQL2, connCart2)
            connCart2.Open()
            cartTotal = cmdCart2.ExecuteScalar().ToString
            lbltotal.Text = "$" & cartTotal
            connCart2.Close()




        ElseIf e.CommandName = "cmdDelete" Then
            Dim strSQL As String = "Delete FROM CartLine  where cartid = '" & strCartID & "' and productid = " & CInt(e.CommandArgument)
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("pocketstoreConnectionString").ConnectionString
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            SqlDSCart2.DataBind()
            lvCart.DataBind()

            'Change the subtotal on bottom when you click the delete for a single item
            Dim strConn3 As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PocketStore.mdf;Integrated Security=True;Connect Timeout=30"
            Dim connCart3 As SqlConnection
            Dim cmdCart3 As SqlCommand
            Dim strSQL3 As String = "Select SUM(Price * Quantity) FROM Cartline WHERE CartID= '" & strCartID & "'"
            Dim cartTotal As String
            connCart3 = New SqlConnection(strConn3)
            cmdCart3 = New SqlCommand(strSQL3, connCart3)
            connCart3.Open()
            cartTotal = cmdCart3.ExecuteScalar().ToString
            lbltotal.Text = "$" & cartTotal
            connCart3.Close()


        ElseIf e.CommandName = "cmdClearCart" Then
            Dim strSQL As String = "Delete FROM CartLine  where cartid = '" & strCartID & "'"
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("pocketstoreConnectionString").ConnectionString
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            SqlDSCart2.DataBind()
            lvCart.DataBind()

            'Change the subtotal on bottom when you click the clear cart button
            Dim strConn4 As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PocketStore.mdf;Integrated Security=True;Connect Timeout=30"
            Dim connCart4 As SqlConnection
            Dim cmdCart4 As SqlCommand
            Dim strSQL4 As String = "Select SUM(Price * Quantity) FROM Cartline WHERE CartID= '" & strCartID & "'"
            Dim cartTotal As String
            connCart4 = New SqlConnection(strConn4)
            cmdCart4 = New SqlCommand(strSQL4, connCart4)
            connCart4.Open()
            cartTotal = cmdCart4.ExecuteScalar().ToString
            lbltotal.Text = "$" & cartTotal
            connCart4.Close()

        End If
    End Sub

    Protected Sub checkoutButton_Click(sender As Object, e As EventArgs) Handles checkoutButton.Click


        Response.Redirect("checkout.aspx")

    End Sub




    Protected Sub lbUpdateQuantity_Click(sender As Object, e As EventArgs)

    End Sub


End Class





