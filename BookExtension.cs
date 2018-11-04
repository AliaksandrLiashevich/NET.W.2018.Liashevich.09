namespace BooksLibraryImplementation
{
    public static class BookExtension
    {
        public static string Print(this Book book)
        {
            return book.ISBN;
        }
    }
}