using System;
using System.Globalization;
using System.Reflection;

namespace BooksLibrary
{
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable, IFormattable
    {
        /// <summary>
        /// public constructor: initialize fields
        /// </summary>
        public Book(string isbn, string author, string title, string publishingHouse,
            int yearOfPublishung, int numberOfPages, double cost)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            PublishingHouse = publishingHouse;
            YearOfPublishing = yearOfPublishung;
            NumberOfPages = numberOfPages;
            Cost = cost;
        }

        public string ISBN { get;  private set; }

        public string Author { get;  private set; }

        public string Title { get;  private set; }

        public string PublishingHouse { get;  private set; }

        public int YearOfPublishing { get;  private set; }

        public int NumberOfPages { get;  private set; }

        public double Cost { get;  private set; }

        /// <summary>
        /// Method of IComparable 'Book' to compare 
        /// objects with type 'Book'
        /// </summary>
        /// <param name="book">source object for comparison</param>
        /// <returns>result of comparison</returns>
        public int CompareTo(Book book)
        {
            if (this.Equals(book))
            {
                return 0;
            }

            return Author.CompareTo(book.Author);
        }

        /// <summary>
        /// Method of IComparable for comparison
        /// objects with type 'object'
        /// </summary>
        /// <param name="obj">source object for comparison</param>
        /// <returns>result of comparison</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Book))
            {
                throw new InvalidOperationException("CompareTo: Not a Book");
            }

            return CompareTo((Book)obj);
        }

        /// <summary>
        /// Method represents object as a string
        /// </summary>
        /// <returns>String representation of object</returns>
        public override string ToString()
        {
            return ToString("FN", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Method represents object as a special format string
        /// </summary>
        /// <param name="format">Descriptor of format</param>
        /// <returns>String representation of object</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Method represents object as a string of special format
        /// according to determined culture
        /// </summary>
        /// <param name="format">Set a way of string formatting</param>
        /// <param name="provider">Set a culture features</param>
        /// <returns>'string' representation of object</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "FN";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpper())
            {
                case "FN":
                    return string.Format(provider, "{0} | {1} | {2} | {3} | {4} | {5} | {6:C3}", ISBN, Author, Title, 
                        PublishingHouse, YearOfPublishing, NumberOfPages, Cost);
                case "AT":
                    return string.Format(provider, "{0} | {1}", Author, Title);
                case "TY":
                    return string.Format(provider, "{0} | {1}", Title, YearOfPublishing);
                case "TC":
                    return string.Format(provider, "{0} | {1:C3}", Title, Cost);
                case "ATP":
                    return string.Format(provider, "{0} | {1} | {2}", Author, Title, PublishingHouse);
                case "TPY":
                    return string.Format(provider, "{0} | {1} | {2}", Title, PublishingHouse, YearOfPublishing);
                case "TYN":
                    return string.Format(provider, "{0} | {1} | {2}", Title, YearOfPublishing, NumberOfPages);
                case "ATPY":
                    return string.Format(provider, "{0} | {1} | {2} | {3}", Author, Title, PublishingHouse, YearOfPublishing);
                case "ATNC":
                    return string.Format(provider, "{0} | {1} | {2} | {3:C3}", Author, Title, NumberOfPages, Cost);
                case "IATP":
                    return string.Format(provider, "{0} | {1} | {2} | {3}", ISBN, Author, Title, PublishingHouse);
                case "ATNPC":
                    return string.Format(provider, "{0} | {1} | {2} | {3} | {4:C3}", Author, Title, NumberOfPages, PublishingHouse, Cost);
                case "IATNC":
                    return string.Format(provider, "{0} | {1} | {2} | {3} | {4:C3}", ISBN, Author, Title, NumberOfPages, Cost);
                case "ATPYN":
                    return string.Format(provider, "{0} | {1} | {2} | {3} | {4}", Author, Title, PublishingHouse, YearOfPublishing, 
                        NumberOfPages);
                default:     
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }

        /// <summary>
        /// Method of special interface to compare on equality 
        /// </summary>
        /// <param name="book">object for comparison on equality</param>
        /// <returns>true or false logical value</returns>
        public bool Equals(Book book)
        {
            return ISBN.Equals(book.ISBN) & Author.Equals(book.Author) & Title.Equals(book.Title) &
                PublishingHouse.Equals(book.PublishingHouse) & YearOfPublishing.Equals(book.YearOfPublishing) &
                NumberOfPages.Equals(book.NumberOfPages) & Cost.Equals(book.Cost);
        }

        /// <summary>
        /// Method to compare on equality
        /// </summary>
        /// <param name="obj">object for comparison on equality</param>
        /// <returns>true or false logical value</returns>
        public override bool Equals(object obj)
        {
            Book book = obj as Book;

            if (book != null)
            {
                return this.Equals(book);
            }

            return false;
        }

        /// <summary>
        /// Method for calculation unique code
        /// </summary>
        /// <returns>hash</returns>
        public override int GetHashCode()     
        {
            return (ISBN + Author + Title + PublishingHouse).GetHashCode();
        }
    }
}
