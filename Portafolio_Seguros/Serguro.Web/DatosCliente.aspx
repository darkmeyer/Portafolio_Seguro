<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DatosCliente.aspx.cs" Inherits="Serguro.Web.DatosCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Datos Cliente:</h2>
        <asp:Label ID="lblRefresh" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnRefresh" runat="server" Text="Refrescar Datos" OnClick="btnRefresh_Click" />
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
                <td><strong>Poliza:</strong></td>
                <td>
                    <asp:Button ID="btnPoliza" runat="server" Text="Ver" OnClick="btnPoliza_Click" />
                </td>
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
        <h3>Vehiculos:</h3><br />
        <asp:DataList ID="dataListVehiculo" runat="server">
        <ItemTemplate>
            <strong>Patente:</strong>
            <asp:Label ID="PatenteLabel" runat="server" Text='<%# Eval("Patente") %>' />
            <strong>Anio:</strong>
            <asp:Label ID="AnioLabel" runat="server" Text='<%# Eval("Anio") %>' />
            <strong>Modelo:</strong>
            <asp:Label ID="ModeloLabel" runat="server" Text='<%# Eval("Modelo.Nombre") %>' />
            <strong>Marca:</strong>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Modelo.Marca.Nombre") %>' />
            <br />
        </ItemTemplate>
    </asp:DataList>        
        <br />
        <h2>Siniestros:</h2>
        <asp:Label ID="lblgrid1Msj" runat="server"></asp:Label>
        <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcommand="CustomersGridView_RowCommand" OnSelectedIndexChanging="Seleccionar" CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" CssClass="mygrid">
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    <asp:BoundField DataField="Patente" HeaderText="Patente" SortExpression="Patente" />
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Movimientos"/>
                    <asp:buttonfield buttontype="Button" 
                        commandname="Presupuesto"
                        text="Presupuesto"/>
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
        <asp:Label ID="lblGrid2Msj" runat="server"></asp:Label>
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
