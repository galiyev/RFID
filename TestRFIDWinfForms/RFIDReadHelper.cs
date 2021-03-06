using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Resources;
using System.Reflection;
using ReaderB;
using System.IO.Ports;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using RFIDLib;
using Timer = System.Threading.Timer;

namespace TestRFIDWinfForms
{
    public class RFIDReadHelper
    {
        private RFIDDic _rfidDic = new RFIDDic();

        private static string IPAddr = "192.168.0.192";
        private static int port = 6002;
        private static string fComAdrStr = "FF";
        private string Edit_WordPtr;

        #region Китайские переменные

        private bool fAppClosed; //在测试模式下响应关闭应用程序
        private byte fComAdr = 0xff; //当前操作的ComAdr
        private int ferrorcode;
        private byte fBaud;
        private double fdminfre;
        private double fdmaxfre;
        private byte Maskadr;
        private byte MaskLen;
        private byte MaskFlag;
        private int fCmdRet = 30; //所有执行指令的返回值
        private int fOpenComIndex; //打开的串口索引号
        private bool fIsInventoryScan;
        private bool fisinventoryscan_6B;
        private byte[] fOperEPC = new byte[36];
        private byte[] fPassWord = new byte[4];
        private byte[] fOperID_6B = new byte[8];
        private int CardNum1 = 0;
        ArrayList list = new ArrayList();
        private bool fTimer_6B_ReadWrite;
        private string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）
        private int frmcomportindex;
        private bool ComOpen = false;
        private bool breakflag = false;
        private double x_z;
        private double y_f;
        //以下TCPIP配置所需变量
        public string fRecvUDPstring = "";
        public string RemostIP = "";

        #endregion

        private int _port;
        private string _IPAddr;


        private Timer _inventoryTimer;

        public RFIDDic RfidDic
        {
            get => _rfidDic;
            set => _rfidDic = value;
        }

        public void OpenPort(int port, string IPAddr)
        {
            _port = port;
            _IPAddr = IPAddr;

            var fComAdr = Convert.ToByte(fComAdrStr, 16); // $FF;
            var openresult = StaticClassReaderB.OpenNetPort(_port, _IPAddr, ref fComAdr, ref frmcomportindex);
            if (openresult == 0)
            {
                GetReaderInfo();
            }
        }

        private void Inventory()
        {
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            fIsInventoryScan = true;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            //if (CheckBox_TID.Checked)
            if (true)
            {
                //AdrTID = Convert.ToByte(textBox4.Text, 16);
                //LenTID = Convert.ToByte(textBox5.Text, 16);
                AdrTID = Convert.ToByte("02", 16);
                LenTID = Convert.ToByte("04", 16);
                TIDFlag = 1;
            }
            else
            {
                AdrTID = 0;
                LenTID = 0;
                TIDFlag = 0;
            }
            ListViewItem aListItem = new ListViewItem();
            fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                fInventory_EPC_List = temps;            //存贮记录
                m = 0;
                /*   while (ListView1_EPC.Items.Count < CardNum)
                  {
                      aListItem = ListView1_EPC.Items.Add((ListView1_EPC.Items.Count + 1).ToString());
                      aListItem.SubItems.Add("");
                      aListItem.SubItems.Add("");
                      aListItem.SubItems.Add("");
                 * 
                  }*/
                if (CardNum == 0)
                {
                    fIsInventoryScan = false;
                    return;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    if (sEPC.Length != EPClen * 2)
                        return;
                    isonlistview = false;
                    foreach (var key in RfidDic.Keys)
                    {
                        if (sEPC == RfidDic[key].Tag)
                        {
                            isonlistview = true;
                        }
                    }
                    if (!isonlistview)
                    {
                       RfidDic.Add(sEPC, new RFIDTag(sEPC));
                    }
                }
            }
            else if (((fCmdRet == 0x30) || (fCmdRet == 0x37) || (fCmdRet == 0x35)))
            {
                fCmdRet = StaticClassReaderB.CloseNetPort(frmcomportindex);
                frmcomportindex = -1;
                int port = Convert.ToInt32(_port);
                string IPAddr = _IPAddr;
                fCmdRet = StaticClassReaderB.OpenNetPort(port, IPAddr, ref fComAdr, ref frmcomportindex);
                fOpenComIndex = frmcomportindex;
            }
            fIsInventoryScan = false;
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        private void GetReaderInfo()
        {
            var fComAdr = Convert.ToByte(fComAdrStr, 16); // $FF;
            byte[] TrType = new byte[2];
            byte[] VersionInfo = new byte[2];
            byte ReaderType = 0;
            byte ScanTime = 0;
            byte dmaxfre = 0;
            byte dminfre = 0;
            byte powerdBm = 0;
            byte FreBand = 0;
            string Edit_Version = "";
            string Edit_ComAdr = "";
            string Edit_scantime = "";
            string Edit_Type = "";
            bool ISO180006B = false;
            bool EPCC1G2 = false;
            string Edit_powerdBm = "";
            string Edit_dminfre = "";
            string Edit_dmaxfre = "";
            string Edit_NewComAdr = "";
            //ComboBox_PowerDbm.Items.Clear();
            int fCmdRet = StaticClassReaderB.GetReaderInformation(ref fComAdr, VersionInfo, ref ReaderType, TrType, ref dmaxfre, ref dminfre, ref powerdBm, ref ScanTime, frmcomportindex);
            if (fCmdRet == 0)
            {
                Edit_Version = Convert.ToString(VersionInfo[0], 10).PadLeft(2, '0') + "." + Convert.ToString(VersionInfo[1], 10).PadLeft(2, '0');
                //if (VersionInfo[1] >= 30)
                //{
                //    for (int i = 0; i < 31; i++)
                //        ComboBox_PowerDbm.Items.Add(Convert.ToString(i));
                //    if (powerdBm > 30)
                //        ComboBox_PowerDbm.SelectedIndex = 30;
                //    else
                //        ComboBox_PowerDbm.SelectedIndex = powerdBm;
                //}
                //else
                //{
                //    for (int i = 0; i < 19; i++)
                //        ComboBox_PowerDbm.Items.Add(Convert.ToString(i));
                //    if (powerdBm > 18)
                //        ComboBox_PowerDbm.SelectedIndex = 18;
                //    else
                //        ComboBox_PowerDbm.SelectedIndex = powerdBm;
                //}
                Edit_ComAdr = Convert.ToString(fComAdr, 16).PadLeft(2, '0');
                Edit_NewComAdr = Convert.ToString(fComAdr, 16).PadLeft(2, '0');
                Edit_scantime = Convert.ToString(ScanTime, 10).PadLeft(2, '0') + "*100ms";
                //ComboBox_scantime.SelectedIndex = ScanTime - 3;
                //Edit_powerdBm.Text = Convert.ToString(powerdBm, 10).PadLeft(2, '0');

                //FreBand = Convert.ToByte(((dmaxfre & 0xc0) >> 4) | (dminfre >> 6));
                //switch (FreBand)
                //{
                //    case 0:
                //        {
                //            radioButton_band1.Checked = true;
                //            fdminfre = 902.6 + (dminfre & 0x3F) * 0.4;
                //            fdmaxfre = 902.6 + (dmaxfre & 0x3F) * 0.4;
                //        }
                //        break;
                //    case 1:
                //        {
                //            radioButton_band2.Checked = true;
                //            fdminfre = 920.125 + (dminfre & 0x3F) * 0.25;
                //            fdmaxfre = 920.125 + (dmaxfre & 0x3F) * 0.25;
                //        }
                //        break;
                //    case 2:
                //        {
                //            radioButton_band3.Checked = true;
                //            fdminfre = 902.75 + (dminfre & 0x3F) * 0.5;
                //            fdmaxfre = 902.75 + (dmaxfre & 0x3F) * 0.5;
                //        }
                //        break;
                //    case 3:
                //        {
                //            radioButton_band4.Checked = true;
                //            fdminfre = 917.1 + (dminfre & 0x3F) * 0.2;
                //            fdmaxfre = 917.1 + (dmaxfre & 0x3F) * 0.2;
                //        }
                //        break;
                //    case 4:
                //        {
                //            radioButton_band5.Checked = true;
                //            fdminfre = 865.1 + (dminfre & 0x3F) * 0.2;
                //            fdmaxfre = 865.1 + (dmaxfre & 0x3F) * 0.2;
                //        }
                //        break;
                //}
                //Edit_dminfre.Text = Convert.ToString(fdminfre) + "MHz";
                //Edit_dmaxfre.Text = Convert.ToString(fdmaxfre) + "MHz";
                //if (fdmaxfre != fdminfre)
                //    CheckBox_SameFre.Checked = false;
                //ComboBox_dminfre.SelectedIndex = dminfre & 0x3F;
                //ComboBox_dmaxfre.SelectedIndex = dmaxfre & 0x3F;
                //if (ReaderType == 0x03)
                //    Edit_Type.Text = "";
                //if (ReaderType == 0x06)
                //    Edit_Type.Text = "";
                //if (ReaderType == 0x09)
                //    Edit_Type.Text = "UHFReader18";
                //if ((TrType[0] & 0x02) == 0x02) //第二个字节低第四位代表支持的协议“ISO/IEC 15693”
                //{
                //    ISO180006B.Checked = true;
                //    EPCC1G2.Checked = true;
                //}
                //else
                //{
                //    ISO180006B.Checked = false;
                //    EPCC1G2.Checked = false;
                //}
            }
            //AddCmdLog("GetReaderInformation", "GetReaderInformation", fCmdRet);
        }

    }
}
