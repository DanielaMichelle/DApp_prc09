<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="XML.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="cmdCreateXml" runat="server" OnClick="cmdCreateXml_Click" Text="Crear XML" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cmdReadXml" runat="server" OnClick="cmdReadXml_Click" Text="Leer XML (como texto)" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cdmReadXmlAsObjects" runat="server" OnClick="cmdReadXmlAsObjects_Click" Text="Leer XML (como objeto)" />
            <br />
            <br />
            <asp:Label ID="lblXml" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gridResults" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
