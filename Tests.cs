using System;
using NUnit.Framework;
using System.Globalization;

namespace BooksLibraryImplementation.Tests
{
    [TestFixture]
    public class BooksTests
    {
        CustomFormatting customProvider = new CustomFormatting();
        IFormatProvider provider = CultureInfo.CreateSpecificCulture("en");
        Book book = new Book("54-5293", "Richter", "C#", "Microsoft Press", 2012, 826, 59.99);

        [TestCase("AT", "Richter | C#")]
        [TestCase("TY", "C# | 2012")]
        [TestCase("TC", "C# | $59.990")]
        [TestCase("ATP", "Richter | C# | Microsoft Press")]
        [TestCase("TPY", "C# | Microsoft Press | 2012")]
        [TestCase("TYN", "C# | 2012 | 826")]
        [TestCase("ATPY", "Richter | C# | Microsoft Press | 2012")]
        [TestCase("ATNC", "Richter | C# | 826 | $59.990")]
        [TestCase("IATP", "54-5293 | Richter | C# | Microsoft Press")]
        [TestCase("ATNPC", "Richter | C# | 826 | Microsoft Press | $59.990")]
        [TestCase("IATNC", "54-5293 | Richter | C# | 826 | $59.990")]
        [TestCase("ATPYN", "Richter | C# | Microsoft Press | 2012 | 826")]
        [TestCase("", "54-5293 | Richter | C# | Microsoft Press | 2012 | 826 | $59.990")]
        [TestCase("FN", "54-5293 | Richter | C# | Microsoft Press | 2012 | 826 | $59.990")]
        
        public void ToString_StringFormatting_FormattedString(string format, string expected)
        {
            Assert.AreEqual(expected, book.ToString(format, provider));
        }

        [TestCase("X")]
        [TestCase("1230")]
        [TestCase("Something")]

        public void ToString_InvalidFormatSpecifier_FormatException(string format)
        {
            Assert.Throws<FormatException>(() => book.ToString(format, provider));
        }
    }

    [TestFixture]
    public class CustomFormattingTests
    {
        CustomFormatting customProvider = new CustomFormatting();
        IFormatProvider provider = CultureInfo.CreateSpecificCulture("en");
        Book book = new Book("54-5293", "Richter", "C#", "Microsoft Press", 2012, 826, 59.99);

        [TestCase("A", ExpectedResult = "Richter")]
        [TestCase("T", ExpectedResult = "C#")]
        [TestCase("I", ExpectedResult = "54-5293")]
        [TestCase("P", ExpectedResult = "Microsoft Press")]
        [TestCase("Y", ExpectedResult = "2012")]
        [TestCase("N", ExpectedResult = "826")]
        [TestCase("C", ExpectedResult = "$59.990")]

        public string Format_StringFormatting_FormattedString(string format)
        {
            return customProvider.Format(format, book, provider);
        }
    }
}