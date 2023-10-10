namespace SporArt.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Cor { get; set; }

        public string Formato { get; set; }


        public int AutorId { get; set; }    

        public Categoria? Categoria { get; set; }

    }
}
