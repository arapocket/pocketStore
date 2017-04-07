<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Payment.aspx.vb" Inherits="Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        CC <asp:TextBox ID="ccField" runat="server"></asp:TextBox>
        Amount $ <asp:TextBox ID="amountField" runat="server"></asp:TextBox>
        <asp:LinkButton ID="submitButton" runat="server" Text="Submit"></asp:LinkButton>

    
    </div>
    </form>
</body>
</html>
