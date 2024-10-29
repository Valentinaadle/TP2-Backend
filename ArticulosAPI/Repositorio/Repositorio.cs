using System.Collections.Generic;
using System.Threading.Tasks;
using ArticulosAPI.Data;
using ArticulosAPI.Dto;
using ArticulosAPI.Modelos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArticulosAPI.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Repositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ArticuloDto>> GetArticulo()
        {
            List<Articulo> articulos = await _context.Articulos.ToListAsync();
            return _mapper.Map<List<ArticuloDto>>(articulos);
        }

        public async Task<ArticuloDto> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            return _mapper.Map<ArticuloDto>(articulo);
        }

        public async Task<ArticuloDto> CrearOActualizar(ArticuloDto articuloDto, int id = 0)
        {
            Articulo articulo = _mapper.Map<Articulo>(articuloDto);

            if (id > 0)
            {
                articulo.Id = id;
                _context.Articulos.Update(articulo);
            }
            else
            {
                await _context.Articulos.AddAsync(articulo);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<ArticuloDto>(articulo);
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
    }
}
