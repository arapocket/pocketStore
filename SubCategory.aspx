<%@ Page Title="" Language="VB" MasterPageFile="~/MainLayout.master" AutoEventWireup="false" CodeFile="SubCategory.aspx.vb" Inherits="SubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



		

<!-- ds and dl for subcategories on side-->
<div class="col-sm-3 panel-heading">
				<h4 >
                    <asp:SqlDataSource ID="DSSubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:PocketStoreConnectionString %>" SelectCommand=""></asp:SqlDataSource>
                    <asp:DataList ID="dlSubCategory" runat="server" DataSourceID="DSSubCategory" RepeatDirection="Vertical">
			            <ItemTemplate>
				            <a  href="ProductDetail.aspx">
						        <span class="badge pull-right"></span>
						        <a href="SubCategory.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>&MainCatName=<%# Request.QueryString("MainCatName")%>&SubCatId=<%#Eval("CategoryID")%>&SubCatName=<%#Eval("CategoryName")%>"><%# Trim(Eval("CategoryName"))%></a>

					        </a>                    
			            </ItemTemplate>
		            </asp:DataList> 
				</h4>
			</div>    
      
<!-- ds and dl for products-->
<div class="col-sm-9 padding-right features_items">
<asp:Label ID="lblMainCatName" runat="server" Text=""></asp:Label>



<!-- "This Month's Featured Items" Heading-->
    <h2 class=" text-center "><asp:Label ID="lblBC" runat="server" Text="This Month's Featured Items"></asp:Label></h2>

    <asp:SqlDataSource ID="DSProductList" runat="server" ConnectionString="<%$ ConnectionStrings:PocketStoreConnectionString %>"></asp:SqlDataSource>
<!-- Each product takes 3 columns--> 
    <asp:Repeater ID="rpProductList" runat="server" DataSourceID="DSProductList">
    <ItemTemplate>                                     
    <div class="col-sm-3 single-products text-center productinfo">
						
<!--image--> 
    <a href="ProductDetail.aspx?
        MainCatId=<%#Request.QueryString("MainCatID")%>&MainCatName=<%#Request.QueryString("MainCatName")%>
        &SubCatId=<%#Eval("CategoryID")%>&SubCatName=<%#Request.QueryString("SubCatName")%>
        &ProductId=<%# Eval("ProductID")%>">
        <img class="product-image-wrapper" src="product-images/<%# Trim(Eval("ProductNo"))%>.jpg" alt="" /></a>

<!--price--> 			
    <h2><a href="ProductDetail.aspx?MainCatId=<%#Request.QueryString("MainCatID")%>&MainCatName=<%#Request.QueryString("MainCatName")%>&SubCatId=<%#Eval("CategoryID")%>&SubCatName=<%#Request.QueryString("SubCatName")%>&ProductId=<%# Eval("ProductID")%>">$<%# Eval("Price")%></a></h2>
<!--product code--> 
    <p>Product Code: <a href="ProductDetail.aspx?MainCatId=<%#Request.QueryString("MainCatID")%>&MainCatName=<%#Request.QueryString("MainCatName")%>&SubCatId=<%#Eval("CategoryID")%>&SubCatName=<%#Request.QueryString("SubCatName")%>&ProductId=<%# Eval("ProductID")%>"><%# Eval("ProductNo")%></a></p>
<!--product name--> 
    <p> <a href="ProductDetail.aspx?MainCatId=<%#Request.QueryString("MainCatID")%>&MainCatName=<%#Request.QueryString("MainCatName")%>&SubCatId=<%#Eval("CategoryID")%>&SubCatName=<%#Request.QueryString("SubCatName")%>&ProductId=<%# Eval("ProductID")%>"><%# Eval("ProductName")%></a></p
<!--cart button--> 
    <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>

					
    </div>  
    </ItemTemplate>        
    </asp:Repeater> 	
            			
</div>





</asp:Content>
