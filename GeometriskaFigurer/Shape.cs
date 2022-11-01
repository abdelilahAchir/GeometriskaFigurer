using System.Numerics;

namespace GeometriskaFigurer
{
    public abstract class Shape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }
        enum shapes
        {
            circle,
            rectangle,
            square,
            cuboid,
            cube,
            sphere,
            triangle
        }
        public static Shape GenerateShape()
        {
            Random random = new Random();
            shapes shape = (shapes)random.Next(0, 7);

            Vector3 centerShape3D = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector3 heightWidthDepthCuboid = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 centerShape2D = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 sizeShape2D = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 trianglePoint1 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 trianglePoint2 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 trianglePoint3 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            float widthSquare = NextFloatHelpers.NextFloat();
            float heightWidthDepthCube = NextFloatHelpers.NextFloat();
            float radius = NextFloatHelpers.NextFloat(1.0f, 10.0f);
            bool isItATriangle = false;
            bool validSide1 = trianglePoint1.Length() + trianglePoint2.Length() > trianglePoint3.Length();
            bool validSide2 = trianglePoint1.Length() + trianglePoint3.Length() > trianglePoint2.Length();
            bool validSide3 = trianglePoint3.Length() + trianglePoint2.Length() > trianglePoint1.Length();

            while (!isItATriangle)
            {
                if (validSide1 && validSide2 && validSide3)
                {
                    isItATriangle = true;
                }
                else
                {
                    isItATriangle = false;
                    trianglePoint1 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
                    trianglePoint2 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
                    trianglePoint3 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
                    validSide1 = trianglePoint1.Length() + trianglePoint2.Length() > trianglePoint3.Length();
                    validSide2 = trianglePoint1.Length() + trianglePoint3.Length() > trianglePoint2.Length();
                    validSide3 = trianglePoint3.Length() + trianglePoint2.Length() > trianglePoint1.Length();
                }
            }

            if (shape == shapes.circle)
            {
                Shape circle = new Circle(centerShape2D, radius);
                return circle;
            }
            else if (shape == shapes.cuboid)
            {
                Shape cuboid = new Cuboid(centerShape3D, heightWidthDepthCuboid);
                return cuboid;
            }
            else if (shape == shapes.cube)
            {
                Shape cube = new Cuboid(centerShape3D, heightWidthDepthCube);
                return cube;
            }
            else if (shape == shapes.rectangle)
            {
                Shape rectangle = new Rectangle(centerShape2D, sizeShape2D);
                return rectangle;
            }
            else if (shape == shapes.square)
            {
                Shape square = new Rectangle(centerShape2D, widthSquare);
                return square;
            }
            else if (shape == shapes.sphere)
            {
                Shape sphere = new Sphere(centerShape3D, radius);
                return sphere;
            }
            else if (shape == shapes.triangle)
            {
                Shape triangle = new Triangle(trianglePoint1, trianglePoint2, trianglePoint3);
                return triangle;
            }
            else
            {
                return null;
            }
        }
        public static Shape GenerateShape(Vector3 centerPoint3DShapes)
        {
            Random random = new Random();
            Vector3 centerShape3D;
            shapes shape = (shapes)random.Next(0, 7);
            Vector3 heightWidthDepthCuboid = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 centerShape2D = new(centerPoint3DShapes.X, centerPoint3DShapes.Y);
            Vector2 sizeShape2D = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 trianglePoint1 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 trianglePoint2 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
            Vector2 centerTriangle = new(centerPoint3DShapes.X, centerPoint3DShapes.Y);
            Vector2 trianglePoint3 = new Vector2((3 * centerTriangle.X) - trianglePoint1.X - trianglePoint2.X, (3 * centerTriangle.Y) - trianglePoint1.Y - trianglePoint2.Y);
            bool isItATriangle = false;
            bool validSide1 = trianglePoint1.Length() + trianglePoint2.Length() > trianglePoint3.Length();
            bool validSide2 = trianglePoint1.Length() + trianglePoint3.Length() > trianglePoint2.Length();
            bool validSide3 = trianglePoint3.Length() + trianglePoint2.Length() > trianglePoint1.Length();

            while (!isItATriangle)
            {
                if (validSide1 && validSide2 && validSide3)
                {
                    isItATriangle = true;
                }
                else
                {
                    isItATriangle = false;
                    trianglePoint1 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
                    trianglePoint2 = new(NextFloatHelpers.NextFloat(), NextFloatHelpers.NextFloat());
                    validSide1 = trianglePoint1.Length() + trianglePoint2.Length() > trianglePoint3.Length();
                    validSide2 = trianglePoint1.Length() + trianglePoint3.Length() > trianglePoint2.Length();
                    validSide3 = trianglePoint3.Length() + trianglePoint2.Length() > trianglePoint1.Length();
                }
            }
            float widthSquare = NextFloatHelpers.NextFloat();
            float heightWidthDepthCube = NextFloatHelpers.NextFloat();
            float radius = NextFloatHelpers.NextFloat(1.0f, 10.0f);
            centerShape3D = centerPoint3DShapes;

            if (shape == shapes.circle)
            {
                Shape circle = new Circle(centerShape2D, radius);
                return circle;
            }
            else if (shape == shapes.cuboid)
            {

                Shape cuboid = new Cuboid(centerShape3D, heightWidthDepthCuboid);
                return cuboid;
            }
            else if (shape == shapes.cube)
            {
                Shape cube = new Cuboid(centerShape3D, heightWidthDepthCube);
                return cube;
            }
            else if (shape == shapes.rectangle)
            {
                Shape rectangle = new Rectangle(centerShape2D, sizeShape2D);
                return rectangle;
            }
            else if (shape == shapes.square)
            {
                Shape square = new Rectangle(centerShape2D, widthSquare);
                return square;
            }
            else if (shape == shapes.sphere)
            {
                Shape sphere = new Sphere(centerShape3D, radius);
                return sphere;
            }
            else if (shape == shapes.triangle)
            {

                Shape triangle = new Triangle(trianglePoint1, trianglePoint2, trianglePoint3);
                return triangle;
            }
            else
            {
                return null;
            }
        }
    }
}