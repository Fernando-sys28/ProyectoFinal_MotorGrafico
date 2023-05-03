using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{
    public class Vertex
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float W { get; set; }

        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1;

        }


        public static Vertex Cross(Vertex a, Vertex b)
        {
            return new Vertex(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        // Computes dot product.
        public static float operator *(Vertex v1, Vertex v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static Vertex operator +(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vertex operator -(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vertex operator -(Vertex v)
        {
            return new Vertex(-v.X, -v.Y, -v.Z);
        }
        public static Vertex operator /(Vertex v1, float a)
        {
            return new Vertex(v1.X / a, v1.Y / a, v1.Z / a);
        }

        public static Vertex operator *(Vertex v1, float b)
        {
            return new Vertex(v1.X * b, v1.Y * b, v1.Z * b);
        }
        public float Mag()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }
        public Vertex Normalize()
        {
            float mag = this.Mag();
            return new Vertex(X / mag, Y / mag, Z / mag);
        }



    }

}