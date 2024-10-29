using System.Collections.Generic;
using System.Threading.Tasks;
using ArticulosAPI.Dto;

namespace ArticulosAPI.Repositorio
{
    public interface IRepositorio
    {
        Task<List<ArticuloDto>> GetArticulo();
        Task<ArticuloDto> GetArticulo(int id);
        Task<ArticuloDto> CrearOActualizar(ArticuloDto articulo, int id = 0);
        Task<bool> EliminarArticulo(int id);
    }
}
