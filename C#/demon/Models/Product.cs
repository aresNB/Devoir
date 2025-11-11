namespace Demon.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Libelle { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }
        public Category? Categorie { get; set; }

        public decimal MontantStock => Prix * QuantiteStock;

        public override string ToString()
        {
            string cat = Categorie != null ? Categorie.Libelle : "Sans catégorie";
            return $"[{Id}] {Libelle} | Prix: {Prix} | Qté: {QuantiteStock} | Catégorie: {cat} | Montant stock: {MontantStock}";
        }
    }
}
