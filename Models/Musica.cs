namespace SporArt.Models
{
    public class Musica
    {
        public int Id { get; set; }

        public string Duracao { get; set; }

        public string Letra { get; set; }

        public short Avaliacoes { get; set; }


        public int AutorId  { get; set; }

        public string Comentarios { get; set; }



    }
}
