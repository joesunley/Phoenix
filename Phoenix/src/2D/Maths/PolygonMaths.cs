using Phoenix.Flat.Maths.Vector;
using Phoenix.Flat.Physics.Collision;

using System;

namespace Phoenix.Flat.Maths
{
    public static class PolygonMaths
    {
        internal static bool IsConvex(PolygonCollider collider)
        {
            return IsConvex(collider.Vertices);
        }

        public static bool IsConvex(Vector2[] vertices)
        {
            // Solution found on Stackoverflow by Rory Daulton
            //  - https://stackoverflow.com/users/6246044/rory-daulton

            try
            {
                if (vertices.Length < 3)
                    return false;

                Vector2 oldV = vertices[vertices.Length - 2];
                Vector2 newV = vertices[vertices.Length - 1];
                double newDirection = Math.Atan2(newV.Y - oldV.Y, newV.X - oldV.X);
                double angleSum = 0;
                double oldDirection = 0;
                double orientation = 0;

                foreach (Vector2 v in vertices)
                {
                    oldV = newV;
                    oldDirection = newDirection;

                    newV = v;
                    newDirection = Math.Atan2(newV.Y - oldV.Y, newV.X - oldV.X);

                    if (oldV.X == newV.X && oldV.Y == newV.Y)
                        return false;

                    double angle = newDirection - oldDirection;

                    if (angle <= -Math.PI)
                        angle += Math.PI * 2;
                    else if (angle > Math.PI)
                        angle -= Math.PI * 2;

                    if (v == vertices[0])                        
                        orientation = (angle > 0) ? 1 : -1;
                    else
                    {
                        if (orientation * angle < 0)
                            return false;
                    }

                    angleSum += angle;
                }

                return Math.Abs(Math.Round(angleSum / (Math.PI * 2))) == 1;
            } catch { return false; }
            
        }

        ///

        

        public static bool DoPolysCollide(Vector2[] poly1, Vector2[] poly2)
        {
            Line[] lines = CalculateLines(poly1, poly2);

            foreach (Line line in lines)
            {
                float[] bounds1 = Project(poly1, line);
                float[] bounds2 = Project(poly2, line);

                if (!Overlap(bounds1, bounds2))
                    return false;
            }

            return true;
        }
      

        private static Line[] CalculateLines(Vector2[] poly1, Vector2[] poly2)
        {
            List<Line> lines = new();

            lines.Add(new(poly1[poly1.Length - 1], poly1[0]));

            for (int i = 1; i < poly1.Length; i++)
                lines.Add(new(poly1[i - 1], poly1[2]));

            lines.Add(new(poly2[poly2.Length - 1], poly2[0]));

            for (int i = 1; i < poly2.Length; i++)
                lines.Add(new(poly2[i - 1], poly2[i]));

            return lines.ToArray();
        }

        private static float[] Project(Vector2[] poly, Line line)
        {
            float min = float.MaxValue,
                max = float.MinValue;


            try
            {
                float gradient = line.Gradient;

                if (gradient != 0)
                {
                    foreach (Vector2 point in poly)
                    {
                        float yIntercept = point.Y + (point.X / gradient);

                        if (yIntercept < min)
                            min = yIntercept;
                        if (yIntercept > max)
                            max = yIntercept;
                    }
                }
                else // Horizontal Line
                {
                    foreach (Vector2 point in poly)
                    {
                        if (point.X < min)
                            min = point.X;
                        if (point.X > max)
                            max = point.X;
                    }
                }
                
            }
            catch // Vertical Line
            {
                foreach (Vector2 point in poly)
                {
                    if (point.Y < min)
                        min = point.Y;
                    if (point.Y > max)
                        max = point.Y;
                }
            }

            return new float[] { min, max };

        }

        private static bool Overlap(float[] poly1, float[] poly2)
        {
            if (poly1[0] == poly2[0] || poly1[1] == poly2[1])
                return true;

            if (poly1[0] < poly2[0])
            {
                if (poly1[1] >= poly2[0])
                    return true;
            }
            else
            {
                if (poly2[1] >= poly1[0])
                    return true;
            }

            return false;
        }

        private struct Line
        {
            public Vector2 Start, End;

            public Line(Vector2 start, Vector2 end)
            {
                Start = start;
                End = end;
            }

            public float Gradient => (Start.Y - End.Y) / (Start.X - End.X);
        }
    }
}
