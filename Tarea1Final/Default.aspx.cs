using Conexion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea1Final.Modelo;

namespace Tarea1Final
{
    public partial class _Default : Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.Conexion con = new Conexion.Conexion();

                if(!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtCantidad.Text) && !String.IsNullOrEmpty(txtDescripcion.Text))
                {

                    String cosultaIMG = "";

                    byte[] bytes = null;
                    if (FileUpload1.HasFile)
                    {
                       
                        using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                        {
                            bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                        }

                        cosultaIMG = $@"Insert into imagenes(idproducto, img, name)
                                        VALUES('{txtID.Text}', null, @imagen)";
                    }


                    string consulta = $@"IF((select COUNT(idproducto) from articulos where idproducto = '{txtID.Text}') = 0)
                                           BEGIN
                                                 INSERT INTO articulos(idproducto, nombre, descripcion, cantidad) 
                                                 VALUES('{txtID.Text}', '{txtNombre.Text}', '{txtDescripcion.Text}',  '{Convert.ToDouble(txtCantidad.Text)}')
 

                                                ";


                    String transaction = string.Format(@"BEGIN TRANSACTION 
                                               BEGIN TRY 
                                               BEGIN 
                                                    {0}

                                                    {1}

                                                
                                                
                                                   END
                                                 ELSE
                                                     BEGIN
                                                       select -3;
                                                     END


    
                                                    COMMIT; 
                                                    SELECT 2
                                               END 
                                               END TRY 
                                               BEGIN CATCH 
                                                 select -1;
                                               END CATCH; ", consulta, cosultaIMG, Convert.ToDouble(txtCantidad.Text), txtID.Text);

                    if (con.AbrirConexion())
                    {
                        int result = con.HacerTransactionImagen(transaction, bytes);
                        
                       if (result > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Acticulo Guardado');", true);
                            txtDescripcion.Text = "";
                            txtID.Text = "";
                            txtNombre.Text = "";
                            txtCantidad.Text = "";
                        }
                        else
                        {
                            if(result == -3)
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Este id ya esta guardado');", true);
                            else
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error al guardar');", true);
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
                else
                {
                    con.CerrarConexion();
                    con = null; 
                }


            }
            catch (Exception ex)
            { 
            }
        }
    }
}