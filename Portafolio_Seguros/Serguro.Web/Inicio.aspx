<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Serguro.Web.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Datos Cliente:</h2>
    <table>
        <tr>
            <td>Nombre:</td>
            <td><asp:Label ID="lblNombre" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Rut:</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ciudad:</td>
            <td><asp:Label ID="lblCiudad" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
</asp:Content>
