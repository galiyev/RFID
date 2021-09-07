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
    [Guid("212D2429-D278-139F-8CCA-4968DA90132C")]
    [ComSourceInterfaces(typeof(IMyRFIDReader))]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    //[ProgId("RFIDCOM.MyRFID2")]
    public class MyRFID2
    {
        public delegate void ReadingDelegate(object значения);
        
        public event ReadingDelegate TagReaded;

        public void Start()
        {
            MessageBox.Show("Started");
        }

        public void Stop()
        {
            MessageBox.Show("Stopped");
        }

     
        public void Set(string IP, int port, int timeOut)
        {
            MessageBox.Show($"IP: {IP} port: {port} timeout:{timeOut}");
        }
        
        public void SendEvent()
        {
            TriggerReading();
            MessageBox.Show("Trigger");
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
