public class ATM
{
    private Dictionary<int, int> Banknotes { get; }

    public ATM(IEnumerable<(int, int)> banknotes)
    {
        var pairs = banknotes.Select(tpl => KeyValuePair.Create(tpl.Item1, tpl.Item2));
        Banknotes = new Dictionary<int, int>(pairs);
    }

    public IEnumerable<(int, int)> GetCash(int value)
    {
        throw new NotImplementedException();        
        return new[] {(5000, 1), (1000, 3)};
    }
}