using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.Enumerations;

namespace PlanetStar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Texture planetTexture = new Texture();
        Texture starTexture = new Texture();
        float rotateStar = 0f;
        int rotatePlanetAroundStar = 0;
        private float speed = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            
            gl.LoadIdentity();

            gl.TexEnv(OpenGL.GL_TEXTURE_ENV, OpenGL.GL_TEXTURE_ENV_MODE, OpenGL.GL_REPLACE);
            gl.Disable(OpenGL.GL_LIGHTING);


            var star = gl.NewQuadric();

            gl.Translate(0f, 0f, -3.5f);
            gl.Rotate(-90.0f, 1.0f, 0.0f, 0.3f);

            if ((bool)checkBox.IsChecked)
            gl.Rotate(rotateStar, 0, 0, 1);
            
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, new float[] { 0f, 0f, 0f, 1f });
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, new float[] { 1.0f, 1.0f, 0.8f });
            starTexture.Bind(gl);

            gl.QuadricTexture(star, 1);
            gl.QuadricDrawStyle(star, OpenGL.GLU_FILL);
            gl.QuadricNormals(star, OpenGL.GLU_SMOOTH);
            gl.QuadricOrientation(star, 100020);
            gl.Sphere(star, 1, 200, 20);

            gl.LoadIdentity();
            gl.TexEnv(OpenGL.GL_TEXTURE_ENV, OpenGL.GL_TEXTURE_ENV_MODE, OpenGL.GL_MODULATE);
            gl.Translate(0f, 0f, -10f);
            if((bool)checkBox_Copy.IsChecked)
            gl.Rotate(rotatePlanetAroundStar, 1, 0, 0);
            gl.Translate(0f, 0f, -6f);
            if((bool)checkBox_Copy1.IsChecked)
            gl.Enable(OpenGL.GL_LIGHTING);
            else
            {
                gl.TexEnv(OpenGL.GL_TEXTURE_ENV, OpenGL.GL_TEXTURE_ENV_MODE, OpenGL.GL_REPLACE);
            }
            if ((bool)checkBox_Copy.IsChecked)
                gl.Rotate(rotateStar, 1, 0, 0);
            var planet = gl.NewQuadric();
            planetTexture.Bind(gl);
            gl.QuadricTexture(planet, 1);
            gl.QuadricDrawStyle(planet, OpenGL.GLU_FILL);
            gl.QuadricNormals(planet, OpenGL.GLU_SMOOTH);
            gl.QuadricOrientation(planet, 100020);
            gl.Sphere(planet, 0.5, 200, 20);
            float.TryParse(textBox.Text, out speed);

            gl.Flush();
            rotateStar += speed;
            rotatePlanetAroundStar +=(int) (3 * speed);
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            planetTexture.Create(gl, "planet.bmp");
            starTexture.Create(gl, "ukraine1.gif");
            gl.Ortho(0, Width, 0, Height, -1, -1);
            gl.ShadeModel(OpenGL.GL_SMOOTH);

            gl.Enable(OpenGL.GL_LIGHT0);

            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        private void Button_star_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox.IsChecked) checkBox.IsChecked = false;
            else checkBox.IsChecked = true;
        }

        private void Button_planet_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox_Copy.IsChecked) checkBox_Copy.IsChecked = false;
            else checkBox_Copy.IsChecked = true;
        }
    }
}
