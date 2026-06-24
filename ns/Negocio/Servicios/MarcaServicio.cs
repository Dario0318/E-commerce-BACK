using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Negocio.DTOs;
using Ecommerce.Negocio.Interfaces;
using Ecommerce.Negocio.Validadores;

namespace Ecommerce.Negocio.Servicios
{
    public class MarcaServicio: IMarcaServicio
    {
        private readonly MarcaValidador _validar;
        private readonly IMarcaRepositorio _repo;

        public MarcaServicio(IMarcaRepositorio repo, MarcaValidador validar)
        {
            _validar = validar;
            _repo = repo;
        }

        public bool CrearMarca(MarcaDTO dto)
        {

            throw new NotImplementedException();
        }

        public bool EditarMarca(MarcaDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool EliminarMarca(int CodMarca)
        {
            throw new NotImplementedException();
        }

        public List<MarcaDTO> ListarMarcas()
        {
            throw new NotImplementedException();
        }

        public MarcaDTO ObtenerMarca(int CodMarca)
        {
            throw new NotImplementedException();
        }
    }
}
