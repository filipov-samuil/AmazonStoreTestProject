using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonStoreTestProject.Products
{
    public class Book
    {
        public string Name { get; set; }
        public string CartTitle { get; set; }

        public Book(string name, string cartTitle)
        {
            Name = name;
            CartTitle = cartTitle;
        }
    }

    public static class Books
    {
        public static readonly Book FinalEmpireMistbornBookOne = new Book(
            "The Final Empire: Mistborn Book 1",
            "Mistborn: The Final Empire"
        );
    }
}
