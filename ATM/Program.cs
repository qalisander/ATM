// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        var pairs = File.ReadAllText(Path.Combine(GetCurrentFileDir(), "input.txt"))
            .Split("\n")
            .Select(line =>
            {
                var strNums = line.Split(new[] {'-', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                return (Convert.ToInt32(strNums[0]), Convert.ToInt32(strNums[1]));
            });
        var atm = new ATM(pairs);
        var cash = atm.GetCash(Convert.ToInt32(args[0]));
        if (cash is null)
        {
            Console.WriteLine("Impossible!");
        }
        else
        {
            Console.WriteLine("Possible");
            foreach (var (faceValue, amount) in cash)
            {
                Console.WriteLine($"{faceValue} - {amount}");
            }
        }
    }

    static string GetCurrentFileDir([CallerFilePath] string path = null) => Path.GetDirectoryName(path);
}