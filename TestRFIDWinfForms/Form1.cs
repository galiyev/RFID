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

namespace TestRFIDWinfForms
{
    public partial class Form1 : Form
    {
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



        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            var fComAdr = Convert.ToByte(fComAdrStr, 16); // $FF;
            var openresult = StaticClassReaderB.OpenNetPort(port, IPAddr, ref fComAdr, ref frmcomportindex);
            if (openresult == 0)
            {
                GetReaderInfo();
            }
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

        private void checkBox_pc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_pc.Checked)
            {
                if (C_EPC)
                {
                    Edit_WordPtr = "02";
                }
                int m, n;
                n = 4;
                if ((checkBox_pc.Checked) && (n % 4 == 0) && (C_EPC))
                {
                    m = n / 4;
                    m = (m & 0x3F) << 3;
                    textBox_pc.Text = Convert.ToString(m, 16).PadLeft(2, '0') + "00";
                }
            }
            else
            {
                //Edit_WordPtr = false;
            }

        }

        public bool C_EPC { get; set; } = true;

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckBox_TID.Checked)
            {
                if ((textBox4.Text.Length) != 2 || ((textBox5.Text.Length) != 2))
                {
                    MessageBox.Show("TID Parameter Error！");
                    return;
                }
            }
            Timer_Test_.Enabled = !Timer_Test_.Enabled;
            //if (!Timer_Test_.Enabled)
            //{
            //    textBox4.Enabled = true;
            //    textBox5.Enabled = true;
            //    CheckBox_TID.Enabled = true;
            //    if (ListView1_EPC.Items.Count != 0)
            //    {
            //        DestroyCode.Enabled = false;
            //        AccessCode.Enabled = false;
            //        NoProect.Enabled = false;
            //        Proect.Enabled = false;
            //        Always.Enabled = false;
            //        AlwaysNot.Enabled = false;
            //        NoProect2.Enabled = true;
            //        Proect2.Enabled = true;
            //        Always2.Enabled = true;
            //        AlwaysNot2.Enabled = true;
            //        P_Reserve.Enabled = true;
            //        P_EPC.Enabled = true;
            //        P_TID.Enabled = true;
            //        P_User.Enabled = true;
            //        Button_DestroyCard.Enabled = true;
            //        Button_SetReadProtect_G2.Enabled = true;
            //        Button_SetEASAlarm_G2.Enabled = true;
            //        Alarm_G2.Enabled = true;
            //        NoAlarm_G2.Enabled = true;
            //        Button_LockUserBlock_G2.Enabled = true;
            //        Button_WriteEPC_G2.Enabled = true;
            //        Button_SetMultiReadProtect_G2.Enabled = true;
            //        Button_RemoveReadProtect_G2.Enabled = true;
            //        Button_CheckReadProtected_G2.Enabled = true;
            //        button4.Enabled = true;
            //        SpeedButton_Read_G2.Enabled = true;
            //        Button_SetProtectState.Enabled = true;
            //        Button_DataWrite.Enabled = true;
            //        BlockWrite.Enabled = true;
            //        Button_BlockErase.Enabled = true;
            //        checkBox1.Enabled = true;
            //    }
            //    if (ListView1_EPC.Items.Count == 0)
            //    {
            //        DestroyCode.Enabled = false;
            //        AccessCode.Enabled = false;
            //        NoProect.Enabled = false;
            //        Proect.Enabled = false;
            //        Always.Enabled = false;
            //        AlwaysNot.Enabled = false;
            //        NoProect2.Enabled = false;
            //        Proect2.Enabled = false;
            //        Always2.Enabled = false;
            //        AlwaysNot2.Enabled = false;
            //        P_Reserve.Enabled = false;
            //        P_EPC.Enabled = false;
            //        P_TID.Enabled = false;
            //        P_User.Enabled = false;
            //        Button_DestroyCard.Enabled = false;
            //        Button_SetReadProtect_G2.Enabled = false;
            //        Button_SetEASAlarm_G2.Enabled = false;
            //        Alarm_G2.Enabled = false;
            //        NoAlarm_G2.Enabled = false;
            //        Button_LockUserBlock_G2.Enabled = false;
            //        SpeedButton_Read_G2.Enabled = false;
            //        Button_DataWrite.Enabled = false;
            //        BlockWrite.Enabled = false;
            //        Button_BlockErase.Enabled = false;
            //        Button_WriteEPC_G2.Enabled = true;
            //        Button_SetMultiReadProtect_G2.Enabled = true;
            //        Button_RemoveReadProtect_G2.Enabled = true;
            //        Button_CheckReadProtected_G2.Enabled = true;
            //        button4.Enabled = true;
            //        Button_SetProtectState.Enabled = false;
            //        checkBox1.Enabled = false;

            //    }
            //    AddCmdLog("Inventory", "Exit Query", 0);
            //    button2.Text = "Query Tag";
            //}
            //else
            //{
            //    textBox4.Enabled = false;
            //    textBox5.Enabled = false;
            //    CheckBox_TID.Enabled = false;
            //    DestroyCode.Enabled = false;
            //    AccessCode.Enabled = false;
            //    NoProect.Enabled = false;
            //    Proect.Enabled = false;
            //    Always.Enabled = false;
            //    AlwaysNot.Enabled = false;
            //    NoProect2.Enabled = false;
            //    Proect2.Enabled = false;
            //    Always2.Enabled = false;
            //    AlwaysNot2.Enabled = false;
            //    P_Reserve.Enabled = false;
            //    P_EPC.Enabled = false;
            //    P_TID.Enabled = false;
            //    P_User.Enabled = false;
            //    Button_WriteEPC_G2.Enabled = false;
            //    Button_SetMultiReadProtect_G2.Enabled = false;
            //    Button_RemoveReadProtect_G2.Enabled = false;
            //    Button_CheckReadProtected_G2.Enabled = false;
            //    button4.Enabled = false;

            //    Button_DestroyCard.Enabled = false;
            //    Button_SetReadProtect_G2.Enabled = false;
            //    Button_SetEASAlarm_G2.Enabled = false;
            //    Alarm_G2.Enabled = false;
            //    NoAlarm_G2.Enabled = false;
            //    Button_LockUserBlock_G2.Enabled = false;
            //    SpeedButton_Read_G2.Enabled = false;
            //    Button_DataWrite.Enabled = false;
            //    BlockWrite.Enabled = false;
            //    Button_BlockErase.Enabled = false;
            //    Button_SetProtectState.Enabled = false;
            //    ListView1_EPC.Items.Clear();
            //    ComboBox_EPC1.Items.Clear();
            //    ComboBox_EPC2.Items.Clear();
            //    ComboBox_EPC3.Items.Clear();
            //    ComboBox_EPC4.Items.Clear();
            //    ComboBox_EPC5.Items.Clear();
            //    ComboBox_EPC6.Items.Clear();
            //    button2.Text = "Stop";
            //    checkBox1.Enabled = false;
            //}
        }

        private void Timer_Test__Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            Inventory();
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

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
            if (CheckBox_TID.Checked)
            {
                AdrTID = Convert.ToByte(textBox4.Text, 16);
                LenTID = Convert.ToByte(textBox5.Text, 16);
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
                    for (i = 0; i < ListView1_EPC.Items.Count; i++)     //判断是否在Listview列表内
                    {
                        if (sEPC == ListView1_EPC.Items[i].SubItems[1].Text)
                        {
                            aListItem = ListView1_EPC.Items[i];
                            ChangeSubItem(aListItem, 1, sEPC);
                            isonlistview = true;
                        }
                    }
                    if (!isonlistview)
                    {
                        aListItem = ListView1_EPC.Items.Add((ListView1_EPC.Items.Count + 1).ToString());
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        s = sEPC;
                        ChangeSubItem(aListItem, 1, s);
                        s = (sEPC.Length / 2).ToString().PadLeft(2, '0');
                        ChangeSubItem(aListItem, 2, s);
                        //if (!CheckBox_TID.Checked)
                        //{
                        //    if (ComboBox_EPC1.Items.IndexOf(sEPC) == -1)
                        //    {
                        //        ComboBox_EPC1.Items.Add(sEPC);
                        //        ComboBox_EPC2.Items.Add(sEPC);
                        //        ComboBox_EPC3.Items.Add(sEPC);
                        //        ComboBox_EPC4.Items.Add(sEPC);
                        //        ComboBox_EPC5.Items.Add(sEPC);
                        //        ComboBox_EPC6.Items.Add(sEPC);
                        //    }
                        //}

                    }
                }
            }
            else if (((fCmdRet == 0x30) || (fCmdRet == 0x37) || (fCmdRet == 0x35)))
            {
                fCmdRet = StaticClassReaderB.CloseNetPort(frmcomportindex);
                frmcomportindex = -1;
                int port = Convert.ToInt32(Form1.port);
                string IPAddr = Form1.IPAddr;
                fCmdRet = StaticClassReaderB.OpenNetPort(port, IPAddr, ref fComAdr, ref frmcomportindex);
                fOpenComIndex = frmcomportindex;
            }
            if (!CheckBox_TID.Checked)
            {
                //if ((ComboBox_EPC1.Items.Count != 0))
                //{
                //    ComboBox_EPC1.SelectedIndex = 0;
                //    ComboBox_EPC2.SelectedIndex = 0;
                //    ComboBox_EPC3.SelectedIndex = 0;
                //    ComboBox_EPC4.SelectedIndex = 0;
                //    ComboBox_EPC5.SelectedIndex = 0;
                //    ComboBox_EPC6.SelectedIndex = 0;
                //}
            }
            fIsInventoryScan = false;
            if (fAppClosed)
                Close();
        }

        public void ChangeSubItem(ListViewItem ListItem, int subItemIndex, string ItemText)
        {
            if (subItemIndex == 1)
            {
                if (ItemText == "")
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    if (ListItem.SubItems[subItemIndex + 2].Text == "")
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                    }
                    else
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    }
                }
                else
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    ListItem.SubItems[subItemIndex + 2].Text = "1";
                }
                else
                {
                    ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    if ((Convert.ToUInt32(ListItem.SubItems[subItemIndex + 2].Text) > 9999))
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                }

            }
            if (subItemIndex == 2)
            {
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                }
            }

        }
    }
}
