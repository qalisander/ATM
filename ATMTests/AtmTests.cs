using System.Diagnostics;
using NUnit.Framework;

namespace ATMTests;

[TestFixture]
public class AtmTests
{
    [Test]
    public void SmokeTest()
    {
        var banknotes = new[] {(5000, 1), (1000, 3)};
        var atm = new ATM(banknotes);
        var valueTuples = atm.GetCash(9000);
        Assert.NotNull(valueTuples);
    }
}