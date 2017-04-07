<%@ Page Title="" Language="VB" MasterPageFile="~/MainLayout.master" AutoEventWireup="false" CodeFile="receipt.aspx.vb" Inherits="receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
               <asp:SqlDataSource ID="SqlDSCart2" runat="server" 
                    DataSourceMode="DataSet"
                    ConnectionString="<%$ ConnectionStrings:PocketStoreConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:PocketStoreConnectionString.ProviderName %>">
                </asp:SqlDataSource>

<div class="container box " style="font-size:20px; text-align:center;">

<asp:ListView ID="lvCart" runat="server" DataSourceID="SqlDSCart2"
        DataKeyField="OrderID"
        RepeatColumns="1" DataKeyNames="OrderID">

        <LayoutTemplate>                                                          


           
            <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />  

                                                          
        </LayoutTemplate>

        <GroupTemplate>
        <asp:PlaceHolder runat="server" id="itemPlaceholder"></asp:PlaceHolder>
        </GroupTemplate>

        <ItemTemplate>   
            
            <div class =" row"  >       
Thank you, <%#Eval("firstname")%>. Your order will be shipping to the following address:
            </div>

            <div class="row"" >
                <br />
                <br />
                 <%#Eval("address")%>,  <%#Eval("city")%>, <%#Eval("state")%>, <%#Eval("zip")%>.
            </div>

            <br />
            <br />
            <br />

            <div style="color:#0094ff; font-family:'Buxton Sketch'; font-size:40px;">

            <div class="row">
                Subtotal: <%#Eval("subtotal")%>
            </div>
            <div class="row">
                Tax: <%#Eval("tax")%>
            </div>
            <div class="row">
                Total: <%#Eval("total")%>
            </div>

            </div>

           
                                                  
               

                             
        </ItemTemplate>


</asp:ListView>

</div>   


</asp:Content>

