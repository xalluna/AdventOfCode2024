namespace Day2;

public interface IReportStrategy
{
    bool CalculateSafety(List<int> data);
}

public class Report
{
    public bool IsSafe => _strategy.CalculateSafety(_data);
    
    private readonly List<int> _data = [];
    private IReportStrategy _strategy { get; set; }

    public void AddData(int dataPoint) => _data.Add(dataPoint);
    public void SetStrategy(IReportStrategy strategy) => _strategy = strategy;
}

public enum Direction
{
    Asc,
    Desc
}

public class DayOneReportStrategy() : IReportStrategy
{
    private const int UpperThreshold = 3;
    private const int LowerThreshold = 1;
    
    public bool CalculateSafety(List<int> data)
    {
        var count = data.Skip(1).Count();
        Direction? reportDirection = null;

        for (var i = 1; i <= count; i++)
        {
            var prev = data.ElementAt(i - 1);
            var curr = data.ElementAt(i);

            var rawDifference = curr - prev;
            var direction = int.IsPositive(rawDifference) ? Direction.Asc : Direction.Desc;

            reportDirection ??= direction;

            if (direction != reportDirection)
            {
                return false;
            }

            var differenceMagnitude = Math.Abs(rawDifference);

            if (differenceMagnitude is < LowerThreshold or > UpperThreshold)
            {
                return false;
            }
        }

        return true;
    }
}

public class DayTwoReportStrategy() : IReportStrategy
{
    private const int UpperThreshold = 3;
    private const int LowerThreshold = 1;
    private const int Tolerance = 1;
    private int _depth = -1;
    
    public bool CalculateSafety(List<int> data)
    {
        _depth++;
        
        var count = data.Skip(1).Count();
        Direction? reportDirection = null;

        var isSafe = true;

        for (var i = 1; i <= count; i++)
        {
            var prev = data.ElementAt(i - 1);
            var curr = data.ElementAt(i);

            var rawDifference = curr - prev;
            var direction = int.IsPositive(rawDifference) ? Direction.Asc : Direction.Desc;

            reportDirection ??= direction;

            if (direction != reportDirection)
            {
                isSafe = false;
                break;
            }

            var differenceMagnitude = Math.Abs(rawDifference);

            if (differenceMagnitude is < LowerThreshold or > UpperThreshold)
            {
                isSafe = false;
                break;
            }
        }

        if (isSafe || _depth >= Tolerance) return isSafe;
        
        for (var i = 0; i < data.Count; i++)
        {
            var copy = new int[data.Count];
            data.CopyTo(copy);
            
            var copyList = copy.ToList();
            copyList.RemoveAt(i);

            isSafe = CalculateSafety(copyList);

            if (isSafe)
            {
                break;
            }
        }

        return isSafe;
    }
    
    
}