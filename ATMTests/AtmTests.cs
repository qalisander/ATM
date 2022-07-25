using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace ATMTests;

[TestFixture]
public class AtmTests
{
    [Test]
    public void AtmTest()
    {
        var banknotes = new[] {(5000, 1), (1000, 3)};
        var atm = new ATM(banknotes);
        var ans = atm.GetCash(9000);
        Assert.IsNull(ans);
        ans = atm.GetCash(8000).ToArray();
        ans.Should().Contain((5000, 1));
        ans.Should().Contain((1000, 3));
    }
    //
    // [Test]
    // [TestCase(new[] {(5000, 1), (1000, 3)}, 8000, new[] {(5000, 1), (1000, 3)})]
    // public void ComplexTest((int, int) banknotes, int value, (int, int) expected)
    // {
    //     // var banknotes = new[] {(5, 2), }
    // }
}