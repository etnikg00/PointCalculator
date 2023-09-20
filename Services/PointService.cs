using PointCalculator.Interfaces;

namespace PointCalculator.Services;
public class PointService : IPointService
{
    public List<Point> ReadPointsFromFile(string filePath)
    {
        var points = new List<Point>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("The input file does not exist.");
            return points;
        }

        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var point = ParsePoint(line);
                if (point != null)
                {
                    points.Add(point);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }

        return points;
    }

    public Point FindFurthestPoint(List<Point> points)
    {
        if (points.Count == 0)
            return null;

        var furthestPoint = points[0];
        var maxDistance = furthestPoint.DistanceFromCenter();

        foreach (var point in points)
        {
            var distance = point.DistanceFromCenter();
            if (distance > maxDistance)
            {
                maxDistance = distance;
                furthestPoint = point;
            }
        }

        return furthestPoint;
    }

    public void PrintResult(Point furthestPoint)
    {
        if (furthestPoint == null)
        {
            Console.WriteLine("No points found in the input file.");
        }
        else
        {
            Console.WriteLine($"The furthest point from the center is {furthestPoint.Name} at ({furthestPoint.X}, {furthestPoint.Y}).");
            Console.WriteLine($"It is in quadrant {furthestPoint.GetQuadrant()}.");
            Console.WriteLine($"Distance from center: {furthestPoint.DistanceFromCenter()}");
        }
    }

    private static Point ParsePoint(string input)
    {
        try
        {
            var parts = input.Split(new[] {'(', ',', ')'}, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 3)
            {
                var name = parts[0].Trim();

                if (int.TryParse(parts[1], out var x) && int.TryParse(parts[2], out var y))
                {
                    return new Point(name, x, y);
                }
                else
                {
                    Console.WriteLine($"Invalid coordinates in line: {input}");
                }
            }
            else
            {
                Console.WriteLine($"Invalid format in line: {input}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing point: {ex.Message}");
        }

        return null;
    }
}