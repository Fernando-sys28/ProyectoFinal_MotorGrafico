using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinal_MotorGrafico
{
    public partial class Form1 : Form
    {
        Scene scena;
        Render render;
        public bool RXYZ = false;

        bool mouseDown = false;
        bool canvasdown = false;
        bool mouseDownY = false;
        Point ptX, ptY, mouse;
        float deltaX = 0;
        float deltaY = 1f;

        float CamaraX = -3;
        float CamaraY = 1;
        float CamaraZ = 2;

        float TrasladarZ = 10;

        float angle = 0;
        int primerFrame = -1;
        int ultimoFrame = -1;
        string filePath;

        //Animacion
        private bool play = false;
        bool stop = false;
        float FOV;
        private List<Scene> meshes;

        //Movimiento
        float posX, posY;
        float rotX, rotY, rotZ;
        float initRotX = 0, initRotY = 0, initRotZ = 0;

        public Form1()
        {
            InitializeComponent();
            meshes = new List<Scene>();
            render = new Render(pictureBox1);
            labelFrames.Text = "FRAME: " + trackBar1.Value + "/" + trackBar1.Maximum;
        }

        private void timer1_Tick(object sender, EventArgs j)
        {
            if (scena != null)
            {

                render.canvas.camera.position.X = CamaraX;
                render.canvas.camera.position.Y = CamaraY;
                render.canvas.camera.position.Z = CamaraZ;

                if (RXYZ)
                {
                    Matrix combinedRotation = Matrix.RotX(angle) * Matrix.RotY(angle) * Matrix.RotZ(angle);
                    scena.transform.rotation = combinedRotation;
                }
                angle++;
                scena.transform = new Transform(scena.transform.scale, scena.transform.traslation, scena.transform.rotation);

                if (play) //Es el encargado de la animación, si es verdadero empezará a reprodcir cuadro por cuadro y al terminar reiniciará en 0
                {
                    if (trackBar1.Value < trackBar1.Maximum && !checkReverse.Checked)
                    {
                        trackBar1.Value++;
                        ObtenerAnimacion(); //En una función porque asi lo podremos usar manual y automaticamente
                    }

                    else if (trackBar1.Value > 0 && checkReverse.Checked)
                    {
                        trackBar1.Value--;
                        ObtenerAnimacion(); //En una función porque asi lo podremos usar manual y automaticamente
                    }

                    else
                        checkReverse.Checked = !checkReverse.Checked;
                }
            }
            render.convertirScenas();

            pictureBox1.Invalidate();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (scena != null)
            {
                FOV = float.Parse(textBox1.Text);
                //canvas.a = FOV;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stop = false;
            RXYZ = true;
        }

        private void ReadOBJ()
        {
            Vertex[] vertices;
            triangulo[] faces;

            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Vertex> vertexList = new List<Vertex>();
                List<triangulo> faceList = new List<triangulo>();

                // Reiniciar el lector del archivo para volver a leer desde el principio
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                reader.DiscardBufferedData();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    // Leer la línea y procesar la información para obtener los vértices
                    if (line.StartsWith("v "))
                    {
                        string[] vertexValues = line.Split(' ');
                        float x = float.Parse(vertexValues[1]);
                        float y = float.Parse(vertexValues[2]);
                        float z = float.Parse(vertexValues[3]);
                        Vertex vertex = new Vertex(x, y, z);
                        vertexList.Add(vertex);
                    }
                    else if (line.StartsWith("f "))
                    {
                        string[] faceValues = line.Split(' ');
                        List<int> faceIndices = new List<int>();
                        for (int j = 0; j < faceValues.Length; j++)
                        {
                            string[] vertexIndexValues = faceValues[j].Split('/');
                            int vertexIndex;
                            if (int.TryParse(vertexIndexValues[0], out vertexIndex))
                            {
                                vertexIndex--; // Restar 1 para índices basados en 0
                                faceIndices.Add(vertexIndex);
                            }
                        }

                        // Crear caras triangulares a partir de los índices obtenidos
                        for (int i = 1; i < faceIndices.Count - 1; i++)
                        {
                            triangulo face = new triangulo(faceIndices[0], faceIndices[i], faceIndices[i + 1], Color.White);
                            faceList.Add(face);
                        }
                    }
                }
                vertices = vertexList.ToArray();
                faces = faceList.ToArray();
            }
            Mesh OBJ;
            OBJ = new Mesh(vertices, faces, new Vertex(0, 0, 0), (float)Math.Sqrt(3));
            NuevaScena(OBJ);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mesh cubo;
            cubo = Cube.Cubo();

            NuevaScena(cubo);

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Mesh cylinder;
            cylinder = Cylinder.CylinderMesh(1f, 2.5f, 10);

            NuevaScena(cylinder);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Mesh sphere;
            sphere = Sphere.SphereM(20, Color.White);
            NuevaScena(sphere);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mesh cone;
            cone = Cone.ConeM(1f, 2f, 15);

            NuevaScena(cone);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Mesh cylinder;
            cylinder = Cylinder.CylinderMesh(1f, 2.5f, 5);

            NuevaScena(cylinder);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
        }



        private void trackBar2_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void trackBar2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                deltaY += (float)(ptY.Y - e.Location.Y) / 300;//------------------
                scena.transform.scale = deltaY;
                ptY.Y = e.Location.Y;
            }
        }

        private void escalarScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            escalarScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void btnBuscarArchivo_Click_1(object sender, EventArgs e)
        {
            // Crear un nuevo cuadro de diálogo de selección de archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configurar propiedades del cuadro de diálogo
            openFileDialog.Title = "Buscar archivo";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Directorio inicial del cuadro de diálogo

            // Mostrar el cuadro de diálogo y obtener el resultado
            DialogResult result = openFileDialog.ShowDialog();

            // Obtener la ruta del archivo seleccionado
            filePath = openFileDialog.FileName;

            ReadOBJ();
        }

        private void camaraYScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void camaraYScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                CamaraY += (float)(ptY.Y - e.Location.Y) / 200;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void camaraYScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            camaraYScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void camaraZScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void camaraZScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                CamaraZ += (float)(ptY.Y - e.Location.Y) / 200;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void camaraZScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            camaraZScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void RotarYScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }



        private void traslationsZScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void traslationsZScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                TrasladarZ += (float)(ptY.Y - e.Location.Y) / 50;//------------------
                scena.transform.traslation.Z = TrasladarZ;
                ptY.Y = e.Location.Y;
            }
        }

        private void traslationsZScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            traslationsZScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void camaraXScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptX = e.Location;
            mouseDown = true;
        }

        private void camaraXScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                CamaraX += (float)(e.Location.X - ptX.X) / 300;
                ptX.X = e.Location.X;
            }
        }

        private void camaraXScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            camaraXScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }
        private void button10_Click(object sender, EventArgs e)
        {
            RXYZ = false;
            angle = 0;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            scena = (Scene)treeView1.SelectedNode.Tag;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            canvasdown = false;
            pictureBox1.Select();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (canvasdown && scena != null)
            {
                Console.WriteLine((float)(mouse.Y - e.Y) / 100);
                scena.transform.traslation.X = posX - (float)(mouse.X - e.X) / 100;
                scena.transform.traslation.Y = posY + (float)(mouse.Y - e.Y) / 100;
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = e.Location;
            canvasdown = true;

            if (scena != null)

            {
                posX = scena.transform.traslation.X;
                posY = scena.transform.traslation.Y;
            }
        }

        private void trackBar2_MouseDown_1(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }



        //Rotate
        //X
        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            ptX = e.Location;
            mouseDown = true;
        }

        private void trackBar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                rotX = RotarXScroll.Value + initRotX;

                RotateMesh();
            }
        }
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            initRotX = rotX;
            RotarXScroll.Value = 0;
        }
        //Y
        private void RotarYScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                rotY = RotarYScroll.Value + initRotY;

                RotateMesh();
            }
        }

        private void RotarYScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            initRotY = rotY;
            RotarYScroll.Value = 0;
        }

        //Z
        private void trackBar2_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                rotZ = trackBar2.Value + initRotZ;
                RotateMesh();
            }
        }
        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            initRotZ = rotZ;
            trackBar2.Value = 0;
        }


        private void RotateMesh()
        {
            scena.transform.rotation = Matrix.Rotate(new Vertex(rotX, rotY, rotZ));
        }


        //Generar Mesh
        private void NuevaScena(Mesh mesh)
        {
            scena = new Scene(mesh, new Transform(1f, new Vertex(0, 0, 10), Matrix.Identity), this);
            render.scenas.Add(scena);
            TreeNode node = new TreeNode("Scena" + (treeView1.Nodes.Count + 1));
            node.Tag = scena; // Guardar una referencia a la escena en la propiedad Tag del nodo
            treeView1.Nodes.Add(node);
            treeView1.SelectedNode = node;
            meshes.Add(scena);
        }

        //Frames
        private void buttonGuardarFrame_Click(object sender, EventArgs e)
        {
            scena.animFramesGuardados[trackBar1.Value] = true;
            scena.animTransforms[trackBar1.Value] = scena.transform;

            scena.animPosX[trackBar1.Value] = scena.transform.traslation.X;
            scena.animPosY[trackBar1.Value] = scena.transform.traslation.Y;
            scena.animPosZ[trackBar1.Value] = scena.transform.traslation.Z;

            scena.animRotations[trackBar1.Value] = new Vertex(rotX, rotY, rotZ);
        }

        //Animación
        private void trackBar1_Scroll(object sender, EventArgs e) //Cambiar frame
        {
            ObtenerAnimacion();
        }

        private void buttonReproducir_Click(object sender, EventArgs e)
        {
            play = !play;

            if (play)
                buttonReproducir.Text = "PAUSA";
            else
                buttonReproducir.Text = "PLAY";
        }

        private void ObtenerAnimacion()
        {
            labelFrames.Text = "FRAME: " + trackBar1.Value + "/" + trackBar1.Maximum;
            if (checkAnimAll.Checked) //Si queremos ver todas las animaciones de las figuras a la vez
                AnimarTodas();

            else //O ver una por una, solo la mesh seleccionada
                AnimarMesh(scena);
        }

        private void AnimarTodas() //Error desconocido
        {
            foreach (Scene meshIndividual in meshes) //para cada mesh existente
            {
                AnimarMesh(meshIndividual); //La misma función cada mesh
            }
        }

        private void AnimarMesh(Scene meshSeleccionado)
        {
            int inicio = -1; //Guardaremos el primer frame que tenga algo guardado
            int final = -1; //Guardaremos el ultimo frame que tenga algo guardado
            float valor; //La posicion en la que estamos entre el inicial y el final, del 0 al 1 (algo asi como un porcentaje)

            if (treeView1.Nodes.Count == 0) //Si no tenemos figuras, evitamos el código para no tener erroes
                return;

            if (meshSeleccionado.animFramesGuardados[trackBar1.Value]) //Si la mesh es un frame guardado no hace nada, ya que no requiere inicio ni fin;
            {
                Console.WriteLine("Fallo");
                return;
            }

            else
            {
                for (int i = trackBar1.Value; i >= 0; i--)
                {
                    if (meshSeleccionado.animFramesGuardados[i])
                    {
                        inicio = i;

                        break;
                    }
                }

                for (int i = trackBar1.Value; i <= meshSeleccionado.animTransforms.Length - 1; i++)
                {
                    if (meshSeleccionado.animFramesGuardados[i])
                    {
                        final = i;
                        break;
                    }
                }
            }

            if (inicio != -1 && final != -1)
            {

                valor = ((float)trackBar1.Value - inicio) / (final - inicio);
                float posX = ((meshSeleccionado.animPosX[final] - meshSeleccionado.animPosX[inicio]) * valor) + meshSeleccionado.animPosX[inicio];
                float posY = ((meshSeleccionado.animPosY[final] - meshSeleccionado.animPosY[inicio]) * valor) + meshSeleccionado.animPosY[inicio];
                float posZ = ((meshSeleccionado.animPosZ[final] - meshSeleccionado.animPosZ[inicio]) * valor) + meshSeleccionado.animPosZ[inicio];
                float scale = ((meshSeleccionado.animTransforms[final].scale - meshSeleccionado.animTransforms[inicio].scale) * valor) + meshSeleccionado.animTransforms[inicio].scale;
                Vertex rot = ((meshSeleccionado.animRotations[final] - meshSeleccionado.animRotations[inicio]) * valor) + meshSeleccionado.animRotations[inicio];

                actualizacionContinua(meshSeleccionado, posX, posY, posZ, scale, rot);
            }
        }

        private void actualizacionContinua(Scene meshSeleccionado, float posX, float posY, float posZ, float scale, Vertex rot) //Funciona igual que el tick, pero solo para guardar valores, así no tenemos que esperar a la computadora para guardar valores
        {
            Console.WriteLine(meshes.IndexOf(meshSeleccionado));
            if (meshSeleccionado != null)
            {
                meshSeleccionado.transform.rotation = Matrix.Rotate(rot);
                meshSeleccionado.transform.scale = scale;
                meshSeleccionado.transform.traslation = new Vertex(posX, posY, posZ);
            }
        }
    }
}
