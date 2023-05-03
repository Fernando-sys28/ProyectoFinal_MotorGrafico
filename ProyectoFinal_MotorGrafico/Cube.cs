using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{
    public class Cube
    {

        public static Mesh Cubo() {
            Mesh mesh;
            Vertex[] vertices = new Vertex[] {
                                            new Vertex(1, 1, 1),
                                            new Vertex(-1, 1, 1),
                                            new Vertex(-1, -1, 1),
                                            new Vertex(1, -1, 1),
                                            new Vertex(1, 1, -1),
                                            new Vertex(-1, 1, -1),
                                            new Vertex(-1, -1, -1),
                                            new Vertex(1, -1, -1)
                                        };


            triangulo[] triangles = new triangulo[] {
                                            new triangulo(0, 1, 2, Color.White),
                                            new triangulo(0, 2, 3, Color.White),
                                            new triangulo(4, 0, 3, Color.White),
                                            new triangulo(4, 3, 7, Color.White),
                                            new triangulo(5, 4, 7, Color.White),//-----------------------
                                            new triangulo(5, 7, 6, Color.White),
                                            new triangulo(1, 5, 6, Color.White),
                                            new triangulo(1, 6, 2, Color.White),
                                            new triangulo(4, 5, 1, Color.White),
                                            new triangulo(4, 1, 0, Color.White),
                                            new triangulo(2, 6, 7, Color.White),
                                            new triangulo(2, 7, 3, Color.White)
                                           };
            mesh = new Mesh(vertices, triangles, new Vertex(0, 0, 0), (float)Math.Sqrt(3));
            return mesh; 
        }
    }
}
