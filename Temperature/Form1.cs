using System;
using System.IO;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using Temperature.Service.Serializer;
using Temperature.Service.TaskWindows;

namespace Temperature
{
    public partial class Form1 : Form
    {
        private int period = 0;
        private bool isMinimize = false;
        private bool isConnected = false;
        private static readonly string docFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TemperatureApp");
        private static readonly string configFile = Path.Combine(docFolder, "TemperatureConfig.xml");
        private readonly string defaultComPort = "COM1";
        private readonly SerialPort serial = new SerialPort();
        private readonly Config config = new Config(configFile);
        private readonly Computer computer = new Computer()
        {
            CPUEnabled = true,
            GPUEnabled = true
        };

        public Form1()
        {
            InitializeComponent();
            InitComPortsItems();
            CheckAppFolder(docFolder);
            Icon = Properties.Resources.ICON;
            autoRunCheckBox.Checked = WindowsTask.TaskExists();
            minimizeOnCloseCheckBox.CheckedChanged += CheckBox4_CheckedChanged;
            notifyIcon1.Icon = Properties.Resources.ICON;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            notifyIcon1.BalloonTipTitle = "Error Message:";
            notifyIcon1.MouseDown += NotifyIcon1_MouseDown;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Resize += Form1_Resize;
            MouseDown += MouseDownEvent;
            button1.MouseDown += MouseDownEvent;
            groupBox1.MouseDown += MouseDownEvent;
            comPortsComboBox.MouseDown += MouseDownEvent;
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);

            }
        }

        private void InitComPortsItems()
        {
            if (comPortsComboBox.Enabled)
            {
                comPortsComboBox.ResetText();
                comPortsComboBox.Items.Clear();
                comPortsComboBox.Items.AddRange(SerialPort.GetPortNames());
            }
            else
            {
                ShowErrorMessage("ComPorts Items is Disabled");
            }
        }

        private void CheckAppFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception exc)
            {
                ShowErrorMessage(exc.Message);
            }
        }

        private void ChangeWindowState()
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Minimized : FormWindowState.Normal;
        }

        private void ShowErrorMessage(string message)
        {
            if (WindowState == FormWindowState.Normal)
            {
                MessageBox.Show(message);
            }
            else
            {
                notifyIcon1.BalloonTipText = message;
                notifyIcon1.ShowBalloonTip(8);
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            isMinimize = minimizeOnCloseCheckBox.Checked;
        }

        private void NotifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangeWindowState();
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(MousePosition);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                ShowInTaskbar = true;
                showToolStripMenuItem.Text = "Hide";
            }
            else
            {
                ShowInTaskbar = false;
                showToolStripMenuItem.Text = "Show";
            }
        }

        private void Connect()
        {
            try
            {
                if (!serial.IsOpen && !string.IsNullOrEmpty(comPortsComboBox.Text))
                {
                    serial.Open();
                    toolStripStatusLabel.Text = $"Status: Connected to port {serial.PortName}";
                    toolStripStatusLabel.BackColor = Color.Green;
                    button1.Text = "Stop";
                    connectToolStripMenuItem.Text = "Stop";
                    comPortsComboBox.Enabled = false;
                    refreshToolStripMenuItem.Enabled = false;
                    refreshToolStripMenuItem1.Enabled = false;
                    isConnected = true;
                    comPortTimer.Enabled = true;
                    SendData();
                }
            }
            catch (Exception exc)
            {
                Disconnect();
                ShowErrorMessage(exc.Message);
            }
        }

        private void Disconnect()
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Write("~");
                    serial.Close();
                }
            }
            catch (Exception exc)
            {
                ShowErrorMessage(exc.Message);
            }

            button1.Text = "Start";
            connectToolStripMenuItem.Text = "Start";
            toolStripStatusLabel.Text = "Status: Disconnected";
            toolStripStatusLabel.BackColor = Color.Red;
            comPortsComboBox.Enabled = true;
            refreshToolStripMenuItem.Enabled = true;
            refreshToolStripMenuItem1.Enabled = true;
            isConnected = false;
            comPortTimer.Enabled = false;
        }

        private void SendData()
        {
            try
            {
                if (serial.IsOpen)
                {
                    string info = GetInformation(computer);
                    serial.Write(info);
                }
            }
            catch (Exception exc)
            {
                Disconnect();
                ShowErrorMessage(exc.Message);
            }
        }

        private string GetInformation(Computer computer)
        {
            string systemInfo;
            if (period == 28 || period == 29)
            {
                systemInfo = DateTime.Now.ToString("HH:mm:ss$dd.MM.yyyy&");
            }
            else
            {
                string hardwareName = null;
                int hardwareLoad = 0;
                int hardwareClock = 0;
                int hardwareTemperature = 0;
                int pass = period % 4;

                foreach (IHardware hardware in computer.Hardware)
                {
                    hardware.Update();
                    if (pass < 2 && hardware.HardwareType == HardwareType.CPU)
                    {
                        string[] names = hardware.Name.Split();
                        hardwareName = names.Last("CPU");

                        foreach (ISensor sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature && sensor.Name.Equals("CPU Package"))
                            {
                                hardwareTemperature = (int)(sensor.Value ?? 0);
                            }
                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("CPU Core"))
                            {
                                hardwareClock = (int)(sensor.Value ?? 0);
                            }
                            if (sensor.SensorType == SensorType.Load && sensor.Name.Equals("CPU Total"))
                            {
                                hardwareLoad = (int)(sensor.Value ?? 0);
                            }
                        }
                    }
                    else if (pass > 1 && (hardware.HardwareType == HardwareType.GpuNvidia || hardware.HardwareType == HardwareType.GpuAti))
                    {
                        string[] name = hardware.Name.Split();
                        hardwareName = name.Length > 4 ? $"{name[3]} {name[4]}" : name.Last("GPU");

                        foreach (ISensor sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature && sensor.Name.Equals("GPU Core"))
                            {
                                hardwareTemperature = (int)(sensor.Value ?? 0);
                            }
                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Equals("GPU Core"))
                            {
                                hardwareClock = (int)(sensor.Value ?? 0);
                            }
                            if (sensor.SensorType == SensorType.Load && sensor.Name.Equals("GPU Core"))
                            {
                                hardwareLoad = (int)(sensor.Value ?? 0);
                            }
                        }
                    }
                }
                systemInfo = $"{hardwareName}^{hardwareTemperature}*{hardwareClock}#{hardwareLoad}@";
            }

            period = (period + 1) % 30;
            return systemInfo;
        }

        private void ComPortsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!serial.IsOpen)
                {
                    string portName = comPortsComboBox.Text;
                    serial.PortName = string.IsNullOrEmpty(portName) ? defaultComPort : portName;
                }
            }
            catch (Exception exc)
            {
                ShowErrorMessage(exc.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            computer.Open();
            config.ReadConfig();
            Location = config.Properties.Location;
            if (comPortsComboBox.Items.Contains(config.Properties.ComPortName))
            {
                comPortsComboBox.Text = config.Properties.ComPortName;
            }
            minimizeOnCloseCheckBox.Checked = config.Properties.MinimizeOnClose;
            WindowState = (startMinimizeCheckBox.Checked = config.Properties.StartMinimize) ? FormWindowState.Minimized : FormWindowState.Normal;
            if ((autoConnectCheckBox.Checked = config.Properties.AutoConnect) && !string.IsNullOrEmpty(comPortsComboBox.Text))
            {
                Connect();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
            computer.Close();
            config.Properties.Location = Location;
            if (!string.IsNullOrEmpty(comPortsComboBox.Text))
            {
                config.Properties.ComPortName = comPortsComboBox.Text;
            }
            config.Properties.MinimizeOnClose = minimizeOnCloseCheckBox.Checked;
            config.Properties.StartMinimize = startMinimizeCheckBox.Checked;
            config.Properties.AutoConnect = autoConnectCheckBox.Checked;
            config.WriteConfig();
            if (autoRunCheckBox.Checked)
            {
                WindowsTask.TaskCreate();
            }
            else
            {
                WindowsTask.TaskDelete();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                isMinimize = false;
                WindowState = FormWindowState.Normal;
            }
            else if (isMinimize)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void ComPortTimer_Tick(object sender, EventArgs e)
        {
            SendData();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                Connect();
            }
            else
            {
                Disconnect();
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeWindowState();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            isMinimize = false;
            Close();
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                Connect();
            }
            else
            {
                Disconnect();
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitComPortsItems();
        }

        private void RefreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitComPortsItems();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (!isConnected && m.WParam.ToInt32() == Constants.USB_CONNECTED)
            {
                InitComPortsItems();
                if (comPortsComboBox.Items.Contains(config.Properties.ComPortName))
                {
                    comPortsComboBox.Text = config.Properties.ComPortName;
                    Connect();
                }
            }
        }
    }
}