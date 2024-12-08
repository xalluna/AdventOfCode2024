using System.Text.RegularExpressions;

namespace Day3;

public class OperatorToken
{
    public const string Do = "do()";
    public const string Dont = "don't()";
}

public interface IMultiplicandEvaluatorState
{
    bool ShouldEvaluate();
}

public class DoState : IMultiplicandEvaluatorState
{
    public bool ShouldEvaluate() => true;
}

public class DontState : IMultiplicandEvaluatorState
{
    public bool ShouldEvaluate() => false;
}

public partial class MultiplicandEvaluator(List<string> tokens)
{
    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex MultiplicandRegex();
    
    private readonly Regex multiplicandRegex = MultiplicandRegex();

    public int Evaluate()
    {
        IMultiplicandEvaluatorState state = new DoState();
        
        var sum = 0;
        var items = new Queue<string>(tokens);
        string token = "";

        while (items.TryDequeue(out token))
        {
            if (token == OperatorToken.Do)
            {
                state = new DoState();
                continue;
            }
            
            if (token == OperatorToken.Dont)
            {
                state = new DontState();
                continue;
            }

            if (state.ShouldEvaluate())
            {
                var match = multiplicandRegex.Match(token);
                
                var x = match.Success ? int.Parse(match.Groups[1].Value) : 0;
                var y = match.Success ? int.Parse(match.Groups[2].Value) : 0;
                
                sum += x * y;
            }
        }
        
        return sum;
    }
}