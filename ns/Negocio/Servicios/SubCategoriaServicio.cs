using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Acceso_a_Datos.Repositorios;
using Ecommerce.Dominio.Entidades;
using Ecommerce.Negocio.DTOs;
using Ecommerce.Negocio.Interfaces;
using Ecommerce.Negocio.Validadores;

namespace Ecommerce.Negocio.Servicios
{
    public class SubCategoriaServicio : ISubCategoriaServicio
    {
        private readonly ISubCategoriaRepositorio _repo;
        private readonly SubCategoriaValidador _validador;
        public SubCategoriaServicio(ISubCategoriaRepositorio repo, 
            SubCategoriaValidador validador)
        {
            _repo = repo;
            _validador = validador;
        }

        public bool CrearSubCategoria(SubCategoriaDTO dto)
        {
            _validador.Validar(dto);

            var entidad = new SubCategoriaEntidad
            {
                CodSubCategoria = dto.CodSubCategoria,
                CodCategoria = dto.CodCategoria,
                NomSubCategoria = dto.NomSubCategoria
            };

            return _repo.CrearSubCategoria(entidad);
        }

        public bool EditarSubCategoria(SubCategoriaDTO dto)
        {
            _validador.Validar(dto);

            var entidad = new SubCategoriaEntidad
            {
                CodSubCategoria = dto.CodSubCategoria,
                CodCategoria = dto.CodCategoria,
                NomSubCategoria = dto.NomSubCategoria
            };

            return _repo.EditarSubCategoria(entidad);
        }

        public bool EliminarSubCategoria(int CodSubCategoria)
        {
            return _repo.EliminarSubCategoria(CodSubCategoria);
        }

        public List<SubCategoriaDTO> ListarSubCategorias()
        {
            return _repo.ListarSubCategorias().Select(x => new SubCategoriaDTO(
                
                )).ToList();
        }

        public SubCategoriaDTO ObtenerSubCategoria(int CodSubCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
