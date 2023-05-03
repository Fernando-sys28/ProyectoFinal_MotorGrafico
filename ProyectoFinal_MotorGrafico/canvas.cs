using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Management.Instrumentation;
using static System.Windows.Forms.AxHost;

namespace ProyectoFinal_MotorGrafico
{
    public class Canvas
    {
        public Bitmap bitmap;
        public int Width, Height;
        public Byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;
        float viewport_size = 1;
        float projection_plane_z = 1;
        float[] depth_buffer;
        float[,] m;
        public float a { get; set; }

        public Camara camera = new Camara(new Vertex(-3, 1, 2), Matrix.RotY(0));
        public bool pintar { get; set; }
        public Canvas(Size size)
        {

            init(size.Width, size.Height);

        }

        public void init(int width, int height)
        {
            //ComputePlanes(120);
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;
            pintar = false;
            format = PixelFormat.Format32bppRgb;
            //bitmap= new Bitmap(width, height);
            Width = width;
            Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8;
            stride = width * pixelFormatSize;
            padding = (stride % 4);
            stride += padding == 0 ? 0 : 4 - padding;
            bits = new byte[stride * height];
            handle = GCHandle.Alloc(bitmap, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bitmap = new Bitmap(width, height, stride, format, bitPtr);
            g = Graphics.FromImage(bitmap);
            
            a = 120;
            depth_buffer = new float[Width * Height];
            for (int i = 0; i < Width * Height; i++)
            {
                depth_buffer[i] = float.MaxValue;
            }
        }

        public void Render(Scene[] scena)
        {
            RenderScene(camera, scena);
        }
        List<float> Interpolate(int i0, float d0, int i1, float d1)
        {
            if (i0 == i1)
            {
                return new List<float> { d0 };
            }

            List<float> values = new List<float>();
            float a = (d1 - d0) / (i1 - i0);
            float d = d0;
            for (var i = i0; i <= i1; i++)
            {
                values.Add(d);
                d += a;
            }

            return values;
        }
        public bool UpdateDepthBufferIfCloser(int x, int y, float inv_z)
        {

            x = Width / 2 + (int)x;
            y = Height / 2 - (int)y - 1;

            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return false;
            }

            int offset = x + Width * y;
            if (depth_buffer[offset] > inv_z)
            {
                return false;
            }

            depth_buffer[offset] = inv_z;
            return true;
        }

        public void ClearAll()
        {
            depth_buffer = new float[Width * Height];
        }
        public void setPixel(int x, int y, Color c)
        {
            long res = (int)((x * pixelFormatSize) + (y * stride));

            bits[res + 0] = c.B;// (byte)Blue;
            bits[res + 1] = c.G;// (byte)Green;
            bits[res + 2] = c.R;// (byte)Red;
            bits[res + 3] = c.A;// (byte)Alpha;
        }

        public void DrawPixel(int x, int y, Color color)
        {
            x = Width / 2 + x;
            y = Height / 2 - y - 1;

            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }
            setPixel(x,y,color);
        }
        public Matrix FOV()
        {
            float r = 1; // aspecto ratio
            float zNear = 1f;
            float zFar = 10000;
            float fov = (float)((Math.PI / 180) * (a));//aperture rads
            float tanHalfFOV = (float)Math.Tan(fov / 2);
            float zRange = zNear - zFar;
            float f = 1.0f / tanHalfFOV;
            float q = (zNear + zFar) / zRange;
            m = new float[,]{
                            {f*r, 0 , 0 , 0 },
                            {0 , f , 0 , 0 },
                            {0 , 0 , -q , 2*zNear*q },
                            {0 , 0 , 1 , 0 }
};
            return new Matrix(m);
        }

        public void ComputePlanes(float fov)
        {
            Vertex left, right, bottom, top;
            float aspect = 1f;
            float near = 0.1f;

            float tanFov = (float)Math.Tan(fov * 0.5f * Math.PI / 180f);
            float height = 2f * tanFov * near;
            float width = height * aspect;

            // Left plane
            float sx = 1f * (width / 2f);
            float sy = 0f;
            float sz = near;

            left = new Vertex(sx, sy, sz);
            left = left.Normalize();

            // Right plane
            sx = -width / 2f;
            sy = 0f;
            sz = near;
            right = new Vertex(sx, sy, sz);
            right = right.Normalize();

            // Bottom plane
            sx = 0f;
            sy = -1f * (height / 2f);
            sz = near;
            bottom = new Vertex(sx, sy, sz);
            bottom = bottom.Normalize();

            // Top plane
            sx = 0f;
            sy = height / 2f;
            sz = near;
            top = new Vertex(sx, sy, sz);
            top = top.Normalize();
            camera.clipping_planes.Add(new Plane(new Vertex(0, 0, 1), 0));   // near
            camera.clipping_planes.Add(new Plane(left, 0));  // left
            camera.clipping_planes.Add(new Plane(right, 0));  // right
            camera.clipping_planes.Add(new Plane(top, 0));  // top
            camera.clipping_planes.Add(new Plane(bottom, 0));  // bottom
        }
     
        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0;// (byte)oldBlue;
                        bits[x + 1] = 0;// (byte)oldGreen;
                        bits[x + 2] = 0;// (byte)oldRed;
                        bits[x + 3] = 0;// (byte)alpha;
                    }
                });
                bitmap.UnlockBits(bitmapData);
            }
        }
        private void Swap(ref Vertex a, ref Vertex b)
        {
            Vertex temp = a;
            a = b;
            b = temp;
        }

        void DrawLine(Vertex p0, Vertex p1, Color color)
        {
            var dx = p1.X - p0.X;
            var dy = p1.Y - p0.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // The line is horizontal-ish. Make sure it's left to right.
                if (dx < 0)
                {
                    Swap(ref p0, ref p1);
                }

                // Compute the Y values and draw.
                var ys = Interpolate((int)p0.X, p0.Y, (int)p1.X, p1.Y);
                for (var x = (int)p0.X; x <= p1.X; x++)
                {
                    DrawPixel(x, (int)ys[(x - (int)p0.X)], color);
                }
            }
            else
            {
                // The line is vertical-ish. Make sure it's bottom to top.
                if (dy < 0)
                {
                    Swap(ref p0, ref p1);
                }

                // Compute the X values and draw.
                var xs = Interpolate((int)p0.Y, p0.X, (int)p1.Y, p1.X);
                for (var y = (int)p0.Y; y <= p1.Y; y++)
                {
                    DrawPixel((int)xs[(y - (int)p0.Y)], y, color);
                }
            }
        }

        public static int[] SortedVertexIndexes(int[] vertex_indexes, List<Vertex> projected)
        {
            int[] indexes = { 0, 1, 2 };

            if (projected[vertex_indexes[indexes[1]]].Y < projected[vertex_indexes[indexes[0]]].Y)
            {
                int swap = indexes[0];
                indexes[0] = indexes[1];
                indexes[1] = swap;
            }

            if (projected[vertex_indexes[indexes[2]]].Y < projected[vertex_indexes[indexes[0]]].Y)
            {
                int swap = indexes[0];
                indexes[0] = indexes[2];
                indexes[2] = swap;
            }

            if (projected[vertex_indexes[indexes[2]]].Y < projected[vertex_indexes[indexes[1]]].Y)
            {
                int swap = indexes[1];
                indexes[1] = indexes[2];
                indexes[2] = swap;
            }

            return indexes;
        }

        public void DrawWireFrameTriangle(Vertex p0, Vertex p1, Vertex p2, Color color)
        {
            DrawLine(p0, p1, color); 
            DrawLine(p1, p2, color);
            DrawLine(p0, p2, color);
        }

        

        public void FillTriangle(Vertex p0, Vertex p1, Vertex p2, Color c)
        {
            List<float> x_left;
            List<float> x_right;

            if (p1.Y < p0.Y)
            {
                Vertex p = p0;
                p0 = p1;
                p1 = p;
            }
            if (p2.Y < p0.Y)
            {
                Vertex p = p0;
                p0 = p2;
                p2 = p;
            }
            if (p2.Y < p1.Y)
            {
                Vertex p = p2;
                p2 = p1;
                p1 = p;
            }

            List<float> x01 = Interpolate((int)p0.Y, p0.X, (int)p1.Y, p1.X);
            List<float> x12 = Interpolate((int)p1.Y, p1.X, (int)p2.Y, p2.X);
            List<float> x02 = Interpolate((int)p0.Y, p0.X, (int)p2.Y, p2.X);

            x01.RemoveAt(x01.Count - 1);
            List<float> x012 = new List<float>();
            x012.AddRange(x01);
            x012.AddRange(x12);

            int m = x02.Count / 2;
            if (m >= 0 && m < x02.Count && m < x012.Count)
            {
                if (x02[m] < x012[m])
                {
                    x_left = x02;
                    x_right = x012;
                }
                else
                {
                    x_left = x012;
                    x_right = x02;
                }

                for (var y = (int)p0.Y; y < p2.Y; y++)
                {
                    int index = y - (int)p0.Y;
                    if (index >= 0 && index < x_left.Count && index < x_right.Count)
                    {
                        for (var x = x_left[index]; x < x_right[index]; x++)
                        {
                            DrawPixel((int)x, y, c);
                        }
                    }
                }
            }

            
        }

        public void DrawShadedTriangle(Vertex a, Vertex b, Vertex d, Color c)
        {
            Point p0 = new Point(), p1 = new Point(), p2 = new Point();
            p0.X = (int)a.X;
            p0.Y = (int)a.Y;
            p1.X = (int)b.X;
            p1.Y = (int)b.Y;
            p2.X = (int)d.X;
            p2.Y = (int)d.Y;

            List<float> x_left;
            List<float> x_right;
            List<float> z_left;
            List<float> z_right;

            if (p1.Y < p0.Y)
            {
                Point p = p0;
                p0 = p1;
                p1 = p;
            }
            if (p2.Y < p0.Y)
            {
                Point p = p0;
                p0 = p2;
                p2 = p;
            }
            if (p2.Y < p1.Y)
            {
                Point p = p2;
                p2 = p1;
                p1 = p;
            }

            List<float> x01 = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
            List<float> z01 = Interpolate(p0.Y, 1 / a.Z, p1.Y, 1 / b.Z);

            List<float> x12 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            List<float> z12 = Interpolate(p1.Y, 1 / b.Z, p2.Y, 1 / d.Z);

            List<float> x02 = Interpolate(p0.Y, p0.X, p2.Y, p2.X);
            List<float> z02 = Interpolate(p0.Y, 1/a.Z, p2.Y, 1 / d.Z);

            x01.RemoveAt(x01.Count - 1);
            List<float> x012 = new List<float>();
            x012.AddRange(x01);
            x012.AddRange(x12);

            z01.RemoveAt(z01.Count - 1);
            List<float> z012 = new List<float>();
            z012.AddRange(z01);
            z012.AddRange(z12);

            int m = x02.Count / 2;

            if (x02[m] < x012[m])
            {
                x_left = x02;
                z_left = z02;
                x_right = x012;
                z_right = z012;
            }
            else
            {
                x_left = x012;
                z_left = z012;
                x_right = x02;
                z_right = z02;
            }


            for (int y = p0.Y; y < p2.Y; y++)
            {
                float x_l = x_left[y - p0.Y];
                float x_r = x_right[y - p0.Y];

                List<float> z_segment = Interpolate((int)x_l, z_left[y - p0.Y], (int)x_r, z_right[y - p0.Y]);

                for (float x = x_l; x < x_r; x++)
                {

                    if (x >= x_l && x <= x_r)
                    {
                        float z = z_segment[(int)Clamp(x - x_l, 0, z_segment.Count - 1)];

                        if (UpdateDepthBufferIfCloser((int)x, y, z))
                        {
                            DrawPixel((int)x, y, c);
                        }
                    }
                }

            }
            DrawWireFrameTriangle(a,b,d,Color.White);
            
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }
        public Vertex ComputeTriangleNormal(Vertex v0, Vertex v1, Vertex v2)
        {
            Vertex v0v1 = v1 -  v0;
            Vertex v0v2 = v2 -  v0;
            return Vertex.Cross(v0v1, v0v2);
        }

        // Converts 2D viewport coordinates to 2D canvas coordinates.
        Vertex ViewportToCanvas(Vertex p2d)
        {
            float vW = (float)bitmap.Width / bitmap.Height;      
            return new Vertex((p2d.X * bitmap.Width / vW), (p2d.Y * bitmap.Height / viewport_size), 0);
        }

        public Vertex ProjectVertex(Vertex v)
        {
            return ViewportToCanvas(new Vertex(v.X * projection_plane_z /v.Z, v.Y * projection_plane_z/ v.Z, 0));
        }

        public void RenderTriangle(triangulo triangle, Vertex[] vertices, List<Vertex> projected)
        {
            int[] indexes = SortedVertexIndexes(triangle.indexes, projected);
            int i0 = indexes[0];
            int i1 = indexes[1];
            int i2 = indexes[2];

            Vertex v0 = vertices[triangle.indexes[i0]];
            Vertex v1 = vertices[triangle.indexes[i1]];
            Vertex v2 = vertices[triangle.indexes[i2]];

            //Compute triangle normal.Use the unsorted vertices, otherwise the winding of the points may change.
            Vertex normal = ComputeTriangleNormal(vertices[triangle.indexes[0]], vertices[triangle.indexes[1]], vertices[triangle.indexes[2]]);
            Vertex vertex_to_camera = camera.position - (vertices[triangle.indexes[0]]);
 
            if (vertex_to_camera * normal <= 0)
            {
                return;
            }
            DrawShadedTriangle(projected[triangle.indexes[i0]], projected[triangle.indexes[i1]], projected[triangle.indexes[i2]], Color.Blue);
        }


        // Clips a triangle against a plane. Adds output to triangles and vertices.
        private List<triangulo> ClipTriangle(triangulo triangle, Plane plane, List<triangulo> triangles, List<Vertex> vertices)
        {
            Vertex v0 = vertices[triangle.a];
            Vertex v1 = vertices[triangle.b];
            Vertex v2 = vertices[triangle.c];

            // vertices in front of the camera
            bool in0 = ((plane.normal * v0) + plane.Distance) > 0;
            bool in1 = ((plane.normal * v1) + plane.Distance) > 0;
            bool in2 = ((plane.normal * v2) + plane.Distance) > 0;

            int in_count = (in0 ? 1 : 0) + (in1 ? 1 : 0) + (in2 ? 1 : 0);

            if (in_count == 0)
            {
                //Console.WriteLine("count zero");
                // Nothing to do - the triangle is fully clipped out.
            }
            else if (in_count == 3)
            {
                // The triangle is fully in front of the plane.
                triangles.Add(triangle);
            }
            else if (in_count == 1)// one positive  
            {
                //Console.WriteLine("count one");
                // The triangle has one vertex in. Output is one clipped triangle.
            }
            else if (in_count == 2)// one negative
            {
                //Console.WriteLine("count two");
                // The triangle has two vertices in. Output is two clipped triangles.
            }

            return triangles;
        }

        public Mesh TransformAndClip(Plane[] clipping_planes, Mesh model, float scale, Matrix transform)
        {
            // Transform the bounding sphere, and attempt early discard.
            Vertex center = transform * model.bounds_center;
            float radius = model.bounds_radius * scale;
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                float distance = (clipping_planes[p].normal * center) + clipping_planes[p].Distance;
                if (distance < -radius)
                {
                    return null;
                }
            }

            // Apply modelview transform.
            List<Vertex> vertices = new List<Vertex>();
            for (int i = 0; i < model.vertices.Length; i++)
            {
                vertices.Add(transform * model.vertices[i]);
            }

            // Clip the entire model against each successive plane.
            List<triangulo> triangles = new List<triangulo>(model.triangulos);
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                List<triangulo> new_triangles = new List<triangulo>();
                for (int i = 0; i < triangles.Count; i++)
                {
                    new_triangles = (ClipTriangle(triangles[i], clipping_planes[p], new_triangles, vertices));
                }
                triangles.AddRange(new_triangles);
            }

            return new Mesh(vertices.ToArray(), triangles.ToArray(), center, model.bounds_radius);
        }

        public void RenderModel(Mesh model)
        {
            // we would have to test here the best fit to
            // translate this to the GPU for massive parallelism
            List<Vertex> projected = new List<Vertex>();

            for (int i = 0; i < model.vertices.Length; i++)
            {
                projected.Add(ProjectVertex(model.vertices[i]));

            }

            for (int i = 0; i < model.triangulos.Length; i++)
            {
                RenderTriangle(model.triangulos[i],model.vertices, projected);
            }
        }

        public void RenderScene(Camara camera, Scene[] instances)
        {
            Matrix cameraMatrix;
            Matrix transform;
            Mesh clipped;

            // if we want to use FOV here we also need to add the FOV matrix of the camera
            cameraMatrix = (camera.orientation.Transposed()) * Matrix.MakeTranslationMatrix(-camera.position);
            for (int i = 0; i < instances.Length; i++)
            {
                transform = (cameraMatrix * instances[i].transform.transform);
                clipped = TransformAndClip(camera.clipping_planes.ToArray(), instances[i].mesh, instances[i].transform.scale, transform);
                if (clipped != null)
                {
                    RenderModel(clipped);          
                }
            }
        }

    }
}
