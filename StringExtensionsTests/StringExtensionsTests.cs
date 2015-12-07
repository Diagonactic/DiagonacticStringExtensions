using System;
using Diagonactic.StringExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensionsTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestLeftOf()
        {
            "Domain\\Name".LeftOf("\\").ShouldBeEquivalentTo("Domain");
            "Domain\\".LeftOf("\\").ShouldBeEquivalentTo("Domain");
            "Domain\\Name".LeftOf("\\Name").ShouldBeEquivalentTo("Domain");
            "Domain\\Name".LeftOf("\\Namea").ShouldBeEquivalentTo(null);
            "Domain\\Name".LeftOf("Domain").ShouldBeEquivalentTo(string.Empty);
            "Domain\\Domain\\Name".LeftOf("Domain\\").ShouldBeEquivalentTo(string.Empty);
            "Domain\\Domain\\Name".LeftOf("Domain\\", SearchDirection.FromRight).ShouldBeEquivalentTo("Domain\\");
        }

        [TestMethod]
        public void TestReverse()
        {
            string.Empty.Reverse().ShouldBeEquivalentTo(string.Empty);
            "Test String".Reverse().ShouldBeEquivalentTo("gnirtS tseT");
        }

        [TestMethod]
        public void TestRightOf()
        {
            "Domain\\Name".RightOf("\\").ShouldBeEquivalentTo("Name");
            "Domain\\".RightOf("\\").ShouldBeEquivalentTo(string.Empty);
            "Domain\\Name".RightOf("Domain\\").ShouldBeEquivalentTo("Name");
            "Domain\\Name".RightOf("\\Namea").ShouldBeEquivalentTo(null);
            "Domain\\Name".RightOf("Domain").ShouldBeEquivalentTo("\\Name");
            "Domain\\Name\\Name\\Name".RightOf("\\Name").ShouldBeEquivalentTo("\\Name\\Name");
            "Domain\\Name\\Name\\Name".RightOf("\\Name", SearchDirection.FromRight).ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void TestRightOfIndex()
        {
            "Domain\\Name".RightOfIndex(11).Should().BeNull();
            "Domain\\Name".RightOfIndex(10).ShouldBeEquivalentTo("e");
            "Domain\\Name".RightOfIndex(0).ShouldBeEquivalentTo("Domain\\Name");
        }

        [TestMethod]
        public void TestLeftOfIndex()
        {
            "Domain\\Name".LeftOfIndex(11).ShouldBeEquivalentTo("Domain\\Name");
            "Domain\\Name".LeftOfIndex(10).ShouldBeEquivalentTo("Domain\\Nam");
            "Domain\\Name".LeftOfIndex(0).ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void TestContains()
        {
            "Domain\\Name".Contains("\\Namea").Should().BeFalse();
            "Domain\\Name".Contains("\\name").Should().BeFalse();
            "Domain\\Name".Contains("\\name", StringComparison.OrdinalIgnoreCase).Should().BeTrue();
            "Domain\\Name".Contains("\\Name").Should().BeTrue();
        }
    }
}
