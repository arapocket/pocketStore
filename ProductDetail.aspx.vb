Imports System.Data
Imports System.Data.SqlClient
Partial Class ProductDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString("MainCatID") <> "" Then
            dssubcategory.SelectCommand = "Select * From Category Where Parent = " & CInt(Request.QueryString("MainCatID"))
            DSProductList.SelectCommand = "Select * From Product Where Parent = " & CInt(Request.QueryString("MainCatID")) & " and Featured = 'Y'"
        End If
        If Request.QueryString("SubCatID") <> "" Then
            DSProductList.SelectCommand = "Select * From Product Where CategoryID = " & CInt(Request.QueryString("SubCatID"))
        End If

        If Request.QueryString("ProductID") <> "" Then
            Dim strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PocketStore.mdf;Integrated Security=True;Connect Timeout=30"
            Dim connProduct As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim drProduct As SqlDataReader
            Dim strSQL As String = "SELECT * FROM Product Where ProductID = " & CInt(Request.QueryString("ProductID"))
            connProduct = New SqlConnection(strConn)
            cmdProduct = New SqlCommand(strSQL, connProduct)
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                lblProductName.Text = drProduct.Item("ProductName")
                lblProductNo.Text = drProduct.Item("ProductNo")
                lblProductID.Text = drProduct.Item("ProductID")
                lblprice.Text = drProduct.Item("Price")
                imgProduct.ImageUrl = "product-images/" + Trim(drProduct.Item("ProductNo")) + ".jpg"
            End If
        End If

        If Request.QueryString("MainCatID") <> "" Then
            DSSubCategory.SelectCommand = "Select * From Category Where Parent = " & CInt(Request.QueryString("MainCatID"))
        End If

    End Sub



    Protected Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click

        quantvalidator.Validate()

        If quantvalidator.IsValid Then

            Dim drCartLine As SqlDataReader
            Dim strSQLStatement As String
            Dim cmdSQL As SqlCommand
            Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("PocketStoreConnectionString").ConnectionString
            Dim conn As New SqlConnection(strConnectionString)
            conn.Open()
            ' *** get product price
            strSQLStatement = "SELECT * FROM Product WHERE ProductID = " & CInt(lblProductID.Text)
            cmdSQL = New SqlCommand(strSQLStatement, conn)
            drCartLine = cmdSQL.ExecuteReader()
            Dim sngPrice As Single
            If drCartLine.Read() Then
                sngPrice = drCartLine.Item("Price")

            End If
            conn.Close()
            '*** get CartID
            Dim strCartID As String
            If HttpContext.Current.Request.Cookies("CartID") Is Nothing Then
                strCartID = GenerateRandomString(10, False)
                Dim CookieTo As New HttpCookie("CartID", strCartID)
                HttpContext.Current.Response.AppendCookie(CookieTo)
            Else
                Dim CookieBack As HttpCookie
                CookieBack = HttpContext.Current.Request.Cookies("CartID")
                strCartID = CookieBack.Value
            End If





            strSQLStatement = "IF NOT EXISTS (SELECT * FROM Cartline WHERE CartID = '" & strCartID & "' AND ProductID = '" & CInt(lblProductID.Text) & "') BEGIN  INSERT INTO CartLine (CartID, ProductID, ProductName, ProductNo, Quantity, Price) values('" & strCartID & "', " & CInt(lblProductID.Text) & ", '" & lblProductName.Text & "', '" & lblProductNo.Text & "', " & CInt(tbQuantity.Text) & ", " & sngPrice & ") END ELSE BEGIN UPDATE Cartline SET Quantity = (Quantity + " & CInt(tbQuantity.Text) & ") WHERE ProductID = " & CInt(lblProductID.Text) & " END"
            cmdSQL = New SqlCommand(strSQLStatement, conn)
            conn.Open()
            drCartLine = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
            Response.Redirect("ViewCart.aspx")

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
