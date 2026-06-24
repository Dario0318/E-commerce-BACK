using Ecommerce.Acceso_a_Datos.Interfaces;
using Microsoft.Data.SqlClient;
using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Acceso_a_Datos.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly string? _CadenaConexion;

        public CategoriaRepositorio(IConfiguration config)
        {
            _CadenaConexion = config.GetConnectionString("DatabaseConnection");
        }

        public bool Crear(CategoriaEntidad categoria)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_CadenaConexion))
                {
                    conn.Open(); // Abrimos la cadena de conexion
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_CREAR_CATEGORIA", conn); // Indicamos que procedimiento se va a ejecutar y le pasamos los parametros
                    cmd.CommandType = System.Data.CommandType.StoredProcedure; // Indicamos el tipo de Comando a utilizar
                    cmd.Parameters.AddWithValue("PINT_INT_CODCATEG", categoria.CodCategoria); // Le indicamos las variables
                    cmd.Parameters.AddWithValue("PINT_VCH_NOMCATEG", categoria.NomCategoria);
                    cmd.ExecuteNonQuery();
                }

                return exito = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return exito;
            }
        }

        public bool Editar(CategoriaEntidad categoria)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_CadenaConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_EDITAR_CATEGORIA", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PINT_INT_CODCATEG", categoria.CodCategoria);
                    cmd.Parameters.AddWithValue("PINT_INT_NOMCATEG",categoria.NomCategoria);
                    cmd.ExecuteNonQuery();
                }

                return exito = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return exito;
            }
        }

        public bool Eliminar(int CodCategoria)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_CadenaConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_ELIMINAR_CATEGORIA", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PINT_INT_CODCATEG", CodCategoria);
                    cmd.ExecuteNonQuery();
                    return exito = true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return exito;
            }
        }

        public List<CategoriaEntidad?> ObtenerDatos()
        {
            var oListaCategoria = new List<CategoriaEntidad?>();
            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SIS_MAE_GET_OBTENER_DATOS_CATEGORIAS", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        oListaCategoria.Add(new CategoriaEntidad()
                        {
                            CodCategoria = (int)reader["CodCategoria"],
                            NomCategoria = reader["NomCategoria"].ToString()
                        });
                    }
                }
                return oListaCategoria;
            }
        }

        public CategoriaEntidad? ObtenerId(int CodCategoria)
        {
            CategoriaEntidad categoria = new CategoriaEntidad();
            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SIS_MAE_GET_OBTENER_CATEGORIA_ID" , conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoria.CodCategoria = (int)reader["CodCategoria"];
                        categoria.NomCategoria = reader["NomCategoria"].ToString();
                    }
                }
            }
            return categoria;
        }
    }
}
