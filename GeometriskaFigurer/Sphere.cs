using System.Numerics;

namespace GeometriskaFigurer
{
    public class Sphere : Shape3D
    {
        public override float Volume => 4F / 3F * ( MathF.PI * MathF.Pow(_radius, 3));

        public override Vector3 Center => _center;

        public override float Area => 4 * (MathF.PI * MathF.Pow(_radius, 2));

        private Vector3 _center;
        private float _radius;
        public Sphere(Vector3 center, float radius)
        {
            _center = center;
            _radius = radius;
        }

        public override string ToString()
        {
            return $"       Sphere @( Center: ({_center.X} {_center.Y} {_center.Z})   Radius: ({_radius}))";
        }
    }
}