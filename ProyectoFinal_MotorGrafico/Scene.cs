using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ProyectoFinal_MotorGrafico
{
    public class Scene
    {
        public Mesh mesh;
        public Transform transform;
    
        //Animated Data
        public bool[] animFramesGuardados; //este será para facilitarnos saber si ya guardamos algo en un frame o no
        public Transform[] animTransforms; //Error con las posiciones
        public float[] animPosX, animPosY, animPosZ;
        public Vertex[] animRotations;

        public Scene(Mesh mesh, Transform transform, Form1 formBase)
        {
            int frames = formBase.trackBar1.Maximum + 1; //El tamaño de datos que necesitaremos será la cantidad de frames necesarios, así si haces mas grande la barra podrás tener mas frames sin problema
            animFramesGuardados = new bool[frames];
            animTransforms = new Transform[frames];
            animPosX = new float[frames];
            animPosY = new float[frames];
            animPosZ = new float[frames];
            animRotations = new Vertex[frames]; 

            this.mesh = mesh;
            this.transform = transform;
        }

    }
    
}
