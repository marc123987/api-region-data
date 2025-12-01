namespace ValueAPI.DTO
{
    public class ContenedorDTO<T>
    {
        public T Contenido { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }
}