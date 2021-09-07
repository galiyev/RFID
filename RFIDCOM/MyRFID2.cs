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
    [Guid("212D1429-D278-439F-8CCA-4968DA90122C"), ClassInterface(ClassInterfaceType.AutoDual),
     ComSourceInterfaces(typeof(IMyRFIDReader))]
    [ProgId("RFIDCOM.MyRFID2")]
    public class MyRFID2
    {
        public delegate void ReadingDelegate(string значения);
        
        public event ReadingDelegate TagReaded;

        public void Start()
        {
            MessageBox.Show("Started");
        }

        public void Stop()
        {
            MessageBox.Show("Stopped");
        }

        public void SendEvent()
        {
            TriggerReading();
            MessageBox.Show("Trigger");
        }

        public void Set(string IP, int port, int timeOut)
        {
            MessageBox.Show($"IP: {IP} port: {port} timeout:{timeOut}");
        }

        public void TriggerReading()
        {
            if (TagReaded != null)
            {
                TagReaded(DateTime.Now.Ticks.ToString());
            }
        }
    }
}
