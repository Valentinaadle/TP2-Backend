namespace ArticulosAPI.Dto
{
    public class ArticuloDto
    {
        public int? Id { get; set; } // Agregado para manejar el Id en las operaciones
        public string Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
    }
}
