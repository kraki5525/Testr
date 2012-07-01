using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAssertions;

using Nancy.Testing;

using Xunit;

namespace Testr.Tests
{
    public class Class1
    {
        [Fact]
        public void Test()
        {
            true.Should().BeTrue();
        }
    }
}
