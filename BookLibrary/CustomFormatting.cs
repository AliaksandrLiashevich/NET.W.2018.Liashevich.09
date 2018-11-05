using System;
using System.Globalization;

namespace BooksLibrary
{
    public class CustomFormatting : IFormatProvider, ICustomFormatter
    {
        private CultureInfo culture;
        
        /// <summary>
        /// Constructor without arguments that 
        /// sets current culture settings
        /// </summary>
        public CustomFormatting()
        {
            culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Constructor that sets culture settings
        /// </summary>
        /// <param name="_culture">Object with culture settings</param>
        public CustomFormatting(CultureInfo _culture)
        {
            culture = _culture;
        }
        
        /// <summary>
        /// Method that sets a format of data
        /// </summary>
        /// <param name="formatType">Input format</param>
        /// <returns>Format Settings</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else if (formatType == typeof(NumberFormatInfo))
            {
                return culture.NumberFormat;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method prepare output string representation of object
        /// according to input format parameter and culture features
        /// </summary>
        /// <param name="format">Format parameter</param>
        /// <param name="book">Transformable object</param>
        /// <param name="provider">Culture features</param>
        /// <returns>String representation of object</returns>
        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg.GetType() == typeof(Book))
            {
                return SetOut(format, (Book)arg, provider);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Helper for Format method
        /// </summary>
        /// <param name="format">Format parameters</param>
        /// <param name="book">Transformable object</param>
        /// <param name="provider">Culture features</param>
        /// <returns>String representation of object</returns>
        private string SetOut(string format, Book book, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "A";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpper())
            {
                case "A":
                    return string.Format(provider, "{0}", book.Author);
                case "T":
                    return string.Format(provider, "{0}", book.Title);
                case "I":
                    return string.Format(provider, "{0}", book.ISBN);
                case "P":
                    return string.Format(provider, "{0}", book.PublishingHouse);
                case "Y":
                    return string.Format(provider, "{0}", book.YearOfPublishing);
                case "N":
                    return string.Format(provider, "{0}", book.NumberOfPages);
                case "C":
                    return string.Format(provider, "{0:C3}", book.Cost);
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
    }
}