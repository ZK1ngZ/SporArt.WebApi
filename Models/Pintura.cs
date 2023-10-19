namespace SporArt.Models
{
    public class Pintura
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public float Avaliacoes { get; set; }

        public int AutorId { get; set; }

        public string Comentario  { get; set; }
    }
}
