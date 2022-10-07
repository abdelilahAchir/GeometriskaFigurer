using System.Numerics;
using System.Xml.Linq;

namespace GeometriskaFigurer
{

    public class Cuboid : Shape3D
    {
        public override float Volume => _height * _width * _depth;

        public override Vector3 Center => _center;

        public override float Area => 2 * ((_depth * _height) + (_width * _height) + (_height * _depth));

        public bool IsCube
        {
            get
            {
                if (_height == _width && _height == _depth && _width == _depth)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private Vector3 _center;
        private float _height;
        private float _width;
        private float _depth;
        public Cuboid(Vector3 center, Vector3 heightWidthDepth)
        {
            _center = center;
            _depth = heightWidthDepth.Z;
            _width = heightWidthDepth.X;
            _height = heightWidthDepth.Y;
        }
        public Cuboid(Vector3 center, float heightWidthDepth)
        {
            _center = center;
            _depth = heightWidthDepth;
            _width = heightWidthDepth;
            _height = heightWidthDepth;
        }

        public override string ToString()
        {
            if (!IsCube)
            {
                return $"Cuboid @({_center.X},{_center.Y},{_center.Z}): w = "
               + $"{_width},h = {_height}, l = {_depth} (Is cube : {IsCube})";
            }
            else
            {
                return $"Cube @({_center.X},{_center.Y},{_center.Z}): w = "
               + $"{_width},h = {_height}, l = {_depth} (Is cube : {IsCube})";
            }
        }
    }
}