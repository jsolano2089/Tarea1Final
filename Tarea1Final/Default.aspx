<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tarea1Final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="Content/Styles.css" />
    <style>
        #customers {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #customers td, #customers th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #customers tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #customers tr:hover {
                background-color: #ddd;
            }

            #customers th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #04AA6D;
                color: white;
            }
    </style>


    <div class="row">
        <div class="col-md-4">
            <h1>Registro de productos</h1>
            <table id="customers">

                <tr>
                    <td>
                        <asp:Label ID="lblID" runat="server" Text="Codigo"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                </tr>



                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Descripción"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td>
                        <asp:Label ID="lblImg" runat="server" Text="Imagen"></asp:Label></td>
                    <td>
                         <asp:FileUpload ID="FileUpload1" runat="server" />  </td>
                </tr>


                <tr>
                    <td></td>
                    <td>
                        <asp:Button runat="server" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" /></td>

                </tr>
            </table>





        </div>
    </div>

</asp:Content>
