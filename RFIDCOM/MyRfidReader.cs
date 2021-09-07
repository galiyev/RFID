using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace RFIDCOM
{
    [ComVisible(true)]
    [Guid("182D1429-D278-439F-8CCA-4968DA90124C"), ClassInterface(ClassInterfaceType.AutoDual),
     ComSourceInterfaces(typeof(IMyRFIDReader))]
    [ProgId("RFIDCOM.MyRfidReader2")]

    public class MyRfidReader2
    {
        [ComVisible(false)]

        public delegate void EventDelegate();

        [ComVisible(false)]

        public delegate void EventWithParameterDelegate(object value);

        [ComVisible(false)]

        public delegate void EventWithParametersDelegate(String событие, object value, object исключение);

        public System.IO.FileSystemWatcher РеальныйОбъект;

        dynamic AutoWrap;

        private SynchronizationContext Sc;

        public event EventWithParametersDelegate EventError;

        public Exception LastError;

        public event EventWithParameterDelegate TagReaded;

        private Object thisLock = new Object();

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
            if (TagReaded != null)
            {
                TagReaded(new object());
            }
        }

        private void SendWithParam(EventWithParameterDelegate evntWithParam, object value)
        {
            Task.Run(() =>
            {
                if (evntWithParam != null)
                {
                    lock (this.thisLock)
                    {
                        try
                        {
                            Sc.Send(()=>evntWithParam(AutoWrap.ОбернутьОбъект(value)));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                }
            });
        }
        
    }
}




