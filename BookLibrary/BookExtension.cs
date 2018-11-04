namespace BooksLibrary
{
    /// <summary>
    /// Extension Method for Book class.
    /// Give special format of output data
    /// </summary>
    public static class BookExtension
    {
        public static string Print(this Book book)
        {
            return book.ISBN;
        }
    }
}