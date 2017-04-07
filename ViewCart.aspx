<%@ Page Title="" Language="VB" MasterPageFile="~/MainLayout.master" AutoEventWireup="false" CodeFile="ViewCart.aspx.vb" Inherits="ViewCart" %>



<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


               <asp:SqlDataSource ID="SqlDSCart2" runat="server" 
                    DataSourceMode="DataSet"
                    ConnectionString="<%$ ConnectionStrings:PocketStoreConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:PocketStoreConnectionString.ProviderName %>">
                </asp:SqlDataSource>

<div class="container">


<asp:ListView ID="lvCart" runat="server" DataSourceID="SqlDSCart2"
        OnItemCommand="lvCart_OnItemCommand" DataKeyField="CartID,ProductID"
        RepeatColumns="1" DataKeyNames="CartID">

        <LayoutTemplate>                                                          
            <br />
            <br />


            <!--- Column Title Row -->      
            <div class="row" style="color:#fff; font-size:20px ">
                <div class="col-sm-2">
        
                </div>
                <div class="col-sm-2">
                    Details
                </div>
                <div class="col-sm-2">
                    Price
                </div>
                <div class="col-sm-2">
                    Quantity
                </div>
                <div class="col-sm-2">
                    Total For This Row
                </div>
                <div class="col-sm-2"></div>
            </div>  
            <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />  
            <!--BOTTOM ROW -->
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2" style="font-size:30px; font-style:normal; color:#ffd800; font-family:Candara";>
                <asp:LinkButton runat="server" ID="lbClearAll" Text='Clear Cart'
                CommandName="cmdClearCart" CommandArgument='<%#Eval("CartID")%>' />
                </div>
            </div>
        <br />
        <br />                                                              
        </LayoutTemplate>

        <GroupTemplate>
        <asp:PlaceHolder runat="server" id="itemPlaceholder"></asp:PlaceHolder>
        </GroupTemplate>

        <ItemTemplate>      
        <br />
        <br />                                                                 
        <!--- ITEM ROW -->                                 
        <div class="row" style="color:#0094ff">
            <!--- I. image -->     
            <div class="col-sm-2" >
                <img src="product-images/<%# Trim(Eval("ProductNo"))%>.jpg" width="80" height="120" >
            </div>
            <!--- II. details -->   
            <div class="col-sm-2">
                <%# Eval("ProductName")%>
            <div class="row">
            <div class="col-sm-2">
            <p><%# Eval("ProductID")%>/<%# Eval("ProductNo")%></p>
            </div>
            </div>
            </div>   
            <!--- III. price -->                                                        
            <div class="col-sm-2" >
            <div class="row">
            <div class="col-sm-2">
            <p>$<%# Eval("Price")%></p>
            </div>                                   
            </div>
            </div>
            <!--- IV. quantity -->                                                        
            <div class="col-sm-2 " >
                    <div class="row">
                    <asp:TextBox ID="tbQuantity" Text='<%#Eval("Quantity")%>' runat="server" Width="30px" />
                    <asp:LinkButton runat="server" OnClick="lbUpdateQuantity_Click" ID="lbUpdateQuantity" Text=' Update Quantity'
                    CommandName="cmdUpdateQuantity" CommandArgument='<%#Eval("ProductID") %>' />

                    </div>
            </div>
            <!--- V. subtotal -->                                                        
            <div class="col-sm-2">
            <p class="cart_total_price">$<%# Eval("Quantity") * Eval("Price") %></p>
            </div>
            <!--- IV. clear row -->                                                        
            <div class="col-sm-2" >
            <asp:LinkButton runat="server" ID="lbDelete" Text='Clear Row'
            CommandName="cmdDelete" CommandArgument='<%# Eval("ProductID") %>' />
            </div>
        </div>                             
        </ItemTemplate>


</asp:ListView>
                <!-- SUBTOTAL ROW -->
<div class="row" style="color:#0ff; font-size:30px ">
    <div class="col-sm-2">
        
    </div>
    <div class="col-sm-2">
        
    </div>
    <div class="col-sm-2">
        
    </div>
    <div class="col-sm-2">
        Subtotal: 
    </div>
    <div class="col-sm-2">
        <asp:Label  ID="lbltotal" runat="server" Text=""> </asp:Label>
    </div>
    <div class="col-sm-2">
        <asp:Button ID="checkoutButton" runat="server" text="Check Out" BackColor="#666699" ForeColor="Black" BorderStyle="ridge" BorderWidth="5px"  />
    </div>
</div>    

</div>   






</asp:Content>

