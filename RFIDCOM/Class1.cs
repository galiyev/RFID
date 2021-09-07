using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace RFIDCOM
{
    [ComVisible(true)]
    [Guid("76BBC602-9CBD-40b4-A210-CBB844E7AA70")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRFIDReader
    {
        [DispId(1)]
        void TagReaded(string value);

        [DispId(2)]
        void Start();
    }

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
