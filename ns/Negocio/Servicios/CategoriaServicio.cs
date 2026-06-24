using Ecommerce.Negocio.Validadores;
using Microsoft.Extensions.Caching.Memory;
using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Dominio.Entidades;
using Ecommerce.Negocio.DTOs;
using Ecommerce.Negocio.Interfaces;

namespace Ecommerce.Negocio.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly ICategoriaRepositorio _repo;
        private readonly CategoriaValidador _validador;
        private readonly IMemoryCache _cache;

        public CategoriaServicio(ICategoriaRepositorio repositorio, CategoriaValidador validador, IMemoryCache cache)
        {
            _repo = repositorio;
            _validador = validador;
            _cache = cache;
        }

        public bool Actualizar(CategoriaDTO dto)
        {
            _validador.Validar(dto);

            var entidad = new CategoriaEntidad()
            {
                CodCategoria = dto.CodCategoria,
                NomCategoria = dto.NomCategoria,
            };

            var resultado = _repo.Editar(entidad);

            _cache.Remove("CATEGORIAS");

            return resultado;
        }

        public bool Eliminar(int id)
        {
            var resultado = _repo.Eliminar(id);

            _cache.Remove("CATEGORIAS");

            return resultado;
        }

        public List<CategoriaDTO> ListarCategorias()
        {
            const string key = "CATEGORIAS";

            if (_cache.TryGetValue(key, out List<CategoriaDTO>? categorias))
            {
                return categorias!;
            }

            categorias = _repo.ObtenerDatos().Select(x => new CategoriaDTO
            {
                CodCategoria = x.CodCategoria,
                NomCategoria = x.NomCategoria
            }).ToList();

            _cache.Set(key , categorias, TimeSpan.FromMinutes(10));

            return categorias;
        }

        public CategoriaDTO ObtenerCategoria(int CodCategoria)
        {
            var Categoria = _repo.ObtenerId(CodCategoria);

            if(Categoria == null)
            {
                return null;
            }

            return new CategoriaDTO
            {
                CodCategoria = Categoria.CodCategoria,
                NomCategoria = Categoria.NomCategoria
            };
        }

        public bool Registrar(CategoriaDTO dto)
        {
            _validador.Validar(dto);

            var entidad = new CategoriaEntidad()
            {
                CodCategoria = dto.CodCategoria,
                NomCategoria = dto.NomCategoria,
            };

            var resultado = _repo.Crear(entidad);

            _cache.Remove("CATEGORIAS");

            return resultado;
        }
    }
}
