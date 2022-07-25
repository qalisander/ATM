public class ATM
{
    private (int, int)[] Banknotes { get; }

    public ATM(IEnumerable<(int, int)> banknotes)
    {
        Banknotes = banknotes.OrderByDescending(tpl => tpl.Item1).ToArray();
    }

    public IEnumerable<(int, int)>? GetCash(int value, int offset = 0)
    {
        // Banknotes[offset]
        // foreach (var (faceValue, amount) in Banknotes.Skip(offset))
        // {
        //     for (var i = Math.Min(value / faceValue, amount); i > 0; i--)
        //     {
        //         var ans = GetCash(value - i * amount, offset + 1);
        //         if (ans is not null)
        //             return ans.Prepend((amount, i));
        //
        //     }
        // }

        var (faceValue, amount) = Banknotes[offset];
        
        for (var i = Math.Min(value / faceValue, amount); i > 0; i--)
        {
            var ans = GetCash(value - i * amount, offset + 1);
            if (ans is not null)
                return ans.Prepend((amount, i));

        }

        return null;
    }
}