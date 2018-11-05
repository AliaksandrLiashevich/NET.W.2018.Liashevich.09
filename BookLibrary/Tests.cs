using System;
using System.Globalization;
using NUnit.Framework;

namespace BooksLibrary.Tests
{
    [TestFixture]
    public class BooksTests
    {
        private IFormatProvider provider = CultureInfo.CreateSpecificCulture("en");
        private Book book = new Book("54-5293", "Richter", "C#", "Microsoft Press", 2012, 826, 59.99);

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
            format = "{0:" + format + "}";
            string result = string.Format(provider, format, book);
            Assert.AreEqual(expected, result);
        }

        [TestCase("X")]
        [TestCase("1230")]
        [TestCase("Something")]

        public void ToString_InvalidFormatSpecifier_FormatException(string format)
        {
            format = "{0:" + format + "}";
            Assert.Throws<FormatException>(() => string.Format(provider, format, book));
        }
    }

    [TestFixture]
    public class CustomFormattingTests
    {
        private CustomFormatting customProvider = new CustomFormatting(new CultureInfo("en"));
        private Book book = new Book("54-5293", "Richter", "C#", "Microsoft Press", 2012, 826, 59.99);

        [TestCase("A", ExpectedResult = "Richter")]
        [TestCase("T", ExpectedResult = "C#")]
        [TestCase("I", ExpectedResult = "54-5293")]
        [TestCase("P", ExpectedResult = "Microsoft Press")]
        [TestCase("Y", ExpectedResult = "2012")]
        [TestCase("N", ExpectedResult = "826")]
        [TestCase("C", ExpectedResult = "$59.990")]

        public string Format_StringFormatting_FormattedString(string format)
        {
            format = "{0:" + format + "}";
            return string.Format(customProvider, format, book);
        }
    }
}