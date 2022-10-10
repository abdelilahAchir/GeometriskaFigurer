using System.Numerics;

namespace GeometriskaFigurer
{
    public class Triangle : Shape2D
    {
        public override float Circumference => _p1.Length() + _p2.Length() + _p3.Length();

        public override Vector3 Center => new Vector3((_p1.X + _p2.X + _p3.X) / 3, (_p1.Y + _p2.Y + _p3.Y) / 3, 0 );
        public override float Area
        {
            get
            {
                return (1F / 4F) * MathF.Sqrt((_p1.Length() + _p2.Length() + _p3.Length()) *
                                                (-_p1.Length() + _p2.Length() + _p3.Length() *
                                                 _p1.Length() - _p2.Length() + _p3.Length() *
                                                  _p1.Length() + _p2.Length() - _p3.Length()));
            }
        }
      

        private Vector2 _p1;
        private Vector2 _p2;
        private Vector2 _p3;
        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }

        public override string ToString()
        {
            return $"       Triangle@( Center: ({Center.X}  {Center.Y})  Point 1: ({_p1.X}  {_p1.Y})  Point 2: ({_p2.X}  {_p2.Y})  Point 3: ({_p3.X}  {_p3.Y}))";
        }
    }
}