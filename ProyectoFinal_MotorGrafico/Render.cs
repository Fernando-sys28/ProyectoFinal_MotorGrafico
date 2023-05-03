using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_MotorGrafico
{
    public class Render
    {
        public List<Scene> scenas;
        public Canvas canvas;
        

        public Render(PictureBox lienzo) {
            scenas = new List<Scene>();
            init(lienzo);
          
        }
        public void init(PictureBox pictureBox1)
        {
            canvas = new Canvas(pictureBox1.Size);
            pictureBox1.Image = canvas.bitmap;
        }

        public void convertirScenas()
        {
            Scene[] scenasArray = scenas.ToArray(); // Convertir la lista en un array
            canvas.FastClear();
            canvas.Render(scenasArray);
            
        }

    }

}
