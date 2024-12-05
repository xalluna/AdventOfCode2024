namespace Day2;

public class Report
{
    public bool IsSafe => CalculateSafety();
    
    private readonly List<int> _data = [];
    private const int UpperThreshold = 3;
    private const int LowerThreshold = 1;
    
    public void AddData(int dataPoint) => _data.Add(dataPoint);

    private bool CalculateSafety()
    {
        var count = _data.Skip(1).Count();
        Direction? reportDirection = null;

        for (var i = 1; i <= count; i++)
        {
            var prev = _data.ElementAt(i - 1);
            var curr = _data.ElementAt(i);

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
    
    private enum Direction
    {
        Asc,
        Desc
    }
}