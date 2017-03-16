using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph;

namespace WPFOpenGl
{
    /// <summary>
    ///    Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            triangle = new Triangle(-0.1, -0.1, 0, 0.1, 0.1, 0, color.R, color.G, color.B);
            textBoxA.Text = "1,0";
            textBoxB.Text = "0,0";
            
        }

        private Color color = Colors.Blue;//колір трикутника
        private Triangle triangle; // трикутник
        private OpenGL gl; 
        private double a = 1; //коефіцієнти
        private double b = 0;
        private double x = 0.0; //
        private double y = 0.0;
        private double z = 0.0;
        private double Angle = 0; //кут повороту
        private double move_x = 0.0;// параметр переміщення
        private bool Left = true; // рух по ох
        private bool Rotate = false;//чи повертати
        private bool Move = true; // чи переміщувати
        private float speed = 0.02f; //швидкість руху
        
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(1, 1, 1, 1);//фон

            gl.LoadIdentity();

            gl.MatrixMode(MatrixMode.Modelview);
            gl.LoadIdentity();

            gl.PushMatrix();
            
            x = -(triangle.Points[0] + triangle.Points[2] + triangle.Points[4]) / 3.0;
            y = -(triangle.Points[1] + triangle.Points[3] + triangle.Points[5]) / 3.0;
            double move_y = a * move_x + b;
            gl.Translate(move_x, move_y, z);//множення на матрицю переміщення
            if (Move)//рух по ох
            {
                if (Left)
                    move_x += speed;
                else
                    move_x -= speed;
                if (a >= 0)
                {
                    if (move_x + Math.Max(Math.Max(triangle.Points[0], triangle.Points[2]), triangle.Points[4]) > 1 ||
                        move_y + Math.Max(Math.Max(triangle.Points[5], triangle.Points[1]), triangle.Points[3]) > 1)
                        Left = false;
                    else if (move_x + Math.Min(Math.Min(triangle.Points[0], triangle.Points[2]), triangle.Points[4]) < -1 ||
                             move_y + Math.Min(Math.Min(triangle.Points[5], triangle.Points[1]), triangle.Points[3]) < -1)
                        Left = true;
                }
                else
                {
                    if (move_x + Math.Max(Math.Max(triangle.Points[0], triangle.Points[2]), triangle.Points[4]) > 1 ||
                        move_y + Math.Max(Math.Max(triangle.Points[5], triangle.Points[1]), triangle.Points[3]) > 1)
                        Left = true;
                    else if (move_x + Math.Min(Math.Min(triangle.Points[0], triangle.Points[2]), triangle.Points[4]) < -1 ||
                             move_y + Math.Min(Math.Min(triangle.Points[5], triangle.Points[1]), triangle.Points[3]) < -1)
                        Left = false;
                }
            }
            // поворот навколо центру фігури(переміщення в центр осей, поворот, переміщення назад
            gl.Translate(-x, -y, -z);
            gl.Rotate(Angle, 0, 0, 1);
            gl.Translate(x, y, z);

            if (Rotate)
                Angle += 3;//збільшення кута
            DrawTriangle(gl, triangle);

            gl.PopMatrix();

            gl.Flush();
        }

        private void DrawTriangle(OpenGL gl, Triangle tr)
        {
            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(tr.Color.ScR, tr.Color.ScG, tr.Color.ScB);

            for (int i = 0; i < 5; i += 2)
            {
                gl.Vertex(tr.Points[i], tr.Points[i + 1]);
            }

            gl.End();

        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            gl = args.OpenGL;
            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Ortho(0, Width, 0, Height, -1, 1);
        }

        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGLControl_OpenGLDraw(sender, args);
        }

        private void textBoxA_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //користувач змінив параметри
            if (!Double.TryParse(textBoxA.Text, out a))
                a = 1.0;
           if (!Double.TryParse(textBoxB.Text, out b))
                b = 0.0;
            if (a > 2) a = 2;
            if (a < -2) a = -2;
            move_x = 0;

        }

        private void checkBox_Check(object sender, RoutedEventArgs e)
        {
            //користувач змінив режим(рух, повертання)
            Rotate = checkBoxRotate.IsChecked !=null && checkBoxRotate.IsChecked == true;
            Move = checkBoxMove.IsChecked !=null && checkBoxMove.IsChecked == true;
        }
    }

    class Triangle
    {
        private Color color;
        private double[] points;
        

        public Triangle(double x1, double y1, double x2, double y2, 
            double x3, double y3, float r=1, float g=0.5f, float b=0.7f)
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