using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Maker.Serial;
using Microsoft.Maker.RemoteWiring;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Custom_Cortana_Command
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        UsbSerial connection;
        RemoteDevice arduino;
        UInt16 lastvalue;
        private const byte SERVO = 10;
        private byte[] angles = new byte[] { 0, 30, 60, 90, 120, 150, 180};
        private int direction;
        private bool fwd;
        private DispatcherTimer timer;
        

        public MainPage()
        {
            Debug.WriteLine("MainPage started");
            this.InitializeComponent();
            this.Unloaded += MainPage_Unloaded;
            Init();

        }

        private void Init()
        {
            connection = new UsbSerial("VID_2341", "PID_0043");
            arduino = new RemoteDevice(connection);
            connection.ConnectionEstablished += OnConnectionEstablished;
            connection.begin(9600, SerialConfig.SERIAL_8N1);
        }
        private void OnConnectionEstablished()
        {
            System.Diagnostics.Debug.WriteLine("Connected");
            arduino.pinMode(SERVO, PinMode.PWM);

            direction = 1;
            fwd = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        
        private void Timer_Tick(object sender, object e)
        {
            System.Diagnostics.Debug.WriteLine("Dir " + direction.ToString());
            if (fwd)
                direction++;
            else
                direction--;
            if (direction > 6)
            {
                fwd = false;
                direction = 6;
            }
            else
                if (direction < 0)
            {
                fwd = true;
                direction = 0;
            }

        }

        
        private void onButtonClickNinety(object sender, RoutedEventArgs e)
        {

        }

        private void onButtonClickOneEighty(object sender, RoutedEventArgs e)
        {

        }
        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            connection.end();
            arduino.Dispose();
        }
        
    }
    

}
