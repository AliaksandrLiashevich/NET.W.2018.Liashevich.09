using System;
using System.Globalization;

namespace BooksLibraryImplementation
{
    public class CustomFormatting : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg.GetType() == typeof(Book))
                return SetOut(format, (Book)arg, provider);
            else
                return null;
        }

        private string SetOut(string format, Book book, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "A";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpper())
            {
                case "A":
                    return String.Format(provider, "{0}", book.Author);
                case "T":
                    return String.Format(provider, "{0}", book.Title);
                case "I":
                    return String.Format(provider, "{0}", book.ISBN);
                case "P":
                    return String.Format(provider, "{0}", book.PublishingHouse);
                case "Y":
                    return String.Format(provider, "{0}", book.YearOfPublishing);
                case "N":
                    return String.Format(provider, "{0}", book.NumberOfPages);
                case "C":
                    return String.Format(provider, "{0}", book.Cost);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}