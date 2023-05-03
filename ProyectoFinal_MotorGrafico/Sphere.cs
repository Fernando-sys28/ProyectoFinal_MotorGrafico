using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{
    public class Sphere
    {
        public static Mesh SphereM( int divs, Color c) {

            List<Vertex> vertices = new List<Vertex>();
            List<triangulo> triangles = new List<triangulo>();
            float delta_angle = 2.0f * (float)Math.PI / divs;

            // Generate vertices and normals.
            for (int d = 0; d < divs + 1; d++)
            {
                float y = (2.0f/ divs) * (d - divs / 2);
                float radius = (float)Math.Sqrt(1.0 - y * y);
                for (int i = 0; i < divs; i++)
                {
                    Vertex vertex = new Vertex(radius * (float)Math.Cos(i * delta_angle), y, radius * (float)Math.Sin(i * delta_angle));
                    vertices.Add(vertex);
                }
            }

            // Generate triangles.
            for (int d = 0; d < divs; d++)
            {
                for (int i = 0; i < divs; i++)
                {
                    int i0 = d * divs + i;
                    int i1 = (d + 1) * divs + (i + 1) % divs;
                    int i2 = divs * d + (i + 1) % divs;
                    int[] tri0 = new int[] { i0, i1, i2 };
                    int[] tri1 = new int[] { i0, i0 + divs, i1 }; ;
                    triangulo tri = new triangulo(tri0[0], tri0[1], tri0[2], c);
                    triangles.Add(tri);
                    triangulo triangulo = new triangulo(tri1[0], tri1[1], tri1[2], c);
                    triangles.Add(triangulo);
                }
            }

            return new Mesh(vertices.ToArray(), triangles.ToArray(), new Vertex(0, 0, 0), (float)Math.Sqrt(1));
        }
    }
}
