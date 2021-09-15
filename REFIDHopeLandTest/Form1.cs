using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFIDHopeLand;
using RFIDReaderAPI;

namespace REFIDHopeLandTest
{
    public partial class Form1 : Form
    {
        private RFIDWrapper wrapper;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IntPtr Handle = User32API.GetCurrentWindowHandle();
            RFIDReaderAPI.Interface.IAsynchronousMessage log = new AsynchronousMessage();
            //RFIDReader.CreateUsbConn()
            wrapper = new RFIDWrapper();
            wrapper.ConnectToUSB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wrapper.InitReaderProporty();
        }
    }
}
