using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;
using NUnit.Framework;

namespace Task3Tests
{
    [TestFixture]
    public class SetTests
    {
        static string[] str1 = new string[] { "one", "two", "three" };
        Set<string> stringSet1 = new Set<string>(str1);
        static string[] str2 = new string[] { "three", "four" };
        Set<string> stringSet2 = new Set<string>(str2);

        /// <summary>
        /// A test for Add().
        /// </summary>
        [Test]
        public void Add_ValidData_ValidResult()
        {
            Set<string> stringSet = new Set<string>();
            stringSet.Add("abc");
            stringSet.Add("bcd");
            string[] expected = new string[] { "abc", "bcd" };
            CollectionAssert.AreEquivalent(expected, stringSet);
        }

        /// <summary>
        /// A test for Add with existing data.
        /// </summary>
        [TestCase("three")]
        public void Add_InvalidData_ThrowsException(string argument)
        {
            string[] str = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven" };
            Set<string> stringSet = new Set<string>(str);
            Assert.Throws<ArgumentException>(() => stringSet.Add(argument));
        }

        /// <summary>
        /// A test for Add with null.
        /// </summary>
        [Test]
        public void Add_Null_ValidResult()
        {
            Set<string> stringSet = new Set<string>();
            Assert.Throws<ArgumentNullException>(() => stringSet.Add(null));
        }

        /// <summary>
        /// A test for Delete().
        /// </summary>
        [Test]
        public void Remove_ValidData_ValidResult()
        {
            string[] str = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven" };
            Set<string> stringSet = new Set<string>(str);
            stringSet.Remove("three");
            string[] expected = new string[] { "one", "two", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven" };
            CollectionAssert.AreEquivalent(expected, stringSet);
        }

        /// <summary>
        /// A test for Remove with invalid data.
        /// </summary>
        [TestCase("twelve")]
        public void Remove_InvalidData_ThrowsException(string argument)
        {
            string[] str = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven" };
            Set<string> stringSet = new Set<string>(str);
            Assert.Throws<ArgumentException>(() => stringSet.Remove(argument));
        }

        /// <summary>
        /// A test for Union.
        /// </summary>
        [Test]
        public void Union_ValidData_ValidResult()
        {
            var actual = stringSet1.UnionCustom(stringSet2);
            string[] expected = new string[] { "one", "two", "three", "four" };
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// A test for Except.
        /// </summary>
        [Test]
        public void Except_ValidData_ValidResult()
        {
            var actual = stringSet1.ExceptCustom(stringSet2);
            string[] expected = new string[] { "one", "two"};
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// A test for Intersect.
        /// </summary>
        [Test]
        public void Intersect_ValidData_ValidResult()
        {
            var actual = stringSet1.IntersectCustom(stringSet2);
            string[] expected = new string[] { "three" };
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
