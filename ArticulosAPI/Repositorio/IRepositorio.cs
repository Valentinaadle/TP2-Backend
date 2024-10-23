using ArticulosAPI.Data;
using ArticulosAPI.Dto;
using ArticulosAPI.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticulosAPI.Repositorio
{
    public class Repositorio : IRepositorio

    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public Repositorio(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ArticuloDto> CrearOActualizar(ArticuloDto articulo, int id = 0)
        {
            Articulo articulos = _mapper.Map<ArticuloDto, Articulo>(articulo);
            if (id > 0)
            {
                articulos.Id = id;
                _context.Articulos.Update(articulos);
            }
            else
            {
                await _context.Articulos.AddAsync(articulos);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Articulo, ArticuloDto>(articulos);
        }

        public async Task<bool> EliminarArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return false;
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ArticuloDto>> GetArticulo()
        {

            List<Articulo> articulos = await _context.Articulos.ToListAsync();
            return _mapper.Map<List<ArticuloDto>>(articulos);
        }

        public Task<ArticuloDto> GetArticulo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
