using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RFIDHopeLand.Helper;
using RFIDReaderAPI;

namespace RFIDHopeLand
{
    public class RFIDWrapper
    {
        public static RFIDReaderAPI.RFID_Option RFID_OPTION = new RFIDReaderAPI.RFID_Option();
        public static RFIDReaderAPI.Param_Option PARAM_SET = new RFIDReaderAPI.Param_Option();
        public static RFIDReaderAPI.Test_Option TEST_OPTION = new RFIDReaderAPI.Test_Option();

        protected static string XMLFIENAME = "ReaderConfig.xml";

        public string ConnID = "";
        List<string> listUsbDevicePath = null;

        private int cb_ConnectType_SelectedIndex;

        private string tb_ConnParamText = string.Empty;
        
        public Dictionary<string, string> dic_UsbDevicePath_Name = new Dictionary<string, string>(); 

        public void ConnectToUSB()
        {
           listUsbDevicePath = RFIDReader.GetUsbHidDeviceList();

        }

        public void Connect()
        {
            bool isConnect = false;
            tb_ConnParamText = listUsbDevicePath[0];
            isConnect = RFIDReader.CreateUsbConn(listUsbDevicePath[0], null, new AsynchronousMessage(), null);


        }

        public void A()
        {
            tb_ConnParamText = MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/AddConnect", "UsbConnect");
            if (String.IsNullOrEmpty(tb_ConnParamText.Trim()))
            {
                tb_ConnParamText = "1:COM1:115200";
            }
        }

        public void AddConnect()
        {
            cb_ConnectType_SelectedIndex = 0;
        }

        public void AddConnect(Int32 connType)
            
        {
            InitCom();
            if (connType == 0)
            {
                cb_ConnectType_SelectedIndex = 1;
                cb_ConnectType_SelectedIndex = 0;
            }
            else if (connType == 1)
                cb_ConnectType_SelectedIndex = 1;
            else if (connType == 2)
                cb_ConnectType_SelectedIndex = 2;
            else if (connType == 3)
                cb_ConnectType_SelectedIndex = 3;
        }

        public void InitCom()
        {
            //try
            //{
            //    this.cb_ComNum.Items.Clear();
            //    foreach (string vPortName in SerialPort.GetPortNames())
            //    {
            //        String portName = Regex.Match(vPortName, @"COM[0-9]+").Value;
            //        this.cb_ComNum.Items.Add(portName);
            //    }
            //    this.cb_usbParam.Items.Clear();
            //    contextForm.dic_UsbDevicePath_Name.Clear();
            //    listUsbDevicePath = RFIDReader.GetUsbHidDeviceList();
            //    for (int i = 0; i < listUsbDevicePath.Count; i++)
            //    {
            //        string path = listUsbDevicePath[i];
            //        contextForm.dic_UsbDevicePath_Name.Add(path, "UHF READER " + (i + 1));
            //        string name = contextForm.dic_UsbDevicePath_Name[path].ToString();
            //        cb_usbParam.Items.Add(name);
            //    }
            //}
            //catch { }
        }

        public void InitReaderProporty()
        {
            //ConnID = dic_UsbDevicePath_Name[0];
            string strReaderProperty = RFID_OPTION.GetReaderProperty(listUsbDevicePath[0]);
            string[] str_array = strReaderProperty.Split('|');
        }
    }
}
