using System;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace RFIDCOM
{
    [ComVisible(true)]
    [Guid("581B3A54-55E0-4e07-8F37-5C20AAC47A25")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComSourceInterfaces(typeof(IRFIDReader))]
    public class RFIDReader
    {
        Timer timer;

        public RFIDReader()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TriggerEvent();
        }

        public void Start()
        {
            MessageBox.Show("RFID ОК");
        }

        public void Set(string param)
        {
            MessageBox.Show($"Set 2 {param}");
        }

        public delegate void TestEvent01_Delegate(string value);

        private event TestEvent01_Delegate TagReaded;

        public void TriggerEvent()
        {
            if (TagReaded != null)
            {
                TagReaded(DateTime.Now.Ticks.ToString());
            }
        }
    }
}