using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Flat.Maths.Vector
{
    public struct Vector2 : IEquatable<Vector2>, IFormattable
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void Set(float newX, float newY)
        {
            X = newX;
            Y = newY;
        }


        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
            // Magnitude from the Origin
        }

        public void Scale(float scale)
        {
            X *= scale;
            Y *= scale;
        }
        public void Scale(Vector2 scale)
        {
            X *= scale.X;
            Y *= scale.Y;
        }

        public void Normalise()
        {
            float mag = Magnitude();

            if (mag > kEpsilon)
                Scale(1 / mag);
            else
                Scale(0);
        }

        bool IEquatable<Vector2>.Equals(Vector2 other)
        {
            return
                X == other.X &&
                Y == other.Y;
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return false;


            Vector2 other = (Vector2)obj;

            return
                X == other.X &&
                Y == other.Y;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToString(null, null);
        }
        public string ToString(string? format)
        {
            return ToString(format, null);
        }
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "F2";
            if (formatProvider == null)
                formatProvider = CultureInfo.InvariantCulture.NumberFormat;

            return $"{X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)}";
        }
        
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        private const float kEpsilon = 0.00001f;
    }
}
