<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DatosCliente.aspx.cs" Inherits="Serguro.Web.DatosCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Datos Cliente:</h2>
        <br />

        <a href="#cliente"><asp:LoginStatus ID="LoginStatus1" runat="server"/></a>
        <div class="tabla">
        <table>
            <tr>
                <td><strong>Nombre:</strong>&nbsp;</td>
                <td><asp:Label ID="lblNombre" runat="server"></asp:Label></td>
                <td>&nbsp;</td>
                <td><strong>Ciudad:</strong>&nbsp;</td>
                <td>
                    <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Rut:</strong>&nbsp;</td>
                <td>
                    <asp:Label ID="lblRut" runat="server" ></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td><strong>Region:</strong>&nbsp;</td>
                <td>
                    <asp:Label ID="lblRegion" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Estado:</strong>&nbsp;</td>
                <td>
                    <asp:Label ID="lblEstado" runat="server" ></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
            </tr>
        </table>
            </div>
        <table>
            <tr>
                <td><strong>Vehiculos:&nbsp;</strong></td>
                <td>
                    <asp:Label ID="lblVehiculo" runat="server" ></asp:Label>
                </td>
            </tr>
    </table>
        <br />
        <h2>Siniestros:</h2>
        <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="Seleccionar" CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" CssClass="mygrid">
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    <asp:BoundField DataField="Patente" HeaderText="Patente" SortExpression="Patente" />
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Movimientos" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        <br />
        <asp:Button ID="btnVolverSiniestros" runat="server" Text="Volver" OnClick="btnVolverSiniestros_Click" />
        <br />
        <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="3" Enabled="False" ForeColor="Black" GridLines="Vertical" CssClass="mygrid" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
</asp:Content>
