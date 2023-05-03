using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{
    
    public class triangulo
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int[] indexes { get; set; }

        public Color color;

        public triangulo(int a, int b, int c, Color color)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.indexes = new int[] { a, b, c };
            this.color = color;
        }

        private Vertex CalculateNormal(Vertex a, Vertex b, Vertex c)
        {
            Vertex edge1 = new Vertex(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
            Vertex edge2 = new Vertex(c.X - a.X, c.Y - a.Y, c.Z - a.Z);

            float CrossX = edge1.Y * edge2.Z - edge1.Z * edge2.Y;
            float CrossY = edge1.Z * edge2.X - edge1.X * edge2.Z;
            float CrossZ = edge1.X * edge2.Y - edge1.Y * edge2.X;

            Vertex normal = new Vertex(CrossX, CrossY, CrossZ);
            return normal;
        }

        private float DotProduct(Vertex a, Vertex b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        }

    }
}
