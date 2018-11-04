using System;
using NUnit.Framework;
using BooksLibraryImplementation;
using System.Globalization;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        IFormatProvider provider = CultureInfo.CreateSpecificCulture("en");
        Book book = new Book("54-5293", "Richter", "C#", "Microsoft Press", 2012, 826, 59.99);

        [TestCase("FN", "54-5293 | Richter | C# | Microsoft Press | 2012 | 826 | $59.990")]
        [TestCase("AT", "Richter | C#")]
        [TestCase("TPY", "C# | Microsoft Press | 2012")]
        [TestCase("ATNC", "Richter | C# | 826 | $59.990")]
        [TestCase("ATPYN", "Richter | C# | Microsoft Press | 2012 | 826")]
        [TestCase("1230", "")]
    
        public void ToString_Value1_and_Value2_String_returned(string format, string expected)
        {
            Assert.AreEqual(expected, book.ToString(format, provider));
        }
    }
}
