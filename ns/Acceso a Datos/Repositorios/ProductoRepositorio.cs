using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Dominio.Entidades;
using Microsoft.Data.SqlClient;

namespace Ecommerce.Acceso_a_Datos.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly string? _CadenaConexion;

        public ProductoRepositorio(IConfiguration configuration)
        {
            _CadenaConexion = configuration.GetConnectionString("DatabaseConnection");
        }

        public bool CrearProducto(ProductoEntidad producto)
        {
            bool exito = false;
            using (SqlConnection conn = new SqlConnection(_CadenaConexion)) 
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_CREAR_PRODUCTO", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PVCH_IN_NOMPRD", producto.NomProducto);
                    cmd.Parameters.AddWithValue("PTXT_IN_DESCRP", producto.Descripcion);
                    cmd.Parameters.AddWithValue("PINT_IN_ESTPRD", producto.CodEstadoProducto);
                    cmd.Parameters.AddWithValue("PINT_IN_CODMAR", producto.CodMarca);
                    cmd.Parameters.AddWithValue("PINT_IN_CODSUBCATEG", producto.CodSubCategoria);
                    cmd.ExecuteNonQuery();
                    return exito = true;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return exito;
                }
            }
        }

        public bool EditarProducto(ProductoEntidad producto)
        {
            bool exito = false;
            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_EDITAR_PRODUCTO", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PINT_INT_CODPRD", producto.CodProducto);
                    cmd.Parameters.AddWithValue("PVCH_IN_NOMPRD", producto.NomProducto);
                    cmd.Parameters.AddWithValue("PTXT_IN_DESCRP", producto.Descripcion);
                    cmd.Parameters.AddWithValue("PINT_IN_ESTPRD", producto.CodEstadoProducto);
                    cmd.Parameters.AddWithValue("PINT_IN_CODMAR", producto.CodMarca);
                    cmd.Parameters.AddWithValue("PINT_IN_CODSUBCATEG", producto.CodSubCategoria);
                    cmd.ExecuteNonQuery();
                    return exito = true;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return exito;
                }
            }
        }
        public bool EliminarProducto(int CodProducto)
        {
            bool exito = false;
            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_ELIMINAR_PRODUCTO", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PINT_IN_CODPRD", CodProducto);
                    cmd.ExecuteNonQuery();
                    return exito = true;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return exito;
                }
            }
        }
        public List<ProductoEntidad> ListarProductos()
        {
            var ListaProductos = new List<ProductoEntidad>();
            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SIS_MAE_GET_LISTAR_PRODUCTOS", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        ListaProductos.Add(new ProductoEntidad
                        {
                            CodProducto = (int)reader["CodProducto"],
                            NomProducto = reader["NomProducto"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            CodEstadoProducto = (int)reader["CodEstadoProducto"],
                            CodMarca = (int)reader["CodMarca"],
                            CodSubCategoria = (int)reader["CodSubCategoria"],
                            Precio = (decimal)reader["Precio"]
                        });
                    }
                }
            }
            return ListaProductos;
        }

        public ProductoEntidad? ObtenerProducto(int CodProducto)
        {
            var Producto = new ProductoEntidad();

            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SIS_MAE_GET_OBTENER_PRODUCTO", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PINT_INT_CODPRD", CodProducto);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Producto.CodProducto = (int)reader["CodProducto"];
                        Producto.NomProducto = reader["NomProducto"].ToString();
                        Producto.Descripcion = reader["Descripcion"].ToString();
                        Producto.CodSubCategoria = (int)reader["CodSubCategoria"];
                        Producto.CodMarca = (int)reader["CodMarca"];
                        Producto.CodEstadoProducto = (int)reader["CodEstadoProducto"];
                        Producto.Precio = (decimal)reader["Precio"];
                    }
                }
            }

            return Producto;
        }
    }
}
