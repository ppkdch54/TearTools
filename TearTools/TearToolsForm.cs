using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZSJCMaster.Models;
using MVSDK;//使用SDK接口
using 纵撕检测.Helpers;
using 纵撕检测.Models.BasicOperation;

namespace TearTools
{
    public partial class tearToolsForm : Form
    {
        #region 引用
        [DllImport("CorrespondModuelDLL.dll", EntryPoint = "InitPort", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InitPort(UInt32 portNo, UInt32 baud, char parity, UInt32 databits, UInt32 stopsbits, bool IsHex);

        [DllImport("CorrespondModuelDLL.dll", EntryPoint = "CommSendDataFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CommSendDataFunction(byte[] pData, UInt32 length);



        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        public delegate void ReadData(string buff, int length);

        [DllImport("CorrespondModuelDLL.dll", EntryPoint = "CommSetCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CommSetCallBack(Delegate pCallBack);

        private ReadData readData = null;



        [DllImport("CorrespondModuelDLL.dll", EntryPoint = "CommStartR", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CommStartR();

        [DllImport("CorrespondModuelDLL.dll", EntryPoint = "ClosePort", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClosePort();


        //[DllImport("SetIO.dll", EntryPoint = "SetHigh", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void SetHigh();

        //[DllImport("SetIO.dll", EntryPoint = "SetLow", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void SetLow();

        #endregion

        bool isSending = false;
        Thread thread;

        private string portString = string.Empty;
        private string comboboxString = string.Empty;

        public tearToolsForm()
        {
            InitializeComponent();

            this.Load += TearToolsForm_Load;
            int handle = InitCamera();
            if (handle>=0)
            {
                GPIO.Init(handle);
            }
        }

        ~tearToolsForm()
        {
            
        }

        private void TearToolsForm_Load(object sender, System.EventArgs e)
        {
            // 列表集合将作为SelectCombobox的数据源
            List<ComboboxItem> list = new List<ComboboxItem>();
            list.Add(new ComboboxItem("1", 1));
            list.Add(new ComboboxItem("2", 2));
            list.Add(new ComboboxItem("3", 3));
            list.Add(new ComboboxItem("4", 4));
            list.Add(new ComboboxItem("5", 5));
            list.Add(new ComboboxItem("6", 6));

            // 绑定
            selectCombobox.DataSource = list;

            // 在SelectCombobox中显示MyItem的Name属性
            selectCombobox.DisplayMember = "Name";

            //线程初始化
            thread = new Thread(SendData);
        }


        private void DataSendButton_Click(object sender, EventArgs e)
        {
            if (!isSending)
            {
                portString = textBox.Text;
                comboboxString = selectCombobox.Text;

                isSending = true;
                dataSendButton.Text = "结束心跳";
                thread.Start();
            }
            else
            {
                isSending = false;
                dataSendButton.Text = "开启心跳";
                thread.Abort();
            }
        }

        private void SendData()
        {
            while (true)
            {
                Thread.Sleep(1000);

                uint portNum = Convert.ToUInt32(portString);
                IntPtr comHandle = InitPort(portNum, 9600, 'N', 8, 1, false);

                readData = ReadDataCallBackFunc;
                CommSetCallBack(readData);

                CommStartR();

                byte param = Convert.ToByte(comboboxString);
                Random random = new Random();
                byte x = 0x00;
                byte y = 0x00;

                byte[] command = { 0x86, x, y, param, 0x00, 0x0a };

                byte[] crc = CRC16.crc_16(command);
                byte[] sendData = new byte[command.Length + 2];
                command.CopyTo(sendData, 0);
                sendData[sendData.Length - 2] = crc[1];
                sendData[sendData.Length - 1] = crc[0];

                bool isWriteSuccessful = CommSendDataFunction(sendData, 8);

                ClosePort();
            }
        }

        private void ReadDataCallBackFunc(string buff, int length)
        {
            //do nothing
        }

        private int InitCamera()
        {
            int m_hCamera = -1;
            tSdkCameraDevInfo[] m_DevInfo = new tSdkCameraDevInfo[] { new tSdkCameraDevInfo() };
            MvApi.CameraEnumerateDevice(out m_DevInfo);
            if (m_DevInfo != null)
            {
                IntPtr m_Grabber = new IntPtr();

                if (MvApi.CameraGrabber_Create(out m_Grabber, ref m_DevInfo[0]) == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                {
                    MvApi.CameraGrabber_GetCameraHandle(m_Grabber, out m_hCamera);
                }
            }
            return m_hCamera;
        }

        private void AlarmButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                //发送120次报警信号跳变,
                for (int i = 0; i < 120; i++)
                {
                    Thread.Sleep(20);
                    GPIO.SetHigh();
                    Thread.Sleep(20);
                    GPIO.SetLow(); 
                }
            });

            portString = textBox.Text;
            comboboxString = selectCombobox.Text;

            uint portNum = Convert.ToUInt32(portString);
            IntPtr comHandle = InitPort(portNum, 9600, 'N', 8, 1, false);

            readData = ReadDataCallBackFunc;
            CommSetCallBack(readData);

            CommStartR();

            byte param = Convert.ToByte(comboboxString);
            Random random = new Random();
            byte x = (byte)(0x50 + random.Next(0, 100));
            byte y = (byte)(0x50 + random.Next(0, 100));

            byte[] command = { 0x86, x, y, param, 0x00, 0x0a };

            byte[] crc = CRC16.crc_16(command);
            byte[] sendData = new byte[command.Length + 2];
            command.CopyTo(sendData, 0);
            sendData[sendData.Length - 2] = crc[1];
            sendData[sendData.Length - 1] = crc[0];

            bool isWriteSuccessful = CommSendDataFunction(sendData, 8);

            ClosePort();
        }
    }
}
