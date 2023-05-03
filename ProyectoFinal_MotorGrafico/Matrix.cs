using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MotorGrafico
{

    public class Matrix
    {
        public float[,] data;

        public float this[int x, int y]
        {
            get { return data[x, y]; }
            set { data[x, y] = value; }
        }

        public Matrix(float[,] data)
        {
            this.data = data;
        }

        public static Matrix Identity = new Matrix(new float[,] {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}});

        public static Matrix MakeScalingMatrix(float scale)
        {
            return new Matrix(new float[,] {
                {scale,     0,     0,  0},
                {    0, scale,     0,  0},
                {    0,     0, scale,  0},
                {    0,     0,     0,  1}});
        }
        public static Matrix operator *(Matrix m, float f)
        {
            Matrix result = new Matrix(new float[4, 4]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = m[i, j] * f;
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix m, Matrix r)
        {
            Matrix res = new Matrix(new float[4, 4]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = m[i, j] + r[i, j];
                }
            }
            return res;
        }
        public static Matrix operator -(Matrix m, Matrix r)
        {
            Matrix res = new Matrix(new float[4, 4]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = m[i, j] - r[i, j];
                }
            }
            return res;
        }

        public static Matrix operator /(Matrix m, float f)
        {
            Matrix result = new Matrix(new float[4, 4]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = m[i, j] / f;
                }
            }
            return result;
        }
        public static Vertex operator *(Matrix m, Vertex v) // 3D vector
        {
            Vertex pts;

            pts = new Vertex(0f, 0f, 0f);

            pts.X = (m[0, 0] * v.X) + (m[0, 1] * v.Y) + (m[0, 2] * v.Z) + (m[0, 3] * v.W);
            pts.Y = (m[1, 0] * v.X) + (m[1, 1] * v.Y) + (m[1, 2] * v.Z) + (m[1, 3] * v.W);
            pts.Z = (m[2, 0] * v.X) + (m[2, 1] * v.Y) + (m[2, 2] * v.Z) + (m[2, 3] * v.W);
            pts.W = (m[3, 0] * v.X) + (m[3, 1] * v.Y) + (m[3, 2] * v.Z) + (m[3, 3] * v.W);

            return pts;
        }


        public static Matrix RotZ(float angle)
        {
            float cos = (float)Math.Cos(angle * Math.PI / 180.0);
            float sin = (float)Math.Sin(angle * Math.PI / 180.0);

            return new Matrix(new float[,]{
                {cos,  -sin ,  0  , 0},
                {sin,   cos ,  0  , 0},
                {0,       0 ,  1  , 0},
                {0,       0 ,  0  , 1}
            });
        }

        public static Matrix RotX(float angle)
        {
            float cos = (float)Math.Cos(angle * Math.PI / 180.0);
            float sin = (float)Math.Sin(angle * Math.PI / 180.0);

            return new Matrix(new float[,]{
                {1,     0 ,  0  , 0},
                {0,   cos ,-sin , 0},
                {0,   sin , cos , 0},
                {0,     0 ,  0  , 1}
            });
        }

        public static Matrix RotY(float angle)
        {
            float cos = (float)Math.Cos(angle * Math.PI / 180.0);
            float sin = (float)Math.Sin(angle * Math.PI / 180.0);

            return new Matrix(new float[,] {
                { cos,   0, -sin,   0},
                {   0,   1,    0,   0},
                { sin,   0,  cos,   0},
                {   0,   0,    0,   1}});
        }

        public static Matrix operator *(Matrix m, Matrix r)//CAMBIAR OPERACIÓN DE MULTIPLICACIÓN
        {
            Matrix res = new Matrix(new float[4, 4]);
            //res[i, j] = m[i, 0] * r[0, j] + m[i, 1] * r[1, j] + m[i, 2] * r[2, j] + m[i, 3] * r[3, j];
            res[0, 0] = m[0, 0] * r[0, 0] + m[0, 1] * r[1, 0] + m[0, 2] * r[2, 0] + m[0, 3] * r[3, 0];
            res[0, 1] = m[0, 0] * r[0, 1] + m[0, 1] * r[1, 1] + m[0, 2] * r[2, 1] + m[0, 3] * r[3, 1];
            res[0, 2] = m[0, 0] * r[0, 2] + m[0, 1] * r[1, 2] + m[0, 2] * r[2, 2] + m[0, 3] * r[3, 2];
            res[0, 3] = m[0, 0] * r[0, 3] + m[0, 1] * r[1, 3] + m[0, 2] * r[2, 3] + m[0, 3] * r[3, 3];

            res[1, 0] = m[1, 0] * r[0, 0] + m[1, 1] * r[1, 0] + m[1, 2] * r[2, 0] + m[1, 3] * r[3, 0];
            res[1, 1] = m[1, 0] * r[0, 1] + m[1, 1] * r[1, 1] + m[1, 2] * r[2, 1] + m[1, 3] * r[3, 1];
            res[1, 2] = m[1, 0] * r[0, 2] + m[1, 1] * r[1, 2] + m[1, 2] * r[2, 2] + m[1, 3] * r[3, 2];
            res[1, 3] = m[1, 0] * r[0, 3] + m[1, 1] * r[1, 3] + m[1, 2] * r[2, 3] + m[1, 3] * r[3, 3];

            res[2, 0] = m[2, 0] * r[0, 0] + m[2, 1] * r[1, 0] + m[2, 2] * r[2, 0] + m[2, 3] * r[3, 0];
            res[2, 1] = m[2, 0] * r[0, 1] + m[2, 1] * r[1, 1] + m[2, 2] * r[2, 1] + m[2, 3] * r[3, 1];
            res[2, 2] = m[2, 0] * r[0, 2] + m[2, 1] * r[1, 2] + m[2, 2] * r[2, 2] + m[2, 3] * r[3, 2];
            res[2, 3] = m[2, 0] * r[0, 3] + m[2, 1] * r[1, 3] + m[2, 2] * r[2, 3] + m[2, 3] * r[3, 3];

            res[3, 0] = m[3, 0] * r[0, 0] + m[3, 1] * r[1, 0] + m[3, 2] * r[2, 0] + m[3, 3] * r[3, 0];
            res[3, 1] = m[3, 0] * r[0, 1] + m[3, 1] * r[1, 1] + m[3, 2] * r[2, 1] + m[3, 3] * r[3, 1];
            res[3, 2] = m[3, 0] * r[0, 2] + m[3, 1] * r[1, 2] + m[3, 2] * r[2, 2] + m[3, 3] * r[3, 2];
            res[3, 3] = m[3, 0] * r[0, 3] + m[3, 1] * r[1, 3] + m[3, 2] * r[2, 3] + m[3, 3] * r[3, 3];

            return res;
        }

        public static Matrix Rotate(Vertex v)
        {
            Matrix x, y, z;

            x = RotX(v.X);//MATRIZ DE ROTACION EN X
            y = RotY(v.Y);//MATRIZ DE ROTACION EN Y
            z = RotZ(v.Z);//MATRIZ DE ROTACION EN Z

            return x * y * z;
        }


        public static Matrix MakeTranslationMatrix(Vertex translation)
        {
            return new Matrix(new float[,] {
                {1,  0,  0,  translation.X},
                {0,  1,  0,  translation.Y},
                {0,  0,  1,  translation.Z},
                {0,  0,  0,              1}});
        }

        public Matrix Transposed()
        {
            Matrix result = new Matrix(new float[4, 4]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = data[j, i];
                }
            }
            return result;
        }

    }
}
