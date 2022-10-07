using System.Numerics;

namespace GeometriskaFigurer
{
    public class Rectangle : Shape2D
    {
        public override float Circumference => 2 * (_size.X + _size.Y);

        public override Vector3 Center => new Vector3(_center.X, _center.Y, 0);

        public override float Area => _size.X * _size.Y;
        public bool IsSquare
        {
            get
            {
                if (_size.X == _size.Y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Vector2 _center;
        private Vector2 _size;

        public Rectangle(Vector2 center, Vector2 size)
        {
            _center = center;
            _size = size;
        }

        public Rectangle(Vector2 center,float width)
        {
            _center = center;
            _size.X = width;
            _size.Y = width;
        }

        
        public override string ToString()
        {
            if (IsSquare)
            {
                return $"Square@({_center.X},{_center.Y}): width = {_size.X} heigth = {_size.Y} Is square: {IsSquare}";

            }else
            {
                return $"Rectangle@({_center.X},{_center.Y}): width = {_size.X} heigth = {_size.Y} Is square: {IsSquare}";

            }
        }
    }
}