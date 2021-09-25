using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using System.Configuration;
using System.Linq;

namespace Conexion
{

    public class Conexion
    {
        SqlConnection cnx = null;
        SqlCommand comando = new SqlCommand();
        public Conexion()
        {
            string cadenaConexion = "Server=127.0.0.1;DataBase=tica;User Id=pruebas;Password=12345;";
            //instaciamos el objeto cnx con la cadena de conexion
            cnx = new SqlConnection(cadenaConexion);
        }


        #region AbrirConexion
        /// <summary>
        /// Abre la Conexion
        /// </summary>
        /// <returns>boolean</returns>
        public bool AbrirConexion()
        {
            //Variable creada para saber el tipo de dato devuelto
            bool exito = true;

            try
            {
                cnx.Open();
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }
        #endregion AbrirConexion

        #region CerrarConexion
        /// <summary>
        /// Cierra la Conexion
        /// </summary>
        /// <returns>boolean</returns>
        public bool CerrarConexion()
        {
            bool exito = true;
            try
            {
                cnx.Close();
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;
        }
        #endregion CerrarConexion   


        #region HacerSelect
        /// <summary>
        /// Realiza consultas de tipo "select"
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>DataTable</returns>
        public DataTable HacerSelect(string consulta)
        {
            //Se instancia el objeto dtResultados
            DataTable dtResultados = new DataTable("Resultado");
            //se instancia un objeto Sqlcommand que recibe dos parametros
            //uno es una consulta y el otro es una conexion
            SqlCommand comando = new SqlCommand(consulta, cnx);
            //Se crea un objeto SqlDataAdapter y se le da como parametro
            //el objeto SqlCommand creado anteriormente
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            //se usa el objeto adapter para llenar la DataTable "dtResultado"
            //con el metodo ".Fill" que recibe como parametro el objeto
            //datTable a llenar
            adapter.Fill(dtResultados);

            //Se devuelve la dataTable dtResultados
            return dtResultados;
        }
        #endregion HacerSelect

        #region HacerHit
        /// <summary>
        /// Metodo que insertar,borrar,actualiza datos de la base de datos
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>int</returns>
        public int HacerHit(string consulta)
        {
            int numeroRegistros = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //instanciamos un objeto sqlcommand con los dos parametros que necesita
                    // que son una consulta y una conexion
                    comando = new SqlCommand(consulta, cnx);
                    try
                    {
                        //Ejecucion de la sentencia
                        numeroRegistros = comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        numeroRegistros = -1;
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
                numeroRegistros = -1;
            }
            catch (ApplicationException)
            {
                numeroRegistros = -1;
            }

            //si la consulta se llevo sin problemas esta devolvera 
            //el numero total de registros afectados que seran de 0 en adelante
            return numeroRegistros;
        }
        #endregion HIT


           #region HacerHitScalar
        /// <summary>
        /// Metodo que insertar,borrar,actualiza datos de la base de datos
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>int</returns>
        /// Este hace hit pudiendo agregar consultas complejas de SQL
        /// 
        public int HacerHitScalar(string consulta)
        {
            int numeroRegistros = 0;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    //instanciamos un objeto sqlcommand con los dos parametros que necesita
                    // que son una consulta y una conexion
                    comando = new SqlCommand(consulta, cnx);

                    try
                    {
                        //Ejecucion de la sentencia
                        numeroRegistros = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        numeroRegistros = -1;
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
                numeroRegistros = -1;
            }
            catch (ApplicationException)
            {
                numeroRegistros = -1;
            }

            //si la consulta se llevo sin problemas esta devolvera 
            //el numero total de registros afectados que seran de 0 en adelante
            return numeroRegistros;
        }
        #endregion HIT

        #region Hacer Transaction con Imagen
        public int HacerTransactionImagen(string consulta, byte[] img)
        {
            int numeroRegistros = 0;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    comando = new SqlCommand(consulta, cnx);

                    if (img != null)
                    {
                        SqlParameter imageParam = comando.Parameters.Add("@imagen", SqlDbType.Image);
                        imageParam.Value = img;
                    }

                    comando.CommandTimeout = 60;

                    try
                    {
                        numeroRegistros = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    catch (Exception gt)
                    {
                        numeroRegistros = -1;
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException s)
            {
                numeroRegistros = -1;
            }
            catch (ApplicationException s)
            {
                numeroRegistros = -1;
            }

            return numeroRegistros;
        }
        #endregion
    }
}
