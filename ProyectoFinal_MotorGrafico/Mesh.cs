using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{   
    public class Mesh
    {

        public Vertex[] vertices;
        public triangulo[] triangulos;
        public Vertex bounds_center;
        public float bounds_radius;
        public Vertex centroid,last;

        public Mesh(Vertex[] vertices, triangulo[] triangulos , Vertex bounds_center, float bounds_radius)
        {
            this.vertices = vertices;
            this.triangulos = triangulos;
            this.bounds_center = bounds_center;
            this.bounds_radius = bounds_radius;
            this.centroid = CalculateCentroid();

        }

        private Vertex CalculateCentroid()
        {
            Vertex centroid = new Vertex(0,0,0);
            foreach (Vertex vertex in vertices)
            {
                centroid.X += vertex.X;
                centroid.Y += vertex.Y;
                centroid.Z += vertex.Z;
            }
            last = centroid;
            centroid.X /= vertices.Length;
            centroid.Y /= vertices.Length;
            centroid.Z /= vertices.Length;
            return centroid;
        }
    }
}
