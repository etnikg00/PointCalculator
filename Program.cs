using PointCalculator.Interfaces;
using PointCalculator.Services;

Console.WriteLine("Enter the path of the input file: ");
var filePath = Console.ReadLine();
if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
{
    Console.WriteLine("Invalid file path or file does not exist.");
    return;
}

IPointService pointService = new PointService();

var points = pointService.ReadPointsFromFile(filePath);
var furthestPoint = pointService.FindFurthestPoint(points);
pointService.PrintResult(furthestPoint);