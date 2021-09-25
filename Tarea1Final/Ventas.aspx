<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Tarea1Final.Ventas" MasterPageFile="~/Site.Master"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <link rel="stylesheet" href="Content/Styles.css" />

    <title>Comprar</title>
</head>

<body>
    <div>
            <asp:GridView runat="server" ID="dataGrid" AutoGenerateColumns="false" UseAccessibleHeader="true"
                CssClass="table-condensed" OnRowDataBound="dataGrid_RowDataBound" OnRowCommand="dataGrid_RowCommand">


                <Columns>
                    <asp:BoundField HeaderText="Cod. Producto" DataField="idproducto"></asp:BoundField>
                    <asp:BoundField HeaderText="Nombre" DataField="nombre"></asp:BoundField>
                    <asp:BoundField HeaderText="Descripcion" DataField="descripcion"></asp:BoundField>
                    <asp:BoundField HeaderText="Cantidad" DataField="cantidad"></asp:BoundField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="150" Height="150"/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField CommandName="Comprar" HeaderText="Comprar" Text="Comprar">
                        <ControlStyle CssClass="UsersGridViewButton"/>
                    </asp:ButtonField>
                </Columns>


            </asp:GridView>
            <br />
            <br />

        </div>
        <%--  <div>
            <asp:DataGrid ID="Grid1" runat="server" PageSize="5" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundColumn HeaderText="EmpId" DataField="EmpId"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="F_Name" DataField="F_Name"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="L_Name" DataField="L_Name"></asp:BoundColumn>
                    <asp:BoundColumn DataField="City" HeaderText="City"></asp:BoundColumn>
                    <asp:BoundColumn DataField="EmailId" HeaderText="EmailId"></asp:BoundColumn>
                    <asp:BoundColumn DataField="EmpJoining" HeaderText="EmpJoining"></asp:BoundColumn>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>
        </div>--%>
</body>

</html>

    </asp:Content>
