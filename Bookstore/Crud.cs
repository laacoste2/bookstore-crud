using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bookstore
{
    internal static class Crud
    {
        public static void AddDataOnDatabase(MySqlConnection cnn)
        {
            Console.Clear();
            cnn.Open();

            Console.WriteLine("Nome do Livro:");
            string name = Console.ReadLine();

            Console.WriteLine("\nGenêro do Livro:");
            string genre = Console.ReadLine();

            Console.WriteLine("\nPaginas do Livro:");
            int pages = int.Parse(Console.ReadLine());

            Console.Clear();

            string query = "INSERT INTO books(name, genre, pages) VALUES (@name, @genre, @pages)";

            using(MySqlCommand cmd = new MySqlCommand(query, cnn) )
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@pages", pages);

                int rowsAffected = cmd.ExecuteNonQuery();

                CheckIfOperationSucessed(rowsAffected);
            }

            cnn.Close();
        }

        public static void RemoveDataFromDatabase(MySqlConnection cnn)
        {
            Console.Clear();
            cnn.Open();

            Console.WriteLine("Informe o ID do livro a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            Console.Clear();

            string query = "DELETE FROM books WHERE id=@id";

            using(MySqlCommand cmd = new MySqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                
                int rowsAffected = cmd.ExecuteNonQuery();

                CheckIfOperationSucessed(rowsAffected);
            }

            cnn.Close();
        }

        public static void UpdateDataFromDatabase(MySqlConnection cnn)
        {
            Console.Clear();
            cnn.Open();

            Console.WriteLine("Informe o ID do livro a ser alterado:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInfore o novo nome do livro:");
            string name = Console.ReadLine();

            Console.WriteLine("\nInforme o novo genêro do livro:");
            string genre = Console.ReadLine();

            Console.WriteLine("\nInforme a nova quantidade de paginas do livro:");
            int pages = int.Parse(Console.ReadLine());

            Console.Clear();

            string query = "UPDATE books SET name=@name, genre=@genre, pages=@pages WHERE id=@id";

            using(MySqlCommand cmd = new MySqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@pages", pages);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                CheckIfOperationSucessed(rowsAffected);
            }

            cnn.Close();
        }

        public static void ShowTableFromDatabase(MySqlConnection cnn)
        {
            Console.Clear();
            cnn.Open();

            string query = "SELECT * FROM books";

            using(MySqlCommand cmd = new MySqlCommand(query, cnn))
            {
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string name = reader.GetString("name");
                        string genre = reader.GetString("genre");
                        int pages = reader.GetInt32("pages");

                        Console.WriteLine($"ID: {id} | Name: {name} | Genre: {genre} | Pages: {pages}");
                        
                    }
                    Console.ReadLine();
                }
            }

            cnn.Close();
        }

        public static void CheckIfOperationSucessed(int rowsAffected)
        {
            if (rowsAffected > 0)
            {
                Console.WriteLine("Operação realizada com sucesso.");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Houve uma falha ao realizar a operação.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
