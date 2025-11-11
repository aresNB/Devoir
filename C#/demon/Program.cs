// See https://aka.ms/new-console-template for more information
//onsole.WriteLine("Hello, World!");


using System;
using System.Globalization;
using Demon.Data;
using Demon.Models;

namespace Demon
{
    class Program
    {
        static InMemoryStore store = new();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool quitter = false;

            while (!quitter)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Ajouter Catégorie");
                Console.WriteLine("2. Lister Catégories");
                Console.WriteLine("3. Ajouter Produit");
                Console.WriteLine("4. Lister Produits");
                Console.WriteLine("5. Lister Produits par Catégorie");
                Console.WriteLine("6. Produit le plus cher");
                Console.WriteLine("7. Quitter");
                Console.Write("Choix : ");
                string? choix = Console.ReadLine();
                Console.WriteLine();

                switch (choix)
                {
                    case "1": AjouterCategorie(); break;
                    case "2": ListerCategories(); break;
                    case "3": AjouterProduit(); break;
                    case "4": ListerProduits(); break;
                    case "5": ListerProduitsParCategorie(); break;
                    case "6": ProduitLePlusCher(); break;
                    case "7": quitter = true; break;
                    default: Console.WriteLine("Choix invalide"); break;
                }
            }
        }

        static void AjouterCategorie()
        {
            Console.Write("Nom de la catégorie : ");
            string? libelle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(libelle))
            {
                Console.WriteLine("Libellé invalide.");
                return;
            }

            var cat = store.AddCategory(libelle.Trim());
            Console.WriteLine($"Catégorie ajoutée : {cat}");
        }

        static void ListerCategories()
        {
            var categories = store.GetCategories();
            if (categories.Count == 0)
            {
                Console.WriteLine("Aucune catégorie trouvée.");
                return;
            }

            Console.WriteLine("Liste des catégories :");
            foreach (var c in categories) Console.WriteLine(c);
        }

        static void AjouterProduit()
        {
            Console.Write("Nom du produit : ");
            string? libelle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(libelle))
            {
                Console.WriteLine("Libellé invalide.");
                return;
            }

            Console.Write("Prix : ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal prix))
            {
                Console.WriteLine("Prix invalide.");
                return;
            }

            Console.Write("Quantité en stock : ");
            if (!int.TryParse(Console.ReadLine(), out int qte))
            {
                Console.WriteLine("Quantité invalide.");
                return;
            }

            Console.WriteLine("Choisis une catégorie (ou vide pour aucune) :");
            ListerCategories();
            Console.Write("Id catégorie : ");
            string? catIdStr = Console.ReadLine();
            Category? cat = null;
            if (int.TryParse(catIdStr, out int catId))
                cat = store.GetCategoryById(catId);

            var p = store.AddProduct(libelle.Trim(), prix, qte, cat);
            Console.WriteLine($"Produit ajouté : {p}");
        }

        static void ListerProduits()
        {
            var produits = store.GetProducts();
            if (produits.Count == 0)
            {
                Console.WriteLine("Aucun produit trouvé.");
                return;
            }

            Console.WriteLine("Liste des produits :");
            foreach (var p in produits) Console.WriteLine(p);
        }

        static void ListerProduitsParCategorie()
        {
            ListerCategories();
            Console.Write("Id de la catégorie : ");
            if (!int.TryParse(Console.ReadLine(), out int catId))
            {
                Console.WriteLine("Id invalide.");
                return;
            }

            var produits = store.GetProductsByCategory(catId);
            if (produits.Count == 0)
            {
                Console.WriteLine("Aucun produit dans cette catégorie.");
                return;
            }

            Console.WriteLine("📦 Produits de la catégorie :");
            foreach (var p in produits) Console.WriteLine(p);
        }

        static void ProduitLePlusCher()
        {
            var prod = store.GetMostExpensiveProduct();
            if (prod == null)
            {
                Console.WriteLine("Aucun produit enregistré.");
                return;
            }

            Console.WriteLine($"Produit le plus cher : {prod.Libelle} ({prod.Prix} FCFA)");
        }
    }
}
