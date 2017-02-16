using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SharpGL;
using SharpGL.SceneGraph;

namespace WPFOpenGl
{
    /// <summary>
    ///    Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Triangle> triangles = new List<Triangle>();
        private OpenGL gl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();

            foreach (var tr in triangles)
            {
                DrawTriangle(gl, tr);
            }

            gl.Flush();

        }

        private void DrawTriangle(OpenGL gl, Triangle tr)
        {
            gl.Begin(OpenGL.GL_TRIANGLES);


            gl.Color(tr.Color.ScR, tr.Color.ScG, tr.Color.ScB);

            double minY = tr.Points[1];
            double maxX = tr.Points[0];
            double minX = tr.Points[0];

            for (int i = 0; i < 5; i += 2)
            {
                gl.Vertex(tr.Points[i], tr.Points[i + 1]);
                if (tr.Points[i + 1] < minY)
                {
                    minY = tr.Points[i + 1];
                }
                if (tr.Points[i] < minX)
                {
                    minX = tr.Points[i];
                }
                if (tr.Points[i] > maxX)
                {
                    maxX = tr.Points[i];
                }
            }

            gl.End();
            double textPosY;
            if (minY < 0)
            {
                textPosY = (1 + minY)*100*Height/2/100;
            }
            else
            {
                textPosY = minY*100*Height/2/100 + Height/2.0;
            }
            double textPosX;
            if (minX < 0)
            {
                textPosX = (1 + minX)*100*Width/2/100;
            }
            else
            {
                textPosX = minX*100*Width/2/100 + Width/2.0;
            }
            gl.DrawText((int) (textPosX), (int) (textPosY), 1, 1, 1, "arial", 14, tr.Color.ToString());
        }


        private void OpenGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            args.OpenGL.Ortho(0, Width, 0, Height, -1.0, 1.0);
        }

        private void OpenGLControl_Resized(object sender, OpenGLEventArgs args)
        {
        }

        private double GetPosition(Random random)
        {
            return random.NextDouble()*(random.NextDouble() > 0.5 ? 1 : -1);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            var r = Convert.ToSingle(rand.NextDouble());
            var g = Convert.ToSingle(rand.NextDouble());
            var b = Convert.ToSingle(rand.NextDouble());

            var tr = new Triangle(GetPosition(rand), GetPosition(rand), GetPosition(rand), GetPosition(rand),
                GetPosition(rand), GetPosition(rand), r, g, b);

            triangles.Add(tr);
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            int n = triangles.Count;
            if (n != 0)
            {
                triangles.Remove(triangles.Last());
            }
        }

    }

    class Triangle
    {
        private Color color;
        private double[] points;

        Triangle() { }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3, float r, float g, float b)
        {
            color = new Color();
            color.ScR = r;
            color.ScG = g;
            color.ScB = b;

            points = new double[6];
            points[0] = x1;
            points[1] = y1;
            points[2] = x2;
            points[3] = y2;
            points[4] = x3;
            points[5] = y3;
        }

        public double[] Points
        {
            get { return points; }
        }

        public Color Color
        {
            get { return color; }
        }
    }


}