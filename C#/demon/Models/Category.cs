namespace Demon.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Libelle { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[{Id}] {Libelle}";
        }
    }
}
