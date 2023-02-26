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

namespace Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rect desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

        //temporizadores
        System.Windows.Forms.Timer timer_ping = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer_download = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer_upload = new System.Windows.Forms.Timer();
        
        //intervalo para los timers
        int interval_timer = 1000;
        Random x1 = new Random(50);
        Random x2 = new Random(99);
        Random x3 = new Random(7);

        public void Init()
        {
            //seteando intervalos
            timer_ping.Interval = interval_timer;
            timer_download.Interval = interval_timer;
            timer_upload.Interval = interval_timer;

            //Creando eventos
            timer_ping.Tick += Timer_ping_Tick;
            timer_upload.Tick += Timer_upload_Tick;
            timer_download.Tick += Timer_download_Tick;

            
            //Inicializando objetos
            timer_ping.Start();
            timer_upload.Start();
            timer_download.Start();
        }

        private void Timer_ping_Tick(object sender, EventArgs e)
        {
            value_ping.Content=x1.Next(9999);
        }
        private void Timer_upload_Tick(object sender, EventArgs e)
        {
            value_subida.Content = x2.Next(9999);
        }
        private void Timer_download_Tick(object sender, EventArgs e)
        {
            value_bajada.Content = x3.Next(9999);
        }


        public MainWindow()
        {

            InitializeComponent();
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
            Init();
        }
    }
}
