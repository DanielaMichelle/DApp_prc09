<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Ejercicio_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Calcular total de sueldos<br />
            <asp:Button ID="calcularSueldo" runat="server" Text="Calcular" OnClick="calcular_Sueldo" />
            <br />
            <asp:Label ID="sueldo_total" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Trabajadores<br />
            Area:&nbsp;
            <asp:DropDownList ID="DropDown_area" runat="server">
                <asp:ListItem>Docencia</asp:ListItem>
                <asp:ListItem>Recursos humanos</asp:ListItem>
                <asp:ListItem>Personal administrativo</asp:ListItem>
                <asp:ListItem>Investigación y desarrollo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Buscar_personal" runat="server" OnClick="mostrar_trabajadores_porArea" Text="Buscar" />
            <br />
            <asp:GridView ID="GridResults" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="crear_button" runat="server" OnClick="crear_Xml" Text="Crear" />
            <br />
        </div>
    </form>
</body>
</html>
