namespace PointCalculator.Interfaces;
public interface IPointService
{
    List<Point> ReadPointsFromFile(string filePath);
    Point FindFurthestPoint(List<Point> points);
    void PrintResult(Point furthestPoint);
}