using GeometriskaFigurer;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        Shape[] shapes = new Shape[20];
        createTwentyShapes(shapes, dialog());
        printOutAllShapes(shapes);
        countAverageAreaOfShapes(shapes);
        trianglesCircumferenceSum(shapes);
        shapeBiggestVolume(shapes);
        mostRepeatedShape(shapes);
    }
    private static ConsoleKey dialog()
    {
        ConsoleKey consoleKey = ConsoleKey.L;
        Console.SetCursorPosition(50, 5);
        Console.WriteLine("Welcome to shapes".ToUpper());
        Console.SetCursorPosition(45, 6);
        Console.WriteLine("you got the following choices".ToUpper());
        Console.SetCursorPosition(20, 8);
        Console.WriteLine("Do you wanna enter the center point of the shapes 3D? Y for YES N for NO If YES,\n" +
            "              you have to enter one center point for 3D shapes and one center point for the triangle shape\n");
        consoleKey = Console.ReadKey().Key;
        Console.WriteLine();
        return consoleKey;
    }
    private static void mostRepeatedShape(Shape[] shapes)
    {
        Dictionary<Shape, int> shapesQuantity = new Dictionary<Shape, int>();
        int circleQuantities = 0;
        int cuboidQuantities = 0;
        int cubeQuantities = 0;
        int rectangleQuantities = 0;
        int squreQuantities = 0;
        int triangleQuantities = 0;
        int sphereQuantities = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            if (shapes[i] is Triangle triangle)
            {
                triangleQuantities++;

                shapesQuantity.Add(triangle, triangleQuantities);
            }
            else if (shapes[i] is Circle circle)
            {
                circleQuantities++;
                shapesQuantity.Add(circle, circleQuantities);
            }
            else if (shapes[i] is Cuboid cuboid)
            {
                if (cuboid.IsCube)
                {

                    cubeQuantities++;
                    shapesQuantity.Add(cuboid, cubeQuantities);
                }
                else
                {
                    cuboidQuantities++;
                    shapesQuantity.Add(cuboid, cuboidQuantities);
                }
            }
            else if (shapes[i] is Rectangle rectangle)
            {
                if (rectangle.IsSquare)
                {
                    squreQuantities++;
                    shapesQuantity.Add(rectangle, squreQuantities);
                }
                else
                {
                    rectangleQuantities++;
                    shapesQuantity.Add(rectangle, rectangleQuantities);

                }
            }
            else if (shapes[i] is Sphere sphere)
            {
                sphereQuantities++;
                shapesQuantity.Add(sphere, sphereQuantities);

            }
        }
        var maxValue = shapesQuantity.Values.Max();

        Shape mostRepeated = null;

        foreach (var shape in shapesQuantity)
        {
            if (maxValue == shape.Value)
            {
                mostRepeated = shape.Key;
            }
        }
        int indexName = mostRepeated.ToString().IndexOf("@");
        Console.WriteLine($"        Most repeated shape is: {mostRepeated.ToString().Substring(0, indexName).ToUpper()} by : {maxValue}\n".ToUpper());
    }

    private static void shapeBiggestVolume(Shape[] shapes)
    {
        Dictionary<Shape, float> shapes3D = new Dictionary<Shape, float>();
        float biggestVolume = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            if (shapes[i] is Shape3D shape3D)
            {
                shapes3D.Add(shape3D, shape3D.Volume);
            }
        }
        biggestVolume = shapes3D.Values.Max();
        Shape shapeHeightsVolume = null;
        foreach (var shape in shapes3D)
        {
            if (shape.Value == biggestVolume)
            {
                shapeHeightsVolume = shape.Key;
            }
        }
        int indexName = shapeHeightsVolume.ToString().IndexOf("@");
        Console.WriteLine($"        The shape with heights volume is: {shapeHeightsVolume.ToString().Substring(0, indexName)} by : {biggestVolume}\n".ToUpper());
    }

    private static void printOutAllShapes(Shape[] shapes)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine(shapes[i] + "\n");
        }
    }

    private static void countAverageAreaOfShapes(Shape[] shapes)
    {
        float avrgAreaOfShapes = 0;

        for (int i = 0; i < shapes.Length; i++)
        {
            avrgAreaOfShapes += shapes[i].Area;
        }
        avrgAreaOfShapes = MathF.Round(avrgAreaOfShapes / shapes.Length, 2);
        Console.WriteLine($"        The average area of all shapes is: {avrgAreaOfShapes}\n".ToUpper());
    }

    private static void trianglesCircumferenceSum(Shape[] shapes)
    {
        float circumferenceSum = 0;
        foreach (var shape in shapes)
        {
            if (shape is Triangle triangle)
            {
                circumferenceSum += triangle.Circumference;
            }
        }
        Console.WriteLine($"        The sum of Triangles circumference is: {circumferenceSum}\n".ToUpper());
    }

    private static void createTwentyShapes(Shape[] shapes, ConsoleKey consoleKey)
    {
        if (consoleKey == ConsoleKey.Y)
        {
            Console.WriteLine("\n       Enter the center point 1 of the the 3D shapes");
            float centerPoint3D1 = 0;
            float.TryParse(Console.ReadLine(), out centerPoint3D1);
            Console.WriteLine("     Enter the center point 2 of the the 3D shapes");
            float centerPoint3D2 = 0;
            float.TryParse(Console.ReadLine(), out centerPoint3D2);
            Console.WriteLine("     Enter the center point 3 of the the 3D shapes");
            float centerPoint3D3 = 0;
            float.TryParse(Console.ReadLine(), out centerPoint3D3);
            Vector3 vector3D = new(centerPoint3D1, centerPoint3D2, centerPoint3D3);
            for (int i = 0; i < shapes.Length; i++)
            {
                Shape shape = Shape.GenerateShape(vector3D);
                shapes[i] = shape;
            }
        }
        else
        {
            for (int i = 0; i < shapes.Length; i++)
            {
                Shape shape = Shape.GenerateShape();
                shapes[i] = shape;
            }
        }

    }
}