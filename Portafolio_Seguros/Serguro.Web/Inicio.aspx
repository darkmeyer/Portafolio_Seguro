<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Serguro.Web.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">        
        .auto-style2 {
            width: 107px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
    <h2>Datos Cliente:</h2>
        <br />
        <table>
            <tr>
                <td>Nombre:</td>
                <td><asp:Label ID="lblNombre" runat="server"></asp:Label></td>
                <td class="auto-style2">&nbsp;</td>
                <td>Vehiculo:</td>
                <td>
                    <asp:Label ID="lblVehiculo" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Rut:</td>
                <td>
                    <asp:Label ID="lblRut" runat="server" ></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>Seguro:</td>
                <td>
                    <asp:Label ID="lblSeguro" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Ciudad:</td>
                <td><asp:Label ID="lblCiudad" runat="server"></asp:Label></td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Region:</td>
                <td>
                    <asp:Label ID="lblRegion" runat="server" ></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <h2>Siniestros:</h2>
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
