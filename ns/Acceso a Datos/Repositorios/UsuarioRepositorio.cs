using Ecommerce.Acceso_a_Datos.Interfaces;
using Microsoft.Data.SqlClient;
using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Acceso_a_Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string? _CadenaConexion;
        public UsuarioRepositorio(IConfiguration config)
        {
            _CadenaConexion = config.GetConnectionString("DatabaseConnection");
        }
        public void ActualizarRefreshToken(UsuarioEntidad usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntidad? ObtenerUsuario(string NomUsuario)
        {
            var usuario = new UsuarioEntidad();
            using (SqlConnection conn = new SqlConnection(_CadenaConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SIS_GET_OBTENER_USUARIO", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PVCH_IN_NOMUSU", NomUsuario);

                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    if (reader.Read())
                    {
                        usuario = new UsuarioEntidad
                        {
                            CodUsuario = (int)reader["CodUsuario"],
                            NomUsuario = reader["NomUsuario"].ToString(),
                            PasswordHash = reader["Password"].ToString(),
                            CodRol = (int)reader["CodRol"]
                        };
                    }
                }

            }
            return usuario;
        }
    }
}
