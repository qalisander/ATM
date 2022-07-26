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
    
    [Test]
    public void Bug800Test()
    {
        var banknotes = new[] {(500, 100), (200, 3323)};
        var atm = new ATM(banknotes);
        var ans = atm.GetCash(800);
        ans.Should().Contain((200, 4));
        ans.Should().NotContain((500, 0));
    }
}