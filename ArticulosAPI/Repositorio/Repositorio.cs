using ArticulosAPI.Dto;

namespace ArticulosAPI.Repositorio
{
    public interface IRepositorio
    {

        Task<List<ArticuloDto>> GetArticulo();
        Task<ArticuloDto> GetArticulo(int id);
        Task<ArticuloDto> CrearOActualizar(ArticuloDto Articulo, int id = 0);
        Task<bool> EliminarArticulo(int id);
    }
}