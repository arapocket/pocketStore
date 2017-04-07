
Partial Class SubCategory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString("MainCatID") <> "" Then
            lblBC.Text = Request.QueryString("MainCatName") & " (Featured Items)"
            DSSubCategory.SelectCommand = "Select * From Category Where Parent = " & CInt(Request.QueryString("MainCatID"))
            DSProductList.SelectCommand = "Select * From Product Where Parent = " & CInt(Request.QueryString("MainCatID")) & " and Featured = 'Y'"
        End If
        If Request.QueryString("SubCatID") <> "" Then
            DSProductList.SelectCommand = "Select * From Product Where CategoryID = " & CInt(Request.QueryString("SubCatID"))
            lblBC.Text = Request.QueryString("MainCatName") + " > " + Request.QueryString("SubCatName")
        End If
    End Sub

End Class
