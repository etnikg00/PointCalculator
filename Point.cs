namespace PointCalculator;
public class Point
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Point(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public double DistanceFromCenter()
    {
        return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
    }

    public int GetQuadrant()
    {
        switch (X)
        {
            case > 0 when Y > 0:
                return 1;
            case < 0 when Y > 0:
                return 2;
            case < 0 when Y < 0:
                return 3;
            case > 0 when Y < 0:
                return 4;
            default:
                return 0;
        }
    }
}