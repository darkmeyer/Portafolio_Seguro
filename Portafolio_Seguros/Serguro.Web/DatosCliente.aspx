<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DatosCliente.aspx.cs" Inherits="Serguro.Web.DatosCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 68px;
    }
    .auto-style2 {
        width: 60px;
    }
    .auto-style3 {
        width: 69px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="centrar2"> 
    <h2>Datos Cliente:</h2>
        <br />

        <a href="#cliente"><asp:LoginStatus ID="LoginStatus1" runat="server"/></a>
        <table>
            <tr>
                <td class="auto-style1">Nombre:</td>
                <td><asp:Label ID="lblNombre" runat="server"></asp:Label></td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">Vehiculo:</td>
                <td>
                    <asp:Label ID="lblVehiculo" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Rut:</td>
                <td>
                    <asp:Label ID="lblRut" runat="server" ></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">Seguro:</td>
                <td>
                    <asp:Label ID="lblSeguro" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Ciudad:</td>
                <td><asp:Label ID="lblCiudad" runat="server"></asp:Label></td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Region:</td>
                <td>
                    <asp:Label ID="lblRegion" runat="server" ></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <h2>Siniestros:</h2>
        <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
</asp:Content>
