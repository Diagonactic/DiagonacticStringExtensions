using System;
using System.Linq;
using Diagonactic.StringExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensionsTests
{
    [TestClass]
    public class SeparatedValuesTests
    {
        [TestMethod]
        public void TestValueSeparatorDefaults()
        {
            var val = new SeparatedValues("Foo,Bar,Baz");
            val.Value.ShouldBeEquivalentTo("Foo, Bar, Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");
            val = new SeparatedValues("Foo, Bar,Baz");
            val.Value.ShouldBeEquivalentTo("Foo, Bar, Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");
        }

        [TestMethod]
        public void TestValueSeparatorSpaceAfter()
        {
            var val = new SeparatedValues("Foo,Bar,Baz", spaceFlags: SeparatorSpaceFlags.AddSpaceAfter);
            val.Value.ShouldBeEquivalentTo("Foo, Bar, Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");
        }

        [TestMethod]
        public void TestSeparatedValuesAddSpaceBeforeAddSpaceAfter()
        {
            var val = new SeparatedValues("Foo,Bar,Baz", spaceFlags: SeparatorSpaceFlags.AddSpaceAfter | SeparatorSpaceFlags.AddSpaceBefore);
            val.Value.ShouldBeEquivalentTo("Foo , Bar , Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");

            val = new SeparatedValues("Foo ,Bar, Baz", spaceFlags: SeparatorSpaceFlags.AddSpaceAfter | SeparatorSpaceFlags.AddSpaceBefore);
            val.Value.ShouldBeEquivalentTo("Foo , Bar , Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");
        }

        [TestMethod]
        public void TestSeparatedValuesAddSpaceBefore()
        {
            var val = new SeparatedValues("Foo,Bar,Baz", spaceFlags: SeparatorSpaceFlags.AddSpaceBefore);
            val.Value.ShouldBeEquivalentTo("Foo ,Bar ,Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");

            val = new SeparatedValues("Foo ,Bar, Baz", spaceFlags: SeparatorSpaceFlags.AddSpaceBefore);
            val.Value.ShouldBeEquivalentTo("Foo ,Bar ,Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");
        }

        [TestMethod]
        public void TestSeparatedValuesNoSpaces()
        {
            var val = new SeparatedValues("Foo,Bar,Baz", spaceFlags: SeparatorSpaceFlags.None);
            val.Value.ShouldBeEquivalentTo("Foo,Bar,Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");

            val = new SeparatedValues("Foo ,Bar, Baz", spaceFlags: SeparatorSpaceFlags.None, entryFlags:EntryFlags.RemoveEmptyEntries);
            val.Value.ShouldBeEquivalentTo("Foo ,Bar, Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo ");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo(" Baz");

            val = new SeparatedValues("Foo ,Bar, Baz,,,", spaceFlags: SeparatorSpaceFlags.None, entryFlags: EntryFlags.RemoveEmptyEntries);
            val.Value.ShouldBeEquivalentTo("Foo ,Bar, Baz");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo ");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo(" Baz");

            val = new SeparatedValues("Foo ,Bar, Baz,,,", spaceFlags: SeparatorSpaceFlags.None, entryFlags: EntryFlags.TrimEntries);
            val.Value.ShouldBeEquivalentTo("Foo,Bar,Baz,,,");
            val.Items.Count.ShouldBeEquivalentTo(6);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Bar");
            val.Items[2].ShouldBeEquivalentTo("Baz");
            val.Items[3].ShouldBeEquivalentTo(string.Empty);
            val.Items[4].ShouldBeEquivalentTo(string.Empty);
            val.Items[5].ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void TestValuePipeSeparator()
        {
            var val = new SeparatedValues("Foo| | Baz|Blah", separator: "|");
            val.Value.ShouldBeEquivalentTo("Foo| Baz| Blah");
            val.Items.Count.ShouldBeEquivalentTo(3);
            val.Items[0].ShouldBeEquivalentTo("Foo");
            val.Items[1].ShouldBeEquivalentTo("Baz");
            val.Items[2].ShouldBeEquivalentTo("Blah");
        }

        [TestMethod]
        public void TestSuffixedSeparated()
        {
            var val = new SuffixedSeparatedValues("Foo, Bar,Baz", "Attribute", ",");
            val.Value.ShouldBeEquivalentTo("FooAttribute, BarAttribute, BazAttribute");
            val.CompareItems[0].ShouldBeEquivalentTo("FooAttribute");
            val.CompareItems[1].ShouldBeEquivalentTo("BarAttribute");
            val.CompareItems[2].ShouldBeEquivalentTo("BazAttribute");
            val.CompareItems[3].ShouldBeEquivalentTo("Foo");
            val.CompareItems[4].ShouldBeEquivalentTo("Bar");
            val.CompareItems[5].ShouldBeEquivalentTo("Baz");
            val.Items[0].ShouldBeEquivalentTo("FooAttribute");
            val.Items[1].ShouldBeEquivalentTo("BarAttribute");
            val.Items[2].ShouldBeEquivalentTo("BazAttribute");

            val = new SuffixedSeparatedValues("FooAttribute|BarAttribute|BazAttribute", "Attribute", "|");
            val.Value.ShouldBeEquivalentTo("FooAttribute| BarAttribute| BazAttribute");
            val.CompareItems[0].ShouldBeEquivalentTo("FooAttribute");
            val.CompareItems[1].ShouldBeEquivalentTo("BarAttribute");
            val.CompareItems[2].ShouldBeEquivalentTo("BazAttribute");
            val.CompareItems[3].ShouldBeEquivalentTo("Foo");
            val.CompareItems[4].ShouldBeEquivalentTo("Bar");
            val.CompareItems[5].ShouldBeEquivalentTo("Baz");
            val.Items[0].ShouldBeEquivalentTo("FooAttribute");
            val.Items[1].ShouldBeEquivalentTo("BarAttribute");
            val.Items[2].ShouldBeEquivalentTo("BazAttribute");
        }
    }
}
