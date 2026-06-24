using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Dominio.Entidades;
using Microsoft.Data.SqlClient;

namespace Ecommerce.Acceso_a_Datos.Repositorios
{
    public class MarcaRepositorio: IMarcaRepositorio
    {
        private readonly string? _CadenaConexion;
        public MarcaRepositorio(IConfiguration configuration)
        {
           _CadenaConexion = configuration.GetConnectionString("DatabaseConnection");
        }

        public bool CrearMarca(MarcaEntidad marca)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_CadenaConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_CREAR_MARCA", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PVCH_IN_MARCA",marca.NomMarca);
                    cmd.ExecuteNonQuery();

                    return exito = true;
                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return exito;
            }

        }

        public bool EditarMarca(MarcaEntidad marca)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_CadenaConexion))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_EDITAR_MARCA", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PVHC_IN_NOMARCA", marca.NomMarca);
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

        public bool EliminarMarca(int CodMarca)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_CadenaConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SIS_MAE_SET_ELIMINAR_MARCA", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PINT_INT_CODMARCA", CodMarca);
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

        public List<MarcaEntidad> ListarMarcas()
        {
            var ListaMarcas = new List<MarcaEntidad>();

            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SIS_MAE_GET_LISTAR_MARCAS", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        ListaMarcas.Add(new MarcaEntidad
                        {
                            CodMarca = (int)reader["CodMarca"],
                            NomMarca = reader["NomMarca"].ToString()
                        });
                    }
                }
            }
            return ListaMarcas;
        }

        public MarcaEntidad? ObtenerMarca(int CodMarca)
        {
            var Marca = new MarcaEntidad();

            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SIS_MAE_GET_OBTENER_PRODUCTO", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PINT_INT_CODMARCA", CodMarca);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Marca.CodMarca = (int)reader["CodMarca"];
                        Marca.NomMarca = reader["NomMarca"].ToString();
                    }
                }
            }
            return Marca;
        }
    }
}
