using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea1Final
{
    public partial class Reporte : System.Web.UI.Page
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
                    string consulta = $@"select d.id, v.id as idventa, a.idproducto, a.nombre, a.descripcion, d.cantidad, v.fecha from detalle d
                                       inner join venta v on v.id = d.idventa
                                       inner join articulos a on a.idproducto = d.idproducto";

                    DataTable data = con.HacerSelect(consulta);

                    if (data != null && data.Rows.Count > 0)
                    {

                        dataGrid.DataSource = data;
                        dataGrid.DataBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sin Datos para Mosta');", true);
                    }


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
    }
}