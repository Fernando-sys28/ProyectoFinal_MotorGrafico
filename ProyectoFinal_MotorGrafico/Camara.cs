using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{
    public class Camara
    {
        public Vertex position;
        public Matrix orientation;
        public List<Plane> clipping_planes;

        public Camara(Vertex position, Matrix orientation)
        {
            this.position = position;
            this.orientation = orientation;
            this.clipping_planes = new List<Plane>();
        }

    }
}
