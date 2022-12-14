using System.Numerics;

namespace GeometriskaFigurer
{
    public class Triangle : Shape2D
    {
        public override float Circumference => (MathF.Sqrt(MathF.Pow(_p2.X - _p1.X, 2) + MathF.Pow(_p2.Y - _p1.Y, 2))) +
                                               (MathF.Sqrt( MathF.Pow(_p3.X - _p2.X  ,2) + MathF.Pow(_p3.Y - _p2.Y,2))) + 
                                               (MathF.Sqrt(MathF.Pow(_p3.X - _p1.X,2) + MathF.Pow(_p3.Y - _p1.Y,2))); 

        public override Vector3 Center => new Vector3((_p1.X + _p2.X + _p3.X) / 3, (_p1.Y + _p2.Y + _p3.Y) / 3, 0);
        public override float Area => MathF.Abs((_p1.X * (_p2.Y - _p3.Y) + _p2.X * (_p3.Y - _p1.Y) + _p3.X * (_p1.Y - _p2.Y)) / 2);



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