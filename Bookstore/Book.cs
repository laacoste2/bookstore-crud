using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    internal class Book
    {
        private string name;
        private string genre;
        private int pages;

        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public int Pages { get => pages; set => pages = value; }

        public Book(string name, string genre, int pages) 
        {
            Name = name;
            Genre = genre;
            Pages = pages;
        }

        public override string ToString()
        {
            return "Nome: " + Name + "\n" +
                   "Genêro: " + Genre + "\n" +
                   "Paginas: " + Pages;
        }
    }
}
