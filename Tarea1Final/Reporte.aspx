<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Tarea1Final.Reporte" MasterPageFile="~/Site.Master"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="Content/Styles.css" />
    <title>Reporte de Ventas</title>
</head>
<body>
   
          <div>
            <asp:GridView runat="server" ID="dataGrid" AutoGenerateColumns="false" UseAccessibleHeader="true"
                CssClass="table-condensed">


                <Columns>
                    <asp:BoundField HeaderText="Id Venta" DataField="idventa"></asp:BoundField>
                    <asp:BoundField HeaderText="Id Producto" DataField="idproducto"></asp:BoundField>
                    <asp:BoundField HeaderText="Nombre" DataField="nombre"></asp:BoundField>
                    <asp:BoundField HeaderText="Descripcion" DataField="descripcion"></asp:BoundField>
                    <asp:BoundField HeaderText="Cantidad" DataField="cantidad"></asp:BoundField>
                    <asp:BoundField HeaderText="Fecha" DataField="fecha"></asp:BoundField>
          
                </Columns>


            </asp:GridView>
            <br />
            <br />

        </div>
  
</body>
</html>
      </asp:Content>
