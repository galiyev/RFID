using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDCOM
{
    [ComVisible(true)]
    [Guid("182D1429-D278-439F-8CCA-4968DA90124C"), ClassInterface(ClassInterfaceType.AutoDual), ComSourceInterfaces(typeof(IMyRFIDReader))]
    [ProgId("RFIDCOM.MyRfidReader2")]

    public class MyRfidReader2 
    {
        public delegate void ReadingDelegate();
        public event ReadingDelegate TagReading;

        private Timer _timer = new Timer()
        {
            Enabled = false,
            Interval = 1000
        };

        public string Set(string IP, int port, int timeOut)
        {
            return "OK";
        }

        public void Start()
        {
            MessageBox.Show("Started555");
            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
            _timer.Enabled = true;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            NewTagEvent();
        }

        public void Stop()
        {
            //MessageBox.Show("Stopped");
        }

        public void NewTagEvent()
        {
            if (TagReading != null)
            {
                TagReading();
            }
        }
    }


}
