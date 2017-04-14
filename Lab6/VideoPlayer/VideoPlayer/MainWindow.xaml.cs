
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace VideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
            InitializeComponent();
            myMedia.Volume = 100;
            myMedia.Play();
            close.Style =(Style)Application.Current.Resources["buttonStyle1"];
            close.FontSize = 28;
        }
        void mediaPlay(Object sender, EventArgs e)
        {
            myMedia.Play();

        }

        void mediaPause(Object sender, EventArgs e)
        {
            myMedia.Pause();
            
        }

        void mediaMute(Object sender, EventArgs e)
        {
            if (myMedia.Volume == 100)
            {
                myMedia.Volume = 0;
                mute.Content = "Cлухати";
            }
            else
            {
                myMedia.Volume = 100;
                mute.Content = "Заглушити";
            }
        }

        void  mediaReplay(Object sender, EventArgs e)
        {
            myMedia.Stop();
            myMedia.Play();
        }

        private void mediaOpen(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd;
            ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "*.*";
            ofd.Filter = "media (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                myMedia.Source = new Uri(ofd.FileName);
                myMedia.Play();
            }
        }
    
        

        void mediaStyle1(Object sender, RoutedEventArgs e)
        {            
            play.Style = (Style)Application.Current.Resources["buttonStyle1"];
            pause.Style = (Style)Application.Current.Resources["buttonStyle1"];
            replay.Style = (Style)Application.Current.Resources["buttonStyle1"];
            mute.Style = (Style)Application.Current.Resources["buttonStyle1"];
            style1.Style = (Style)Application.Current.Resources["buttonStyle1"];
            style2.Style = (Style)Application.Current.Resources["buttonStyle1"];
            style3.Style = (Style)Application.Current.Resources["buttonStyle1"];
            window.Style = (Style)Application.Current.Resources["windowStyle1"];
        }

        void mediaStyle2(Object sender, RoutedEventArgs e)
        {
            play.Style = (Style)Application.Current.Resources["buttonStyle2"];
            pause.Style = (Style)Application.Current.Resources["buttonStyle2"];
            replay.Style = (Style)Application.Current.Resources["buttonStyle2"];
            mute.Style = (Style)Application.Current.Resources["buttonStyle2"];
            style1.Style = (Style)Application.Current.Resources["buttonStyle2"];
            style2.Style = (Style)Application.Current.Resources["buttonStyle2"];
            style3.Style = (Style)Application.Current.Resources["buttonStyle2"];
            window.Style = (Style)Application.Current.Resources["windowStyle2"];
        }

        void mediaStyle3(Object sender, RoutedEventArgs e)
        {
            play.Style = (Style)Application.Current.Resources["buttonStyle3"];
            pause.Style = (Style)Application.Current.Resources["buttonStyle3"];
            replay.Style = (Style)Application.Current.Resources["buttonStyle3"];
            mute.Style = (Style)Application.Current.Resources["buttonStyle3"];
            style1.Style = (Style)Application.Current.Resources["buttonStyle3"];
            style2.Style = (Style)Application.Current.Resources["buttonStyle3"];
            style3.Style = (Style)Application.Current.Resources["buttonStyle3"];
            window.Style = (Style)Application.Current.Resources["windowStyle3"];
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
