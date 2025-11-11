using System.Collections.Generic;
using System.Linq;
using Demon.Models;

namespace Demon.Data
{
    public class InMemoryStore
    {
        private readonly List<Category> _categories = new();
        private readonly List<Product> _products = new();
        private int _nextCategoryId = 1;
        private int _nextProductId = 1;

        // Ajouter catégorie
        public Category AddCategory(string libelle)
        {
            var cat = new Category { Id = _nextCategoryId++, Libelle = libelle };
            _categories.Add(cat);
            return cat;
        }

        // Lister les catégories
        public List<Category> GetCategories() => _categories;

        public Category? GetCategoryById(int id) => _categories.FirstOrDefault(c => c.Id == id);

        // Ajouter produit
        public Product AddProduct(string libelle, decimal prix, int quantite, Category? categorie)
        {
            var prod = new Product
            {
                Id = _nextProductId++,
                Libelle = libelle,
                Prix = prix,
                QuantiteStock = quantite,
                Categorie = categorie
            };
            _products.Add(prod);
            return prod;
        }

        // Lister produits
        public List<Product> GetProducts() => _products;

        // Produits par catégorie
        public List<Product> GetProductsByCategory(int categoryId) =>
            _products.Where(p => p.Categorie != null && p.Categorie.Id == categoryId).ToList();

        // Produit le plus cher
        public Product? GetMostExpensiveProduct() =>
            _products.OrderByDescending(p => p.Prix).FirstOrDefault();
    }
}
