using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{
    public class Transform
    {
        public float scale;
        public Vertex traslation;
        public Matrix transform;
        public Matrix rotation { get; set; }
        public Transform(float scale, Vertex traslation, Matrix rotation=null)
        {
            this.scale = scale;
            this.rotation = rotation ?? Matrix.Identity; ;

            this.traslation = traslation;
            this.transform = Matrix.MakeTranslationMatrix(this.traslation) * this.rotation * Matrix.MakeScalingMatrix(this.scale);
        }
        
        public Transform Clone()
        {
            Vertex translationClone = new Vertex(this.traslation.X, this.traslation.Y, this.traslation.Z);
            Matrix rotationClone = this.rotation;
            return new Transform(this.scale, translationClone, rotationClone);
        }
    }
}
