using Newtonsoft.Json;

namespace SporArt.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]    

        public IEnumerable<Item> Itens { get; set; }


    }
}
