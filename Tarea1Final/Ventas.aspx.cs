using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea1Final
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack) 
                    BindData();  
        }

        public void BindData()
        {
            try
            {
                Conexion.Conexion con = new Conexion.Conexion();

                if (con.AbrirConexion())
                {
                    string consulta = $@"select a.idproducto, cantidad, nombre, descripcion, name from articulos a
                                         INNER JOIN imagenes i on i.idproducto = a.idproducto
                                          where a.cantidad > 0";

                    DataTable data = con.HacerSelect(consulta);

                    if (data != null && data.Rows.Count > 0)
                    {
                         
                    }
                    else
                    {
                       
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sin Datos para Mostrar :C');", true);
                    }

                    dataGrid.DataSource = data;
                    dataGrid.DataBind();

                    con.CerrarConexion();
                    con = null;
                }
                else
                {

                }
            }
            catch (Exception ex)
            { 
            }
        }

        protected void dataGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["name"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
            }
        }

        protected void dataGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Comprar")
                {
                    //INDEX DEL ROW
                    int rowIndex = Convert.ToInt32(e.CommandArgument);

                    //ROW SELECCIONADO
                    GridViewRow row = dataGrid.Rows[rowIndex];

                    //Obtenemos el id
                    string ID_Producto = row.Cells[0].Text;


                    Conexion.Conexion con = new Conexion.Conexion();

                    String transaction = $@"BEGIN TRANSACTION 
                                               BEGIN TRY 
                                               BEGIN 
                                                   
                                                    DECLARE @idVenta int;
                                                    set @idVenta = (select ISNULL(MAX(id), 0) + 1 FROM venta);

                                                    IF((select cantidad from articulos where idproducto = '{ID_Producto}') > 0)
                                                        BEGIN
                                                                INSERT INTO venta(id, fecha, estado)
                                                                VALUES(@idVenta , GETDATE(), 1)


                                                                INSERT INTO detalle (id, idventa, idproducto, cantidad, estado)
                                                                VALUES((select ISNULL(MAX(id), 0) + 1 FROM detalle), @idVenta, {ID_Producto} , 1, 1)

                                                                UPDATE articulos set cantidad = cantidad -  1 where idproducto = {ID_Producto} 

                                                                        SELECT 2;
                                                        END
                                                      ELSE
                                                            SELECT -100;

    
                                                    COMMIT; 
                                                    
                                               END 
                                               END TRY 
                                               BEGIN CATCH 
                                                 select -1;
                                               END CATCH;";

                    if (con.AbrirConexion())
                    {
                        int result = con.HacerHitScalar(transaction);

                        if (result > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Acticulo Comprado');", true);
                            BindData();

                        }
                        else
                        {
                            if (result == -100)
                                BindData();
                            else
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error al Comprar :-C');", true);
                        }


                        con.CerrarConexion();
                        con = null;
                    }
                    else
                    {
                        con.CerrarConexion();
                        con = null;
                    }


                }
            }
            catch (Exception ex)
            { 
            }
        }
    }
}