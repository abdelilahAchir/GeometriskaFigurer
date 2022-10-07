using System.Numerics;

namespace GeometriskaFigurer
{
    public class Circle : Shape2D
    {
        public override float Circumference => _radius * MathF.PI;
        public override Vector3 Center => new Vector3(_center.X, _center.Y, 0);
        public override float Area => MathF.PI * MathF.Pow(_radius, 2);
        private Vector2 _center;

        private float _radius;
        public Circle(Vector2 center, float radius)
        {
            _center = center;
            _radius = radius;
        }

        public override string ToString()
        {
            return $"Circle@({Center.X}, {Center.Y}): radius = {_radius}";
        }
    }
}