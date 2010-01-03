<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generate-textfile.aspx.cs" Inherits="newsflippers.generate_textfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Write Text File" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
