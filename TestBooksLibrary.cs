using System;
using System.Globalization;
using BooksLibraryImplementation;

namespace BooksLibrary
{
    class TestBooksLibrary
    {
        static void Main(string[] args)
        {
            Book book = new Book("545-9187356", "Richter", "C#", "Microsoft Press", 2012, 826, 59.99);
            Console.WriteLine(String.Format(new CultureInfo("en"), "{0:FN}", book));
            Console.WriteLine(book.Print());
            Console.WriteLine(String.Format(new CustomFormatting(), "{0:A}", book));
            Console.ReadKey();
        }
    }
}
