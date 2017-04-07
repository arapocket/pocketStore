<%@ Page Title="" Language="VB" MasterPageFile="~/MainLayout.master" AutoEventWireup="false" CodeFile="checkout.aspx.vb" Inherits="checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


                   <asp:SqlDataSource ID="SqlDSCart2" runat="server" 
                    DataSourceMode="DataSet"
                    ConnectionString="<%$ ConnectionStrings:PocketStoreConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:PocketStoreConnectionString.ProviderName %>">
                </asp:SqlDataSource>


<section class="checkout" >

<div class="container">
           






<div class="row">
<div class="col-xs-8">


<div class="box">                  
<h3>Checkout</h3>
<div class="box-header">
<div class="box-content">



<!-- FIRST NAME -->
        <div class="form-group">
        <label for="first_name" class="control-label">First name</label>
        <div class="controls">
        <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="firstnamevalid" ControlToValidate="firstname" ValidationExpression="[a-zA-Z]{1,}" ErrorMessage="Enter a valid name." EnableClientScript="false" runat="server" />
                    <asp:RequiredFieldValidator ID="namereq" ControlToValidate="firstname" ErrorMessage="Enter a valid name." EnableClientScript="false" runat="server" />

        </div>
        </div>


<!-- LAST NAME -->
        <div class="form-group">
        <label for="last_name" class="control-label">Last name</label>
        <div class="controls">
        <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="lastnamevalid" ControlToValidate="lastname" ValidationExpression="[a-zA-Z]{1,}" ErrorMessage="Enter a valid last name." EnableClientScript="false" runat="server" />
                     <asp:RequiredFieldValidator ID="lastnamereq" ControlToValidate="lastname" ErrorMessage="Enter a valid name." EnableClientScript="false" runat="server" />

        </div>
        </div>


<!-- Email -->
    <div class="form-group">
    <label for="email" class="control-label">Email:</label>
    <div class="controls">
    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="emailvalid" ControlToValidate="email" ValidationExpression="([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})" ErrorMessage="Enter a valid email." EnableClientScript="false" runat="server" />
                 <asp:RequiredFieldValidator ID="emailreq" ControlToValidate="email" ErrorMessage="Enter a valid email." EnableClientScript="false" runat="server" />

    </div>
    </div>


<!-- PHONE-->
        <div class="form-group">
<label for="phone" class="control-label">Phone</label>
<div class="controls">
        <asp:TextBox ID="phone" runat="server"></asp:TextBox>
             <asp:RegularExpressionValidator ID="phonevalid" ControlToValidate="phone" ValidationExpression="[0-9]{10}" ErrorMessage="Enter a valid phone number." EnableClientScript="false" runat="server" />
             <asp:RequiredFieldValidator ID="phonereq" ControlToValidate="phone" ErrorMessage="Enter a valid phone number." EnableClientScript="false" runat="server" />

</div>
</div>



<!-- STREET ADDRESS -->
    <div class="form-group">
        <label for="street_address" class="control-label">Street address</label>
        <div class="controls">
            <asp:TextBox ID="address" runat="server"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="addressvalid" ControlToValidate="address" ValidationExpression="[a-zA-Z0-9 ]{1,}" ErrorMessage="Enter a valid address." EnableClientScript="false" runat="server" />
                     <asp:RequiredFieldValidator ID="addressreq" ControlToValidate="address" ErrorMessage="Enter a valid phone address." EnableClientScript="false" runat="server" />
                        
        </div>
    </div>




<!-- CITY -->
    <div class="form-group">
        <label for="city" class="control-label">City</label>
        <div class="controls">
            <asp:TextBox ID="city" runat="server"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="cityvalid" ControlToValidate="city" ValidationExpression="[a-zA-Z ]{1,}" ErrorMessage="Enter a valid city." EnableClientScript="false" runat="server" />
                         <asp:RequiredFieldValidator ID="cityreq" ControlToValidate="city" ErrorMessage="Enter a valid city." EnableClientScript="false" runat="server" />
                         
        </div>
    </div>


<!-- STATE -->  
         
        <div class="form-group ">
<label for="state" class="control-label">State</label>
<div class="controls">
<asp:DropDownList id="state" runat="server" Width="100px"  AutoPostBack="True"  >


                  <asp:ListItem Selected="True" Value="CA">CA</asp:ListItem>
                  <asp:ListItem Value="NY">NY</asp:ListItem>
                  <asp:ListItem Value="FL">FL</asp:ListItem>
                  <asp:ListItem Value="CH">CH</asp:ListItem>
                  <asp:ListItem Value="NJ">NJ</asp:ListItem>

</asp:DropDownList>  
                                                                                 						
</div>
</div>

<!-- ZIP -->
        <div class="form-group">
        <label for="zip" class="control-label">Zip</label>
        <div class="controls">
        <asp:TextBox ID="zip" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="zipvalid" ControlToValidate="zip" ValidationExpression="[0-9]{5}" ErrorMessage="Enter a valid zip code." EnableClientScript="false" runat="server" />
                 <asp:RequiredFieldValidator ID="zipreq" ControlToValidate="zip" ErrorMessage="Enter a valid zip code." EnableClientScript="false" runat="server" />
                 
        </div>
    </div>


<!-- CREDIT CARD TYPE -->
        <div class="form-group">
<label for="cctype" class="control-label">Credit Card Type</label>
<div class="controls">
<asp:DropDownList id="cctype" runat="server" Width="100px" AutoPostBack="true">

                  <asp:ListItem Selected="True" Value="VISA">VISA</asp:ListItem>
                  <asp:ListItem Value="MASTERCARD">MASTERCARD</asp:ListItem>
                  <asp:ListItem Value="DISCOVER">DISCOVER</asp:ListItem>
                  <asp:ListItem Value="AMERICAN EXPRESS">AMERICAN EXPRESS</asp:ListItem>

</asp:DropDownList>
</div>
        </div>

<!-- CREDIT CARD FIELD -->
        <div class="form-group">
        <label for="ccfield" class="control-label">Credit Card #:</label>
        <div class="controls">
            <asp:TextBox ID="ccfield" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="ccvalid" ControlToValidate="ccfield" ValidationExpression="" ErrorMessage="Enter a valid credit card number." EnableClientScript="false" runat="server" />
                <asp:RequiredFieldValidator ID="ccreq" ControlToValidate="ccfield" ErrorMessage="Enter a valid credit card number." EnableClientScript="false" runat="server" />
                
        </div>
    </div>

<!-- EXP FIELD -->
        <div class="form-group ">
        <label for="expfield" class="control-label">Expiration Date: MMDD</label>
        <div class="controls">
            <asp:TextBox Width="60px" ID="ccexp" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="expvalid" ControlToValidate="ccexp" ValidationExpression="[0-9]{4}" ErrorMessage="Enter a valid credit card expiration date." EnableClientScript="false" runat="server" />
                <asp:RequiredFieldValidator ID="expreq" ControlToValidate="ccexp" ErrorMessage="Enter a valid credit card expiration date." EnableClientScript="false" runat="server" />

        </div>
    </div>



    <div class="form-group" style="font-size: 20px;">
        <div class="col-xs-3">Sub-total</div>
        <div class="col-xs-9">
            $: <asp:Label ID="subtotal" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="form-group" style="font-size: 20px; color: #0026ff;" >

        <div class="col-xs-3" >
            Tax
        </div>
        <div class="col-xs-9">$: 
            <asp:Label ID="tax" runat="server" Text=""></asp:Label></div>
    </div>

    <br />
    <br />
    <br />

    <div class="form-group" style="font-size: 20px;">

        <div class="col-xs-3">
            Total
        </div>
        <div class="col-xs-9">
            $: 
            <asp:Label ID="total" runat="server" Text=""></asp:Label>

        </div>
    </div>



    <!-- BOTTOM BUTTONS -->
      <div class="box-footer" style="background-color: #fff;">
        
            <asp:Button ID="backtocartbutton" CausesValidation="false" runat="server" CssClass="btn btn-primary pull-left add-to-cart fa fa-shopping-cart" Text="Back to Cart" />
            <asp:Button ID="submitbutton" CausesValidation="false" runat="server" CssClass="btn btn-primary pull-right add-to-cart fa fa-shopping-cart" Text="Submit" />
     
    </div>
    	
</div>
</div>
</div>			
</div>
    
    	    
</div>
</div>
            	
</section>

</asp:Content>

