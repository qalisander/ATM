public class ATM
{
    private (int, int)[] Banknotes { get; }

    public ATM(IEnumerable<(int, int)> banknotes)
    {
        Banknotes = banknotes.OrderByDescending(tpl => tpl.Item1).ToArray();
    }

    public IEnumerable<(int, int)>? GetCash(int value, int offset = 0)
    {
        if (offset == Banknotes.Length)
        {
            return value == 0 ? Enumerable.Empty<(int, int)>() : null;
        }
        
        var (faceValue, amount) = Banknotes[offset];
        
        for (var i = Math.Min(value / faceValue, amount); i >= 0; i--)
        {
            var ans = GetCash(value - i * faceValue, offset + 1);
            if (ans is not null)
                return i != 0 ? ans.Prepend((faceValue, i)) : ans;
        }

        return null;
    }
}