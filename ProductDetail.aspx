<%@ Page Title="" Language="VB" MasterPageFile="~/MainLayout.master" AutoEventWireup="false" CodeFile="ProductDetail.aspx.vb" Inherits="ProductDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


<!-- sub categories on left of screen -->
<div class="left-sidebar panel-heading col-sm-3">
<h4>
<asp:sqldatasource id="dsproductlist" runat="server" connectionstring="<%$ connectionstrings:pocketstoreconnectionstring %>" selectcommand=""></asp:sqldatasource>
<asp:sqldatasource id="dssubcategory" runat="server" connectionstring="<%$ connectionstrings:pocketstoreconnectionstring %>" selectcommand=""></asp:sqldatasource>
<asp:DataList ID="dlSubCategory" runat="server" DataSourceID="DSSubCategory"
RepeatDirection="Vertical">
<ItemTemplate>
<a href="ProductDetail.aspx">
<span class="badge pull-right"></span>
<a href="SubCategory.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>&MainCatName=<%# Request.QueryString("MainCatName")%>&SubCatId=<%# Eval("CategoryID")%>&SubCatName=<%# Eval("CategoryName")%>"><%# Trim(Eval("CategoryName"))%></a>
</a>
</ItemTemplate>
</asp:DataList>
 </h4>
</div>


<!-- Outer Column I. Product Details -->
<div class="col-sm-9 padding-right">
        <!-- Column Within Column -->
        <div class="col-sm-9 padding-right product-details">
        <!-- Column I. The Product Image -->
        <div class="col-sm-5 view-product"><asp:Image ID="imgProduct" runat="server" /></div>
        <!-- Column II. The Product Details 1 -->
        <div class="col-sm-7">
        <!-- Name and Product Code -->
        <h2><asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></h2>
        <p>Product Code: <asp:Label ID="lblProductNo" runat="server" Text=""></asp:Label><asp:Label ID="lblProductID" runat="server" Text=""></asp:Label></p> 


        <!-- Price and Quantity Row -->
        <div class="row ">
        <div class="col-xs-6 ara1" >
        <p></p>
        <p></p>
        <!-- Price -->
        <span>US$<asp:Label ID="lblprice" runat="server" Text=""></asp:Label></span>
        <!-- Quantity -->
        <p><label>Quantity:</label></p>
        <asp:TextBox ID="tbQuantity" runat="server"></asp:TextBox>
        <!-- Cart Button -->
        <asp:Button ID="btnAddToCart" CausesValidation="false" runat="server" CssClass="btn btn-default add-to-cart fa fa-shopping-cart" Text="Add to Cart" />
        <!-- Validator for Quantity--> 
        <div>
        <asp:RegularExpressionValidator ID="quantvalidator" ControlToValidate="tbQuantity" ValidationExpression="[0-9]{1,5}" ErrorMessage="Enter a valid number dummie " EnableClientScript="false" runat="server" />
        </div>
        </div>
        </div>
        </div>
        </div>
</div>
<!-- Outer Column II. (Empty) -->
<div class="col-sm-3"></div>


</asp:Content>

